using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testLib
{
    public class SwapClass
    {
        public static bool Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
            return true;
        }
    }

}
