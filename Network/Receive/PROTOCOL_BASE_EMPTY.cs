using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class PROTOCOL_BASE_EMPTY : PacketReader
    {
        public PROTOCOL_BASE_EMPTY(SocketClient Client, byte[] Data)
        {
            Init(Client, Data);
        }

        protected internal override void Read()
        {
        }

        protected internal override void Run()
        {
        }
    }
}
