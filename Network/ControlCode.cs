using System;
namespace Client
{
    public class ControlCode
    {
        public Int16 ControlCodeV;

        public Int16 Update(int length)
        {
            ControlCodeV = (Int16)(((int)(ControlCodeV + 4084) + length * 17405) % 65536);
            return ControlCodeV;
        }
        public void Set(Int16 ControlCode)
        {
            ControlCodeV = ControlCode;
        }
    }
}
