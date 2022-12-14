using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class PROTOCOL_BASE_SERVER_TEXT : PacketReader
    {
        String Text;
        public PROTOCOL_BASE_SERVER_TEXT(SocketClient Client, byte[] Data)
        {
            Init(Client, Data);
        }

        protected internal override void Read()
        {

            Text = PReadStringSystem(GetLeng() - 4);
        }

        protected internal override void Run()
        {
            Program.MainV.ServerText(Text);
            Utils.UpdateServerLog(Text);
        }
    }
}
