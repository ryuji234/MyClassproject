using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass10
{
    internal class Pokergame
    {
        
        private int[] trumpCardSet;      // 내가 사용할 카드 세트뭉치
        private string[] trumpCardMark;     // 트럼프 카드의 마크
        private string[] trumpCardType;

        public void SetupTrumpCards()
        {
            trumpCardSet = new int[52];
            for (int i = 0; i < trumpCardSet.Length; i++)
            {
                trumpCardSet[i] = i + 1;

            }       // loop: 카드를 셋업하는 루프
            trumpCardMark = new string[4] { "♥", "♠", "◆", "♣" };
            
        }       // SetupTrumpCard()

        public int[] shuffleonce(int[] intArray)  // 굉장히 무거운 함수
        {
            Random random = new Random();
            int sourIndex = random.Next(0, intArray.Length);
            int destIndex = random.Next(0, intArray.Length);

            int tempvariable = intArray[sourIndex];
            intArray[sourIndex] = intArray[destIndex];
            intArray[destIndex] = tempvariable;
            
            return intArray;
        }       // 카드 한번 섞기
        public void shufflecards(int howManyLoop)
        {
            for (int i = 0; i < howManyLoop; i++)
            {
                trumpCardSet = shuffleonce(trumpCardSet);
            }
        }       // 카드 횟수만큼 섞기

        public void shufflecard()
        {
            shufflecards(100);
        }       // 카드 100번 섞기


        public List<int> ComputerCardSet()
        {
            List<int> ComputerCard = new List<int>();

            for(int i =0;i<5;i++)
            {
                ComputerCard.Add(trumpCardSet[i]);
            }
            
            //ComputerCard.Sort();

            //int count = 0;
            //int[] CardArray= new int[5];
            //foreach(int card in ComputerCard)
            //{
            //    CardArray[count++] = card;                
            //}            
            return ComputerCard;
        }       // 컴퓨터 카드 세팅


        public void ComputerCardshow(List<int> computercard)
        {
            int[] array = new int[5];
            int count =0;
            foreach(int i in computercard)
            {
                array[count++] = i;
            }
            Console.WriteLine("컴퓨터의의 카드:");
            //for(int i = 0; i < 5; i++)
            //{
            //    Console.Write("  〓〓〓〓〓  ");
            //}
            //Console.WriteLine();
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(" |          | ");
            //}
            //Console.WriteLine();
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(" |          | ");
            //}
            //Console.WriteLine();
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(" |          | ");
            //}
            //Console.WriteLine();
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(" |          | ");
            //}
            //Console.WriteLine();
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(" |          | ");
            //}
            //Console.WriteLine();
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write("  〓〓〓〓〓  ");
            //}
            Console.WriteLine();
            for (int k = 0; k < array.Length; k++)
            {
                Console.Write(" -------  ");
            }
            Console.WriteLine();
            for (int j = 0; j < 5; j++)
            {
                switch ((int)(Math.Round(array[j] % 13.1)))
                {
                    case 1:
                        Console.Write("| A");
                        break;
                    case 10:
                        Console.Write("|10");
                        break;
                    case 11:
                        Console.Write("| J");
                        break;
                    case 12:
                        Console.Write("| Q");
                        break;
                    case 13:
                        Console.Write("| K");
                        break;
                    default:
                        Console.Write("|{0} ", (int)(Math.Round(array[j] % 13.1)));
                        break;
                }

                Console.Write("{0}   | ", trumpCardMark[(array[j] - 1) / 13]);
            }
            Console.WriteLine();
            for (int k = 0; k < array.Length; k++)
            {
                Console.Write("|       | ");
            }
            Console.WriteLine();
            for (int k = 0; k < array.Length; k++)
            {
                Console.Write("|       | ");
            }
            Console.WriteLine();
            for (int j = 0; j < 5; j++)
            {
                Console.Write("|   {0}", trumpCardMark[(array[j] - 1) / 13]);
                switch ((int)(Math.Round(array[j] % 13.1)))
                {
                    case 1:
                        Console.Write("A | ");
                        break;
                    case 10:
                        Console.Write("10| ");
                        break;
                    case 11:
                        Console.Write("J | ");
                        break;
                    case 12:
                        Console.Write("Q | ");
                        break;
                    case 13:
                        Console.Write("K | ");
                        break;
                    default:
                        Console.Write("{0} | ", (int)(Math.Round(array[j] % 13.1)));
                        break;
                }
            }
            Console.WriteLine();
            for (int k = 0; k < array.Length; k++)
            {
                Console.Write(" -------  ");
            }
            Console.WriteLine();           // 카드 모양 만들기 
        }
        public int[] ComputerCardplus()
        {
            List<int> ComputerCard = ComputerCardSet();
            for(int i =10;i<12;i++)
            {
                ComputerCard.Add(trumpCardSet[i]);
            }
            ComputerCard.Sort();

            int count = 0;
            int[] ComputerCardArray = new int[7];
            foreach (int card in ComputerCard)
            {
                ComputerCardArray[count++] = card;
            }
            return ComputerCardArray;

        }       // 컴퓨터 카드에 2장 추가
        public int[] UserCardSet()
        {
            List<int> UserCard= new List<int>();

            for(int i =5;i<10;i++)
            {
                UserCard.Add(trumpCardSet[i]);
            }
            UserCard.Sort();
            int count = 0;
            int[] CardArray= new int[5];
            foreach(int card in UserCard)
            {
                CardArray[count++] = card;
            }
            return CardArray;
        }       // 유저 카드 세팅

        public void UserShow(int[] inputcards)
        {
            int[] array = inputcards;
            Console.WriteLine("\n유저의 카드:\n");
            for (int k = 0; k < array.Length; k++)
            {
                Console.Write(" -------  ");
            }
            Console.WriteLine();
            for (int j = 0; j < 5; j++)
            {
                switch ((int)(Math.Round(array[j] % 13.1)))
                {
                    case 1:
                        Console.Write("| A");
                        break;
                    case 10:
                        Console.Write("|10");
                        break;
                    case 11:
                        Console.Write("| J");
                        break;
                    case 12:
                        Console.Write("| Q");
                        break;
                    case 13:
                        Console.Write("| K");
                        break;
                    default:
                        Console.Write("| {0}", (int)(Math.Round(array[j] % 13.1)));
                        break;
                }

                Console.Write("{0}   | ", trumpCardMark[(array[j] - 1) / 13]);
            }
            Console.WriteLine();
            for (int k = 0; k < array.Length; k++)
            {
                Console.Write("|       | ");
            }
            Console.WriteLine();
            for (int k = 0; k < array.Length; k++)
            {
                Console.Write("|       | ");
            }
            Console.WriteLine();
            for (int j = 0; j < 5; j++)
            {
                Console.Write("|   {0}", trumpCardMark[(array[j] - 1) / 13]);
                switch ((int)(Math.Round(array[j] % 13.1)))
                {
                    case 1:
                        Console.Write("A | ");
                        break;
                    case 10:
                        Console.Write("10| ");
                        break;
                    case 11:
                        Console.Write("J | ");
                        break;
                    case 12:
                        Console.Write("Q | ");
                        break;
                    case 13:
                        Console.Write("K | ");
                        break;
                    default:
                        Console.Write("{0} | ", (int)(Math.Round(array[j] % 13.1)));
                        break;
                }
            }
            Console.WriteLine();
            for (int k = 0; k < array.Length; k++)
            {
                Console.Write(" -------  ");
            }
            Console.WriteLine();           // 카드 모양 만들기 
        }
        public int[] UserChange(int[] inputcards,int i)
        {
            int[] array = inputcards;
            bool enter = true;
            string number = null;
            Console.WriteLine("\n카드를 바꾸시겠습니까?(1,2,3,4,5중 선택(없으면 0))");
           
                while (enter)
                {
                    number = Console.ReadLine();
                    switch (number)
                    {
                        case "1":
                            array[0] = trumpCardSet[12 + i];
                            enter = false;
                            break;
                        case "2":
                            array[1] = trumpCardSet[12 + i];
                            enter = false;
                            break;
                        case "3":
                            array[2] = trumpCardSet[12 + i];
                            enter = false;
                            break;
                        case "4":
                            array[3] = trumpCardSet[12 + i];
                            enter = false;
                            break;
                        case "5":
                            array[4] = trumpCardSet[12 + i];
                            enter = false;
                            break;
                        case "0":
                            enter = false;
                            break;
                        default: 
                            break;
                    }
                number = null;
                }
                Console.WriteLine("유저의 카드:");
            for(int k = 0; k < array.Length; k++)
            {
                Console.Write(" -------  ");
            }
            Console.WriteLine();
            for (int j = 0; j < 5; j++)
            {
                switch ((int)(Math.Round(array[j] % 13.1)))
                {
                    case 1:
                        Console.Write("| A");
                        break;
                    case 10:
                        Console.Write("|10");
                        break;
                    case 11:
                        Console.Write("| J");
                        break;
                    case 12:
                        Console.Write("| Q");
                        break;
                    case 13:
                        Console.Write("| K");
                        break;
                    default:
                        Console.Write("|{0} ", (int)(Math.Round(array[j] % 13.1)));
                        break;
                }

                Console.Write("{0}   | ", trumpCardMark[(array[j] - 1) / 13]);
            }
            Console.WriteLine();
            for (int k = 0; k < array.Length; k++)
            {
                Console.Write("|       | ");
            }
            Console.WriteLine();
            for (int k = 0; k < array.Length; k++)
            {
                Console.Write("|       | ");
            }
            Console.WriteLine();
            for (int j = 0; j < 5; j++)
            {
                Console.Write("|   {0}", trumpCardMark[(array[j] - 1) / 13]);
                switch ((int)(Math.Round(array[j] % 13.1)))
                {
                    case 1:
                        Console.Write("A | ");
                        break;
                    case 10:
                        Console.Write("10| ");
                        break;
                    case 11:
                        Console.Write("J | ");
                        break;
                    case 12:
                        Console.Write("Q | ");
                        break;
                    case 13:
                        Console.Write("K | ");
                        break;
                    default:
                        Console.Write("{0} | ", (int)(Math.Round(array[j] % 13.1)));
                        break;
                }    
            }
            Console.WriteLine();
            for (int k = 0; k < array.Length; k++)
            {
                Console.Write(" -------  ");
            }
            Console.WriteLine();           // 카드 모양 만들기 
                                    
            // 카드 바꾸기


            return array;
        }
        public int UserCardRoll(int[] inputcards)
        {
            int[] cardnumbers = new int[5];
            string[] cardmarks = new string[5];
            int Numcount = 0;            
            for (int i = 0; i < 5;i++)
            {
                cardnumbers[i] = (int)Math.Round((double)inputcards[i] % 13.1);
                cardmarks[i] = trumpCardMark[(inputcards[i] - 1) / 13];
            }
            List<int> numbers = new List<int>();
            List<string> marks =new List<string>();
            for(int i = 0; i < 5; i++)
            {
                numbers.Add(cardnumbers[i]);
                marks.Add(cardmarks[i]);
            }
            numbers.Sort();
            marks.Sort();
            int a = 0; int b=0;
            foreach(int num in numbers)
            {
                cardnumbers[a++] = num;
            }
            foreach(string ch in marks)
            {
                cardmarks[b++] = ch;
            }
            
            
            
            for (int i= 0;i<4;i++)
            {
                if (cardnumbers[i] == cardnumbers[i+1]) // 같은 숫자
                {
                    Numcount++;         // Numcount가 1이면 원페어, 2면 투페어
                    ++i;
                }                            
            }
            for (int i = 0; i < 3; i++)
            {
                if (cardnumbers[i] == cardnumbers[i+1]&&
                    cardnumbers[i+1]  == cardnumbers[i+2])
                {
                    if(Numcount <=2)
                    {
                        Numcount = 3;
                    }
                    else { Numcount += 3; }
                }
            }

            if (cardnumbers[0] + 1 == cardnumbers[1] &&
                cardnumbers[1] + 1 == cardnumbers[2] &&
                cardnumbers[2] + 1 == cardnumbers[3] &&
                cardnumbers[3] + 1 == cardnumbers[4] )
            {
                
                Numcount = 4;   
            }
            if (cardmarks[0] == cardmarks[1] &&
                cardmarks[0] == cardmarks[2] &&
                cardmarks[0] == cardmarks[3] &&
                cardmarks[0] == cardmarks[4] )
            {
                
                Numcount = 5;
            }
            switch (Numcount)
            {
                case 0:
                    Console.WriteLine("노페어");
                    break;
                case 1:
                    Console.WriteLine("원페어");
                    break;
                case 2:
                    Console.WriteLine("투페어");
                    break;
                case 3:
                    Console.WriteLine("트리플");
                    break;
                case 4:
                    Console.WriteLine("스트레이트");
                    break;
                case 5:
                    Console.WriteLine("플러쉬");
                    break;
                case 6:
                    Console.WriteLine("포카드");
                    break;
                default:
                    break;
            }
            return Numcount;
        }       // 유저 패 맞추기

        public int ComputerRoll(int[] inputcards)
        {
            int[] cardnumber = new int[7];
            string[] cardmarks = new string[7];
            int Numcount = 0;
            for (int i = 0; i < 7; i++)
            {
                cardnumber[i] = (int)Math.Round((double)inputcards[i] % 13.1);
                cardmarks[i] = trumpCardMark[(inputcards[i] - 1) / 13];
            }
            Console.WriteLine("컴퓨터의 카드:");
            for (int k = 0; k < cardnumber.Length; k++)
            {
                Console.Write(" -------  ");
            }
            Console.WriteLine();
            for (int j = 0; j < 7; j++)
            {
                switch ((int)(Math.Round(cardnumber[j] % 13.1)))
                {
                    case 1:
                        Console.Write("| A");
                        break;
                    case 10:
                        Console.Write("|10");
                        break;
                    case 11:
                        Console.Write("| J");
                        break;
                    case 12:
                        Console.Write("| Q");
                        break;
                    case 13:
                        Console.Write("| K");
                        break;
                    default:
                        Console.Write("| {0}", (int)(Math.Round(cardnumber[j] % 13.1)));
                        break;
                }

                Console.Write("{0}   | ", cardmarks[j]);
            }
            Console.WriteLine();
            for (int k = 0; k < cardnumber.Length; k++)
            {
                Console.Write("|       | ");
            }
            Console.WriteLine();
            for (int k = 0; k < cardnumber.Length; k++)
            {
                Console.Write("|       | ");
            }
            Console.WriteLine();
            for (int j = 0; j < 7; j++)
            {
                Console.Write("|   {0}", cardmarks[j]);
                switch ((int)(Math.Round(cardnumber[j] % 13.1)))
                {
                    case 1:
                        Console.Write("A | ");
                        break;
                    case 10:
                        Console.Write("10| ");
                        break;
                    case 11:
                        Console.Write("J | ");
                        break;
                    case 12:
                        Console.Write("Q | ");
                        break;
                    case 13:
                        Console.Write("K | ");
                        break;
                    default:
                        Console.Write("{0} | ", (int)(Math.Round(cardnumber[j] % 13.1)));
                        break;
                }
            }
            Console.WriteLine();
            for (int k = 0; k < cardnumber.Length; k++)
            {
                Console.Write(" -------  ");
            }
            Console.WriteLine();           // 카드 모양 만들기 
            List<int> numbers = new List<int>();
            List<string> marks = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                numbers.Add(cardnumber[i]);
                marks.Add(cardmarks[i]);
            }
            numbers.Sort();
            marks.Sort();
            int a = 0; int b = 0;
            foreach (int num in numbers)
            {
                cardnumber[a++] = num;
            }
            foreach (string ch in marks)
            {
                cardmarks[b++] = ch;
            }
            for (int i = 0; i < 6; i++)
            {
                if (cardnumber[i] == cardnumber[i + 1]) // 같은 숫자
                {
                    if(Numcount >=2)
                    {

                    }
                    else
                    {
                        Numcount++;         // Numcount가 1이면 원페어, 2면 투페어
                        ++i;
                    }
                    
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (cardnumber[i] == cardnumber[i + 1] &&
                    cardnumber[i + 1] == cardnumber[i + 2])
                {
                    if (Numcount <= 2)
                    {
                        Numcount = 3;
                    }
                    else { Numcount += 3; }
                }
            }
            for(int i =0;i<3;i++)
            {
                if (cardnumber[0] + 1 == cardnumber[1] &&
                cardnumber[1] + 1 == cardnumber[2] &&
                cardnumber[2] + 1 == cardnumber[3] &&
                cardnumber[3] + 1 == cardnumber[4])
                {
                    Numcount = 4;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (cardmarks[0] == cardmarks[1] &&
                cardmarks[0] == cardmarks[2] &&
                cardmarks[0] == cardmarks[3] &&
                cardmarks[0] == cardmarks[4])
                {
                    Numcount = 5;
                }
            }
                
            switch (Numcount)
            {
                case 0:
                    Console.WriteLine("노페어");
                    break;
                case 1:
                    Console.WriteLine("원페어");
                    break;
                case 2:
                    Console.WriteLine("투페어");
                    break;
                case 3:
                    Console.WriteLine("트리플");
                    break;
                case 4:
                    Console.WriteLine("스트레이트");
                    break;
                case 5:
                    Console.WriteLine("플러쉬");
                    break;
                case 6:
                    Console.WriteLine("포카드");
                    break;
                default:
                    break;
            }
            return Numcount;
        }       // 컴퓨터 패 맞추기

        public void matching()
        {
            SetupTrumpCards();
            int playerPoint = 10000;
            while(playerPoint > 0 && playerPoint < 100000) 
            {
                shufflecard();
                ComputerCardshow(ComputerCardSet());
                UserShow(UserCardSet());
                Console.Write("\n\n몇 포인트를 배팅 하시겠습니까? ");
                Console.Write("(플레이어의 포인트: {0}): ", playerPoint);
                int userbatting = int.Parse(Console.ReadLine());
                int computer = ComputerRoll(ComputerCardplus());
                int user = 0;
                if (userbatting >= 0 &&userbatting <= playerPoint)
                {
                    
                    

                    user = UserCardRoll(UserChange(UserChange(UserCardSet(),1),2));


                    if (user == computer) 
                    { 
                        Console.WriteLine("비겼습니다.\n");
                        Console.WriteLine("플레이어의 포인트: {0}", playerPoint);
                    }
                    else if (user > computer) 
                    {
                        Console.WriteLine("이겼습니다.\n");
                        playerPoint += userbatting * 2;
                        Console.WriteLine("플레이어의 포인트: {0}", playerPoint);
                    }
                    else if (user < computer) 
                    { 
                        Console.WriteLine("졌습니다.\n");
                        playerPoint -= userbatting;
                        Console.WriteLine("플레이어의 포인트: {0}", playerPoint);
                    }
                    Task.Delay(5000).Wait();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("잘못 입력 하셨습니다.");
                }
                
                
            }
           
        }// 컴퓨터와 유저 패 비교하기 
    }
}
