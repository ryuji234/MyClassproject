using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyuClass7
{
    internal class Class4
    {
        

        public static void Main()
        {
            LottoCreator Lotto = new LottoCreator();
            Lotto.PrintLottoNumber(); 
        }

        
    }
    public class LottoCreator
    {
        int[] lottoNumber;
        public void PrintLottoNumber()
        {
            lottoNumber = new int[45];
            for (int index = 0; index < 45; index++)
            {
                lottoNumber[index] = index + 1;
            }
            for (int index = 0; index < 100; index++)
            {
                lottoNumber = shuffleonce(lottoNumber);
            }

            for (int index = 0; index < 6; index++)
            {
                Console.Write("{0} ", lottoNumber[index]);
            }
        }

        public int[] shuffleonce(int[] lottoNumber_)
        {
            Random random = new Random();
            int sourIndex = random.Next(0, lottoNumber_.Length);
            int destIndex = random.Next(0, lottoNumber_.Length);

            int tempvariable = lottoNumber_[sourIndex];
            lottoNumber_[sourIndex] = lottoNumber_[destIndex];
            lottoNumber_[destIndex] = tempvariable;

            return lottoNumber_;
        }
    }


}
