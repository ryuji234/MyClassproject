using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyuClass7
{
    internal class TrumpCard
    {
        private int[] trumpCardSet;
        private string[] trumpCardMark;
        

        public void SetupTrumpCards()
        {
            trumpCardSet = new int[52];
            for(int i=0; i<trumpCardSet.Length;i++)
            {
                trumpCardSet[i] = i + 1;
               
            }       // loop: 카드를 셋업하는 루프
            trumpCardMark = new string[4] { "♥", "♠","◆","♣"} ;
        }       // SetupTrumpCard()

        public void shufflecards()
        {
            shufflecards(200);
        }
        // !셔플 하고서 카드를 한 장 뽕아서 출력하는 함수
        public void ReRollCard()
        {
            shufflecards();
            
        }
        public void UserBetting()
        {
            int Yes = 0, No = -1;
            int check = No;
            int loop = No;
            int UserPoint = 10000;
            int betting = 0;
            while(loop == No)
            {
                ReRollCard();
                ComputerCardShow();
                while (check == No)
                {
                    Console.WriteLine("몇 포인트를 거시겠습니다. 현재 포인트: {0}", UserPoint);

                    betting = int.Parse(Console.ReadLine());
                    if (betting > UserPoint)
                    {
                        Console.WriteLine("다시 베팅하세요");
                        check = No;
                    }
                    else
                    {
                        check = Yes;
                    }
                }
                int user = UserCard();
                int[] Computer = ComputerCard();
                if (Computer[0] > Computer[1])
                {
                    int temp = Computer[0];
                    Computer[0] = Computer[1];
                    Computer[1] = temp;
                }
                if (Computer[0] < user && user < Computer[1])
                {
                    UserPoint = 2 * betting + UserPoint;
                    Console.WriteLine("이기셨습니다. 현재 포인트: {0}\n\n", UserPoint);
                }
                else
                {
                    UserPoint = UserPoint - betting;
                    Console.WriteLine("지셨습니다. 현재 포인트: {0}\n\n", UserPoint);

                }
                if (UserPoint <= 0||UserPoint >=100000)
                {
                    loop = Yes;
                    
                }
                else
                {
                    check = No;
                    continue;
                }
                
            }
            
        }

        public int[] ComputerCardShow()
        {
            int[] Twocard = { trumpCardSet[0], trumpCardSet[1] };

            Console.WriteLine("컴퓨터가 뽑은 카드:");
            for (int i=0; i<2;i++)
            {
                string cardmark = trumpCardMark[(Twocard[i] - 1) / 13];
                string cardNumber = Math.Ceiling(Twocard[i] % 13.1).ToString();
                
                switch (cardNumber)
                {
                    case "1":
                        cardNumber = "A";
                        break;
                    case "11":
                        cardNumber = "J";
                        break;
                    case "12":
                        cardNumber = "Q";
                        break;
                    case "13":
                        cardNumber = "K";
                        break;
                    default:
                        break;
                }       //switch
                Console.WriteLine(" ----");
                Console.WriteLine("|{0}{1} |", cardmark, cardNumber);
                Console.WriteLine("|    |");
                Console.WriteLine("| {0}{1}|", cardNumber, cardmark);
                Console.WriteLine(" ----");
                Console.WriteLine();
                Twocard[i] = (int)Math.Ceiling(Twocard[i] % 13.1);
            }
            return Twocard;
        }
        public int[] ComputerCard()
        {
            int[] Twocard = { trumpCardSet[0], trumpCardSet[1] };                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        

            
            for (int i = 0; i < 2; i++)
            {
                
                Twocard[i] = (int)Math.Ceiling(Twocard[i] % 13.1);
            }
            return Twocard;
        }
        public int UserCard()
        {

            int card = trumpCardSet[2];
            string cardmark = trumpCardMark[(card - 1) / 13];
            string cardNumber = Math.Ceiling(card % 13.1).ToString();

            switch (cardNumber)
            {
                case "1":
                    cardNumber = "A";
                    break;
                case "11":
                    cardNumber = "J";
                    break;
                case "12":
                    cardNumber = "Q";
                    break;
                case "13":
                    cardNumber = "K";
                    break;
                default:
                    break;
            }       //switch


            
            Console.WriteLine(" ----");
            Console.WriteLine("|{0}{1} |", cardmark, cardNumber);
            Console.WriteLine("|    |");
            Console.WriteLine("| {0}{1}|", cardNumber, cardmark);
            Console.WriteLine(" ----");

            return (int)Math.Ceiling(card % 13.1);
        }       // UserCard()

        //! 한장의 카드를 뽑아서 보여주는 함수
        public void RollCard()
        {

            int card = trumpCardSet[0];
            string cardmark = trumpCardMark[(card-1) / 13];
            string cardNumber = Math.Ceiling(card % 13.1).ToString();

            switch (cardNumber)
            {
                case "1":
                    cardNumber = "A";
                    break;
                case "11":
                    cardNumber = "J";
                    break;
                case "12":
                    cardNumber = "Q";
                    break;
                case "13":
                    cardNumber = "K";
                    break;
                default:
                    break;
            }       //switch


            Console.WriteLine("내가 뽑은 카드는 {0}{1} 입니다.", cardmark,cardNumber);
            Console.WriteLine(" ----");
            Console.WriteLine("|{0}{1} |", cardmark, cardNumber);
            Console.WriteLine("|    |");
            Console.WriteLine("| {0}{1}|", cardNumber, cardmark);
            Console.WriteLine(" ----");
        }       // RollCard()
        public void shufflecards(int howManyLoop)
        {
            for(int i=0; i<howManyLoop; i++)
            {
                trumpCardSet = shuffleonce(trumpCardSet);
            }
        }

        private void PrintcasrdSet()
        {
            foreach(int card in trumpCardSet)
            {
               
            }
        }       // PrintCardSet()

        public int[] shuffleonce(int[] intArray)
        {
            Random random = new Random();
            int sourIndex = random.Next(0, intArray.Length);
            int destIndex = random.Next(0, intArray.Length);

            int tempvariable = intArray[sourIndex];
            intArray[sourIndex] = intArray[destIndex];
            intArray[destIndex] = tempvariable;

            return intArray;
        }     //  shuffleonce()
        
    }       // Class TrumpCard()
}
