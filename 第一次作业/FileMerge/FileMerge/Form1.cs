using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMerge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string folder_path;
        private void buttonChoose_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folder_path = folderBrowserDialog1.SelectedPath;
            }
            label3.Text = folder_path;
        }
        public static string[] folder_files;
        private void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(folder_path))
                    folder_files = Directory.GetFiles(folder_path, textBox1.Text, SearchOption.AllDirectories);
                listBox1.Items.Clear();
                int selected_index = 0;
                foreach (string folder_file in folder_files)
                {
                    selected_index = listBox1.Items.Add(folder_file);
                    listBox1.SetSelected(selected_index, true);
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("不合法");
            }
       }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem);
        }

        private void buttonSingle_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Only txt (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sFileName = openFileDialog1.FileName;
                listBox2.Items.Add(sFileName);
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            int sel_index = listBox2.SelectedIndex;
            string sel_str = listBox2.SelectedItem.ToString();
            if (sel_index > 0)
            {
                listBox2.Items[sel_index] = listBox2.Items[sel_index - 1];
                listBox2.Items[sel_index - 1] = sel_str;
                listBox2.SetSelected(sel_index, false);
                listBox2.SetSelected(sel_index - 1, true);
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            int sel_index = listBox2.SelectedIndex;
            string sel_str = listBox2.SelectedItem.ToString();
            if (sel_index >= 0)
            {
                listBox2.Items[sel_index] = listBox2.Items[sel_index + 1];
                listBox2.Items[sel_index + 1] = sel_str;
                listBox2.SetSelected(sel_index, false);
                listBox2.SetSelected(sel_index + 1, true);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        public static string dest_file;
        private void buttonDestination_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "选择要合并后的文件";
            saveFileDialog1.InitialDirectory = System.Environment.SpecialFolder.DesktopDirectory.ToString();
            saveFileDialog1.OverwritePrompt = false;
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dest_file = saveFileDialog1.FileName;
                label2.Text = dest_file;
            }
        }

        private void buttonMerge_Click(object sender, EventArgs e)
        {
            if(File.Exists(dest_file))
            {
                File.Delete(dest_file);
            }
            FileStream fs_dest = new FileStream(dest_file, FileMode.CreateNew, FileAccess.Write);
            byte[] DataBuffer = new byte[100000];
            byte[] file_name_buf;
            FileStream fs_source = null;
            int read_len;
            FileInfo fi_a = null;
            for(int i=0; i<listBox2.Items.Count; i++)
            {
                fi_a = new FileInfo(listBox2.Items[i].ToString());
                file_name_buf = Encoding.Default.GetBytes(fi_a.Name);
                fs_dest.Write(file_name_buf, 0, file_name_buf.Length);
                fs_dest.WriteByte((byte)13);
                fs_dest.WriteByte((byte)10);

                fs_source = new FileStream(fi_a.FullName, FileMode.Open, FileAccess.Read);
                read_len = fs_source.Read(DataBuffer, 0, 10000);
                while(read_len > 0)
                {
                    fs_dest.Write(DataBuffer, 0, read_len);
                    read_len = fs_source.Read(DataBuffer, 0, 10000);
                }

                fs_dest.WriteByte((byte)13);
                fs_dest.WriteByte((byte)10);
                fs_source.Close();
            }

            fs_source.Dispose();
            fs_dest.Flush();
            fs_dest.Close();
            fs_dest.Dispose();
            //Process.Start(dest_file);
        }


    }
}
