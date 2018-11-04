using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyCom
{
    [Guid("9908C3F1-7AC0-4CF2-9D9E-0638D99826B8")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class PrintResult : ICalculator
    {
        public String Add(int num1, int num2)
        {
            string result = String.Format("{0} + {1} = {2}", num1, num2, num1 + num2);
            return result;
        }

        public String Subtract(int num1, int num2)
        {
            string result = String.Format("{0} - {1} = {2}", num1, num2, num1 - num2);
            return result;
        }

        public String Multiply(int num1, int num2)
        {
            string result = String.Format("{0} * {1} = {2}", num1, num2, num1 * num2);
            return result;
        }

        public String Divide(double num1, double num2)
        {
            string result = String.Format("{0} / {1} = {2}", num1, num2, num1 / num2);
            return result;
        }
    }
}
