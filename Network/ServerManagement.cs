using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class ServerManagement
    {
        private static Int32 Count = 0;
        private static ServerManagement Instance = new ServerManagement();
        public static List<SocketClient> ServerClients = new List<SocketClient>();

        public static ServerManagement GetInstance()
        {
            return Instance;
        }

        public static void AddServer(String Ip,Int32 Port)
        {
            SocketClient CN = new SocketClient(Ip, Port);
            CN.ServerId = Count;
            Count++;
            ServerClients.Add(CN);
        }

        

        public static void SendPacketToServerNo(Int32 No,PacketSender Packet)
        {
            ServerClients[No].SendData(Packet);
        }

        public static SocketClient GetClientFromNo(Int32 No)
        {
            return ServerClients[No];
        }
    }
}
