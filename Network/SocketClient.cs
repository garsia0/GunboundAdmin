using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace Client
{
    public class SocketClient
    {
        
        public String IpAddres;
        public Int32 Port;
        public bool FirthPacket;
        public bool Reconnect;
        public Int32 ServerId;
        public bool Connected = false;

        //Variables Dinamicas
        private Socket _Socket;
        private UInt16 Opcode;
        public ControlCode CCode = new ControlCode();
        Byte[] BufferLeng = new Byte[4];
        Byte[] BufferData;


        public SocketClient(String IpAddresV, Int32 PortV)
        {
            IpAddres = IpAddresV;
            Port = PortV;
        }

        public bool Connect()
        {

            try
            {
                IPEndPoint RemoteEP = new IPEndPoint(IPAddress.Parse(IpAddres), Port);
                _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _Socket.Connect(RemoteEP);
#if Debug
                Program.LogFormV.UpdateLog("[" + IpAddres + ":" + Port + "] Connected...");
#endif
                Connected = true;
                Reconnect = true;
                new Thread(Read).Start();
                return true;
            }

            catch (Exception ex)
            {
#if Debug
                Program.LogFormV.UpdateLog("Error Al Conectar" + Environment.NewLine + ex.ToString());
#endif
                return false;
            }
        }


        private void Read()
        {
            try
            {

                SocketError Error;

                Int32 RBytes = _Socket.Receive(BufferLeng, 0, 2, SocketFlags.None, out Error);

                if (Error == SocketError.Success)
                {

                    UInt32 NewSize = BitConverter.ToUInt16(BufferLeng, 0);

                    Int32 BytesRead = 0;

                    if (NewSize > 65535)
                    {
                        BufferData = new Byte[NewSize - 2];
                        BytesRead = _Socket.Receive(BufferData, 0, 65535, SocketFlags.None, out Error);
                    }
                    else
                    {
                        BufferData = new Byte[NewSize - 2];
                        BytesRead = _Socket.Receive(BufferData, 0, (Int32)(NewSize - 2), SocketFlags.None, out Error);
                    }



                    if (Error == SocketError.Success)
                    {
                        if (BytesRead > 0)
                        {
                            if (BytesRead == (NewSize - 2))
                            {
                               

                                
                                UInt16 SQ = BitConverter.ToUInt16(BufferData, 0);
                                Opcode = BitConverter.ToUInt16(BufferData, 2);
#if DEBUG
                                Program.LogFormV.UpdateLog("IP:" + _Socket.RemoteEndPoint.ToString() + Environment.NewLine +
                                               "Recv Data Leng:" + BytesRead + Environment.NewLine +
                                               "Recv Header Leng:" + NewSize + Environment.NewLine +
                                               "Recv SQ=" + SQ.ToString("X") + "(" + SQ + ")" + Environment.NewLine +
                                               "Recv CD=" + Opcode + Environment.NewLine + 
                                               Utils.HexDump(BufferData));
#endif
                                HandlePacket(BufferData);
                                Read();
                                
                            }
                            else
                            {
                                //LongPacket(NewSize, BytesRead);
                                Program.MainV.ToolLog("Error: LongPacket No Suported");
                            }
                        }

                    }
                    else
                    {
                        ManageError(Error, "ReadData");
                    }
                }
                else
                {
                    ManageError(Error, "ReadLength");
                }
            }
            catch (Exception ex)
            {
                Disconnect();
                Program.MainV.ToolLog("Error:" + ex.Data + "Message:" + ex.Message);
            }
        }


        private void ManageError(SocketError Data, String Tipe)
        {
            Program.MainV.ToolLog("Event: " + Tipe + " SocketError: " + Data.ToString());
            Disconnect();

        }

        public void Disconnect()
        {
            Connected = false;
            Program.MainV.ServerUpdateState(ServerId, "Disconnected.");
            try
            {
                _Socket.Close();
            }
            catch 
            { }

            Program.MainV.ToolLog("Disconnect Server:" + this.ServerId);

            Thread.Sleep(1000);

            if (Reconnect & false)
            {
                if (Connect())
                {
                    SendData(new PROTOCOL_FIRST_PACKET_ACK(this));
                }
                else
                {
                    Program.MainV.ServerUpdateState(ServerId, "Cant Connect To Server.");
                }
            }

            


        }

        public void SendData(PacketSender BufferPacket)
        {
            Int16 SQ = CCode.ControlCodeV;

            BufferPacket.Write();
            byte[] Data = BufferPacket.ToByteArray();
            UInt16 Opcode = BitConverter.ToUInt16(Data, 0);

            if (!FirthPacket)
            {
                SQ = CCode.Update(Data.Length);

            }
            else
            {
                FirthPacket = false;
            }

            SocketError Error = SocketError.AccessDenied;

            Int16 Size = Convert.ToInt16(Data.Length + 4);
            List<byte> List = new List<byte>(Size);
            List.AddRange(BitConverter.GetBytes(Size));
            List.AddRange(BitConverter.GetBytes(SQ));
            List.AddRange(Data);
            byte[] BytesV = List.ToArray();

            try
            {
                if (BytesV.Length > 0)
                {

                    _Socket.Send(BytesV, 0, BytesV.Length, SocketFlags.None, out Error);


                    if (Error == SocketError.Success)
                    {
#if DEBUG
                        Program.LogFormV.UpdateLog2("Send Leng" + BytesV.Length);
                        Program.LogFormV.UpdateLog2("Send SQ=" + SQ.ToString("X") + "(" + SQ + ")");
                        Program.LogFormV.UpdateLog2("Send CD=" + Opcode);
                        Program.LogFormV.UpdateLog2(Utils.HexDump(BytesV));
#endif

                    }
                    else
                    {
                        ManageError(Error, "Send");
                    }


                }
            }
            catch
            {
                ManageError(Error, "Send");
            }

        }


        private void HandlePacket(byte[] DATA)
        {
            Opcode = BitConverter.ToUInt16(DATA, 2);

            List<PacketReader> Packets = new List<PacketReader>();

            switch (Opcode)
            {
                case 20737:
                    {
                        Packets.Add(new PROTOCOL_BASE_SERVER_TEXT(this,DATA));
                        break;
                    }
                case 4097:
                    {
                        Packets.Add(new PROTOCOL_BASE_LOGIN_RQS(this,DATA));
                        break;
                    }
                case 4114:
                    {
                        Packets.Add(new PROTOCOL_BASE_LOGIN(this,DATA));
                        break;
                    }
                case 8225:
                    {
                        Program.MainV.ServerUpdateResult(ServerId, "Enter Chat Succeed.");
                        Packets.Add(new PROTOCOL_BASE_EMPTY(this, DATA));
                        break;
                    }
                case 8227:
                    {
                        Program.MainV.ServerUpdateResult(ServerId, "Leave Chat Succeed.");
                        Packets.Add(new PROTOCOL_BASE_EMPTY(this, DATA));
                        break;
                    }
                case 8239:
                    {
                        Packets.Add(new PROTOCOL_BASE_CHAT_MSG(this,DATA));
                        break;
                    }
                case 8451:
                    {
                        Packets.Add(new PROTOCOL_BASE_SERVERLIST(this,DATA));
                        break;
                    }
                case 8453:
                    {
                        Packets.Add(new PROTOCOL_BASE_ROOMINFO(this,DATA));
                        break;
                    }
                case 8689:
                    {
                        Packets.Add(new PROTOCOL_BASE_SERVERLIST_ROOM_CLOSE(this, DATA));
                        break;
                    }
                case 8691:
                    {
                        Packets.Add(new PROTOCOL_BASE_SERVERLIST_MAP_CHANGE(this,DATA));
                        break;
                    }
                case 8692:
                    {
                        Packets.Add(new PROTOCOL_BASE_SERVERLIST_SUDDEN(this, DATA));
                        break;
                    }
                case 8693:
                    {
                        Packets.Add(new PROTOCOL_BASE_SERVERLIST_ROOM_JOIN(this, DATA));
                        break;
                    }
                case 8694:
                    {
                        Packets.Add(new PROTOCOL_BASE_SERVERLIST_MAXP_CHANGE(this,DATA));
                        break;
                    }
                case 8695:
                    {
                        Packets.Add(new PROTOCOL_BASE_SERVERLIST_STATE_CHANGE(this,DATA));
                        break;
                    }
                case 20753:
                    {
                        Packets.Add(new PROTOCOL_BASE_STATUS(this,DATA));
                        break;
                    }
                case 20757:
                    {
                        Program.MainV.ServerUpdateResult(ServerId, "Message Broadcasted Successfully.");
                        Packets.Add(new PROTOCOL_BASE_EMPTY(this, DATA));
                        break;
                    }

                default:
#if Debug
                    Program.LogFormV.UpdateLog("Received unknown request " + Opcode);
#endif
                    Program.MainV.ToolLog("Received unknown request " + Opcode);
                    Utils.UpdateLog("Received unknown request " + Opcode);
                    break;
            }

            if (Packets != null && Packets.ToArray().Length > 0)
            {
                foreach (PacketReader msg in Packets)
                {
                    new Thread(msg.Run).Start();
                }
            }
            else
            {
#if Debug
                Program.LogFormV.UpdateLog("NULL or Empty Packet Collections.");
#endif
                Program.MainV.ToolLog("NULL or Empty Packet Collections.");
                Utils.UpdateLog("NULL or Empty Packet Collections.");
            }
        }
    }
}
