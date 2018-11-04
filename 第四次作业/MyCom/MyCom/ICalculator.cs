using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MyCom
{
    [Guid("52CD62AE-BCEA-47E4-81DC-B1EA37D1673E")]
    [ComVisible(true)]
    public interface ICalculator
    {
        String Add(int num1, int num2);
        String Subtract(int num1, int num2);
        String Multiply(int num1, int num2);
        String Divide(double num1, double num2);
    }
}
