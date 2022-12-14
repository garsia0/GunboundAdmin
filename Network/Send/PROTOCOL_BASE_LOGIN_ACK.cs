using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class PROTOCOL_BASE_LOGIN_ACK : PacketSender
    {
        String LoginT, PasswordT;
        byte[] CryptedDataUser, CryptedSalt, EncDynData;

        public PROTOCOL_BASE_LOGIN_ACK(String Loginv, String Passwordv, UInt32 Saltv)
        {
            Init();

            LoginT = Loginv;
            PasswordT = Passwordv;

            UInt32 U1 = 2251387023;
            UInt32 U2 = 2251387023;

            Crypto.Initialize();
            Crypto CryptoV;
            

            byte[] UserBytes = System.Text.Encoding.ASCII.GetBytes(Loginv);

            CryptedDataUser = Crypto.EncryptStatic(UserBytes);

            byte[] CryptoSalt = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            
            List<byte> TempSalt = new List<byte>(16);
            TempSalt.AddRange(BitConverter.GetBytes(Saltv));
            TempSalt.AddRange(CryptoSalt);


            byte[] CryptoSaltData = TempSalt.ToArray();

            CryptedSalt = Crypto.EncryptStatic(CryptoSaltData);


            CryptoV = new Crypto(Loginv, Passwordv, Saltv);

           

            List<byte> Temp = new List<byte>(32);
            Temp.AddRange(BitConverter.GetBytes(U1)); //CheckSum1
            Temp.AddRange(Encoding.ASCII.GetBytes(Passwordv)); //Clave
            Temp.AddRange(new byte[12 - Passwordv.Length]); //Espacios En Blanco De La Clave
            Temp.AddRange(BitConverter.GetBytes(U2)); //CheckSum2
            Temp.AddRange(new byte[12]); //ETC

            byte[] DynData = Temp.ToArray();

            EncDynData = CryptoV.EncryptDynamic(DynData);

            

            /*
            Crypto Test = new Crypto("garsia", "acuacion", Saltv);

            byte[] testout = new byte[32];

            Test.PacketDecrypt(EncDynData, ref testout, 4113);

            Program.LogFormV.UpdateLog("DecryptDynData " + Utils.HexDump(testout, 16));
            */


        }

        protected internal override void Write()
        {
            
            PWriteInt16(4113);
            PWriteBytes(CryptedDataUser);
            PWriteBytes(CryptedSalt);
            PWriteBytes(EncDynData);
        }

    }

}
