using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Reflection;
using MyCom;
using MsExcel = Microsoft.Office.Interop.Excel;
using MsWord = Microsoft.Office.Interop.Word;
using System.IO;

namespace ComDisplay
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private const string CLSID = "{9908C3F1-7AC0-4CF2-9D9E-0638D99826B8}";
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Type word = Type.GetTypeFromCLSID(Guid.Parse(CLSID));
                object wordObj = Activator.CreateInstance(word);

                int opcode1 = Convert.ToInt32(textBox.Text);
                int opcode2 = Convert.ToInt32(textBox1.Text);

                MethodInfo method = word.GetMethod("Add");
                Object[] args = { opcode1, opcode2 };
                var result = method.Invoke(wordObj, args);

                textBox8.Text = result.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void buttonSub_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Type word = Type.GetTypeFromCLSID(Guid.Parse(CLSID));
                object wordObj = Activator.CreateInstance(word);

                int opcode1 = Convert.ToInt32(textBox2.Text);
                int opcode2 = Convert.ToInt32(textBox3.Text);

                MethodInfo method = word.GetMethod("Subtract");
                Object[] args = { opcode1, opcode2 };
                var result = method.Invoke(wordObj, args);

                textBox9.Text = result.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void buttonMul_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Type word = Type.GetTypeFromCLSID(Guid.Parse(CLSID));
                object wordObj = Activator.CreateInstance(word);

                int opcode1 = Convert.ToInt32(textBox4.Text);
                int opcode2 = Convert.ToInt32(textBox5.Text);

                MethodInfo method = word.GetMethod("Multiply");
                Object[] args = { opcode1, opcode2 };
                var result = method.Invoke(wordObj, args);

                textBox10.Text = result.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void buttonDiv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Type word = Type.GetTypeFromCLSID(Guid.Parse(CLSID));
                object wordObj = Activator.CreateInstance(word);

                double opcode1 = Convert.ToDouble(textBox6.Text);
                double opcode2 = Convert.ToDouble(textBox7.Text);

                MethodInfo method = word.GetMethod("Divide");
                Object[] args = { opcode1, opcode2 };
                var result = method.Invoke(wordObj, args);

                textBox11.Text = result.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void WordTest1_Click(object sender, RoutedEventArgs e)
        {
            MsWord.Application oWordApplic;
            MsWord.Document oDoc;

            try
            {
                string doc_file_name = Directory.GetCurrentDirectory() + @"\Testcontent.doc";
                if (File.Exists(doc_file_name))
                {
                    File.Delete(doc_file_name);
                }
                oWordApplic = new MsWord.Application();
                object missing = System.Reflection.Missing.Value;

                MsWord.Range curRange;
                object curTxt;
                int curSectionNum = 1;
                oDoc = oWordApplic.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                oDoc.Activate();
                textBoxWord.Text = "正在生成文档小节";
                object section_nextPage = MsWord.WdBreakType.wdSectionBreakNextPage;



            }
            catch(Exception exce)
            {
                MessageBox.Show(exce.Message);
            }
        }
    }
}
