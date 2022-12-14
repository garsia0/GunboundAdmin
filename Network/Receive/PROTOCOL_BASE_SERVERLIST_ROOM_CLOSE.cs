using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class PROTOCOL_BASE_SERVERLIST_ROOM_CLOSE : PacketReader
    {
        Int16 RoomId;
        public PROTOCOL_BASE_SERVERLIST_ROOM_CLOSE(SocketClient Client, byte[] Data)
        {
            Init(Client, Data);
        }

        protected internal override void Read()
        {

            RoomId = PReadInt16();
        }

        protected internal override void Run()
        {
            Program.MainV.RoomClose(RoomId);
        }
    }
}
