using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyuClass7
{
    internal class Class3
    {
        public static void Main()
        {
            Lotto.LottoNum();
        }

    }

    public class Lotto
    {
        enum Check
        {
            No = -1,Yes = 1
        }

        public static void LottoNum()
        {
            Random randomNum= new Random();
            int[] lottonum = new int[6];
            int x = 0;
            int k = 0;
            int IsOverLaped;
            

            while(x<6)
            {
                IsOverLaped = (int)Check.No;
                k = randomNum.Next(1,46);
                for(int i=0; i<x;i++)
                {
                    if (lottonum[i] == k)
                    {
                        IsOverLaped = (int)Check.Yes;
                        break;
                    }
                }
                if (IsOverLaped == (int)Check.No)
                {
                    lottonum[x] = k;
                    x++;
                }
            }
            Console.WriteLine("오늘의 로또번호");
            for(int i=0; i<6;i++)
            {
                Console.Write($"{lottonum[i]}  ");
            }
        }
    }

}
