using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class PROTOCOL_BASE_ROOMINFO : PacketReader
    {
        PlayerInfo PInfo = new PlayerInfo();
        public PROTOCOL_BASE_ROOMINFO(SocketClient Client, byte[] Data)
        {
            Init(Client, Data);
        }

        protected internal override void Read()
        {
            if (GetLeng() > 6)
            {
                PReadInt16();

                Int32 L = PReadByte();
                String RoomName = PReadStringL(L);

                PReadInt16();
                PReadInt16();
                PReadInt16();
                byte User = PReadByte();
                byte Max = PReadByte();
                PReadInt16();

                PInfo.User = User;

                if (User > 0)
                {
                    String Name = PReadStringL(13);
                    byte Side = PReadByte();
                    String Guild = PReadStringL(8);
                    Int16 TotalGrade = PReadInt16();
                    Int16 SeasonGrade = PReadInt16();
                    Int16 CountryGrade = PReadInt16();
                    Int16 Country = PReadInt16();

                    PInfo.Slot0.Name = Name;
                    PInfo.Slot0.Guild = Guild;
                    PInfo.Slot0.TotalGrade = TotalGrade;
                    PInfo.Slot0.SeasonGrade = SeasonGrade;
                    PInfo.Slot0.CountryGrade = CountryGrade;
                    PInfo.Slot0.Country = Country;
                    PInfo.Slot0.Side = Side;
                }

                if (User > 1)
                {
                    String Name = PReadStringL(13);
                    byte Side = PReadByte();
                    String Guild = PReadStringL(8);
                    Int16 TotalGrade = PReadInt16();
                    Int16 SeasonGrade = PReadInt16();
                    Int16 CountryGrade = PReadInt16();
                    Int16 Country = PReadInt16();

                    PInfo.Slot1.Name = Name;
                    PInfo.Slot1.Guild = Guild;
                    PInfo.Slot1.TotalGrade = TotalGrade;
                    PInfo.Slot1.SeasonGrade = SeasonGrade;
                    PInfo.Slot1.CountryGrade = CountryGrade;
                    PInfo.Slot1.Country = Country;
                    PInfo.Slot1.Side = Side;
                }

                if (User > 2)
                {
                    String Name = PReadStringL(13);
                    byte Side = PReadByte();
                    String Guild = PReadStringL(8);
                    Int16 TotalGrade = PReadInt16();
                    Int16 SeasonGrade = PReadInt16();
                    Int16 CountryGrade = PReadInt16();
                    Int16 Country = PReadInt16();

                    PInfo.Slot2.Name = Name;
                    PInfo.Slot2.Guild = Guild;
                    PInfo.Slot2.TotalGrade = TotalGrade;
                    PInfo.Slot2.SeasonGrade = SeasonGrade;
                    PInfo.Slot2.CountryGrade = CountryGrade;
                    PInfo.Slot2.Country = Country;
                    PInfo.Slot2.Side = Side;
                }

                if (User > 3)
                {
                    String Name = PReadStringL(13);
                    byte Side = PReadByte();
                    String Guild = PReadStringL(8);
                    Int16 TotalGrade = PReadInt16();
                    Int16 SeasonGrade = PReadInt16();
                    Int16 CountryGrade = PReadInt16();
                    Int16 Country = PReadInt16();

                    PInfo.Slot3.Name = Name;
                    PInfo.Slot3.Guild = Guild;
                    PInfo.Slot3.TotalGrade = TotalGrade;
                    PInfo.Slot3.SeasonGrade = SeasonGrade;
                    PInfo.Slot3.CountryGrade = CountryGrade;
                    PInfo.Slot3.Country = Country;
                    PInfo.Slot3.Side = Side;
                }

                if (User > 4)
                {
                    String Name = PReadStringL(13);
                    byte Side = PReadByte();
                    String Guild = PReadStringL(8);
                    Int16 TotalGrade = PReadInt16();
                    Int16 SeasonGrade = PReadInt16();
                    Int16 CountryGrade = PReadInt16();
                    Int16 Country = PReadInt16();

                    PInfo.Slot4.Name = Name;
                    PInfo.Slot4.Guild = Guild;
                    PInfo.Slot4.TotalGrade = TotalGrade;
                    PInfo.Slot4.SeasonGrade = SeasonGrade;
                    PInfo.Slot4.CountryGrade = CountryGrade;
                    PInfo.Slot4.Country = Country;
                    PInfo.Slot4.Side = Side;
                }

                if (User > 5)
                {
                    String Name = PReadStringL(13);
                    byte Side = PReadByte();
                    String Guild = PReadStringL(8);
                    Int16 TotalGrade = PReadInt16();
                    Int16 SeasonGrade = PReadInt16();
                    Int16 CountryGrade = PReadInt16();
                    Int16 Country = PReadInt16();

                    PInfo.Slot5.Name = Name;
                    PInfo.Slot5.Guild = Guild;
                    PInfo.Slot5.TotalGrade = TotalGrade;
                    PInfo.Slot5.SeasonGrade = SeasonGrade;
                    PInfo.Slot5.CountryGrade = CountryGrade;
                    PInfo.Slot5.Country = Country;
                    PInfo.Slot5.Side = Side;
                }

                if (User > 6)
                {
                    String Name = PReadStringL(13);
                    byte Side = PReadByte();
                    String Guild = PReadStringL(8);
                    Int16 TotalGrade = PReadInt16();
                    Int16 SeasonGrade = PReadInt16();
                    Int16 CountryGrade = PReadInt16();
                    Int16 Country = PReadInt16();

                    PInfo.Slot6.Name = Name;
                    PInfo.Slot6.Guild = Guild;
                    PInfo.Slot6.TotalGrade = TotalGrade;
                    PInfo.Slot6.SeasonGrade = SeasonGrade;
                    PInfo.Slot6.CountryGrade = CountryGrade;
                    PInfo.Slot6.Country = Country;
                    PInfo.Slot6.Side = Side;
                }

                if (User > 7)
                {
                    String Name = PReadStringL(13);
                    byte Side = PReadByte();
                    String Guild = PReadStringL(8);
                    Int16 TotalGrade = PReadInt16();
                    Int16 SeasonGrade = PReadInt16();
                    Int16 CountryGrade = PReadInt16();
                    Int16 Country = PReadInt16();

                    PInfo.Slot7.Name = Name;
                    PInfo.Slot7.Guild = Guild;
                    PInfo.Slot7.TotalGrade = TotalGrade;
                    PInfo.Slot7.SeasonGrade = SeasonGrade;
                    PInfo.Slot7.CountryGrade = CountryGrade;
                    PInfo.Slot7.Country = Country;
                    PInfo.Slot7.Side = Side;
                }

            }
            else
            {
                GetClient().SendData(new PROTOCOL_BASE_SERVERLIST_ACK());
            }
        }

        protected internal override void Run()
        {
            Program.MainV.RoomInfo(PInfo);
        }
    }
}
