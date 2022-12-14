using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class PROTOCOL_BASE_SERVERLIST_MAXP_CHANGE : PacketReader
    {
        Int16 Room;
        byte MAX;
        public PROTOCOL_BASE_SERVERLIST_MAXP_CHANGE(SocketClient Client, byte[] Data)
        {
            Init(Client, Data);
        }

        protected internal override void Read()
        {
            Room = PReadInt16();
            MAX = PReadByte();
        }

        protected internal override void Run()
        {
            if (GetClient().ServerId == MemoryData.SelectedServer)
            {
                Program.MainV.RoomMaxPlayerChange(Room, MAX);
            }
        }
    }
}
