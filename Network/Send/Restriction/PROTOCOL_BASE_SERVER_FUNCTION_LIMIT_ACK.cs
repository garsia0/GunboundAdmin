using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PROTOCOL_BASE_SERVER_FUNCTION_LIMIT_ACK : PacketSender
    {
        public PROTOCOL_BASE_SERVER_FUNCTION_LIMIT_ACK()
        {
            Init();
        }

        protected internal override void Write()
        {
            PWriteInt16(20772); //CD
            PWriteInt32(0); 
            PWriteInt32(0); // 1 Jewel // 2 TAG // 4 Score // 8 Solo // 16 Enable Prop Effect
        }

    }

}
