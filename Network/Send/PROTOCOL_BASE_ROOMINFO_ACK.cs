using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PROTOCOL_BASE_ROOMINFO_ACK : PacketSender
    {
        Int16 RoomV;
        public PROTOCOL_BASE_ROOMINFO_ACK(Int16 Room)
        {
            Init();
            RoomV = Room;
            RoomV--;
        }

        protected internal override void Write()
        {
            PWriteInt16(8452); //CD
            PWriteInt16(RoomV);
        }

    }

}
