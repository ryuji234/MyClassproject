using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    internal class TEXTRPGMain
    {
        public static class Global
        {
            public static int Chance = 40;
            public static int BigChance = 20;
            public static int Event = 0;
        }
        static void battle(ref int HP, ref int SP, ref int[] Status) // 전투 (아직 미구현)
        {

        }



        static void num1(ref int HP, ref int SP, ref int[] Status) //바위 굴러오는 이벤트(일반 이벤트)
        {

            string choose;
            int Acheck, Acheck1, Bcheck;

            Random rand = new Random();
            Acheck = Global.Chance + 7 * (Status[0] - 5);
            Acheck1 = Global.BigChance + 5 * (Status[0] - 5);
            Bcheck = Global.Chance + 7 * (Status[1] - 5);
            Console.WriteLine("\n\t당신 머리위로 바위가 떨어지고 있습니다.\n\t뭔가 하지 않으면 죽을수도 있습니다.");
            Console.WriteLine("\n\tA.주먹으로 바위를 친다{힘 필요}(성공확률:{" + Acheck.ToString() + "}%)\n\tB.피한다{민첩 필요}(성공확률:{" + Bcheck.ToString() + "}%)\n\tC.지켜본다.");

            choose = Console.ReadLine();

            switch (choose)
            {
                case "A":

                    if (Acheck > rand.Next(1, 101))
                    {
                        if (Acheck1 > rand.Next(1, 101))
                        {
                            Console.WriteLine("\t대성공!!!\n\t당신은 아무런 피해없이 바위를 파괴했습니다.");
                        }
                        else
                        {
                            Console.WriteLine("\t성공!\n\t당신은 바위를 파괴하는데 성공했습니다. 하지만 피해가 없지는 않군요\n\t(힘이 1 감소합니다.)");
                            --Status[0];
                        }

                    }
                    else
                    {
                        Console.WriteLine("\t아... 바위를 부수기에는 힘이 부족했습니다.\n\t(체력이 1 감소합니다.)");
                        --HP;
                    }
                    break;
                case "B":
                    if (Bcheck > rand.Next(1, 101))
                    {
                        Console.WriteLine("당신은 신속하게 바위를 피하는데 성공했습니다.");
                    }
                    else
                    {
                        Console.WriteLine("\t아... 바위를 피하기에는 너무 느렸습니다.\n\t(체력이 1 감소합니다.)");
                        --HP;
                    }
                    break;
                case "C":
                    Console.WriteLine("\t당신은 그냥 바위를 맞았습니다.\n\t(체력이 1 감소합니다.)");
                    --HP;
                    break;
                default:
                    Console.WriteLine("\t잘못된 선택으로 바위를 맞았습니다.\n\t(체력이 1 감소합니다.)");
                    --HP;
                    break;
            }

        }
        static void num2(ref int HP, ref int SP, ref int[] Status) // 요정의 샘
        {
            string choose;
            Console.WriteLine("\n\t당신은 요정의 샘을 발견했습니다.\n\t어떻게 하시겠습니까.");
            Console.WriteLine("\tA.샘물을 마셔본다.\n\tB.샘물로 몸을 씻는다.\n\tC.샘물을 챙긴다.");
            choose = Console.ReadLine();
            switch (choose)
            {
                case "A":
                    Console.WriteLine("\t요정의 샘물을 마신 당신의 지능이 올라갑니다.");
                    ++Status[2];
                    break;

                case "B":
                    Console.WriteLine("\t요정의 샘물로 몸을 씻으니 상처가 회복됩니다.");
                    if (HP != 2 + Status[4] / 3)
                    {
                        ++HP;
                    }
                    break;
                case "C":
                    Console.WriteLine("\t당신은 요정의 샘물을 얻었습니다.");
                    Global.Event = 3;
                    break;
                default:
                    Console.WriteLine("\t당신은 그냥 샘물을 지나쳐 갑니다.");
                    break;
            }

        }
        static void num3(ref int HP, ref int SP, ref int[] Status) // 산불과 조우(물이 있으면 쉽게 해결 가능)
        {

        }
        static void num4(ref int HP, ref int SP, ref int[] Status) // 눈먼 노인
        {

        }
        static void num5(ref int HP, ref int SP, ref int[] Status) // 용의 출현 (성검 발견 이벤트 봤으면 쉽게 클리어)
        {

        }
        static void num6(ref int HP, ref int SP, ref int[] Status) // 산적 조우
        {

        }
        static void num7(ref int HP, ref int SP, ref int[] Status) // 성검 발견(한정 이벤트(한번 보면 더이상 발생 안함))
        {

        }
        static void num8(ref int HP, ref int SP, ref int[] Status) // 약 장수와 만남
        {

        }
        static void num9(ref int HP, ref int SP, ref int[] Status) // 쉼터
        {

        }
        static void num10(ref int HP, ref int SP, ref int[] Status) // 
        {

        }

        static void Main(string[] args)
        {

            int[] StatusArray = { 7, 10, 7, 8, 8, 10 };
            string[] StatusArrayName = { "힘", "민첩", "지능", "카리스마", "건강", "지혜" };

            int UserHP = 2 + StatusArray[4] / 3;

            int UserSP = 2 + StatusArray[5] / 3;
            string start;
            int stage, count = 1;
            Random rand = new Random();
            Console.WriteLine("====== 모험가 이야기=====\n");
            Console.WriteLine("       \"A\" 입력  ");
            start = Console.ReadLine();
            if (start != "A")
            {
                Console.WriteLine("당신은 모험 시작부터 발을 헛디뎌 죽었습니다");
                Environment.Exit(0);
            }
            while (true)
            {

                stage = rand.Next(1, 101);
                Console.WriteLine("\n======================================================================================");
                Console.WriteLine("\n{0}일차", count);
                switch (stage % 2)
                {
                    case 0:
                        num1(ref UserHP, ref UserSP, ref StatusArray);
                        break;
                    case 1:
                        num2(ref UserHP, ref UserSP, ref StatusArray);
                        break;
                    case 2:
                        num3(ref UserHP, ref UserSP, ref StatusArray);
                        break;
                    case 3:
                        num4(ref UserHP, ref UserSP, ref StatusArray);
                        break;
                    case 4:
                        num5(ref UserHP, ref UserSP, ref StatusArray);
                        break;
                    case 5:
                        num6(ref UserHP, ref UserSP, ref StatusArray);
                        break;
                    case 6:
                        num7(ref UserHP, ref UserSP, ref StatusArray);
                        break;
                    case 7:
                        num3(ref UserHP, ref UserSP, ref StatusArray);
                        break;
                    case 8:
                        num9(ref UserHP, ref UserSP, ref StatusArray);
                        break;
                    case 9:
                        num10(ref UserHP, ref UserSP, ref StatusArray);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("\n======================================================================================");

                Console.WriteLine("체력/최대체력: {0}/{1}", UserHP, 2 + StatusArray[4] / 3);
                Console.WriteLine("정신력/최대정신력: {0}/{1}", UserSP, 2 + StatusArray[5] / 3);
                for (int i = 0; i < 6; i++)
                {
                    Console.Write("{" + StatusArrayName[i] + ":" + StatusArray[i].ToString() + "}\n");
                }

                if (UserHP <= 0)
                {
                    Console.WriteLine("\t당신은 죽었습니다.");
                    Environment.Exit(0);
                }
                ++count;
                if (count > 10)
                {
                    Console.WriteLine("\t당신은 10일동안 모험을 하면서 많은 경험을 했고 이제는 어떠한 위험에도 살아남을수 있는 모험가가 되었습니다.   -끝-");
                    Environment.Exit(0);
                }
            }

        }
    }
}
