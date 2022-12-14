using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Xml.Serialization;
namespace Client
{
    public partial class Main : Form
    {
        NotifyIcon NI = new NotifyIcon();
        private ContextMenu m_menu;

        public Main()
        {
            InitializeComponent();
        }

        List<AutoTime> Auto = new List<AutoTime>();

        System.Timers.Timer ServerList = new System.Timers.Timer();

        public void ServerText(String Text)
        {

            if (TXTSERVER.InvokeRequired)
            {
                TXTSERVER.Invoke((MethodInvoker)delegate { ServerText(Text); });
            }
            else
            {
                TXTSERVER.Text += Text + Environment.NewLine;
            }
        }

        public void ToolLog(String Text)
        {

            if (TXTTLOG.InvokeRequired)
            {
                TXTTLOG.Invoke((MethodInvoker)delegate { ToolLog(Text); });
            }
            else
            {
                TXTTLOG.Text += Text + Environment.NewLine;
            }
        }

        public void ChannelText(String Text)
        {

            if (TXTCHANNEL.InvokeRequired)
            {
                TXTCHANNEL.Invoke((MethodInvoker)delegate { ChannelText(Text); });
            }
            else
            {
                TXTCHANNEL.Text += Text + Environment.NewLine;
            }
        }

        public void RoomInfo(PlayerInfo Data)
        {

            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { RoomInfo(Data); });
            }
            else
            {
                DGVRoomInfo.Rows.Clear();

                Int32 Row;

                if (Data.User > 0)
                {
                    Row = DGVRoomInfo.Rows.Add();
                    DGVRoomInfo.Rows[Row].Cells[0].Value = "0";
                    DGVRoomInfo.Rows[Row].Cells[1].Value = Utils.Rank(Data.Slot0.CountryGrade);
                    DGVRoomInfo.Rows[Row].Cells[2].Value = Utils.Rank(Data.Slot0.TotalGrade);
                    DGVRoomInfo.Rows[Row].Cells[3].Value = Data.Slot0.Name;
                    DGVRoomInfo.Rows[Row].Cells[4].Value = Data.Slot0.Guild;

                    
                }

                if (Data.User > 1)
                {
                    Row = DGVRoomInfo.Rows.Add();
                    DGVRoomInfo.Rows[Row].Cells[0].Value = "1";
                    DGVRoomInfo.Rows[Row].Cells[1].Value = Utils.Rank(Data.Slot1.CountryGrade);
                    DGVRoomInfo.Rows[Row].Cells[2].Value = Utils.Rank(Data.Slot1.TotalGrade);
                    DGVRoomInfo.Rows[Row].Cells[3].Value = Data.Slot1.Name;
                    DGVRoomInfo.Rows[Row].Cells[4].Value = Data.Slot1.Guild;
                }

                if (Data.User > 2)
                {
                    Row = DGVRoomInfo.Rows.Add();
                    DGVRoomInfo.Rows[Row].Cells[0].Value = "2";
                    DGVRoomInfo.Rows[Row].Cells[1].Value = Utils.Rank(Data.Slot2.CountryGrade);
                    DGVRoomInfo.Rows[Row].Cells[2].Value = Utils.Rank(Data.Slot2.TotalGrade);
                    DGVRoomInfo.Rows[Row].Cells[3].Value = Data.Slot2.Name;
                    DGVRoomInfo.Rows[Row].Cells[4].Value = Data.Slot2.Guild;
                }

                if (Data.User > 3)
                {
                    Row = DGVRoomInfo.Rows.Add();
                    DGVRoomInfo.Rows[Row].Cells[0].Value = "3";
                    DGVRoomInfo.Rows[Row].Cells[1].Value = Utils.Rank(Data.Slot3.CountryGrade);
                    DGVRoomInfo.Rows[Row].Cells[2].Value = Utils.Rank(Data.Slot3.TotalGrade);
                    DGVRoomInfo.Rows[Row].Cells[3].Value = Data.Slot3.Name;
                    DGVRoomInfo.Rows[Row].Cells[4].Value = Data.Slot3.Guild;
                }

                if (Data.User > 4)
                {
                    Row = DGVRoomInfo.Rows.Add();
                    DGVRoomInfo.Rows[Row].Cells[0].Value = "4";
                    DGVRoomInfo.Rows[Row].Cells[1].Value = Utils.Rank(Data.Slot4.CountryGrade);
                    DGVRoomInfo.Rows[Row].Cells[2].Value = Utils.Rank(Data.Slot4.TotalGrade);
                    DGVRoomInfo.Rows[Row].Cells[3].Value = Data.Slot4.Name;
                    DGVRoomInfo.Rows[Row].Cells[4].Value = Data.Slot4.Guild;
                }

                if (Data.User > 5)
                {
                    Row = DGVRoomInfo.Rows.Add();
                    DGVRoomInfo.Rows[Row].Cells[0].Value = "5";
                    DGVRoomInfo.Rows[Row].Cells[1].Value = Utils.Rank(Data.Slot5.CountryGrade);
                    DGVRoomInfo.Rows[Row].Cells[2].Value = Utils.Rank(Data.Slot5.TotalGrade);
                    DGVRoomInfo.Rows[Row].Cells[3].Value = Data.Slot5.Name;
                    DGVRoomInfo.Rows[Row].Cells[4].Value = Data.Slot5.Guild;
                }

                if (Data.User > 6)
                {
                    Row = DGVRoomInfo.Rows.Add();
                    DGVRoomInfo.Rows[Row].Cells[0].Value = "6";
                    DGVRoomInfo.Rows[Row].Cells[1].Value = Utils.Rank(Data.Slot6.CountryGrade);
                    DGVRoomInfo.Rows[Row].Cells[2].Value = Utils.Rank(Data.Slot6.TotalGrade);
                    DGVRoomInfo.Rows[Row].Cells[3].Value = Data.Slot6.Name;
                    DGVRoomInfo.Rows[Row].Cells[4].Value = Data.Slot6.Guild;
                }

                if (Data.User > 7)
                {
                    Row = DGVRoomInfo.Rows.Add();
                    DGVRoomInfo.Rows[Row].Cells[0].Value = "7";
                    DGVRoomInfo.Rows[Row].Cells[1].Value = Utils.Rank(Data.Slot7.CountryGrade);
                    DGVRoomInfo.Rows[Row].Cells[2].Value = Utils.Rank(Data.Slot7.TotalGrade);
                    DGVRoomInfo.Rows[Row].Cells[3].Value = Data.Slot7.Name;
                    DGVRoomInfo.Rows[Row].Cells[4].Value = Data.Slot7.Guild;
                }
                
            }
        }

        public void RoomAddRow(List<Room> RData)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke((MethodInvoker)delegate
                {
                    RoomAddRow(RData);
                });
            }
            else
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        bool found = false;

                        for (int j = 0; j < RData.Count; j++)
                        {

                            if (dataGridView1.Rows[i].Cells[0].Value.ToString() == (RData[j].No).ToString())
                            {
                                found = true;
                                break;
                            }


                        }

                        if (!found)
                        {
                            dataGridView1.Rows.RemoveAt(i);
                        }

                    }
                }
                catch { }

                for (int i = 0; i < RData.Count; i++)
                {
                    bool found = false;
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        if (dataGridView1.Rows[j].Cells[0].Value.ToString() == (RData[i].No).ToString())
                        {
                            found = true;
                            dataGridView1.Rows[j].Cells[1].Value = RData[i].Name;
                            dataGridView1.Rows[j].Cells[2].Value = RData[i].State;
                            dataGridView1.Rows[j].Cells[3].Value = RData[i].Map;
                            dataGridView1.Rows[j].Cells[4].Value = RData[i].Type;
                            dataGridView1.Rows[j].Cells[5].Value = RData[i].Sudden;
                            dataGridView1.Rows[j].Cells[6].Value = RData[i].User + "/" + RData[i].Max;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Int32 Row = dataGridView1.Rows.Add(RData[i].No.ToString());
                        dataGridView1.Rows[Row].Cells[1].Value = RData[i].Name;
                        dataGridView1.Rows[Row].Cells[2].Value = RData[i].State;
                        dataGridView1.Rows[Row].Cells[3].Value = RData[i].Map;
                        dataGridView1.Rows[Row].Cells[4].Value = RData[i].Type;
                        dataGridView1.Rows[Row].Cells[5].Value = RData[i].Sudden;
                        dataGridView1.Rows[Row].Cells[6].Value = RData[i].User + "/" + RData[i].Max;
                    }
                }
            }
        }

        public void RoomMapChange(Int16 Room, byte Map)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke((MethodInvoker)delegate
                {
                    RoomMapChange(Room, Map);
                });
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    try
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == (Room + 1).ToString())
                        {
                            dataGridView1.Rows[i].Cells[3].Value = Utils.Map(Map);
                            break;
                        }
                    }
                    catch { }
                    
                }
            }


        }

        public void RoomGameMode(Int16 Room, String Sudden,String GameMode)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke((MethodInvoker)delegate
                {
                    RoomGameMode(Room, Sudden, GameMode);
                });
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    try
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == (Room + 1).ToString())
                        {
                            dataGridView1.Rows[i].Cells[4].Value = GameMode;
                            dataGridView1.Rows[i].Cells[5].Value = Sudden;
                            break;
                        }
                    }
                    catch { }

                }
            }


        }

        public void RoomClose(Int16 Room)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke((MethodInvoker)delegate
                {
                    RoomClose(Room);
                });
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    try
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == (Room + 1).ToString())
                        {
                            dataGridView1.Rows.RemoveAt(i);
                            break;
                        }
                    }
                    catch { }

                }
            }


        }

        public void RoomMaxPlayerChange(Int16 Room, byte Max)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke((MethodInvoker)delegate
                {
                    RoomMaxPlayerChange(Room, Max);
                });
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    try
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == (Room + 1).ToString())
                        {
                            dataGridView1.Rows[i].Cells[6].Value = dataGridView1.Rows[i].Cells[6].Value.ToString().Substring(0,1) + "/" + Max;
                            break;
                        }
                    }
                    catch { }

                }
            }


        }

        public void RoomPlayerChange(Int16 Room, byte Player)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke((MethodInvoker)delegate
                {
                    RoomPlayerChange(Room, Player);
                });
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    try
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == (Room + 1).ToString())
                        {
                            dataGridView1.Rows[i].Cells[6].Value = Player + "/" + dataGridView1.Rows[i].Cells[6].Value.ToString().Substring(2, 1);
                            break;
                        }
                    }
                    catch { }

                }
            }


        }

        public void RoomStateChange(Int16 Room, byte State)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke((MethodInvoker)delegate
                {
                    RoomStateChange(Room, State);
                });
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    try
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == (Room + 1).ToString())
                        {


                            if (State == 1)
                            {
                                dataGridView1.Rows[i].Cells[2].Value = "Play";
                            }
                            else
                            {
                                if (dataGridView1.Rows[i].Cells[5].Value.ToString().Substring(0, 1) == dataGridView1.Rows[i].Cells[5].Value.ToString().Substring(2, 1))
                                {
                                    dataGridView1.Rows[i].Cells[2].Value = "Full";
                                }
                                else
                                {
                                    dataGridView1.Rows[i].Cells[2].Value = "Waiting";
                                }
                            }
                            break;
                        }
                    }
                    catch { }

                }
            }


        }

        public void RoomClearRow()
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke((MethodInvoker)delegate
                {
                    RoomClearRow();
                });
            }
            else
            {
                dataGridView1.Rows.Clear();
            }


        }

        public void ServerUpdateRow(Int32 Index, ServerInfo Data)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke((MethodInvoker)delegate
                {
                    ServerUpdateRow(Index,Data);
                });
            }
            else
            {

                dataGridViewServer.Rows[Index].Cells[4].Value = Data.User;
                dataGridViewServer.Rows[Index].Cells[5].Value = Data.Room;
                dataGridViewServer.Rows[Index].Cells[6].Value = Data.UserInRoom;
                dataGridViewServer.Rows[Index].Cells[7].Value = Data.UserInChannel;
                dataGridViewServer.Rows[Index].Cells[8].Value = Data.VersionMin + " - " + Data.VersionMax;
                dataGridViewServer.Rows[Index].Cells[9].Value = Data.GradeDown + " < " + Data.GradeUp;
            }


        }

        public void ServerUpdateState(Int32 Index, String Data)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke((MethodInvoker)delegate
                {
                    ServerUpdateState(Index, Data);
                });
            }
            else
            {
                dataGridViewServer.Rows[Index].Cells[3].Value = Data;
                if (dataGridViewServer.SelectedRows.Count > 0)
                {
                    MemoryData.SelectedServer = Int32.Parse(dataGridViewServer.SelectedRows[0].Cells[0].Value.ToString());
                    if(MemoryData.SelectedServer == Index)
                    {
                        toolStripStatusS.Text = Data;
                    }
                }
            }
        }

        public void ServerUpdateResult(Int32 Index, String Data)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke((MethodInvoker)delegate
                {
                    ServerUpdateResult(Index, Data);
                });
            }
            else
            {
                dataGridViewServer.Rows[Index].Cells[10].Value = Data;
            }
        }

        public void UpdateLabel(String Text)
        {

            if (ErrorLVL.InvokeRequired)
            {
                ErrorLVL.Invoke((MethodInvoker)delegate { ErrorLVL.Text += Text; });
            }
            else
            {
                ErrorLVL.Text += Text;
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (SocketClient Client in ServerManagement.ServerClients)
            {
                if (Client.Connected)
                {
                    Client.Disconnect();
                }
            }
            Environment.Exit(0);
        }

        protected void Exit_Click(Object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }

        protected void Show_Click(Object sender, System.EventArgs e)
        {
            ShowInTaskbar = true;
            NI.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            m_menu = new ContextMenu();
            m_menu.MenuItems.Add(0,
                new MenuItem("Show", new System.EventHandler(Show_Click)));
            m_menu.MenuItems.Add(1,
                new MenuItem("Exit", new System.EventHandler(Exit_Click)));

            NI.Icon = ((System.Drawing.Icon)Client.Properties.Resources.Tool_Ico); //The tray icon to use
            NI.BalloonTipText = "GunboundAdminTool";
            NI.BalloonTipTitle = "GunboundAdminTool";
            NI.MouseDoubleClick += new MouseEventHandler(NI_MouseDoubleClick);
            NI.Text = "GunboundAdminTool";
            NI.ContextMenu = m_menu;


            ImageList IL = new ImageList();
            IL.ImageSize = new Size(25,15);

            for (short i = -5; i <= 23; i++)
			{
                Int32 T = IL.Images.Add(Utils.Rank(i),Color.Magenta);
			}
    
            LVGRADELOWER.SmallImageList = IL;
            LVGRADELOWER.Items.Add("-4|Silver Dragon", 1);
            LVGRADELOWER.Items.Add("-3|Red Dragon", 2);
            LVGRADELOWER.Items.Add("-2|Blue Dragon", 3);
            LVGRADELOWER.Items.Add("-1|Diamond Wand", 4);
            LVGRADELOWER.Items.Add(" 0|Ruby Wand", 5);
            LVGRADELOWER.Items.Add(" 1|Sapphire Wand", 6);
            LVGRADELOWER.Items.Add(" 2|Amethyst Wand", 7);
            LVGRADELOWER.Items.Add(" 3|Gold Double Sided Axe +", 8);
            LVGRADELOWER.Items.Add(" 4|Gold Double Sided Axe", 9);
            LVGRADELOWER.Items.Add(" 5|Silver Double Sided Axe +", 10);
            LVGRADELOWER.Items.Add(" 6|Silver Double Sided Axe", 11);
            LVGRADELOWER.Items.Add(" 7|Metal Double Sided Axe +", 12);
            LVGRADELOWER.Items.Add(" 8|Metal Double Sided Axe", 13);
            LVGRADELOWER.Items.Add(" 9|Double Gold Axes", 14);
            LVGRADELOWER.Items.Add("10|Gold Axe", 15);
            LVGRADELOWER.Items.Add("11|Double Silver Axes", 16);
            LVGRADELOWER.Items.Add("12Silver Axes", 17);
            LVGRADELOWER.Items.Add("13|Double Metal Axes", 18);
            LVGRADELOWER.Items.Add("14|Metal Axes", 19);
            LVGRADELOWER.Items.Add("15|Double Stone Hammer", 20);
            LVGRADELOWER.Items.Add("16|Stone Hammer", 21);
            LVGRADELOWER.Items.Add("17|Double Wooden Hammer", 22);
            LVGRADELOWER.Items.Add("18|Wooden Hammer", 23);
            LVGRADELOWER.Items.Add("19|A Little Chick", 24);
            LVGRADELOWER.Items.Add("20|Admin Block", 25);
            LVGRADELOWER.Items.Add("21|Admin Unblock", 26);
            LVGRADELOWER.Items.Add("22|GM Male", 27);
            LVGRADELOWER.Items.Add("23|GM Female", 28);

            LVGRADEUPPER.SmallImageList = IL;
            LVGRADEUPPER.Items.Add("-4|Silver Dragon", 1);
            LVGRADEUPPER.Items.Add("-3|Red Dragon", 2);
            LVGRADEUPPER.Items.Add("-2|Blue Dragon", 3);
            LVGRADEUPPER.Items.Add("-1|Diamond Wand", 4);
            LVGRADEUPPER.Items.Add(" 0|Ruby Wand", 5);
            LVGRADEUPPER.Items.Add(" 1|Sapphire Wand", 6);
            LVGRADEUPPER.Items.Add(" 2|Amethyst Wand", 7);
            LVGRADEUPPER.Items.Add(" 3|Gold Double Sided Axe +", 8);
            LVGRADEUPPER.Items.Add(" 4|Gold Double Sided Axe", 9);
            LVGRADEUPPER.Items.Add(" 5|Silver Double Sided Axe +", 10);
            LVGRADEUPPER.Items.Add(" 6|Silver Double Sided Axe", 11);
            LVGRADEUPPER.Items.Add(" 7|Metal Double Sided Axe +", 12);
            LVGRADEUPPER.Items.Add(" 8|Metal Double Sided Axe", 13);
            LVGRADEUPPER.Items.Add(" 9|Double Gold Axes", 14);
            LVGRADEUPPER.Items.Add("10|Gold Axe", 15);
            LVGRADEUPPER.Items.Add("11|Double Silver Axes", 16);
            LVGRADEUPPER.Items.Add("12Silver Axes", 17);
            LVGRADEUPPER.Items.Add("13|Double Metal Axes", 18);
            LVGRADEUPPER.Items.Add("14|Metal Axes", 19);
            LVGRADEUPPER.Items.Add("15|Double Stone Hammer", 20);
            LVGRADEUPPER.Items.Add("16|Stone Hammer", 21);
            LVGRADEUPPER.Items.Add("17|Double Wooden Hammer", 22);
            LVGRADEUPPER.Items.Add("18|Wooden Hammer", 23);
            LVGRADEUPPER.Items.Add("19|A Little Chick", 24);
            LVGRADEUPPER.Items.Add("20|Admin Block", 25);
            LVGRADEUPPER.Items.Add("21|Admin Unblock", 26);
            LVGRADEUPPER.Items.Add("22|GM Male", 27);
            LVGRADEUPPER.Items.Add("23|GM Female", 28);
         
            
            
            
            Int32 Count = 0;
            //MemoryData.Shutdown = false;
            //BTNAccept_Click(null, null);
            if (File.Exists(MemoryData.Location + "Server.txt"))
            {

                String Line;
                System.IO.StreamReader SServers = new System.IO.StreamReader(MemoryData.Location + "Server.txt");
                while ((Line = SServers.ReadLine()) != null)
                {
                    String[] Server = Line.Split(':');
                    ServerManagement.AddServer(Dns.GetHostAddresses(Server[0])[0].ToString(), Int32.Parse(Server[1]));
                    Int32 Item = dataGridViewServer.Rows.Add(Count.ToString());
                    Count++;
                    dataGridViewServer.Rows[Item].Cells[1].Value = Server[0];
                    dataGridViewServer.Rows[Item].Cells[2].Value = Server[1];
                }

                SServers.Close();

                TimeStatus();

                ServerList.Elapsed += new System.Timers.ElapsedEventHandler(UpdateServerList);
                ServerList.Interval = 30000;
                ServerList.AutoReset = true;




                if (File.Exists(MemoryData.Location + "Broadcast.xml"))
                {
                    XmlSerializer XMLFile = new XmlSerializer(typeof(FileTimer));
                    StreamReader TReader = new StreamReader(MemoryData.Location + "Broadcast.xml");
                    FileTimer FT = (FileTimer)XMLFile.Deserialize(TReader);
                    Auto = FT.Auto;
                    TReader.Close();
                    for (int i = 0; i < Auto.Count; i++)
                    {
                        Auto[i].Count = Auto[i].Time * 60;
                        ListTime.Items.Add("Every " + Auto[i].Time + " Minutes");
                    }
                }

                if (File.Exists(MemoryData.Location + "Config.xml"))
                {
                    XmlSerializer XMLFile = new XmlSerializer(typeof(Setup));
                    StreamReader TReader = new StreamReader(MemoryData.Location + "Config.xml");
                    Setup ST = (Setup)XMLFile.Deserialize(TReader);

                    MemoryData.UserName = ST.UserName;
                    MemoryData.Password = ST.Password;
                    if (ST.AutoHide)
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }

                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;

                        if (ST.AutoLogin)
                        {

                            foreach (SocketClient Sicket_Client in ServerManagement.ServerClients)
                            {
                                if (Sicket_Client.Connect())
                                {
                                    Thread.Sleep(1000);
                                    Sicket_Client.SendData(new PROTOCOL_FIRST_PACKET_ACK(Sicket_Client));
                                }
                            }
                        }
                        
                    }).Start();
                    
                }
                else
                {
                    Setup Temp = new Setup();
                    Temp.UserName = "Name";
                    Temp.Password = "****";
                    Temp.AutoLogin = false;
                    XmlSerializer Serializer = new XmlSerializer(typeof(Setup));
                    TextWriter TWriter = new StreamWriter(MemoryData.Location + "Config.xml");
                    Serializer.Serialize(TWriter, Temp);
                    TWriter.Close();
                }

                System.Windows.Forms.Timer T = new System.Windows.Forms.Timer();
                T.Enabled = true;
                T.Interval = 100;
                T.Tick += new EventHandler(T_Tick);
                T.Start();

            }
            else
            {
                MessageBox.Show("File No Found: Server.txt");
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                NI.Visible = true;
                NI.ShowBalloonTip(1000);
            }
        }

        void NI_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            NI.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        void T_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Auto.Count; i++)
            {
                if (Auto[i].Enable)
                {
                    Auto[i].Count--;

                    if (Auto[i].Count <= 0)
                    {
                        if (Auto[i].Ramdom)
                        {
                            Random R = new Random();

                            foreach (SocketClient SC in ServerManagement.ServerClients)
                            {
                                if (SC.Connected)
                                    SC.SendData(new PROTOCOL_BASE_BROADCAST_SEND_ACK(3, Auto[i].Text[R.Next(0, Auto[i].Text.Length - 1)]));
                            }
                        }
                        else
                        {

                            if (Auto[i].LineCount > Auto[i].Text.Length - 1)
                            {
                                Auto[i].LineCount = 0;
                            }

                            foreach (SocketClient SC in ServerManagement.ServerClients)
                            {
                                if (SC.Connected)
                                    SC.SendData(new PROTOCOL_BASE_BROADCAST_SEND_ACK(3, Auto[i].Text[Auto[i].LineCount]));
                            }
                            Auto[i].LineCount++;
                        }

                        Auto[i].Count = Auto[i].Time * 60;
                    }
                }
            }
        }

        static void Time_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            foreach (SocketClient Client in ServerManagement.ServerClients)
            {
                if (Client.Connected)
                {
                    Client.SendData(new PROTOCOL_BASE_STATUS_ACK());
                }
            }
        }


        private static void TimeStatus()
        {
            System.Timers.Timer Time = new System.Timers.Timer();
            Time.Elapsed += new System.Timers.ElapsedEventHandler(Time_Elapsed);
            Time.Interval = 60000;
            Time.AutoReset = true;
            Time.Start();
        }

        void UpdateServerList(object sender, System.Timers.ElapsedEventArgs e)
         {
             if (ServerManagement.GetClientFromNo(MemoryData.SelectedServer).Connected)
             {
                 ServerManagement.SendPacketToServerNo(MemoryData.SelectedServer, new PROTOCOL_BASE_SERVERLIST_ACK());
             }
         }

        private void BTNSERVERLIST_Click(object sender, EventArgs e)
         {
             if (dataGridViewServer.SelectedRows.Count > 0)
             {

                 if (ServerManagement.GetClientFromNo(MemoryData.SelectedServer).Connected)
                 {
                     dataGridView1.Rows.Clear();
                     ServerManagement.SendPacketToServerNo(MemoryData.SelectedServer, new PROTOCOL_BASE_SERVERLIST_ACK());
                 }
                 else
                 {
                     MessageBox.Show("Server Status Disconnected.");
                 }
             }
             else
             {
                 MessageBox.Show("Select Server Required.");
             }
         }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            DGVRoomInfo.Rows.Clear();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                ServerManagement.SendPacketToServerNo(MemoryData.SelectedServer, new PROTOCOL_BASE_ROOMINFO_ACK((Int16.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()))));
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login L = new Login();
            L.ShowDialog();
        }

        private void BTN_CMD_Click(object sender, EventArgs e)
        {
            if (dataGridViewServer.SelectedRows.Count > 0)
            {
                if (ServerManagement.GetClientFromNo(MemoryData.SelectedServer).Connected)
                {
                    ServerManagement.SendPacketToServerNo(MemoryData.SelectedServer, new PROTOCOL_BASE_P_ACK(TXTCMD.Text));
                }
                else
                {
                    MessageBox.Show("Server Status Disconnected.");
                }
                
            }
            else
            {
                MessageBox.Show("Select Server Required.");
            }
        }

        private void TXTCMD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TXTCMD.Text.Length >= 1 & e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BTN_CMD_Click(null, null);
            }
        }

        private void dataGridViewServer_SelectionChanged(object sender, EventArgs e)
        {
            
            if (dataGridViewServer.SelectedRows.Count > 0)
            {
                MemoryData.SelectedServer = Int32.Parse(dataGridViewServer.SelectedRows[0].Cells[0].Value.ToString());
                LBLServer.Text = (MemoryData.SelectedServer + 1).ToString();
                toolStripStatusServer.Text = (MemoryData.SelectedServer + 1).ToString();
                toolStripStatusS.Text = "None";
            }
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                BTNSERVERLIST_Click(null, null);
                ServerList.Start();
            }
            else
            {
                ServerList.Stop();
            }
        }

        private void BTNSEND_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ServerManagement.ServerClients.Count; i++)
			{
                if (RBMent.Checked)
                {
                    if (CheckChannel.Checked)
                    {
                        ServerManagement.ServerClients[i].SendData(new PROTOCOL_BASE_MESSAGE_SEND_ACK(1, TXTMessage.Text));
                    }

                    if (CheckGame.Checked)
                    {
                        ServerManagement.ServerClients[i].SendData(new PROTOCOL_BASE_MESSAGE_SEND_ACK(2, TXTMessage.Text));
                    }
                }

                if (RBBroadCast.Checked)
                {
                    if (CheckChannel.Checked && CheckGame.Checked)
                    {
                        ServerManagement.ServerClients[i].SendData(new PROTOCOL_BASE_BROADCAST_SEND_ACK(3, TXTMessage.Text));
                    }
                    else if (CheckChannel.Checked)
                    {
                        ServerManagement.ServerClients[i].SendData(new PROTOCOL_BASE_BROADCAST_SEND_ACK(2, TXTMessage.Text));
                    }
                    else if (CheckGame.Checked)
                    {
                        ServerManagement.ServerClients[i].SendData(new PROTOCOL_BASE_BROADCAST_SEND_ACK(1, TXTMessage.Text));
                    }
                }
			} 
        }

        private void RBMent_CheckedChanged(object sender, EventArgs e)
        {
            if (RBMent.Checked)
            {
                CheckGame.Checked = false;
                CheckChannel.Checked = false;
            }
        }

        private void BTNADDB_Click(object sender, EventArgs e)
        {
            Int32 Index = ListTime.Items.Add("Every " + TextTime.Text + " Minutes");
            AutoTime T = new AutoTime();
            T.Ramdom = CheckRamdomL.Checked;
            T.Enable = CheckEnable.Checked;
            String[] CurrentData = TextText.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            List<String> Temp = new List<string>();
            for (int i = 0; i < CurrentData.Length; i++)
            {
                if (CurrentData[i].Length > 0)
                {
                    Temp.Add(CurrentData[i]);
                }
            }
            T.Text = Temp.ToArray();

            T.Time = Int32.Parse(TextTime.Text);
            T.Count = T.Time * 60;
            Auto.Add(T);
            FileTimer Data = new FileTimer();
            Data.Auto = Auto;
            XmlSerializer Serializer = new XmlSerializer(typeof(FileTimer));
            TextWriter TWriter = new StreamWriter(MemoryData.Location + "Broadcast.xml");
            Serializer.Serialize(TWriter, Data);
            TWriter.Close();

        }

        private void ListTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListTime.SelectedIndex > -1)
            {
                AutoTime T = Auto[ListTime.SelectedIndex];
                CheckRamdomL.Checked = T.Ramdom;
                CheckEnable.Checked = T.Enable;
                String Temp = String.Empty;
                for (int i = 0; i < T.Text.Length; i++)
                {
                    Temp += T.Text[i] + Environment.NewLine;
                }
                TextText.Text = Temp;
                TextTime.Text = T.Time.ToString();
            }
        }

        private void BTNEDITB_Click(object sender, EventArgs e)
        {
            AutoTime T = new AutoTime();
            T.Ramdom = CheckRamdomL.Checked;
            T.Enable = CheckEnable.Checked;
            String[] CurrentData = TextText.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            List<String> Temp = new List<string>();
            for (int i = 0; i < CurrentData.Length; i++)
            {
                if (CurrentData[i].Length > 0)
                {
                    Temp.Add(CurrentData[i]);
                }
            }
            T.Text = Temp.ToArray();


            T.Time = Int32.Parse(TextTime.Text);
            T.Count = T.Time * 60;
            if (ListTime.SelectedIndex > -1)
            {
                Auto[ListTime.SelectedIndex] = T;
                ListTime.Items[ListTime.SelectedIndex] = "Every " + T.Time + " Minutes";
                FileTimer Data = new FileTimer();
                Data.Auto = Auto;
                XmlSerializer Serializer = new XmlSerializer(typeof(FileTimer));
                TextWriter TWriter = new StreamWriter(MemoryData.Location + "Broadcast.xml");
                Serializer.Serialize(TWriter, Data);
                TWriter.Close();
            }
        }

        private void BTNRemoveB_Click(object sender, EventArgs e)
        {
            if (ListTime.SelectedIndex > -1)
            {
                Auto.RemoveAt(ListTime.SelectedIndex);
                FileTimer Data = new FileTimer();
                Data.Auto = Auto;
                XmlSerializer Serializer = new XmlSerializer(typeof(FileTimer));
                TextWriter TWriter = new StreamWriter(MemoryData.Location + "Broadcast.xml");
                Serializer.Serialize(TWriter, Data);
                TWriter.Close();
                ListTime.Items.RemoveAt(ListTime.SelectedIndex);
            }
        }

        private void BTNVERCIONSAVE_Click(object sender, EventArgs e)
        {
            if (dataGridViewServer.SelectedRows.Count > 0)
            {
                for (int i = 0; i < ServerManagement.ServerClients.Count; i++)
                {
                    if (ServerManagement.ServerClients[i].ServerId == MemoryData.SelectedServer)
                    {
                        if (ServerManagement.ServerClients[i].Connected)
                        {
                            ServerManagement.ServerClients[i].SendData(new PROTOCOL_BASE_VERCION_ACK(Int32.Parse(TXTVERCIONLOWER.Text),Int32.Parse(TXTVERCIONUPPER.Text)));
                        }
                    }
                }
            }
        }

        private void LVGRADELOWER_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LVGRADELOWER.SelectedItems.Count > 0)
            {
                labelGRADEL.Text = LVGRADELOWER.SelectedItems[0].Text;
                pictureBox1L.Image = LVGRADELOWER.SmallImageList.Images[LVGRADELOWER.SelectedItems[0].ImageIndex];
            }
        }

        private void LVGRADEUPPER_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LVGRADEUPPER.SelectedItems.Count > 0)
            {
                labelGRADEU.Text = LVGRADEUPPER.SelectedItems[0].Text;
                pictureBoxU.Image = LVGRADEUPPER.SmallImageList.Images[LVGRADEUPPER.SelectedItems[0].ImageIndex];
            }
        }

        private void BTNGRADESAVE_Click(object sender, EventArgs e)
        {
            if (labelGRADEL.Text != "None" && labelGRADEU.Text != "None")
            {
                for (int i = 0; i < ServerManagement.ServerClients.Count; i++)
                {
                    if (ServerManagement.ServerClients[i].ServerId == MemoryData.SelectedServer)
                    {
                        if (ServerManagement.ServerClients[i].Connected)
                        {
                            ServerManagement.ServerClients[i].SendData(new PROTOCOL_BASE_GRADE_LIMIT_ACK(Int16.Parse(labelGRADEU.Text.Split('|')[0]), Int16.Parse(labelGRADEU.Text.Split('|')[0])));
                        }
                    }
                }
            }
        }
    }

    public class AutoTime
    {
        public String[] Text { get; set; }
        public Int32 Time { get; set; }
        public bool Ramdom { get; set; }
        public bool Enable { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public Int32 Count;
        [System.Xml.Serialization.XmlIgnore]
        public Int32 LineCount; 
    }

    public class FileTimer
    {
        public List<AutoTime> Auto { get; set; } 
    }

    public class Setup
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public bool AutoLogin { get; set; }
        public bool AutoHide { get; set; }
    }
}
