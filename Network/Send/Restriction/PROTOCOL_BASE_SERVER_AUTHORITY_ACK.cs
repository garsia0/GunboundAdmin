using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PROTOCOL_BASE_SERVER_AUTHORITY_ACK : PacketSender
    {
        public PROTOCOL_BASE_SERVER_AUTHORITY_ACK()
        {
            Init();
        }

        protected internal override void Write()
        {
            PWriteInt16(20778); //CD
            PWriteInt16(1); // Enter Lowest Permision Default 1;
        }

    }

}
