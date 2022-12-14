using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PROTOCOL_BASE_BROADCAST_SEND_ACK : PacketSender
    {
        byte VType;
        String VData;
        public PROTOCOL_BASE_BROADCAST_SEND_ACK(byte Type, String Data)
        {
            VType = Type;
            VData = Data;
            Init();
        }

        protected internal override void Write()
        {
            PWriteInt16(20756); //CD
            PWriteByte(VType); //Cannel 02 //GameRoom 01 //All 03
            PWriteStrinP(VData);
        }

    }

}
