using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WinFormMessage
{
    public partial class FormSub : Form
    {
        const int BM_CLICK = 0xF5;

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hwnd, int wMsg, int wParam, ref COPYDATASTRUCT lParam);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);

        public FormSub()
        {
            InitializeComponent();
        }

        //protected override void OnShown(EventArgs e)
        //{
        //    this.Hide();
        //}

        protected override void WndProc(ref Message m)
        {
            const int BM_CLICK = 0xF5;

            if (m.Msg == BM_CLICK)
            {
                COPYDATASTRUCT cds = new COPYDATASTRUCT();
                Type t = cds.GetType();
                cds = (COPYDATASTRUCT)m.GetLParam(t);
                string strResult = cds.dwData.ToString() + ":" + cds.lpData;
                textBox1.Text += strResult;
                textBox1.Text += "\r\n";
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void SendMessage(string pcReceiveForm)
        {
            int WINDOW_HANDLER = FindWindow(null, pcReceiveForm);
            if (WINDOW_HANDLER != 0)
            {
                byte[] sarr = System.Text.Encoding.Default.GetBytes(stringText.Text);
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)Convert.ToInt32(intText.Text);//可以是任意值
                cds.cbData = len + 1;//指定lpData内存区域的字节数
                cds.lpData = stringText.Text;//发送给目标窗口所在进程的数据

                SendMessage(WINDOW_HANDLER, BM_CLICK, 0, ref cds);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMessage("FormTest");
        }
    }
}

