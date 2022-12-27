using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyuClass6
{
    internal class Class4
    {
        public static void Main()
        {
            Console.WriteLine("문자를 입력하시오:");
            string Word = Console.ReadLine();
            char[] SwapWord = new char[Word.Length];
            int num = Word.Length - 1;
            foreach (char c in Word)
            {
                SwapWord[num] = c;
                num--;
            }
            Console.WriteLine("입력한 문자의 역순:");
            for (int i =0; i< SwapWord.Length; i++) 
            {
                Console.Write(SwapWord[i]);
            }
            

        }
    }
}
