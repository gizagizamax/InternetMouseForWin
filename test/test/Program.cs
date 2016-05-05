using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = Encoding.Unicode.GetBytes("abc");
            for (int i = 0; i < bytes.Length; i++)
                Console.Write("{0:X2} ", bytes[i]);
            Console.ReadKey();
        }
    }
}
