using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PROTOCOL_BASE_ENTER_CHAT_ACK : PacketSender
    {
        public PROTOCOL_BASE_ENTER_CHAT_ACK()
        {
            Init();
        }

        protected internal override void Write()
        {
            PWriteInt16(8224); //CD
        }

    }

}
