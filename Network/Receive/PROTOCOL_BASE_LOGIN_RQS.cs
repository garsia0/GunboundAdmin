using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class PROTOCOL_BASE_LOGIN_RQS : PacketReader
    {
        UInt32 Datos;
        public PROTOCOL_BASE_LOGIN_RQS(SocketClient Client, byte[] Data)
        {
            Init(Client,Data);
        }

        protected internal override void Read()
        {
            Datos = PReadUInt32();
        }

        protected internal override void Run()
        {
            GetClient().SendData(new PROTOCOL_BASE_LOGIN_ACK(MemoryData.UserName, MemoryData.Password, Datos));
        }
    }
}
