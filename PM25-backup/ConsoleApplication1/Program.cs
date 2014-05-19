using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int i = 2000;
            //object o = i;
            //i = 2001;
            //int j = (int)o;
            //Console.WriteLine("i={0},o={1},j={2}", i, o, j);


            Console.WriteLine(MathFunc(7));


            Console.ReadKey();
        }

        private static int MathFunc(int num)
        {
            int result = 0;
            if (num <= 0)
            {
                return 0;
            }
            else if (num == 1)
            {
                return 1;
            }
            result = MathFunc(num - 1) + MathFunc(num - 2);
            return result;
        }
    }
}
