using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Client
{
    public class Crypto
    {
        private static Rijndael m_StaticRijndael;
        //private static byte[] m_StaticKey = { 0xA9, 0x27, 0x53, 0x04, 0x1B, 0xFC, 0xAC, 0xE6, 0x5B, 0x23, 0x38, 0x34, 0x68, 0x46, 0x03, 0x8C };//static key broker
        private static byte[] m_StaticKey = { 0xFF, 0xB3, 0xB3, 0xBE, 0xAE, 0x97, 0xAD, 0x83, 0xB9, 0x61, 0x0E, 0x23, 0xA4, 0x3C, 0x2E, 0xB0 };//static key gs
        private Rijndael m_DynamicRijndael;
        public static void Initialize()
        {
            Crypto.m_StaticRijndael = Rijndael.Create();
            Crypto.m_StaticRijndael.Key = Crypto.m_StaticKey;
            Crypto.m_StaticRijndael.Mode = CipherMode.ECB;
            Crypto.m_StaticRijndael.Padding = PaddingMode.Zeros;
        }
        public static byte[] DecryptStatic(byte[] cipherData)
        {
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Crypto.m_StaticRijndael.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(cipherData, 0, cipherData.Length);
            cryptoStream.Close();
            return memoryStream.ToArray();
        }
        public static byte[] EncryptStatic(string strData)
        {
            byte[] cipherData = Encoding.ASCII.GetBytes(strData);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Crypto.m_StaticRijndael.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(cipherData, 0, cipherData.Length);
            cryptoStream.Close();
            return memoryStream.ToArray();
        }
        public static byte[] EncryptStatic(byte[] cipherData)
        {
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Crypto.m_StaticRijndael.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(cipherData, 0, cipherData.Length);
            cryptoStream.Close();
            return memoryStream.ToArray();
        }
        public byte[] EncryptDynamic(byte[] cipherData)
        {
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, this.m_DynamicRijndael.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(cipherData, 0, cipherData.Length);
            cryptoStream.Close();
            return memoryStream.ToArray();
        }
        public byte[] DecryptDynamic(byte[] cipherData)
        {
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, this.m_DynamicRijndael.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(cipherData, 0, cipherData.Length);
            cryptoStream.Close();
            return memoryStream.ToArray();
        }
        public static byte[] DecryptStaticBuffer(byte[] decryptme)
        {
            byte[] result;
            if (decryptme.Length != 16)
            {
#if Debug
                Program.LogFormV.UpdateLog("DecyryptStatic() is 128-bit only.");
#endif
                result = null;
            }
            else
            {
                result = Crypto.DecryptStatic(decryptme);
            }
            return result;
        }
        public void Dispose()
        {
            this.m_DynamicRijndael = null;
        }
        public bool PacketDecrypt(byte[] input, ref byte[] output, ushort packetid)
        {
            bool result;
            if (input.Length == 0)
            {
#if Debug
                Program.LogFormV.UpdateLog("Empty buffer passed for decryption");
#endif
                result = false;
            }
            else
            {
                if (input.Length % 16 != 0)
                {
#if Debug
                    Program.LogFormV.UpdateLog("Decrypt failed. Input byte count is not a multiple of 16.");
#endif
                    result = false;
                }
                else
                {
                    int num = input.Length / 16;
                    int num2 = num * 12;
                    byte[] array = new byte[input.Length];
                    byte[] array2 = new byte[num2];
                    array = this.DecryptDynamic(input);//se mandan defrente para desencryptar

                    /*
                    Utils.Log("Packet DynDecrypted: {0}", new object[]
							{
								Server.Utils.BytesToString(array,0,array.Length)
							});
                     * 
                     * */
                    //PacketReader packetReader = new PacketReader(array, array.Length);//se pasan al packet reader
                    uint num3 = 2251382910u;
                    for (int i = 0; i < num; i++)
                    {
                        //packetReader.Seek(16 * i, SeekOrigin.Begin);
                        uint num4 = BitConverter.ToUInt32(array,16 * i);//packetReader.ReadUInt32();//se leen los 4 primeros ya desencryptados pero en la inicialisacion
                        if (num4 - (uint)packetid != num3)
                        {
                            /*
                            Utils.Log("Bad Packet Signature. G: {0,8:X8} E: {1,8:X8}", new object[]
							{
								num4,
								num3 + (uint)packetid
							});
                             * */
                            result = false;
                            return result;
                        }
                        for (int j = 4; j < 16; j++)
                        {
                            array2[i * 12 + (j - 4)] = array[i * 16 + j];
                        }
                    }
                    output = array2;
                    result = true;
                }
            }
            return result;
        }
        public Crypto(string login, string pass, uint dword)
        {
            if (login.Length <= 16 && pass.Length <= 20)
            {
                SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
                SpecialSHA specialSHA = new SpecialSHA();
                String text = String.Empty;
                byte[] SaltBytes = BitConverter.GetBytes(dword);
                for (int i = 0; i < SaltBytes.Length; i++)
                {
                    text += specialSHA.Chr(SaltBytes[i]);
                }
                string inMsg = login + pass + text;
                byte[] key = specialSHA.SHA1(inMsg);
                this.m_DynamicRijndael = Rijndael.Create();
                this.m_DynamicRijndael.Key = key;
                this.m_DynamicRijndael.Mode = CipherMode.ECB;
                this.m_DynamicRijndael.Padding = PaddingMode.Zeros;
            }
        }

        public bool PacketDecryptasd(byte[] input, ref byte[] output, ushort packetid, uint num3)
        {
            bool result;
            if (input.Length == 0)
            {
#if Debug
                Program.LogFormV.UpdateLog("Empty buffer passed for decryption");
#endif
                result = false;
            }
            else
            {
                if (input.Length % 16 != 0)
                {
#if Debug
                    Program.LogFormV.UpdateLog("Decrypt failed. Input byte count is not a multiple of 16.");
#endif
                    result = false;
                }
                else
                {
                    int num = input.Length / 16;
                    int num2 = num * 12;
                    byte[] array = new byte[input.Length];
                    byte[] array2 = new byte[num2];
                    array = this.DecryptDynamic(input);//se mandan defrente para desencryptar

                    /*
                    Utils.Log("Packet DynDecrypted: {0}", new object[]
							{
								Server.Utils.BytesToString(array,0,array.Length)
							});
                     * 
                     * */
                    //PacketReader packetReader = new PacketReader(array, array.Length);//se pasan al packet reader
                    for (int i = 0; i < num; i++)
                    {
                        //packetReader.Seek(16 * i, SeekOrigin.Begin);
                        uint num4 = BitConverter.ToUInt32(array, 16 * i);//packetReader.ReadUInt32();//se leen los 4 primeros ya desencryptados pero en la inicialisacion
                        
                        if (num4 - (uint)packetid != num3)
                        {
                            /*
                            Utils.Log("Bad Packet Signature. G: {0,8:X8} E: {1,8:X8}", new object[]
							{
								num4,
								num3 + (uint)packetid
							});
                             * */
                            result = false;
                            return result;
                        }
                        for (int j = 4; j < 16; j++)
                        {
                            array2[i * 12 + (j - 4)] = array[i * 16 + j];
                        }
                    }
                    output = array2;
                    result = true;
                }
            }
            return result;
        }
    }
}
