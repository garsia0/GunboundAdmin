using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Drawing;
using System.IO;

namespace Client
{
    public class Utils
    {
        public static string GetMd5Hash(string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = "dfg";// GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }


        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        public static string HexDump(byte[] bytes, int bytesPerLine = 16)
        {
            if (bytes == null) return "<null>";
            int bytesLength = bytes.Length;

            char[] HexChars = "0123456789ABCDEF".ToCharArray();

            int firstHexColumn =
                  8                   // 8 characters for the address
                + 3;                  // 3 spaces

            int firstCharColumn = firstHexColumn
                + bytesPerLine * 3       // - 2 digit for the hexadecimal value and 1 space
                + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
                + 2;                  // 2 spaces 

            int lineLength = firstCharColumn
                + bytesPerLine           // - characters to show the ascii value
                + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            char[] line = (new String(' ', lineLength - 2) + Environment.NewLine).ToCharArray();
            int expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
            StringBuilder result = new StringBuilder(expectedLines * lineLength);

            for (int i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = HexChars[(i >> 28) & 0xF];
                line[1] = HexChars[(i >> 24) & 0xF];
                line[2] = HexChars[(i >> 20) & 0xF];
                line[3] = HexChars[(i >> 16) & 0xF];
                line[4] = HexChars[(i >> 12) & 0xF];
                line[5] = HexChars[(i >> 8) & 0xF];
                line[6] = HexChars[(i >> 4) & 0xF];
                line[7] = HexChars[(i >> 0) & 0xF];

                int hexColumn = firstHexColumn;
                int charColumn = firstCharColumn;

                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0) hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
                    }
                    else
                    {
                        byte b = bytes[i + j];
                        line[hexColumn] = HexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = HexChars[b & 0xF];
                        line[charColumn] = (b < 32 ? '·' : (char)b);
                    }
                    hexColumn += 3;
                    charColumn++;
                }
                result.Append(line);
            }
            return result.ToString();
        }

        public static Image Rank(Int16 Data)
        {
            Image Temp = null;

            switch (Data)
            {
                case -5:
                    Temp = Client.Properties.Resources.M5;
                    break;
                case -4:
                    Temp = Client.Properties.Resources.M4;
                    break;
                case -3:
                    Temp = Client.Properties.Resources.M3;
                    break;
                case -2:
                    Temp = Client.Properties.Resources.M2;
                    break;
                case -1:
                    Temp = Client.Properties.Resources.M1;
                    break;
                case 0:
                    Temp = Client.Properties.Resources.D0;
                    break;
                case 1:
                    Temp = Client.Properties.Resources.D1;
                    break;
                case 2:
                    Temp = Client.Properties.Resources.D2;
                    break;
                case 3:
                    Temp = Client.Properties.Resources.D3;
                    break;
                case 4:
                    Temp = Client.Properties.Resources.D4;
                    break;
                case 5:
                    Temp = Client.Properties.Resources.D5;
                    break;
                case 6:
                    Temp = Client.Properties.Resources.D6;
                    break;
                case 7:
                    Temp = Client.Properties.Resources.D7;
                    break;
                case 8:
                    Temp = Client.Properties.Resources.D8;
                    break;
                case 9:
                    Temp = Client.Properties.Resources.D9;
                    break;
                case 10:
                    Temp = Client.Properties.Resources.D10;
                    break;
                case 11:
                    Temp = Client.Properties.Resources.D11;
                    break;
                case 12:
                    Temp = Client.Properties.Resources.D12;
                    break;
                case 13:
                    Temp = Client.Properties.Resources.D13;
                    break;
                case 14:
                    Temp = Client.Properties.Resources.D14;
                    break;
                case 15:
                    Temp = Client.Properties.Resources.D15;
                    break;
                case 16:
                    Temp = Client.Properties.Resources.D16;
                    break;
                case 17:
                    Temp = Client.Properties.Resources.D17;
                    break;
                case 18:
                    Temp = Client.Properties.Resources.D18;
                    break;
                case 19:
                    Temp = Client.Properties.Resources.D19;
                    break;
                case 20:
                    Temp = Client.Properties.Resources.D20;
                    break;
                case 21:
                    Temp = Client.Properties.Resources.D21;
                    break;
                case 22:
                    Temp = Client.Properties.Resources.D22;
                    break;
                case 23:
                    Temp = Client.Properties.Resources.D23;
                    break;
                default:
                    break;
            }

            return Temp;
        }

        public static String Map(byte Data)
        {
            String Temp = String.Empty;

            switch (Data)
            {

                case 0:
                    {
                        Temp = "Cave(Random)";
                        break;
                    }
                case 1:
                    {
                        Temp = "MiramoTown";
                        break;
                    }
                case 2:
                    {
                        Temp = "Nirvana";
                        break;
                    }
                case 3:
                    {
                        Temp = "Metropolis";
                        break;
                    }
                case 4:
                    {
                        Temp = "SeaOfHero";
                        break;
                    }
                case 5:
                    {
                        Temp = "AdiumRoot";
                        break;
                    }
                case 6:
                    {
                        Temp = "Dragon";
                        break;
                    }
                case 7:
                    {
                        Temp = "CozyTower";
                        break;
                    }
                case 8:
                    {
                        Temp = "DummySlope";
                        break;
                    }
                case 9:
                    {
                        Temp = "StarDust";
                        break;
                    }
                case 10:
                    {
                        Temp = "Metamine";
                        break;
                    }
                default:
                    Temp = "None";
                    break;
            }
            return Temp;
        }

        public static String GameModeBit(byte[] Data)
        {
            String Temp = String.Empty;

            if (Data[0] == 0)
            {
                Temp = "Solo";

                if (Data[2] == 1)
                {
                    Temp = "Score";
                }

                if (Data[3] == 1)
                {
                    Temp = "Tag";
                }

                if (Data[2] == 1 & Data[3] == 1)
                {
                    Temp = "Jewel";
                }
            }
            else
            {
                Temp = "Solo (B Side)";

                if (Data[2] == 1)
                {
                    Temp = "Score (B Side)";
                }

                if (Data[3] == 1)
                {
                    Temp = "Tag (B Side)";
                }

                if (Data[2] == 1 & Data[3] == 1)
                {
                    Temp = "Jewel (B Side)";
                }
            }


            return Temp;
        }

        public static String SuddenBit(byte[] Data)
        {
            String Temp = String.Empty;
            String Temp2 = String.Empty;
            String Temp3 = String.Empty;

            if (Data[0] == 0 && Data[0] == 0)
            {
                Temp = "Inactive";
            }
            if (Data[0] == 1 && Data[1] == 0)
            {
                Temp = "Double Deatch";
            }

            if (Data[0] == 0 && Data[1] == 1)
            {
                Temp = "Big Bomb Deatch";
            }

            if (Data[0] == 1 & Data[1] == 1)
            {
                Temp = "SS Deatch";
            }

            if (Data[4] == 1 & Data[5] == 0)
            {
                Temp2 = "(40)";
            }

            if (Data[4] == 0 & Data[5] == 1)
            {
                Temp2 = "(56)";
            }

            if (Data[4] == 1 & Data[5] == 1)
            {
                Temp2 = "(72)";
            }

            if (Data[6] == 0 & Data[7] == 1)
            {
                Temp3 = " Attack Bomb";
            }

            if (Data[6] == 1 & Data[7] == 0)
            {
                Temp3 = " Bomb Basic";
            }

            return Temp + Temp2 + Temp3;
        }

        public static void UpdateLog(String DATA)
        {
            try
            {
                StreamWriter log;
                if (!File.Exists(MemoryData.Location + "Log.txt"))
                {
                    log = new StreamWriter(MemoryData.Location + "Log.txt");
                }
                else
                {
                    log = File.AppendText(MemoryData.Location + "Log.txt");
                }
                log.WriteLine(DATA);
                log.Close();
            }
            catch
            {

            }
        }

        public static void UpdateLobbyLog(String DATA)
        {
            try
            {
                StreamWriter log;
                if (!File.Exists(MemoryData.Location + "LobbyLog.txt"))
                {
                    log = new StreamWriter(MemoryData.Location + "LobbyLog.txt");
                }
                else
                {
                    log = File.AppendText(MemoryData.Location + "LobbyLog.txt");
                }
                log.WriteLine(DATA);
                log.Close();
            }
            catch
            {

            }
        }

        public static void UpdateServerLog(String DATA)
        {
            try
            {
                StreamWriter log;
                if (!File.Exists(MemoryData.Location + "ServerLog.txt"))
                {
                    log = new StreamWriter(MemoryData.Location + "ServerLog.txt");
                }
                else
                {
                    log = File.AppendText(MemoryData.Location + "ServerLog.txt");
                }
                log.WriteLine(DATA);
                log.Close();
            }
            catch
            {

            }
        }

    }

}
