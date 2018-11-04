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
        public FormSub()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            this.Hide();
        }

        protected override void WndProc(ref Message m)
        {
            const int BM_CLICK = 0xF5;

            if (m.Msg == BM_CLICK)
            {
                MessageBox.Show("子窗体收到事件");
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
