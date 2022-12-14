using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PROTOCOL_BASE_SERVER_RATE_ACK : PacketSender
    {
        public PROTOCOL_BASE_SERVER_RATE_ACK()
        {
            Init();
        }

        protected internal override void Write()
        {
            PWriteInt16(20780); //CD
            PWriteInt32(0); // Score 100
            PWriteInt32(0); // Gold 100
        }

    }

}
