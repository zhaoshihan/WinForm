using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFEvent
{
    public class DataChangeEventArgs : EventArgs
    {
        // 定义委托
        public delegate void DataChangeHandler(object sender, DataChangeEventArgs args);
        public string devA { get; set; }

        public string devB { get; set; }

        public DataChangeEventArgs(string s1, string s2)
        {
            devA = s1;
            devB = s2;
        }
    }
}
