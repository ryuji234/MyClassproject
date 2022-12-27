using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyuClass6
{
    internal class Class2
    {
        public static void Main()
        {
            Hi();
            Multiplay(5, 4);
        }

        static void Hi() => Console.WriteLine("안녕하세요");

        static void Multiplay(int x, int y) => Console.WriteLine(x * y);
    }
}
