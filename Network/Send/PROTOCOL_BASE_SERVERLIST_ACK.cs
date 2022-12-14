using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PROTOCOL_BASE_SERVERLIST_ACK : PacketSender
    {
        public PROTOCOL_BASE_SERVERLIST_ACK()
        {
            Init();
        }

        protected internal override void Write()
        {
            PWriteInt16(8448); //CD
            PWriteBytes(new byte[] {0x02, 0x00,  0x00, 0x09, 0x00  });
        }

    }

}
