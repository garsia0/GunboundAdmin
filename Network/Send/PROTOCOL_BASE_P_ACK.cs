using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PROTOCOL_BASE_P_ACK : PacketSender
    {
        String VDatos;
        public PROTOCOL_BASE_P_ACK(String Datos)
        {
            VDatos = Datos;
            Init();
        }

        protected internal override void Write()
        {
            PWriteInt16(20736); //CD
            PWriteStrinP(VDatos);
        }

    }

}
