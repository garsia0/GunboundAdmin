using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Client
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BTNAccept_Click(object sender, EventArgs e)
        {
            if (Password.Text.Length > 0 & UserId.Text.Length > 0)
            {
                MemoryData.UserName = UserId.Text;
                MemoryData.Password = Password.Text;

                foreach (SocketClient Client in ServerManagement.ServerClients)
                {
                    if (Client.Connect())
                    {
                        Thread.Sleep(3000);
                        Client.SendData(new PROTOCOL_FIRST_PACKET_ACK(Client));
                    }
                }
                this.Close();
            }
            else
            {
                ErrorLVL.Text = "Introduzca el Usuario y Contraseña";
            }
        }

        private void BTNCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (UserId.Text.Length >= 1 & e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Password.Focus();
            }
        }

        private void Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (UserId.Text.Length >= 1 & e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BTNAccept.Focus();
            }
        }
    }
}
