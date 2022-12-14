using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class PROTOCOL_BASE_SERVERLIST : PacketReader
    {
        Int32 RoomCount;
        List<Room> RData = new List<Room>();
        public PROTOCOL_BASE_SERVERLIST(SocketClient Client, byte[] Data)
        {
            Init(Client, Data);
        }

        protected internal override void Read()
        {
            PReadInt16();
            RoomCount = PReadInt16();

            for (int i = 0; i < RoomCount; i++)
            {
                Room R = new Room();
                R.No = PReadInt16() + 1;
                int Leng = PReadByte();
                R.Name = PReadStringL(Leng);



                R.Map = Utils.Map(PReadByte());

                PReadByte();
                byte ST = PReadByte();
                BitFieldCL STemp = new BitFieldCL((UInt64)ST);
                R.Sudden = Utils.SuddenBit(STemp.BitField());

                byte Type = PReadByte();
                BitFieldCL Temp = new BitFieldCL((UInt64)Type);
                R.Type = Utils.GameModeBit(Temp.BitField());

                PReadByte(); //

                PReadByte();
                

                PReadByte(); //

                R.User = PReadByte();
                R.Max = PReadByte();
                byte Play = PReadByte();
                PReadByte(); //

                if (Play == 1)
                {
                    R.State = "Play";
                }
                else
                {
                    if (R.User == R.Max)
                    {
                        R.State = "Full";
                    }
                    else
                    {
                        R.State = "Waiting";
                    }
                }

                RData.Add(R);
            }

            

            
        }

        protected internal override void Run()
        {
            Program.MainV.RoomAddRow(RData);
        }

      
        

        
        


        /*
         * Cave(Random)
MiramoTown
Nirvana 
Metropolis
SeaOfHero
AdiumRoot 
Dragon 
CozyTower
DummySlope
StarDust
Metamine*/
    }

    
}
