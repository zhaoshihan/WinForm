using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPFMessage
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            MainWindow NewWindowA = new MainWindow();
            NewWindowA.Title = "MainWindow";
            NewWindowA.Show();

            SubWindow NewWindowB = new SubWindow();
            NewWindowB.Title = "SubWindow";
            NewWindowB.Show();
        }
    }
}
