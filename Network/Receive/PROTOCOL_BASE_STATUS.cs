using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class PROTOCOL_BASE_STATUS : PacketReader
    {
        Int32 User, CRoom, UserInRoom, UserInChannel, VersionMin, VersionMax, GradeDown, GradeUp;

        public PROTOCOL_BASE_STATUS(SocketClient Client, byte[] Data)
        {
            Init(Client, Data);
        }

        protected internal override void Read()
        {
            PReadInt16();
            User = PReadInt16();
            CRoom = PReadInt16();
            UserInRoom = PReadInt16();
            UserInChannel = PReadInt16();
            GradeUp = PReadInt16();
            GradeDown = PReadInt16();


            PReadInt32();
            PReadInt32();


            VersionMin = PReadInt32();
            VersionMax = PReadInt32();

            PReadInt32();
            PReadInt32();
            PReadInt32();
      
           
        }

        protected internal override void Run()
        {

            ServerInfo Data = new ServerInfo();
            Data.User = User;
            Data.Room = CRoom;
            Data.UserInRoom = UserInRoom;
            Data.UserInChannel = UserInChannel;
            Data.VersionMin = VersionMin;
            Data.VersionMax = VersionMax;
            Data.GradeDown = GradeDown;
            Data.GradeUp = GradeUp;
            Program.MainV.ServerUpdateRow(GetClient().ServerId, Data);
            Program.MainV.ServerUpdateResult(GetClient().ServerId, "Status Request Succeed.");
        }
    }
}
