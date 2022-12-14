using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PROTOCOL_BASE_VERCION_ACK : PacketSender
    {
        Int32 VLower, VUpper;
        public PROTOCOL_BASE_VERCION_ACK(Int32 Lower,Int32 Upper)
        {
            VLower = Lower;
            VUpper = Upper;
            Init();
        }

        protected internal override void Write()
        {
            PWriteInt16(20758); //CD
            PWriteInt32(VLower); //Lower
            PWriteInt32(VUpper); //Upper
            PWriteBytes(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }); //CheckSum

        }

    }

}
