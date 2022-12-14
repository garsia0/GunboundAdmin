using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PROTOCOL_BASE_GUILD_EXISTENCE_ACK : PacketSender
    {
        public PROTOCOL_BASE_GUILD_EXISTENCE_ACK()
        {
            Init();
        }

        protected internal override void Write()
        {
            PWriteInt16(20770); //CD
            PWriteInt16(0); // 0 No Limit // 1 Having Guild Only // 2 Having No Guild Only
        }

    }

}
