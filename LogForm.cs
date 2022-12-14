using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        public void UpdateLog(String DATA)
        {
            if (LogTXT.InvokeRequired)
            {
                LogTXT.Invoke((MethodInvoker)delegate
                {
                    LogTXT.Text += DATA + Environment.NewLine;
                    LogTXT.SelectionStart = LogTXT.Text.Length;
                    LogTXT.ScrollToCaret();
                });
            }

            else
            {
                LogTXT.Text += DATA + Environment.NewLine;
                LogTXT.SelectionStart = LogTXT.Text.Length;
                LogTXT.ScrollToCaret();
            }
        }

        public void UpdateLog2(String DATA)
        {
            if (LogTXT2.InvokeRequired)
            {
                LogTXT2.Invoke((MethodInvoker)delegate
                {
                    LogTXT2.Text += DATA + Environment.NewLine;
                    LogTXT2.SelectionStart = LogTXT2.Text.Length;
                    LogTXT2.ScrollToCaret();
                });
            }

            else
            {
                LogTXT2.Text += DATA + Environment.NewLine;
                LogTXT2.SelectionStart = LogTXT2.Text.Length;
                LogTXT2.ScrollToCaret();
            }
        }

        private void BTN_CLEAR_Click(object sender, EventArgs e)
        {
            LogTXT2.Text = String.Empty;
            LogTXT.Text = String.Empty;
        }
    }

}
                
            