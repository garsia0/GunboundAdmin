using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PlayerInfo
    {
        public PlayerSlot Slot0 = new PlayerSlot();
        public PlayerSlot Slot1 = new PlayerSlot();
        public PlayerSlot Slot2 = new PlayerSlot();
        public PlayerSlot Slot3 = new PlayerSlot();
        public PlayerSlot Slot4 = new PlayerSlot();
        public PlayerSlot Slot5 = new PlayerSlot();
        public PlayerSlot Slot6 = new PlayerSlot();
        public PlayerSlot Slot7 = new PlayerSlot();
        public byte User; 
    }

    public class PlayerSlot
    {
        
        public String Name;
        public String Guild;
        public Int16 TotalGrade;
        public Int16 SeasonGrade;
        public Int16 CountryGrade;
        public Int16 Country;
        public byte Side;

    }
}
