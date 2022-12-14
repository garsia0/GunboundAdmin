using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class MemoryData
    {
        ///////////////////////////////////////////////////////////////

        public static String UserName;
        public static String Password;
        public static Int32 SelectedServer = 0;
        public static String Location = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";

    }

}
