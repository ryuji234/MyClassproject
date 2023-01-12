namespace TEXTRPG
{


    internal class TEXTRPGMain
    {
        public static int EventUnlock = 1;
        public static bool[] EventCheck = new bool[] { true, true, true, true };
        public static int previousstage = 3;
        public static int previousEvent = 0;

        public static int StageSelect()
        {
            int stage = 0;
            int Event = EVENT.count;
            bool overlap = true;
            Random rand = new Random();

            while (overlap)
            {
                int[] arr = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
                
                arr = arr.OrderBy(x => rand.Next()).ToArray();
                stage =  arr[0];
                if (previousstage != stage)
                {
                    overlap = false;

                }
            }
            return stage;
        }

        static void Main(string[] args)
        {



            int Num = 0;
            Player player = new Player();
            int stage;
            Random rand = new Random();
            Console.CursorVisible = false;
            Console.SetWindowSize(57, 40);

            Console.WriteLine(" =======================================================");
            Console.WriteLine("|                                                       |");
            Console.WriteLine("|                                                       |");
            Console.WriteLine("|\t  ====== 잠깐의 모험, 위험한 여행 =====\t\t|");
            Console.WriteLine("|                                                       |");
            Console.WriteLine("|\t\t      -Enter- 입력         \t\t|");
            Console.WriteLine("|                                                       |");
            Console.WriteLine("|                                                       |");
            Console.WriteLine(" =======================================================");
            ConsoleKeyInfo c;
            string Key = null;
            c = Console.ReadKey();
            Key = c.Key.ToString();

            while (Key != "Enter")
            {
                c = Console.ReadKey();
                Key = c.Key.ToString();
            }
            Key = null;


            while (Key != "Enter")
            {

                Console.Clear();
                Console.WriteLine("\n =======================================================");
                Console.WriteLine("|                                                       |");
                Console.WriteLine("|                                                       |");
                Console.WriteLine("|              당신의 모험가를 선택하시요               |");
                switch (Num)
                {
                    case 0:
                        Console.WriteLine("|           ▶1.전사    2.도적    3.마법사              |");
                        Console.WriteLine("|                        쉬움                           |");
                        break;
                    case 1:
                        Console.WriteLine("|             1.전사  ▶2.도적    3.마법사              |");
                        Console.WriteLine("|                        중간                           |");
                        break;
                    case 2:
                        Console.WriteLine("|             1.전사    2.도적  ▶3.마법사              |");
                        Console.WriteLine("|                        어려움                         |");
                        break;
                }
                
                Console.WriteLine("|                                                       |");
                Console.WriteLine(" =======================================================");

                c = Console.ReadKey();
                Key = c.Key.ToString();
                switch (c.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (Num < 2) Num++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Num > 0) Num--;
                        break;
                    default:
                        break;
                }
            }
            switch (Num)
            {
                case 0:
                    player = new Warrior();
                    break;
                case 1:
                    player = new Thief();
                    break;
                case 2:
                    player = new Wizard();
                    break;
            }
            int[] StatusArray = { player.STR, player.DEX, player.INT };
            Console.Clear();
            EVENT Event = new EVENT();

            while (true)
            {
            First:
                stage = StageSelect();
                switch (stage)
                {
                    case 0:
                        Event.num1(player); // 바위 굴러오는 이벤트(일반 이벤트)

                        break;

                    case 1:
                        Event.num2(player); // 요정의 샘(아이템을 얻는 이벤트)

                        break;

                    case 2:
                        if (EventUnlock % 2 != 0)
                        {
                            EventUnlock = EventUnlock * Event.num3(player); // 작은불 이벤트(연계 이벤트 시작점,아이템 사용(요점의 샘물),특정 선택이후 연계 이벤트 실행 될때까지 안나옴)
                        }
                        else
                        {
                            goto First;
                        }
                        break;

                    case 3:                     // 거대한불 이벤트(작은불 연계 이벤트,아이템 사용(요점의 샘물)
                        if (EventUnlock % 2 == 0)
                        {
                            Event.num4(player); // 거대한불 이벤트(작은불 연계 이벤트,아이템 사용(요점의 샘물)


                            EventUnlock = EventUnlock / 2;
                        }
                        else
                        {
                            goto First;
                        }

                        break;

                    case 4:                                 // 길잃은 노인 이벤트(연계 이벤트 시작점,한번만 발동)
                        if (EventCheck[0])
                        {
                            EventUnlock = Event.num5(player); // 길잃은 노인 이벤트(연계 이벤트 시작점,한번만 발동)


                            EventCheck[0] = false;
                        }
                        else
                        {
                            goto First;
                        }

                        break;

                    case 5:                                     // 효자 산적과 조우(길잃은 노인 연계 이벤트,아이템 사용(미끄러운 점액),한번만 발동)
                        if (EVENT.count % 4 == 0)
                        {
                            if (EventCheck[1])
                            {
                                Event.num6(player, ref EventUnlock); // 효자 산적과 조우(길잃은 노인 연계 이벤트,아이템 사용(미끄러운 점액),한번만 발동)

                                EventCheck[1] = false;
                            }
                            else
                            {
                                goto First;
                            }
                        }
                        else
                        {
                            goto First;
                        }

                        break;

                    case 6:                                 // 산적과 조우(아이템 사용(미끄러운 점액))
                        
                        if (EVENT.count % 4 == 0)
                        {
                            if (EventUnlock % 3 == 0)
                            {
                                int eventunlock = EventUnlock / 3;
                                Event.num6(player, ref eventunlock);

                            }
                            else if (EventUnlock % 3 != 0)
                            {
                                Event.num6(player, ref EventUnlock);

                            }
                        }
                        else
                        {
                            goto First;
                        }
                        break;

                    case 7:                             //숲속 생명체
                        Event.num7(player);
                        break;

                    case 8:                             // 고블린과의 거래
                        
                        Event.num8(player);
                        break;

                    case 9:
                        if (EVENT.count > 10)
                        {
                            if (EventCheck[2])
                            {
                                Event.num9(player);
                                EventCheck[2] = false;
                            }
                        }
                        else
                        {
                            goto First;
                        }


                        break;

                    case 10:
                        if(EVENT.count % 1 == 0)
                        {
                            if (EventUnlock % 5 != 0)
                            {
                                EventUnlock = Event.num10(player);
                            }
                            else
                            {
                                goto First;
                            }
                        }                   
                        else
                        {
                            goto First;
                        }
                        
                        break;
                    case 11:
                        Event.num11(player);
                        break;
                    case 12:
                        Event.num12(player);
                        break;
                    case 13:
                        if (EVENT.count > 10)
                        {
                            if (EventCheck[3])
                            {
                                Event.num13(player);
                                EventCheck[3] = false;
                            }
                            else
                            {
                                goto First;
                            }
                        }
                        else
                        {
                            goto First;
                        }
                        break;
                    default:
                        break;
                }
                ++EVENT.count;
                previousstage = stage;
                if (player.HP <= 0)
                {
                    Console.Clear();
                    
                    Console.WriteLine(" =======================================================");
                    Console.WriteLine("|                                                       |");
                    Console.WriteLine("|                        ╋                              |");
                    Console.WriteLine("|                        ┃                              |");
                    Console.WriteLine("|                     〓〓〓〓                          |");
                    Console.WriteLine("|\t\t  당신은 죽었습니다.\t\t\t|");
                    Console.WriteLine("|                                                       |");
                    Console.WriteLine("|                                                       |");
                    Console.WriteLine(" =======================================================");
                    Environment.Exit(0);
                }

                if (EVENT.count > 20)
                {
                    Console.Clear();
                    Console.WriteLine(" =======================================================");
                    Console.WriteLine("|                                                       |");
                    Console.WriteLine("|  당신은 긴 여정 동안 모험속에서 살아남았습니다.\t|\n" +
                                      "|  하지만 모험의 위험성을 깨닭은 당신은 지금 까지의\t|\n" +
                                      "|  모험을 그만두고 집으로 돌아가기로 합니다.\t\t|   ");
                    Console.WriteLine("|                                            Happy End  |");
                    Console.WriteLine(" =======================================================");
                    Environment.Exit(0);
                }

                Console.Clear();
            }

        }
    }
}
