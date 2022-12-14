using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class PROTOCOL_BASE_SERVERLIST_STATE_CHANGE : PacketReader
    {
        Int16 Room;
        byte State;
        public PROTOCOL_BASE_SERVERLIST_STATE_CHANGE(SocketClient Client, byte[] Data)
        {
            Init(Client, Data);
        }

        protected internal override void Read()
        {
            Room = PReadInt16();
            State = PReadByte();
        }

        protected internal override void Run()
        {
            if (GetClient().ServerId == MemoryData.SelectedServer)
            {
                Program.MainV.RoomStateChange(Room, State);
            }
        }
    }
}
