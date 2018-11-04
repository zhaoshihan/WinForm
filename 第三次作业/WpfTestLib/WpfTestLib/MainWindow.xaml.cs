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
using testLib;

namespace WpfTestLib
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("C:\\Users\\Administrator\\Documents\\Visual Studio 2015\\Projects\\CppClassDll\\Debug\\CppClassDll.dll",
            CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sumTwo(int var_x, int var_y);
        [DllImport("C:\\Users\\Administrator\\Documents\\Visual Studio 2015\\Projects\\CppClassDll\\Debug\\CppClassDll.dll",
            CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int minusTwo(int var_x, int var_y);
        [DllImport("C:\\Users\\Administrator\\Documents\\Visual Studio 2015\\Projects\\CppClassDll\\Debug\\CppClassDll.dll",
            CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int multiplyTwo(int var_x, int var_y);
        [DllImport("C:\\Users\\Administrator\\Documents\\Visual Studio 2015\\Projects\\CppClassDll\\Debug\\CppClassDll.dll",
            CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern double divideTwo(double var_x, double var_y);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MaxCD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int opcode1 = Convert.ToInt32(textbox1.Text);
                int opcode2 = Convert.ToInt32(textbox2.Text);
                int result = MaxCDClass.MaxCD(opcode1, opcode2);
                textBox.Text = result.ToString();
            }
            catch(Exception exce)
            {
                MessageBox.Show(exce.ToString());
            }

        }

        private void Swap_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int opcode1 = Convert.ToInt32(textbox1.Text);
                int opcode2 = Convert.ToInt32(textbox2.Text);
                SwapClass.Swap(ref opcode1, ref opcode2);
                string s = String.Format("{0}, {1}", opcode1, opcode2);
                textBox.Text = s;
            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.ToString());
            }

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int opcode1 = Convert.ToInt32(textbox1.Text);
                int opcode2 = Convert.ToInt32(textbox2.Text);
                int result = sumTwo(opcode1, opcode2);
                textBox.Text = result.ToString();
            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.ToString());
            }
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int opcode1 = Convert.ToInt32(textbox1.Text);
                int opcode2 = Convert.ToInt32(textbox2.Text);
                int result = minusTwo(opcode1, opcode2);
                textBox.Text = result.ToString();
            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.ToString());
            }
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int opcode1 = Convert.ToInt32(textbox1.Text);
                int opcode2 = Convert.ToInt32(textbox2.Text);
                int result = multiplyTwo(opcode1, opcode2);
                textBox.Text = result.ToString();
            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.ToString());
            }
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double opcode1 = Convert.ToDouble(textbox1.Text);
                double opcode2 = Convert.ToDouble(textbox2.Text);
                double result = divideTwo(opcode1, opcode2);
                textBox.Text = result.ToString();
            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.ToString());
            }
        }
    }
}
