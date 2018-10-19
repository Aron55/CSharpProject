using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5778_00_6274
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomMethod();
            Console.ReadKey();
        }

        private static void WelcomMethod()
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.WriteLine("{0}, Welcome to my first console application", name);
        }
    }
}
