using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public abstract class PacketReader
    {
        private byte[] Buffer;
        private int Offset;
        private SocketClient Client;

        protected internal SocketClient GetClient()
        {
            return Client;
        }

        protected internal byte[] GetBuffer()
        {
            return Buffer;
        }
        protected internal Int32 GetLeng()
        {
            return Buffer.Length;
        }

        protected internal void Init(SocketClient VClient, byte[] VBuffer)
        {
            Client = VClient;
            Buffer = VBuffer;
            Offset = 4; // 0 и 1 байты опкод, в самом пакете он нах не надо.
            Read();
        }

        protected internal byte PReadByte()
        {
            byte res = Buffer[Offset];
            Offset += 1;
            return res;
        }

        protected internal byte[] PReadBytes(int Length)
        {
            byte[] result = new byte[Length];
            Array.Copy(Buffer, Offset, result, 0, Length);
            Offset += Length;
            return result;
        }

        protected internal short PReadInt16()
        {
            short res = BitConverter.ToInt16(Buffer, Offset);
            Offset += 2;
            return res;
        }
        protected internal int PReadInt32()
        {
            int res = BitConverter.ToInt32(Buffer, Offset);
            Offset += 4;
            return res;
        }

        protected internal long PReadInt64()
        {
            long res = BitConverter.ToInt64(Buffer, Offset);
            Offset += 8;
            return res;
        }

        protected internal double PReadDouble()
        {
            double res = BitConverter.ToDouble(Buffer, Offset);
            Offset += 8;
            return res;
        }

        protected internal UInt16 PReadUInt16()
        {
            UInt16 res = BitConverter.ToUInt16(Buffer, Offset);
            Offset += 2;
            return res;
        }
        protected internal UInt32 PReadUInt32()
        {
            UInt32 res = BitConverter.ToUInt32(Buffer, Offset);
            Offset += 4;
            return res;
        }

        protected internal UInt64 PReadUInt64()
        {
            UInt64 res = BitConverter.ToUInt64(Buffer, Offset);
            Offset += 8;
            return res;
        }

        protected internal string PReadStringLeng(int Length)
        {
            string res = "";
            try
            {
                res = Encoding.ASCII.GetString(Buffer, Offset, Length);
                Offset = Offset + Length;
            }
            catch (Exception ex)
            {
                //ConsoleL.Error("while reading string from packet, " + ex.Message + " " + ex.StackTrace);
            }
            return res;
        }

        protected internal string PReadStringL(int Length)
        {
            string res = "";
            try
            {
                res = Encoding.GetEncoding(1251).GetString(Buffer, Offset, Length);

                int idx = res.IndexOf((char)0x00);
                if (idx != -1)
                {
                    res = res.Substring(0, idx);
                }
                Offset += Length;
            }
            catch (Exception ex)
            {
                //ConsoleL.Error("while reading string from packet, " + ex.Message + " " + ex.StackTrace);
            }
            return res;
        }

        protected internal string PReadStringSystem(int Length)
        {
            string res = "";
            try
            {
                res = Encoding.ASCII.GetString(Buffer, Offset, Length);
            }
            catch (Exception ex)
            {
                //ConsoleL.Error("while reading string from packet, " + ex.Message + " " + ex.StackTrace);
            }

            res = res.Replace("\0", "");

            return res.Replace("\n",Environment.NewLine);
        }

        protected internal string PReadStringH()
        {
            string result = "";
            try
            {
                Int32 Leng = PReadInt32();
                result = System.Text.Encoding.ASCII.GetString(Buffer, Offset, Leng);
                int count = (Buffer.Length - Offset);
                Offset += Leng;
            }
            catch (Exception ex)
            {
                //Program.MainV..UpdateLog("Error:Reading string from packet, " + ex.Message + " " + ex.StackTrace);
                //ConsoleL.Error("while reading string from packet, " + ex.Message + " " + ex.StackTrace);
            }
            return result;
        }

        protected internal string PReadString()
        {
            string result = "";
            try
            {
                int count = (Buffer.Length - Offset);
                result = System.Text.Encoding.ASCII.GetString(Buffer, Offset, count);

                int idx = result.IndexOf((char)0x00);
                if (idx != -1)
                {
                    result = result.Substring(0, idx);
                }
                Offset += result.Length + 1;
            }
            catch (Exception ex)
            {
                //ConsoleL.Error("while reading string from packet, " + ex.Message + " " + ex.StackTrace);
            }
            return result;
        }

        protected internal void ignore(int inOffset)
        {
            //Игнорируем несколько байт. =)
            Offset = Offset + inOffset;
            //ConsoleL.Warning("Ignore " + inOffset + "bytes");
        }

        protected internal abstract void Read();
        protected internal abstract void Run();
    }
}
