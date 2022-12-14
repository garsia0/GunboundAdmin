using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PROTOCOL_BASE_GRADE_LIMIT_ACK : PacketSender
    {
        Int16 VUpper, VLower;
        public PROTOCOL_BASE_GRADE_LIMIT_ACK(Int16 Upper,Int16 Lower)
        {
            VUpper = Upper;
            VLower = Lower;
            Init();
        }

        protected internal override void Write()
        {
            PWriteInt16(20768); //CD
            PWriteInt16(VUpper); //Upper
            PWriteInt16(VLower); //Lower
        }

    }

}
