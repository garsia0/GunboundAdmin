using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class PROTOCOL_BASE_CHAT_MSG : PacketReader
    {
        String Login,NickName, Guild, MSG;
        Int16 Channel, TotalGrade, SeasonGrade;

        public PROTOCOL_BASE_CHAT_MSG(SocketClient Client, byte[] Data)
        {
            Init(Client, Data);
        }

        protected internal override void Read()
        {
            Channel = PReadInt16();
            Login = PReadString();
            PReadInt32();
            PReadInt32();
            PReadByte();
            NickName = PReadStringL(12);
            Guild = PReadStringL(8);
            TotalGrade = PReadInt16();
            SeasonGrade = PReadInt16();
            byte Leng = PReadByte();
            MSG = PReadStringL(Leng);
        }

        protected internal override void Run()
        {
            String GData = String.Empty;
            if (Guild != "")
            {
                GData = " Guild:[" + Guild + "]";
            }

            Program.MainV.ChannelText("Server:" + (GetClient().ServerId + 1) + GData + " Id:[" + Login + "] Nick:[" + NickName + "] Channel:(" + Channel + ") >" + MSG);
            Utils.UpdateLobbyLog("Server:" + (GetClient().ServerId + 1) + GData + " Id:[" + Login + "] Nick:[" + NickName + "] Channel:(" + Channel + ") >" + MSG);
        }
    }
}
