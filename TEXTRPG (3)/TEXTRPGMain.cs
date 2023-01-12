namespace TEXTRPG
{


    internal class TEXTRPGMain
    {
        public static int EventUnlock = 1;
        public static bool[] EventCheck = new bool[2] { true, true };
        public static int previousstage = 3;
        public static int previousEvent = 0;
        
        public static int StageSelect(bool check)
        {
            int stage=0;
            int Event = EVENT.count;
            bool overlap = true;
            Random rand = new Random();

            while(overlap)
            {

                stage = rand.Next(0, 7);
                Console.WriteLine(stage);
                Console.WriteLine(previousstage);
                ConsoleKeyInfo c = Console.ReadKey();
                if (previousstage != stage)
                {
                    overlap = false;
                    if(check)
                    {
                        previousstage = stage;
                    }
                    
                }
            }
            return stage;
        }

        static void Main(string[] args)
        {


            string[] StatusArrayName = { "힘", "민첩", "지혜" };
            int Num = 0;
            Player player = new Player();
            int stage;
            bool playevent = true;
            bool playCheck =false;
            Random rand = new Random();
            Console.CursorVisible = false;
            Console.WriteLine("\n\n\t====== 모험가 이야기 =====\n");
            Console.WriteLine("\t       -Enter- 입력  ");

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
                Console.WriteLine("\n ==================================================");
                Console.WriteLine("|                                                  |");
                Console.WriteLine("|                                                  |");
                Console.WriteLine("|        당신의 모험가를 선택하시요                |");
                switch (Num)
                {
                    case 0:
                        Console.WriteLine("|       ▶1.전사    2.도적    3.마법사             |");
                        break;
                    case 1:
                        Console.WriteLine("|         1.전사  ▶2.도적    3.마법사             |");
                        break;
                    case 2:
                        Console.WriteLine("|         1.전사    2.도적  ▶3.마법사             |");
                        break;
                }
                Console.WriteLine("|                                                  |");
                Console.WriteLine("|                                                  |");
                Console.WriteLine(" ==================================================\n");

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
            stage = rand.Next(0,7);
            while (true)
            {

                switch (stage)
                {
                    case 0:
                        Event.num1(player); // 바위 굴러오는 이벤트(일반 이벤트)
                        ++EVENT.count;
                        playCheck = true;
                        break;
                    case 1:
                        Event.num2(player); // 요정의 샘(아이템을 얻는 이벤트)
                        ++EVENT.count;
                        playCheck = true;
                        break;
                    case 2:
                        EventUnlock = EventUnlock * Event.num3(player); // 작은불 이벤트(연계 이벤트 시작점,아이템 사용(요점의 샘물))
                        ++EVENT.count;
                        playCheck = true;
                        break;
                    case 3:                     // 거대한불 이벤트(작은불 연계 이벤트,아이템 사용(요점의 샘물)
                        if (EventUnlock % 2 == 0)
                        {
                            Event.num4(player); // 거대한불 이벤트(작은불 연계 이벤트,아이템 사용(요점의 샘물)
                            ++EVENT.count;
                            playCheck = true;
                            EventUnlock = EventUnlock / 2;
                        }
                        else
                        {
                            playCheck = false;
                        }

                        break;
                    case 4:                                 // 길잃은 노인 이벤트(연계 이벤트 시작점,한번만 발동)
                        if (EventCheck[0])
                        {
                            EventUnlock = Event.num5(player); // 길잃은 노인 이벤트(연계 이벤트 시작점,한번만 발동)
                            ++EVENT.count;
                            playCheck = true;
                            EventCheck[0] = false;
                        }
                        else
                        {
                            playCheck = false;
                        }
                        break;
                    case 5:                                     // 효자 산적과 조우(길잃은 노인 연계 이벤트,아이템 사용(미끄러운 점액),한번만 발동)
                        if (EVENT.count % 4 == 0)
                        {
                            if (EventCheck[1])
                            {
                                Event.num6(player, ref EventUnlock); // 효자 산적과 조우(길잃은 노인 연계 이벤트,아이템 사용(미끄러운 점액),한번만 발동)
                                ++EVENT.count;
                                playCheck = true;
                                EventCheck[1] = false;
                            }
                            else
                            {
                                playCheck = false;
                            }
                        }
                        else
                        {
                            playCheck = false;
                        }
                        break;
                    case 6:                                 // 산적과 조우(아이템 사용(미끄러운 점액))
                        if (EVENT.count % 4 == 0)
                        {
                            if (EventUnlock % 3 == 0)
                            {
                                int eventunlock = EventUnlock / 3;
                                Event.num6(player, ref eventunlock);
                                ++EVENT.count;
                                playCheck = true;
                            }
                            else if (EventUnlock % 3 != 0)
                            {
                                Event.num6(player, ref EventUnlock);
                                ++EVENT.count;
                                playCheck = true;
                            }
                        }
                        else
                        {
                            playCheck = false;
                        }
                        break;
                    case 7:
                        Event.num3(player);
                        break;
                    case 8:
                        Event.num9(player);
                        break;
                    case 9:
                        Event.num10(player);
                        break;
                    default:
                        break;
                }
                
                stage = StageSelect(playevent);
                if (playCheck)
                {
                    playevent = true;
                }
                else
                {
                    playevent = false;
                }
                playCheck = false;
                if (player.HP <= 0)
                {
                    Console.WriteLine("\t당신은 죽었습니다.");
                    Environment.Exit(0);
                }
                
                if (EVENT.count > 20)
                {
                    Console.WriteLine("\t당신은 20일동안 모험을하면서 여러가지 위험에서 살아남았습니다.\n하지만 모험이라는 것이 위험한 행위라는 것을 깨닭은 당신은\n지금 까지의 모험을 그만두고 집으로 돌아가기로 합니다.   -끝-");
                    Environment.Exit(0);
                }

                Console.Clear();
            }

        }
    }
}
