using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class PROTOCOL_BASE_SERVERLIST_SUDDEN : PacketReader
    {
        Int16 RoomId, GameMode;
        byte Sudden;
        public PROTOCOL_BASE_SERVERLIST_SUDDEN(SocketClient Client, byte[] Data)
        {
            Init(Client, Data);
        }

        protected internal override void Read()
        {

            RoomId = PReadInt16();
            PReadByte();
            Sudden = PReadByte();
            GameMode = PReadInt16();

        }

        protected internal override void Run()
        {
            BitFieldCL STemp = new BitFieldCL((UInt64)Sudden);
            BitFieldCL Temp = new BitFieldCL((UInt64)GameMode);
            Program.MainV.RoomGameMode(RoomId, Utils.SuddenBit(STemp.BitField()), Utils.GameModeBit(Temp.BitField()));
        }
    }
}
