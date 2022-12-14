using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PROTOCOL_FIRST_PACKET_ACK : PacketSender
    {
        public PROTOCOL_FIRST_PACKET_ACK(SocketClient Data)
        {
            Init();
            Data.CCode.Set(14001);
            Data.FirthPacket = true;
        }

        protected internal override void Write()
        {
            PWriteInt16(4096); //CD
        }

    }

}
