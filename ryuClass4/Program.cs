using System;

namespace ryuClass4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word1 = Console.ReadLine();
            string word2 = Console.ReadLine();

            bool check = word1 == word2;

            if(check)
            {
                Console.WriteLine("두 단어는 서로 같습니다.");
            }
            else
            {
                Console.WriteLine("두 단어는 서로 다릅니다.");
            }
        }
    }
}