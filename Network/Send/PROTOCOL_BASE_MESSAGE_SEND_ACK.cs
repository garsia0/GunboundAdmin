using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PROTOCOL_BASE_MESSAGE_SEND_ACK : PacketSender
    {
        byte VType;
        String VData;
        public PROTOCOL_BASE_MESSAGE_SEND_ACK(byte Type, String Data)
        {
            VType = Type;
            VData = Data;
            Init();
        }

        protected internal override void Write()
        {
            PWriteInt16(20754); //CD
            PWriteByte(VType);
            PWriteStrinP(VData);
        }

    }

}
