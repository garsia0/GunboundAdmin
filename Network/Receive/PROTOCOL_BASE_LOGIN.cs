using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Client
{
    class PROTOCOL_BASE_LOGIN : PacketReader
    {
        UInt16 Datos;
        public PROTOCOL_BASE_LOGIN(SocketClient Client, byte[] Data)
        {
            Init(Client, Data);
        }

        protected internal override void Read()
        {
            Datos = PReadUInt16();
            
        }

        protected internal override void Run()
        {
            if (Datos == 17)
            {
                GetClient().Reconnect = false;
                Program.MainV.ServerUpdateState(GetClient().ServerId, "Close.");
                /*
                

                GetClient().Disconnect();

                Thread.Sleep(1000);

                Program.MainV.ServerUpdateState(GetClient().ServerId, "Retry.");

                Program.MainV.UpdateLabel(String.Empty);
                if (GetClient().Connect())
                {
                    GetClient().SendData(new PROTOCOL_FIRST_PACKET_ACK(GetClient()));
                }
                else
                {
                      Program.MainV.ServerUpdateState(GetClient().ServerId,"Cant Connect To Server.");
                }*/
            }
            if (Datos == 0)
            {
                Program.MainV.ServerUpdateResult(GetClient().ServerId, "Successfully Logined.");
                Program.MainV.ServerUpdateState(GetClient().ServerId, "Connected.");
                GetClient().SendData(new PROTOCOL_BASE_STATUS_ACK());
                Thread.Sleep(1000);
                GetClient().SendData(new PROTOCOL_BASE_ENTER_CHAT_ACK());
            }
            if (Datos == 25)
            {
                Program.MainV.ServerUpdateState(GetClient().ServerId, "Login Failed.");
            }
            
        }
    }
}
