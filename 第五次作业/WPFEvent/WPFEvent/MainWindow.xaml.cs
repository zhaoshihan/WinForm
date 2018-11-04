using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFEvent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonNewWindow_Click(object sender, RoutedEventArgs e)
        {
            SubWindow subWindow = new SubWindow();
            subWindow.Activate();
            subWindow.Show();
            subWindow.updateMainwindowLabel += SubWindow_updateMainwindowLabel; // 用 += 操作符添加事件到事件队列中
            SubWindow.myFireAlarm.FireEvent += new FireAlarm.FireEventHandler(ExtinguishFire);
        }

        private void SubWindow_updateMainwindowLabel(string labelContent)   // 定义事件发起函数
        {
            textBox.Text += labelContent;
            textBox.Text += "\r\n";
        }

        void ExtinguishFire(object sender, FireEventArgs fe)    // 定义事件发起函数
        {

            String notice = String.Format("The ExtinguishFire function was called by {0}.", sender.ToString());
            textBox.Text += notice;
            textBox.Text += "\r\n";

            if (fe.ferocity < 2)
            {
                String respond =  String.Format("This fire in the {0} is no problem.  I'm going to pour some water on it.", fe.room);
                textBox.Text += respond;
                textBox.Text += "\r\n";
            }
            else if (fe.ferocity < 5)
            {
                String respond = String.Format("I'm using FireExtinguisher to put out the fire in the {0}.", fe.room);
                textBox.Text += respond;
                textBox.Text += "\r\n";
            }
            else
            {
                String respond = String.Format("The fire in the {0} is out of control.  I'm calling the fire department!", fe.room);
                textBox.Text += respond;
                textBox.Text += "\r\n";
            }
                
        }

    }

}
