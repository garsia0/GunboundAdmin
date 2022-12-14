using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PROTOCOL_BASE_STATUS_ACK : PacketSender
    {
        public PROTOCOL_BASE_STATUS_ACK()
        {
            Init();
        }

        protected internal override void Write()
        {
            PWriteInt16(20752); //CD
        }

    }

}
