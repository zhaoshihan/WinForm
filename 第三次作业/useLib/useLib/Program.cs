using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testLib;
using System.Runtime.InteropServices;

namespace useLib
{
    class Program
    {
        [DllImport("C:\\Users\\Administrator\\Documents\\Visual Studio 2015\\Projects\\CppClassDll\\Debug\\CppClassDll.dll",
            CharSet=CharSet.Unicode, CallingConvention=CallingConvention.Cdecl)]
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

        static void Main(string[] args)
        {
            int first, second;
            Console.WriteLine("This is a test program of mylib.ddl");

            //Console.WriteLine("Test SwapClass");
            //Console.WriteLine("Write the first integer:");
            //first = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Write the second integer:");
            //second = Convert.ToInt32(Console.ReadLine());
            //SwapClass.Swap(ref first, ref second);
            //Console.WriteLine("Now the first={0}, the second={1}", first, second);

            //Console.WriteLine("\nTest MaxCDClass");
            //Console.WriteLine("Write the first integer:");
            //first = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Write the second integer:");
            //second = Convert.ToInt32(Console.ReadLine());
            //int result = MaxCDClass.MaxCD(first, second);
            //Console.WriteLine("Now the greatest common divisor={0}", result);


            Console.WriteLine("\nAnother program for test CppLibrary(C++)");
            Console.WriteLine("Write the first integer:");
            first = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write the second integer:");
            second = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Now the sum result={0}", sumTwo(first, second));
            Console.WriteLine("Now the minus result={0}", minusTwo(first, second));
            Console.WriteLine("Now the multiply result={0}", multiplyTwo(first, second));
            Console.WriteLine("Now the divide result={0}", divideTwo(first, second));

            Console.ReadKey();
        }
    }
}
