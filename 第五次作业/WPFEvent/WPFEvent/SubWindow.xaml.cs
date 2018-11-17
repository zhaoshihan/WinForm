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
using System.Windows.Shapes;

namespace WPFEvent
{
    /// <summary>
    /// Interaction logic for SubWindow.xaml
    /// </summary>
    public partial class SubWindow : Window
    {
        public delegate void UpdateMainwindowLabel(string labelContent);    // 用delegate 关键字定义事件对象类型（含事件发起者以及事件参数）
        public event UpdateMainwindowLabel updateMainwindowLabel;   // 用 event 关键字定义事件对象，它同时也是一个 delegate 对象（引用）

        public static FireAlarm myFireAlarm;

        public SubWindow()
        {
            InitializeComponent();
            myFireAlarm = new FireAlarm();
        }

        private void buttonAlarm_Click(object sender, RoutedEventArgs e)
        {
            if (updateMainwindowLabel != null)
                updateMainwindowLabel(textBox.Text.Trim());

            myFireAlarm.ActivateFireAlarm("Kitchen", 3);
            myFireAlarm.ActivateFireAlarm("Study", 1);
            myFireAlarm.ActivateFireAlarm("Porch", 5);
        }

    }
}
