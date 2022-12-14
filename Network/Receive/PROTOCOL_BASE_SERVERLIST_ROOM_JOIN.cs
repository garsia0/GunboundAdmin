using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class PROTOCOL_BASE_SERVERLIST_ROOM_JOIN : PacketReader
    {
        Int16 Room;
        byte Player;
        public PROTOCOL_BASE_SERVERLIST_ROOM_JOIN(SocketClient Client, byte[] Data)
        {
            Init(Client, Data);
        }

        protected internal override void Read()
        {
            Room = PReadInt16();
            Player = PReadByte();
        }

        protected internal override void Run()
        {
            if (GetClient().ServerId == MemoryData.SelectedServer)
            {
                Program.MainV.RoomPlayerChange(Room, Player);
            }
        }
    }
}
