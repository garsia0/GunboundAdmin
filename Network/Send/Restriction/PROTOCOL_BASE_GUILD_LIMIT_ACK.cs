using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PROTOCOL_BASE_GUILD_LIMIT_ACK : PacketSender
    {
        public PROTOCOL_BASE_GUILD_LIMIT_ACK()
        {
            Init();
        }

        protected internal override void Write()
        {
            PWriteInt16(20774); //CD
            PWriteInt16(3); // numero de Guild

            //Row Data Dividida Entre Count Ejemplo   AAAAAA = 6  BB = 2 CCC = 3 Como A Es Mayor Las Demas Se Rellenan Al mismo Length CCC___ BB____ SERIA 18 BYTES / 3 = 3 Datos 

        }

    }

}
