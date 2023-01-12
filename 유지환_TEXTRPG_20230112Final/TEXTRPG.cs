namespace TEXTRPG
{

    public class EVENT
    {
        public static int Chance = 40;
        public static int BigChance = 20;
        public static int[] select = new int[3];
        public static int count = 1;
        public static string[] statusname = { "힘", "민첩", "지혜" };
        public static int EventUnlock = 1;

        public void num1(Player player) // 바위 굴러오는 이벤트(일반 이벤트)
        {


            int[] status = new int[] { player.STR, player.DEX, player.INT };
            int Acheck, Acheck1, Bcheck;
            Random rand = new Random();
            Acheck = Chance + 7 * (player.STR - 5);
            Bcheck = Chance + 7 * (player.DEX - 5);


            string[] EventSelect = new string[3] { "A.주먹으로 바위를 친다{힘 필요}\t\t\t|",
                                                   "B.피한다{민첩 필요}\t\t\t\t|",
                                                   "C.지켜본다.\t\t\t\t\t|"};
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            bool EventEnd = true;
            ConsoleKeyInfo c;
            string Key = null;
            while (EventEnd)
            {
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n =======================================================");
                Console.WriteLine("|\t\t\t\t\t\t\t|\n|\t당신 머리위로 바위가 떨어지고 있습니다.         |" +
                                "\n|\t뭔가 하지 않으면 피해를 입습니다.               |");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("|\t\t\t\t\t\t\t|\n|      ");
                            break;
                        case 1:
                            Console.Write("|\t\t\t\t\t\t\t|\n|   ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);
                }


                if (Key == "Enter")
                {
                    Console.WriteLine("|\t\t\t\t\t\t\t|\n =======================================================");
                    switch (Num)
                    {

                        case 0:
                            if (Acheck > rand.Next(1, 101))
                            {

                                Console.WriteLine("|   성공!\t\t\t\t\t\t|\n|   당신은 바위를 파괴하는데 성공했습니다.              |");

                            }
                            else
                            {
                                Console.WriteLine("|   실패... 바위를 부수기에는 힘이 부족했습니다.\t|\n|   (체력이 5 감소합니다.)\t\t\t\t|");
                                player.HP = player.HP - 5;
                            }
                            break;
                        case 1:
                            if (Bcheck > rand.Next(1, 101))
                            {
                                Console.WriteLine("|   성공!\t\t\t\t\t\t|\n|   당신은 신속하게 바위를 피하는데 성공했습니다.       |");
                            }
                            else
                            {
                                Console.WriteLine("|   실패... 바위를 피하기에는 너무 느렸습니다.\t\t|\n|   (체력이 5 감소합니다.)\t\t\t\t|");
                                player.HP = player.HP - 5;
                            }
                            break;
                        case 2:
                            Console.WriteLine("|   당신은 그냥 바위를 맞았습니다.\t\t\t|\n|   (체력이 5 감소합니다.)\t\t\t\t|");
                            player.HP = player.HP - 5;
                            break;
                    }
                    EventEnd = false;
                    Key = null;
                }

                ShowStatusAndInventory(player);

                c = Console.ReadKey();
                Key = c.Key.ToString();
                Console.Clear();
                if (Key != "Enter")
                {
                    switch (Key)
                    {
                        case "UpArrow":
                            if (Num != 0)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[--Num] = 1;
                            }
                            break;
                        case "DownArrow":
                            if (Num != 2)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[++Num] = 1;
                            }
                            break;
                    }

                }

            }

        }
        public void num2(Player player) // 요정의 샘(아이템을 얻는 이벤트)
        {

            int[] status = new int[] { player.STR, player.DEX, player.INT };
            string[] EventSelect = new string[3] { "A.샘물을 마셔본다.\t\t\t\t|",
                                                   "B.샘물로 몸을 씻는다.\t\t\t\t|",
                                                   "C.샘물을 챙긴다.\t\t\t\t\t|" };
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            bool EventEnd = true;
            bool Drop = true;
            ConsoleKeyInfo c;
            ConsoleKeyInfo Numc;
            string Key = null;
            string DropItem = null;
            while (EventEnd)        // 이벤트가 끝났는가
            {
            First:
                Console.Clear();
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n =======================================================");
                Console.WriteLine("|\t\t\t\t\t\t\t|\n|\t당신은 요정의 샘을 발견했습니다.\t\t|" +
                                "\n|\t어떻게 하시겠습니까.\t\t\t\t|");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("|\t\t\t\t\t\t\t|\n|      ");
                            break;
                        case 1:
                            Console.Write("|\t\t\t\t\t\t\t|\n|   ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);
                }



                if (Key == "Enter")
                {
                    Console.WriteLine("|\t\t\t\t\t\t\t|\n =======================================================");
                    switch (Num)
                    {
                        case 0:
                            Console.WriteLine("|\t요정의 샘물을 마신 당신의 지능이 올라갑니다.\t|");
                            ++status[2];
                            ++player.INT;
                            break;

                        case 1:
                            Console.WriteLine("|\t요정의 샘물로 몸을 씻으니 상처가 회복됩니다.\t|");
                            if (player.HP + 5 > player.MaxHP)
                            {
                                player.HP = player.HP + (player.MaxHP - player.HP);
                            }
                            else
                            {
                                player.HP = player.HP + 5;
                            }
                            break;

                        case 2:
                            if (player.Inventory.Count < 5)
                            {
                                if (Drop)
                                {
                                    Console.WriteLine("|\t당신은 요정의 샘물을 얻었습니다.\t\t|");
                                    player.Inventory.Add("요정의 샘물");
                                    //player.Inventory.Add(String.Format("요정의 샘물{0}", count));
                                    Drop = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("|\t인벤토리가 가득차서 무언가를 버려야 합니다.\t|");
                                Console.WriteLine("|\t어떤것을 버리겠습니까?(1,2,3,4,5,6 중에 선택)\t|");
                                if (Drop)
                                {
                                    player.Inventory.Add("요정의 샘물");
                                    //player.Inventory.Add(String.Format("요정의 샘물{0}", count));
                                }

                                if (Drop == false)
                                {
                                    if (DropItem != null)
                                    {
                                        Console.WriteLine("|\t인벤토리의 \'{0}\' 아이템을 버립니다.\t|", DropItem);
                                    }

                                }
                                Drop = false;
                            }



                            break;

                    }

                    EventEnd = false;

                }
                ShowStatusAndInventory(player);
                if (player.Inventory.Count < 6) { }

                else
                {
                    Numc = Console.ReadKey();
                    string number = Numc.Key.ToString();

                    switch (number)
                    {
                        case "D1":
                            DropItem = player.Inventory[0];
                            player.Inventory.RemoveAt(0);

                            break;
                        case "D2":
                            DropItem = player.Inventory[1];
                            player.Inventory.RemoveAt(1);

                            break;
                        case "D3":
                            DropItem = player.Inventory[2];
                            player.Inventory.RemoveAt(2);

                            break;
                        case "D4":
                            DropItem = player.Inventory[3];
                            player.Inventory.RemoveAt(3);

                            break;
                        case "D5":
                            DropItem = player.Inventory[4];
                            player.Inventory.RemoveAt(4);

                            break;
                        case "D6":
                            DropItem = player.Inventory[5];
                            player.Inventory.RemoveAt(5);

                            break;
                        default:
                            break;
                    }
                    goto First;
                }



                c = Console.ReadKey();
                Key = c.Key.ToString();

                if (Key != "Enter")
                {
                    switch (Key)
                    {
                        case "UpArrow":
                            if (Num != 0)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[--Num] = 1;
                            }
                            break;
                        case "DownArrow":
                            if (Num != 2)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[++Num] = 1;
                            }
                            break;
                    }
                    Key = null;
                }

            }           // 이벤트가 끝났는가

        }
        public int num3(Player player) // 작은불 이벤트(연계 이벤트 시작점,아이템 사용(요점의 샘물))
        {
            int[] status = new int[] { player.STR, player.DEX, player.INT };
            string[] EventSelect = new string[3] { "A.불을 끄기위해 노력한다.\t\t\t|",
                                                   "B.물을 부어 불을 끈다.(요정의 샘물 필요)\t\t|",
                                                   "C.불은 불일 뿐, 신경 쓰지 않고 지나간다.\t\t|" };
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            bool EventEnd = true;
            ConsoleKeyInfo c;
            string Key = null;
            while (EventEnd)
            {
                EventUnlock = 1;
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n =======================================================");
                Console.WriteLine("|\t당신은 산길을 가던중\t\t\t\t|" +
                                "\n|\t불이 피어오르는 것을 발견했습니다.\t\t|" +
                                "\n|\t어떻게 하시겠습니까?\t\t\t\t|");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("|\t\t\t\t\t\t\t|\n|      ");
                            break;
                        case 1:
                            Console.Write("|\t\t\t\t\t\t\t|\n|   ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);
                }


                if (Key == "Enter")
                {
                    Console.WriteLine("|\t\t\t\t\t\t\t|\n =======================================================");
                    switch (Num)
                    {
                        case 0:
                            player.HP = player.HP - 5;
                            if (player.HP <= 0)
                            {
                                Console.WriteLine("|\t당신은 불을 끌려고 하다가\t\t\t|\n" +
                                                  "|\t전신에 불이 붙고 타죽고 말았습니다.\t\t|\n" +
                                                  "|\t정말 허무한 죽음이네요..\t\t\t|");
                            }
                            else
                            {
                                Console.WriteLine("|\t당신은 불을 끄는데 성공 하였습니다.\t\t|\n" +
                                                  "|\t하지만 불을 끄는 과정에서\t\t\t|\n" +
                                                  "|\t조금의 화상을 입고 말았습니다.\t\t\t|");
                                Console.WriteLine("|\t(HP가 5 감소합니다.)\t\t\t\t|");
                            }
                            EventEnd = false;
                            break;
                        case 1:
                            if (player.Inventory.Contains("요정의 샘물") == true)
                            {
                                Console.WriteLine("|\t당신은 요정의 샘물을 사용하여\t\t\t|\n" +
                                                  "|\t불을 끄는데 성공 하였습니다.\t\t\t|");
                                player.Inventory.Remove("요정의 샘물");
                                EventEnd = false;
                            }
                            else
                            {
                                Console.WriteLine("|\t당신은 요정의 샘물을 가지고 있지 않습니다.\t|\n" +
                                                  "|\t다른 선택지를 고르세요\t\t\t\t|");
                            }
                            break;
                        case 2:
                            Console.WriteLine("|\t당신은 산에난 불을 보고도 그냥 지나쳐 갑니다.\t|\n" +
                                              "|\t그 선택이 어떠한 결과를 가져올지도 모른체...\t|");
                            EventUnlock = EventUnlock * 2;                          // 거대한 불 이벤트
                            EventEnd = false;
                            break;
                    }

                    Key = null;
                }
                ShowStatusAndInventory(player);




                c = Console.ReadKey();
                Key = c.Key.ToString();
                Console.Clear();
                if (Key != "Enter")
                {
                    switch (Key)
                    {
                        case "UpArrow":
                            if (Num != 0)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[--Num] = 1;
                            }
                            break;
                        case "DownArrow":
                            if (Num != 2)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[++Num] = 1;
                            }
                            break;
                    }

                }
            }
            return EventUnlock;

        }
        public void num4(Player player) // 거대한불 이벤트(작은불 연계 이벤트,아이템 사용(요점의 샘물)
        {
            int Acheck = Chance + 7 * (player.INT - 5);
            Random rand = new Random();
            int[] status = new int[] { player.STR, player.DEX, player.INT };
            string[] EventSelect = new string[3] { "A.어쩔수 없다. 빠르게 불길을 돌파한다.\t\t|",
                                                   "B.물을 부어 몸을 젹시고 빠르게 빠져나간다.\t|",
                                                   "C.불길 속에도 길이 있다.\t\t\t\t|\n" +
                                                   "|\t 정신을 집중하고 길을 찾는다.{지혜 필요}\t|" };
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            bool EventEnd = true;
            ConsoleKeyInfo c;
            string Key = null;
            while (EventEnd)
            {
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n =======================================================");
                Console.WriteLine("|당신은 지금 거대한 불길 속에 갇히고 말았습니다. 과거에 |\n" +
                                  "|끄지 않고 지나쳤던 불이 거대한 불이 되어 버렸습니다.\t|\n" +
                                  "|어떻게 하시겠습니까?\t\t\t\t\t|");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("|\t\t\t\t\t\t\t|\n|      ");
                            break;
                        case 1:
                            Console.Write("|\t\t\t\t\t\t\t|\n|   ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);
                }

                if (Key == "Enter")
                {
                    Console.WriteLine("|\t\t\t\t\t\t\t|\n =======================================================");
                    switch (Num)
                    {
                        case 0:
                            player.HP = player.HP - 15;
                            if (player.HP <= 0)
                            {
                                player.HP = 0;
                                Console.WriteLine("|  당신은 거대한 불길 속에서 살아남지 못했고\t\t|\n" +
                                                  "|  결국 거대한 불길에 삼켜져 버렸습니다.\t\t|");
                                Console.WriteLine("|  정말 허무한 죽음이군요..\t\t\t\t|");
                            }
                            else
                            {
                                Console.WriteLine("|  당신을 거대한 불길 속에서 살아남았습니다.\t\t|\n" +
                                                  "|  하지만 몸에 많은 화상을 남기는 것을\t\t\t|\n" +
                                                  "|  피할 수는 없었습니다.\t\t\t\t|");
                                Console.WriteLine("|  (HP가 15 감소합니다.)\t\t\t\t|");
                            }

                            EventEnd = false;
                            break;
                        case 1:
                            if (player.Inventory.Contains("요정의 샘물") == true)
                            {
                                player.HP = player.HP - 5;
                                if (player.HP <= 0)
                                {
                                    Console.WriteLine("|  당신은 요정의 샘물로 몸을 적셔 거대한 불길에서\t|\n" +
                                                      "|  빠져 나오기위해 노력했지만. 실패하고 말았습니다.\t|\n" +
                                                      "|  정말 허무한 죽음이네요..\t\t\t\t|");
                                }
                                else
                                {
                                    Console.WriteLine("|  당신은 요정의 샘물로 몸을 적셔 거대한 불길에서\t|\n" +
                                                      "|  빠져 나왔습니다. 그리고 약간의 화상을 입었습니다.\t|");
                                }

                                player.Inventory.Remove("요정의 샘물");
                                EventEnd = false;
                            }
                            else
                            {
                                Console.WriteLine("|  당신은 요정의 샘물을 가지고 있지 않습니다.\t\t|\n" +
                                                  "|  다른 선택지를 고르세요\t\t\t\t|");
                            }
                            break;
                        case 2:
                            if (Acheck > rand.Next(1, 101))
                            {
                                Console.WriteLine("|  성공!\t\t\t\t\t\t|\n" +
                                                  "|  당신은 명석한 머리로 불길에서 탈출로를 찾아냈고\t|\n" +
                                                  "|  피해 없이 불길에서 빠져 나왔습니다.\t\t\t|");
                            }
                            else
                            {
                                player.HP = player.HP - 15;
                                if (player.HP <= 0)
                                {
                                    Console.WriteLine("|  실패...\t\t\t\t\t\t|\n" +
                                                      "|  당신은 불길속에서 탈출로를 찾는데 실패하였고\t\t|\n" +
                                                      "|  결국 거대한 불길에 삼켜져 죽고 말았습니다.\t\t|");
                                    Console.WriteLine("|  정말 허무한 죽음이군요..\t\t\t\t|");
                                }
                                else
                                {
                                    Console.WriteLine("|  실패...\t\t\t\t\t\t|\n" +
                                                      "|  당신은 불길속에서 탈출로를 찾는데 실패하였고\t\t|\n" +
                                                      "|  몸에 많은 화상을 남기는 것을 피할 수는 없었습니다.\t|");
                                    Console.WriteLine("|  (HP가 15 감소합니다.)\t\t\t\t|");

                                }
                            }
                            EventEnd = false;
                            break;
                    }

                    Key = null;
                }
                ShowStatusAndInventory(player);

                c = Console.ReadKey();
                Key = c.Key.ToString();
                Console.Clear();
                if (Key != "Enter")
                {
                    switch (Key)
                    {
                        case "UpArrow":
                            if (Num != 0)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[--Num] = 1;
                            }
                            break;
                        case "DownArrow":
                            if (Num != 2)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[++Num] = 1;
                            }
                            break;
                    }

                }
            }
        }
        public int num5(Player player) // 길잃은 노인 이벤트(연계 이벤트 시작점,한번만 발동)
        {
            int[] status = new int[] { player.STR, player.DEX, player.INT };
            string[] EventSelect = new string[3] { "A.불쌍한 노인이다. 집까지 데려다준다.\t\t|",
                                                   "B.저 노인이 가지고 있는 물건이 탐이 난다.\t|\n" +
                                                   "|\t 물건을 빼앗자\t\t\t\t\t|",
                                                   "C.내 코가 석 자인데,\t\t\t\t|\n" +
                                                   "|\t 노인을 도울 여력이 어디 있는가, 그냥 지나친다.\t|"};
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            bool EventEnd = true;
            ConsoleKeyInfo c;
            string Key = null;
            EventUnlock = 1;
            while (EventEnd)
            {
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n =======================================================");
                Console.WriteLine("|   당신은 길 건너편에서 길을 해메고 있는 노인을\t|\n" +
                                  "|   발견했습니다. 노인의 손에는 몸에 좋다는 식물이\t|\n" +
                                  "|   들려있습니다. 어떻게 하시겠습니까?\t\t\t|");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("|\t\t\t\t\t\t\t|\n|      ");
                            break;
                        case 1:
                            Console.Write("|\t\t\t\t\t\t\t|\n|   ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);
                }

                if (Key == "Enter")
                {
                    Console.WriteLine("|\t\t\t\t\t\t\t|\n =======================================================");
                    switch (Num)
                    {
                        case 0:
                            Console.WriteLine("|  당신은 노인을 도와 노인이 집에 찾아갈 수 있게\t|\n" +
                                              "|  도와주었습니다. 노인은 이 은혜를 잊지 않을 것이라고\t|\n" +
                                              "|  말했습니다.\t\t\t\t\t\t|");
                            EventUnlock = EventUnlock * 3;
                            EventEnd = false;
                            break;
                        case 1:
                            Console.WriteLine("|  당신은 노인에게서 몸에 좋다는 식물을 빼았아\t\t|\n" +
                                              "|  먹어버리고, 달아났습니다.저 멀리서 노인이\t\t|\n" +
                                              "|  이 원한을 잊지 않을 것이라고 소리칩니다.\t\t|");
                            Console.WriteLine("|  (힘이 1 상승합니다.)\t\t\t\t\t|");
                            ++player.STR;
                            ++status[0];
                            EventUnlock = EventUnlock * 7;
                            EventEnd = false;
                            break;
                        case 2:
                            Console.WriteLine("|  당신은 노인을 지나치고 자신이 갈 길을 걷습니다.\t|");
                            EventEnd = false;
                            break;
                    }

                    Key = null;
                }
                ShowStatusAndInventory(player);

                c = Console.ReadKey();
                Key = c.Key.ToString();
                Console.Clear();
                if (Key != "Enter")
                {
                    switch (Key)
                    {
                        case "UpArrow":
                            if (Num != 0)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[--Num] = 1;
                            }
                            break;
                        case "DownArrow":
                            if (Num != 2)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[++Num] = 1;
                            }
                            break;
                    }

                }
            }
            return EventUnlock;

        }
        public void num6(Player player, ref int eventcheck) // 효자 산적과 조우(길잃은 노인 연계 이벤트,아이템 사용(미끄러운 점액),한번만 발동)
        {
            int[] status = new int[] { player.STR, player.DEX, player.INT };
            int Acheck, Bcheck;
            Random rand = new Random();
            Acheck = Chance + 7 * (player.STR - 5);
            Bcheck = Chance + 7 * (player.DEX - 5);
            string[] EventSelect = new string[3] { "A.산적을 위협하여 도망가게 한다.{힘 필요}\t|",
                                                   "B.산적에게서 빠르게 도망친다.{민첩 필요}\t\t|",
                                                   "C.미끄러운 점액을 던지고, 도망친다.\t\t|\n" +
                                                   "|\t {미끄러운 점액 필요}\t\t\t\t|" };
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            bool EventEnd = true;
            bool BattleStart = false;
            ConsoleKeyInfo c;
            string Key = null;
            Monster monster = new Monster();
            while (EventEnd)
            {
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n =======================================================");
                Console.WriteLine("|  당신은 길을 걷던중 갑작스럽게 산적과 조우하게\t|\n" +
                                  "|  되었습니다. 어떻게 하시겠습니까?\t\t\t|");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("|\t\t\t\t\t\t\t|\n|      ");
                            break;
                        case 1:
                            Console.Write("|\t\t\t\t\t\t\t|\n|   ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);
                }

                if (Key == "Enter")
                {
                    Console.WriteLine("|\t\t\t\t\t\t\t|\n =======================================================");
                    if (eventcheck % 3 == 0)
                    {
                        Console.WriteLine("|  산적은 당신을 해칠 생각이 없다는 제스처를 취합니다.\t|");
                        Console.WriteLine("|  산적은 과거 당신이 도와준 노인의 아들이였습니다.\t|\n" +
                                          "|  산적은 그 은혜에 보답하여 당신을 그냥 보내줍니다.\t|");
                        EventEnd = false;
                        eventcheck = eventcheck / 3;
                    }
                    else if (eventcheck % 7 == 0)
                    {
                        Console.WriteLine("|  산적은 당신을 강렬한 눈빛으로 노려봅니다.\t\t|");
                        Console.WriteLine("|  산적은 과거 당신이 물건을 훔친 노인의 아들이였습니다.|\n" +
                                          "|  산적은 그 원한을 갚기위해 지금껏 칼을 갈아왔습니다.\t|\n" +
                                          "|  - 전투 시작 -\t\t\t\t\t|");
                        monster = new Bandit();
                        monster.HP += 10;
                        monster.MaxHP += 10;
                        monster.STR++;
                        monster.DEX++;
                        BattleStart = true;
                    }
                    else
                    {
                        switch (Num)
                        {
                            case 0:
                                if (Acheck > rand.Next(1, 101))
                                {
                                    Console.WriteLine("|  성공!\t\t\t\t\t\t|\n" +
                                                      "|  산적은 당신의 위협에 겁을 먹고 도망쳐 버렸습니다.\t|");
                                }
                                else
                                {
                                    Console.WriteLine("|  실패..\t\t\t\t\t\t|\n" +
                                                      "|  산적은 당신의 위협을 비웃고 칼을 뽑아 듭니다.\t|\n" +
                                                      "|  - 전투 시작 -\t\t\t\t\t|");
                                    monster = new Bandit();
                                    BattleStart = true;
                                }
                                EventEnd = false;
                                break;
                            case 1:
                                if (Bcheck > rand.Next(1, 101))
                                {
                                    Console.WriteLine("|  성공!\t\t\t\t\t\t|\n" +
                                                      "|  당신은 빠른발로 산적에게서 도망쳤습니다.\t\t|");
                                }
                                else
                                {
                                    Console.WriteLine("|  실패..\t\t\t\t\t\t|\n" +
                                                      "|  당신은 산적에서 도망치는데 실패했습니다.\t\t|\n" +
                                                      "|  산적이 칼을 뽑아 듭니다.\t\t\t\t|\n" +
                                                      "|  - 전투 시작 -\t\t\t\t\t|");
                                    monster = new Bandit();
                                    BattleStart = true;
                                }
                                EventEnd = false;
                                break;
                            case 2:
                                if (player.Inventory.Contains("미끄러운 점액") == true)
                                {
                                    Console.WriteLine("|  당신은 미끄러운 점액을 산적에게 던졌고,\t\t|\n" +
                                                      "|  산적은 미끄러운 점액 때문에 도망치는 당신을\t\t|\n" +
                                                      "|  따라가지 못합니다.\t\t\t\t\t|");
                                    player.Inventory.Remove("미끄러운 점액");
                                    EventEnd = false;
                                }
                                else
                                {
                                    Console.WriteLine("|   당신은 미끄러운 점액을 가지고 있지 않습니다.\t|\n" +
                                                      "|   다른 선택지를 고르세요\t\t\t\t|");
                                }
                                break;
                        }
                    }


                    Key = null;
                }
                ShowStatusAndInventory(player);

                c = Console.ReadKey();
                Key = c.Key.ToString();
                Console.Clear();
                if (Key != "Enter")
                {
                    switch (Key)
                    {
                        case "UpArrow":
                            if (Num != 0)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[--Num] = 1;
                            }
                            break;
                        case "DownArrow":
                            if (Num != 2)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[++Num] = 1;
                            }
                            break;
                    }
                }
                if (BattleStart)
                {
                    battle(player, monster);
                }
            }
        }
        public void num7(Player player) // 숲속의 생명체(전투 이벤트)
        {
            int[] status = new int[] { player.STR, player.DEX, player.INT };
            Random rand = new Random();
            int Acheck = Chance + 7 * (player.STR - 5);
            int Bcheck = Chance + 7 * (player.DEX - 5);
            string[] EventSelect = new string[3] { "A.선빵필승! 일단 강하게 내려친다.{힘 필요}\t|",
                                                   "B.몰래다가가서 깜짝 놀래키고 공격한다.{민첩 필요}|",
                                                   "C.안전하게 그냥 지나가도록 한다.\t\t\t|" };
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            bool EventEnd = true;
            bool BattleStart = false;
            ConsoleKeyInfo c;
            string Key = null;
            Monster monster = new Monster();
            switch (rand.Next(1, 3))
            {
                case 1:
                    monster = new Slim();
                    break;
                case 2:
                    monster = new Wolf();
                    break;
            }

            while (EventEnd)
            {
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n =======================================================");
                Console.WriteLine("|  당신은 숲풀 속에서 무언가 움직이는 것을 봤습니다.\t|\n" +
                                  "|  아마도 어떤 몬스터인 것 같습니다.\t\t\t|\n" +
                                  "|  어떻게 하시겠습니까?\t\t\t\t\t|");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("|\t\t\t\t\t\t\t|\n|      ");
                            break;
                        case 1:
                            Console.Write("|\t\t\t\t\t\t\t|\n|   ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);
                }


                if (Key == "Enter")
                {
                    Console.WriteLine("|\t\t\t\t\t\t\t|\n =======================================================");
                    switch (Num)
                    {
                        case 0:
                            if (Acheck > rand.Next(1, 101))
                            {
                                Console.WriteLine("|  성공!\t\t\t\t\t\t|\n" +
                                                  "|  당신은 숲속에 있던 몬스터 {0}를 공격해서\t\t|\n" +
                                                  "|  상처를 입혔습니다. - 전투 시작 -\t\t\t|", monster.Name);
                                monster.HP -= 5;

                            }
                            else
                            {
                                Console.WriteLine("|  실패...\t\t\t\t\t\t|\n" +
                                                  "|  당신은 숲속에 있던 몬스터 {0}를 공격해서\t\t|\n" +
                                                  "|  상처를 입히지 못했습니다. \t\t\t\t|\n" +
                                                  "|  몬스터가 분노 합니다. - 전투 시작 -\t\t\t|", monster.Name);
                                ++monster.DEX;
                                ++monster.STR;

                            }
                            BattleStart = true;
                            break;
                        case 1:
                            if (Bcheck > rand.Next(1, 101))
                            {
                                Console.WriteLine("|  성공!\t\t\t\t\t\t|\n" +
                                                  "|  몬스터 {0}는(은) 당신의 갑작스러운 등장에\t\t|\n" +
                                                  "|  혼란스러움을 느낍니다. - 전투 시작 -\t\t\t|", monster.Name);
                                --monster.DEX;
                            }
                            else
                            {
                                Console.WriteLine("|  실패...\t\t\t\t\t\t|\n" +
                                                  "|  몬스터 {0}는 당신이 다가오는 것을 눈치 챘습니다.\t|\n" +
                                                  "|  당신을 상대하기 위한 준비를 하고 있었습니다.\t\t|\n" +
                                                  "|  - 전투 시작 -\t\t\t\t\t|", monster.Name);
                                ++monster.DEX;
                                ++monster.STR;
                            }
                            BattleStart = true;
                            break;
                        case 2:
                            Console.WriteLine("|  당신은 숲풀에 있는 생명체에게 들키지 않도록\t\t|\n" +
                                              "|  조심하면서 길을 지나갑니다.\t\t\t\t|");
                            BattleStart = false;
                            break;
                    }

                    Key = null;
                    EventEnd = false;
                }
                ShowStatusAndInventory(player);

                c = Console.ReadKey();
                Key = c.Key.ToString();
                Console.Clear();
                if (Key != "Enter")
                {
                    switch (Key)
                    {
                        case "UpArrow":
                            if (Num != 0)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[--Num] = 1;
                            }
                            break;
                        case "DownArrow":
                            if (Num != 2)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[++Num] = 1;
                            }
                            break;
                    }
                }
                if (BattleStart)
                {
                    battle(player, monster);
                }
            }
        }
        public void num8(Player player) // 고블린과의 거래(일반 이벤트, 전투 이벤트,아이템 사용(늑대의 가죽))
        {
            int[] status = new int[] { player.STR, player.DEX, player.INT };
            string[] EventSelect = new string[3] { "A.몬스터와의 거래는 없다! 고블린을 공격한다.\t|",
                                                   "B.고블린, 늑대 가죽은 좋아하나?(늑대의 가죽 필요)|",
                                                   "C.줄만한 것이 없다. 아쉽지만 지나간다.\t\t|" };
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            bool EventEnd = true;
            bool BattleStart = false;
            ConsoleKeyInfo c;
            string Key = null;
            Monster monster = new Monster();
            monster = new Goblin();
            while (EventEnd)
            {
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n =======================================================");
                Console.WriteLine("|  어떤 고블린이 당신에게 다가옵니다.\t\t\t|\n" +
                                  "|  고블린은 당신에게 좋은 물건이 있다면 자신의 장신구와\t|\n" +
                                  "|  바꾸자고 합니다. 어떻게 하시겠습니까?\t\t|");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("|\t\t\t\t\t\t\t|\n|      ");
                            break;
                        case 1:
                            Console.Write("|\t\t\t\t\t\t\t|\n|   ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);
                }

                if (Key == "Enter")
                {
                    Console.WriteLine("|\t\t\t\t\t\t\t|\n =======================================================");
                    switch (Num)
                    {
                        case 0:
                            Console.WriteLine("|  당신이 고블린을 공격할려고 하자,\t\t\t|\n" +
                                              "|  고블린도 공격자세를 잡습니다. - 전투 시작 -\t\t|");
                            BattleStart = true;
                            EventEnd = false;
                            break;
                        case 1:
                            if (player.Inventory.Contains("늑대의 가죽") == true)
                            {
                                Console.WriteLine("|  고블린은 당신이 건낸 늑대 가죽을 마음에 들어 했고,\t|\n" +
                                                  "|  고블린은 자신이 가지고 있던 고블린 장신구를 당신에게\t|\n" +
                                                  "|  주었습니다.\t\t\t\t\t\t|");
                                player.Inventory.Remove("늑대의 가죽");
                                player.Inventory.Add("고블린 장신구");
                                EventEnd = false;
                            }
                            else
                            {
                                Console.WriteLine("|  당신은 늑대의 가죽을 가지고 있지 않습니다.\t\t|\n" +
                                                  "|  다른 선택지를 고르세요\t\t\t\t|");
                            }
                            break;
                        case 2:
                            Console.WriteLine("|  당신은 고블린에게 줄 것이 없다고 말하고,\t\t|\n" +
                                              "|  가려던 길을 걸어갑니다.\t\t\t\t|");
                            EventEnd = false;
                            break;
                    }

                    Key = null;
                }
                ShowStatusAndInventory(player);

                c = Console.ReadKey();
                Key = c.Key.ToString();
                Console.Clear();
                if (Key != "Enter")
                {
                    switch (Key)
                    {
                        case "UpArrow":
                            if (Num != 0)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[--Num] = 1;
                            }
                            break;
                        case "DownArrow":
                            if (Num != 2)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[++Num] = 1;
                            }
                            break;
                    }
                }
                if (BattleStart)
                {
                    battle(player, monster);
                }
            }
        }
        public void num9(Player player) // 함정이 설치된 장신구 걸이(일반 이벤트, 아이템 사용(고블린 장신구),한번만 나옴)
        {
            int[] status = new int[] { player.STR, player.DEX, player.INT };
            Random rand = new Random();
            int Bcheck = Chance + 7 * (player.DEX - 5);
            string[] EventSelect = new string[3] { "A.고블린 장신구와 바꿉니다.{고블린 징신구 필요}\t|",
                                                   "B.빠른 속도로 장신구를 빼옵니다.{민첩 필요}\t|",
                                                   "C.위험을 감수할 수 없습니다. 그냥 지나갑니다.\t|" };
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            bool EventEnd = true;
            ConsoleKeyInfo c;
            string Key = null;
            while (EventEnd)
            {
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n =======================================================");
                Console.WriteLine("|  당신은 숨겨진 장소에 어떠한 기운이 느껴지는 장신구를\t|\n" +
                                  "|  발견했습니다. 하지만 장신구 주변에는 함정이 설치되어\t|\n" +
                                  "|  있는것 같습니다.어떻게 하시겠습니까?\t\t\t|");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("|\t\t\t\t\t\t\t|\n|      ");
                            break;
                        case 1:
                            Console.Write("|\t\t\t\t\t\t\t|\n|   ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);
                }

                if (Key == "Enter")
                {
                    Console.WriteLine("|\t\t\t\t\t\t\t|\n =======================================================");
                    switch (Num)
                    {

                        case 0:
                            if (player.Inventory.Contains("고블린 장신구"))
                            {
                                Console.WriteLine("|  당신은 고블린 장신구를 이용하여 장신구를 안전하게\t|\n" +
                                                  "|  가져올수 있었습니다. 장신구가 가지고 있던 기운이\t|\n" +
                                                  "|  당신에게 들어옵니다.\t\t\t\t\t|");
                                player.Inventory.Remove("고블린 장신구");
                                player.MaxHP += 10;
                                player.HP += 10;
                                ++player.STR;
                                ++player.INT;
                                ++player.DEX;
                                ++status[0];
                                ++status[1];
                                ++status[2];
                                EventEnd = false;
                            }
                            else
                            {
                                Console.WriteLine("|  당신은 고블린 장신구을 가지고 있지 않습니다.\t\t|\n" +
                                                  "|  다른 선택지를 고르세요\t\t\t\t|");
                            }
                            break;
                        case 1:
                            if (Bcheck > rand.Next(1, 101))
                            {
                                Console.WriteLine("|  성공!\t\t\t\t\t\t|\n" +
                                                  "|  당신은 함정이 발동 되지 전에 장신구를 가져왔습니다.\t|\n" +
                                                  "|  하지만 너무 서두른 나머지 장신구가 손상 되었습니다.\t|\n" +
                                                  "|  장신구가 가지고 있던 기운이 당신에게 조금 들어옵니다.|");

                                player.MaxHP += 5;
                                player.HP += 5;
                            }
                            else
                            {
                                player.HP -= 5;
                                if (player.HP <= 0)
                                {
                                    Console.WriteLine("|  실패...\t\t\t\t\t\t|\n" +
                                                      "|  당신은 발동된 함정으로 인해 사망하였습니다.\t\t|\n" +
                                                      "|  정말 허무한 죽음이네요..\t\t\t\t|");
                                }
                                else
                                {
                                    Console.WriteLine("|  실패...\t\t\t\t\t\t|\n" +
                                                      "|  당신은 발동된 함정으로 인해 상처를 입었고\t\t|\n" +
                                                      "|  장신구도 망가져 버렸습니다.\t\t\t\t|");
                                }
                            }
                            EventEnd = false;
                            break;
                        case 2:
                            Console.WriteLine("|  당신은 장신구 때문에 목숨을 걸수는 없다고\t\t|\n" +
                                              "|  생각했습니다. 그래서 장신구는 포기하고\t\t|\n" +
                                              "|  다시 길을 걷습니다.\t\t\t\t\t|");
                            EventEnd = false;
                            break;
                    }

                    Key = null;
                }
                ShowStatusAndInventory(player);

                c = Console.ReadKey();
                Key = c.Key.ToString();
                Console.Clear();
                if (Key != "Enter")
                {
                    switch (Key)
                    {
                        case "UpArrow":
                            if (Num != 0)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[--Num] = 1;
                            }
                            break;
                        case "DownArrow":
                            if (Num != 2)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[++Num] = 1;
                            }
                            break;
                    }
                }
            }
        }
        public int num10(Player player) // 행상인과의 거래(일반 이벤트,아이템 사용(늑대 가죽, 산적의 두건))
        {
            int[] status = new int[] { player.STR, player.DEX, player.INT };
            string[] EventSelect = new string[3] { "A.늑대의 가죽으로 거래하자고 한다.\t\t|\n" +
                                                   "|\t {늑대의 가죽 필요}\t\t\t\t|",
                                                   "B.산적의 두건을 쓰고 행산인을 협박한다.\t\t|\n" +
                                                   "|\t {산적의 두건 필요}{지혜 필요}\t\t\t|",
                                                   "C.거래할만한 물건이 없다. 그냥 지나간다.\t\t|" };
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            int ACheck = Chance + 7 * (player.INT - 5);
            Random rand = new Random();
            bool EventEnd = true;
            ConsoleKeyInfo c;
            string Key = null;
            while (EventEnd)
            {
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n =======================================================");
                Console.WriteLine("|  당신은 건너편에 지나가고 있는 행상인과 마주쳤습니다.\t|\n" +
                                  "|  행상인은 만약 당신이 좋은 물건을 가지고 있으면 자신이|\n" +
                                  "|  가지고 있는 포션과 거래하자고 합니다.\t\t|");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("|\t\t\t\t\t\t\t|\n|      ");
                            break;
                        case 1:
                            Console.Write("|\t\t\t\t\t\t\t|\n|   ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);

                }

                if (Key == "Enter")
                {
                    Console.WriteLine("|\t\t\t\t\t\t\t|\n =======================================================");
                    switch (Num)
                    {

                        case 0:
                            if (player.Inventory.Contains("늑대의 가죽") == true)
                            {
                                Console.WriteLine("|  행상인은 당신이 건낸 늑대 가죽을 마음에 들어 했고,\t|\n" +
                                                  "|  행상인이 가지고 있던 포션을 당신에게 주었습니다.\t|");

                                player.Inventory.Remove("늑대의 가죽");
                                switch (rand.Next(1, 5))
                                {
                                    case 1:
                                        Console.WriteLine("|  힘 포션을 마셨습니다.(힘이 1 증가합니다.)\t\t|");
                                        player.STR++;
                                        status[0]++;
                                        break;
                                    case 2:
                                        Console.WriteLine("|  민첩 포션을 마셨습니다.(민첩이 1 증가합니다.)\t|");
                                        player.DEX++;
                                        status[1]++;
                                        break;
                                    case 3:
                                        Console.WriteLine("|  지혜 포션을 마셨습니다.(지혜가 1 증가합니다.)\t|");
                                        player.INT++;
                                        status[2]++;
                                        break;
                                    case 4:
                                        Console.WriteLine("|  체력 포션을 마셨습니다.(체력이 10 증가합니다.)\t\t|");
                                        if (player.HP + 10 > player.MaxHP)
                                        {
                                            player.HP = player.MaxHP;
                                        }
                                        else
                                        {
                                            player.HP += 10;
                                        }
                                        break;
                                }

                                EventEnd = false;
                            }
                            else
                            {
                                Console.WriteLine("|  당신은 늑대의 가죽을 가지고 있지 않습니다.\t\t|\n" +
                                                  "|  다른 선택지를 고르세요\t\t\t\t|");
                            }
                            EventEnd = false;
                            break;
                        case 1:
                            if (player.Inventory.Contains("산적의 두건") == true)
                            {
                                if (ACheck > rand.Next(1, 101))
                                {
                                    Console.WriteLine("|  성공!\t\t\t\t\t\t|\n" +
                                                      "|  당신은 산적의 두건을 둘러쓰고 행상인을 위협하는데\t|\n" +
                                                      "|  성공 했습니다.\t\t\t\t\t|\n" +
                                                      "|  행상인이 가지고 있던 포션 2개를 획득했습니다.\t|\n" +
                                                      "|  하지만 이제 행상인을 볼 수 없을 것 같습니다.\t\t|");
                                    EventUnlock = EventUnlock * 5;
                                    for (int i = 0; i < 2; i++)
                                    {
                                        switch (rand.Next(1, 5))
                                        {
                                            case 1:
                                                Console.WriteLine("|  힘 포션을 마셨습니다.(힘이 1 증가합니다.)\t\t|");
                                                player.STR++;
                                                status[0]++;
                                                break;
                                            case 2:
                                                Console.WriteLine("|  민첩 포션을 마셨습니다.(민첩이 1 증가합니다.)\t|");
                                                player.DEX++;
                                                status[1]++;
                                                break;
                                            case 3:
                                                Console.WriteLine("|  지혜 포션을 마셨습니다.(지혜가 1 증가합니다.)\t|");
                                                player.INT++;
                                                status[2]++;
                                                break;
                                            case 4:
                                                Console.WriteLine("|  체력 포션을 마셨습니다.(체력이 10 증가합니다.)\t|");
                                                if (player.HP + 10 > player.MaxHP)
                                                {
                                                    player.HP = player.MaxHP;
                                                }
                                                else
                                                {
                                                    player.HP += 10;
                                                }
                                                break;
                                        }
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("|  실패...\t\t\t\t\t\t|\n" +
                                                      "|  당신은 산적의 두건을 둘러쓰고 행상인을 위협하는데\t|\n" +
                                                      "|  실패 했습니다.\t\t\t\t\t|\n" +
                                                      "|  이제 행상인을 볼 수 없을 것 같습니다.\t\t|");
                                    EventUnlock = EventUnlock * 5;
                                }

                            }
                            else
                            {
                                Console.WriteLine("|  당신은 산적의 두건을 가지고 있지 않습니다.\t\t|\n" +
                                                  "|  다른 선택지를 고르세요\t\t\t\t|");
                            }
                            EventEnd = false;
                            break;
                        case 2:
                            Console.WriteLine("|  당신은 행상인이 원할만한 물건을 가지고 있지 않습니다.|\n" +
                                              "|  다시 길을 걷습니다.\t\t\t\t\t|");
                            EventEnd = false;
                            break;
                    }

                    Key = null;
                }
                ShowStatusAndInventory(player);

                c = Console.ReadKey();
                Key = c.Key.ToString();
                Console.Clear();
                if (Key != "Enter")
                {
                    switch (Key)
                    {
                        case "UpArrow":
                            if (Num != 0)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[--Num] = 1;
                            }
                            break;
                        case "DownArrow":
                            if (Num != 2)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[++Num] = 1;
                            }
                            break;
                    }
                }
            }
            return EventUnlock;
        }
        public void num11(Player player) // 늑대 이벤트(일반 이벤트,전투 이벤트)
        {
            int[] status = new int[] { player.STR, player.DEX, player.INT };
            string[] EventSelect = new string[3] { "A.뒤에서 들린것 같다 앞으로 도망친다.\t\t|",
                                                   "B.앞에서 들린것 같다 뒤로 도망친다.\t\t|",
                                                   "C.늑대따위 무섭지 않다. 싸운다!\t\t\t|" };
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            Monster monster = new Monster();
            Random random = new Random();
            int FrontAndBack;
            bool EventEnd = true;
            bool BattleStart = false;
            ConsoleKeyInfo c;
            string Key = null;
            while (EventEnd)
            {
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n =======================================================");
                Console.WriteLine("|  당신은 어디선가 늑대의 울음소리를 들었습니다.\t|\n" +
                                  "|  하지만 정확이 어디에서 들리는지 알수 없었습니다.\t|\n" +
                                  "|  늑대에서 도망치기 위해 어느쪽으로 달리시겠습니까\t|");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("|\t\t\t\t\t\t\t|\n|      ");
                            break;
                        case 1:
                            Console.Write("|\t\t\t\t\t\t\t|\n|   ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);

                }
                if (Key == "Enter")
                {
                    FrontAndBack = random.Next(1, 3);                // 1: 앞,2: 뒤
                    Console.WriteLine("|\t\t\t\t\t\t\t|\n =======================================================");
                    switch (Num)
                    {
                        case 0:
                            if (FrontAndBack == 1)
                            {
                                Console.WriteLine("|   당신은 운이 좋게도 늑대에게서 벋어났습니다.\t\t|\n" +
                                                  "|   운이 좋군요\t\t\t\t\t\t|");
                            }
                            else
                            {
                                Console.WriteLine("|   당신은 운이 나쁘게도 늑대와 마주쳤습니다.\t\t|\n" +
                                                  "|   -전투 시작-\t\t\t\t\t\t|");
                                monster = new Wolf();
                                BattleStart = true;
                            }
                            EventEnd = false;
                            break;
                        case 1:
                            if (FrontAndBack == 2)
                            {
                                Console.WriteLine("|   당신은 운이 좋게도 늑대에게서 벋어났습니다.\t\t|\n" +
                                                  "|   운이 좋군요\t\t\t\t\t\t|");
                            }
                            else
                            {
                                Console.WriteLine("|   당신은 운이 나쁘게도 늑대와 마주쳤습니다.\t\t|\n" +
                                                  "|   -전투 시작-\t\t\t\t\t\t|");
                                monster = new Wolf();
                                BattleStart = true;
                            }
                            EventEnd = false;
                            break;
                        case 2:
                            Console.WriteLine("|   당신은 늑대와 싸우기 위해 늑대가 나타나길\t\t|\n" +
                                              "|   기다렸고, 곧 늑대가 나타났습니다. - 전투 시작 -\t|");
                            monster = new Wolf();
                            BattleStart = true;
                            EventEnd = false;
                            break;
                    }
                }
                ShowStatusAndInventory(player);

                c = Console.ReadKey();
                Key = c.Key.ToString();
                Console.Clear();
                if (Key != "Enter")
                {
                    switch (Key)
                    {
                        case "UpArrow":
                            if (Num != 0)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[--Num] = 1;
                            }
                            break;
                        case "DownArrow":
                            if (Num != 2)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[++Num] = 1;
                            }
                            break;
                    }
                }
                if (BattleStart)
                {
                    battle(player, monster);
                }
            }
        }
        public void num12(Player player) // 연금술사 이벤트 (아이템 확률 변환, 아이템 확률 복제)
        {
            int[] status = new int[] { player.STR, player.DEX, player.INT };
            string[] EventSelect = new string[3] { "A.아이템 변환 기능을 사용한다.\t\t\t|",
                                                   "B.아이템 복제 기능을 사용한다.\t\t\t|",
                                                   "C.사악한 기술이다. 사용하지 않는다.\t\t|" };
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            ConsoleKeyInfo c;
            string Key = null;
            bool EventEnd = true;
            int KeyNumber = new int();
            int DropNumber = new int();
            Random rand = new Random();
            bool AlchemyEvent = true;
            bool Drop = true;
            string Item = null;
            string DropItem = null;
            while (EventEnd)
            {
            First:
                Console.Clear();
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n =======================================================");
                Console.WriteLine("|  당신은 연금술사를 만났습니다.\t\t\t|\n" +
                                  "|  연금술사는 자신이 새로운 연금술을 개발해 아이템을\t|\n" +
                                  "|  변환하거나, 복제할 수 있다고 했고, 기술을 시험해\t|\n" +
                                  "|  보겠냐고 물어봅니다. 어떻게 하시겠습니까\t\t|");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("|\t\t\t\t\t\t\t|\n|      ");
                            break;
                        case 1:
                            Console.Write("|\t\t\t\t\t\t\t|\n|   ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);

                }
                if (Key == "Enter")
                {
                    Console.WriteLine("|\t\t\t\t\t\t\t|\n =======================================================");
                    switch (Num)
                    {
                        case 0:
                            if (player.Inventory.Count == 0)
                            {
                                Console.WriteLine("|  가지고 있는 아이템이 없습니다.\t\t\t|\n" +
                                                  "|  다른 선택지를 고르세요\t\t\t\t|");
                            }
                            else
                            {
                                EventEnd = false;
                                if (AlchemyEvent)
                                {
                                    Console.WriteLine("|  어떤 아이템을 변환 하시겠습니까\t\t\t|");
                                    ShowStatusAndInventory(player);

                                    var Numc = Console.ReadKey();

                                    if (char.IsDigit(Numc.KeyChar))
                                    {
                                        KeyNumber = int.Parse(Numc.KeyChar.ToString());
                                    }
                                    else
                                    {
                                        KeyNumber = 9;
                                    }
                                }



                                if (KeyNumber <= player.Inventory.Count)
                                {
                                    if (AlchemyEvent)
                                    {
                                        switch (rand.Next(0, 5))
                                        {
                                            case 0:
                                                Item = "미끄러운 점액";
                                                break;
                                            case 1:
                                                Item = "늑대의 가죽";
                                                break;
                                            case 2:
                                                Item = "고블린 장신구";
                                                break;
                                            case 3:
                                                Item = "산적의 두건";
                                                break;
                                            case 4:
                                                Item = "꽝";
                                                break;
                                        }
                                    }

                                    if (Item == "꽝")
                                    {
                                        if (AlchemyEvent)
                                        {

                                            AlchemyEvent = false;
                                            goto First;
                                        }
                                        Console.WriteLine("|  아이템 변환이 실패하여 아무것도 나오지 않습니다.\t|");
                                        player.Inventory.RemoveAt(KeyNumber - 1);
                                    }
                                    else
                                    {
                                        if (AlchemyEvent)
                                        {

                                            AlchemyEvent = false;
                                            goto First;
                                        }
                                        Console.WriteLine("|  당신의 아이템 {0}이 {1}로\t\t|\n" +
                                                          "|  변환되었습니다.\t\t\t\t\t|", player.Inventory[KeyNumber - 1], Item);
                                        player.Inventory.RemoveAt(KeyNumber - 1);
                                        player.Inventory.Add(Item);
                                    }

                                }
                                else
                                {
                                    if (AlchemyEvent)
                                    {
                                        goto First;
                                    }
                                }
                            }
                            
                            break;
                        case 1:
                            if (player.Inventory.Count == 0)
                            {
                                Console.WriteLine("|  가지고 있는 아이템이 없습니다.\t\t\t|\n" +
                                                  "|  다른 선택지를 고르세요\t\t\t\t|");
                            }
                            else
                            {
                                EventEnd = false;
                                if (AlchemyEvent)
                                {
                                    Console.WriteLine("|  어떤 아이템을 복제 하시겠습니까\t\t\t|");
                                    ShowStatusAndInventory(player);

                                    var Numc = Console.ReadKey();

                                    if (char.IsDigit(Numc.KeyChar))
                                    {
                                        KeyNumber = int.Parse(Numc.KeyChar.ToString());
                                    }
                                    else
                                    {
                                        KeyNumber = 9;
                                    }
                                }
                                if (KeyNumber <= player.Inventory.Count)
                                {
                                    if(Drop)
                                    {
                                        switch (rand.Next(0, 2))
                                        {
                                            case 0:
                                                if (AlchemyEvent)
                                                {
                                                    AlchemyEvent = false;
                                                    goto First;
                                                }
                                                Console.WriteLine("|   아이템 복제에 성공했습니다.\t\t\t\t|");
                                                player.Inventory.Add(player.Inventory[KeyNumber - 1]);
                                                break;
                                            case 1:

                                                if (AlchemyEvent)
                                                {
                                                    AlchemyEvent = false;
                                                    goto First;
                                                }
                                                Console.WriteLine("|   아이템 복제에 실패했습니다.\t\t\t\t|");
                                                player.Inventory.RemoveAt(KeyNumber - 1);
                                                break;
                                        }
                                        Drop = false;
                                    }
                                        
                                   
                                    if (player.Inventory.Count >= 6)
                                    {
                                        Console.WriteLine("|\t인벤토리가 가득차서 무언가를 버려야 합니다.\t|");
                                        Console.WriteLine("|\t어떤것을 버리겠습니까?(1,2,3,4,5,6 중에 선택)\t|");

                                        if (DropItem != null)
                                        {
                                            Console.WriteLine("|\t인벤토리의 \'{0}\' 아이템을 버립니다.\t|", DropItem);
                                            player.Inventory.RemoveAt(KeyNumber - 1);
                                        }
                                    }

                                }
                                else
                                {
                                    if (AlchemyEvent)
                                    {
                                        goto First;
                                    }
                                }
                            }
                            
                            break;
                        case 2:
                            Console.WriteLine("|  당신은 연금술같은 사악한 기술은\t\t\t|\n" +
                                              "|  믿을수 없다고 생각합니다.\t\t\t\t|\n" +
                                              "|  가던길을 계속 걷습니다.\t\t\t\t|");
                            EventEnd = false;
                            break;

                    }
                }
                ShowStatusAndInventory(player);
                if (player.Inventory.Count >= 6)
                {
                   
                    var Numc = Console.ReadKey();

                    if (char.IsDigit(Numc.KeyChar))
                    {
                        DropNumber = int.Parse(Numc.KeyChar.ToString());
                    }
                    else
                    {
                        DropNumber = 9;
                    }

                    switch (DropNumber)
                    {
                        case 1:
                            DropItem = player.Inventory[0];
                            break;
                        case 2:
                            DropItem = player.Inventory[1];
                            break;
                        case 3:
                            DropItem = player.Inventory[2];
                            break;
                        case 4:
                            DropItem = player.Inventory[3];
                            break;
                        case 5:
                            DropItem = player.Inventory[4];
                            break;
                        case 6:
                            DropItem = player.Inventory[5];
                            break;
                        default:
                            
                            break;
                    }
                    goto First;
                }
                c = Console.ReadKey();
                Key = c.Key.ToString();
                Console.Clear();
                if (Key != "Enter")
                {
                    switch (Key)
                    {
                        case "UpArrow":
                            if (Num != 0)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[--Num] = 1;
                            }
                            break;
                        case "DownArrow":
                            if (Num != 2)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[++Num] = 1;
                            }
                            break;
                    }
                }
            }

        }
        public void num13(Player player) // 랜덤 도박 이벤트
        {
            int[] status = new int[] { player.STR, player.DEX, player.INT };
            string[] EventSelect = new string[3] { "A.왼쪽 상자를 고른다.\t\t\t\t|",
                                                   "B.가운데 상자를 고른다.\t\t\t\t|",
                                                   "C.오른쪽 상자를 고른다.\t\t\t\t|" };
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            ConsoleKeyInfo c;
            string Key = null;
            bool EventEnd = true;
            int Box = new int();
            Random rand = new Random(); 
            while(EventEnd)
            {
                Console.Clear();
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n =======================================================");
                Console.WriteLine("|  당신은 상자 3개를 가지고 있는 사람을 만났습니다.\t|\n" +
                                  "|  3개의 상자중 하나를 고르면 상자에 있는 내용물을\t|\n" +
                                  "|  얻을수 있습니다. 어떤 상자를 고르시겠습니까\t\t|");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("|\t\t\t\t\t\t\t|\n|      ");
                            break;
                        case 1:
                            Console.Write("|\t\t\t\t\t\t\t|\n|   ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);

                }
                if (Key == "Enter")
                {
                    Box = rand.Next(0, 3);
                    Console.WriteLine("|\t\t\t\t\t\t\t|\n =======================================================");
                    if(Num == Box)
                    {
                        Console.WriteLine("|   당신이 고른 상자에서 신비한 기운이\t\t\t|\n" +
                                          "|   뿜어져 나옵니다. 신비한 기운으로\t\t\t|\n" +
                                          "|   모든 상처가 치유 됩니다.\t\t\t\t|");
                        player.HP = player.MaxHP;
                    }
                    else
                    {
                        Console.WriteLine("|   상자 안에는 아무것도 없었습니다.\t\t\t|");
                    }
                    EventEnd = false;

                }
                ShowStatusAndInventory(player);
                c = Console.ReadKey();
                Key = c.Key.ToString();
                Console.Clear();
                if (Key != "Enter")
                {
                    switch (Key)
                    {
                        case "UpArrow":
                            if (Num != 0)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[--Num] = 1;
                            }
                            break;
                        case "DownArrow":
                            if (Num != 2)
                            {
                                SelectNumber[Num] = 0;
                                SelectNumber[++Num] = 1;
                            }
                            break;
                    }
                }
            }

        }   

        public void ShowStatusAndInventory(Player player)
        {
            Console.WriteLine("|\t\t\t\t\t\t\t|\n =======================================================");
            Console.WriteLine("당신의 캐릭터:{0}", player.Name);
            Console.WriteLine("MAXHP/HP: {0}/{1}", player.MaxHP, player.HP);
            Console.WriteLine("MAXMP/MP: {0}/{1}", player.MaxMP, player.MP);
            Console.Write("{힘:" + player.STR + "}\n{민첩:" + player.DEX + "}\n{지혜:" + player.INT + "}\n");
            Console.Write("인벤토리: ");

            for (int i = 0; i < player.Inventory.Count; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("{0}.{1}", i + 1, player.Inventory[i]);
                }
                else
                {

                    Console.WriteLine("          {0}.{1}", i + 1, player.Inventory[i]);
                }
            }
        }
        public void ShowMonsterStatus(Monster monster)
        {
            Console.WriteLine("{0} :몬스터", monster.Name);
            Console.WriteLine("{0}/{1}: MAXHP/HP", monster.MaxHP, monster.HP);
            Console.Write("{" + monster.STR + ":힘}\n{" + monster.DEX + ":민첩}\n");
        }
        public void battle(Player player, Monster monster)
        {
            int[] status = new int[] { player.STR, player.DEX, player.INT };
            bool BattleFinish = true;
            bool Drop = true;
            string DropItem = null;
            Random rand = new Random();
            ConsoleKeyInfo c;
            ConsoleKeyInfo Numc;
            string Key = null;
            int Num;
            ShowMonsterStatus(monster);
            Console.WriteLine(" ======================================================= \n" +
                              "|\t\t\t\t\t\t\t|");
            Console.WriteLine("|\t  몬스터 {0}와 의 전투를 시작합니다.   \t|", monster.Name);
            ShowStatusAndInventory(player);

            c = Console.ReadKey();
            Key = c.Key.ToString();

            while (Key != "Enter")
            {
                c = Console.ReadKey();
                Key = c.Key.ToString();
            }
            Key = null;


            while (BattleFinish)
            {
                Console.Clear();
                ShowMonsterStatus(monster);
                Num = player.PlayerTurn(monster, Key);
                ShowStatusAndInventory(player);
                while (Key != "Enter")
                {
                    Key = null;
                    c = Console.ReadKey();
                    Key = c.Key.ToString();
                    Console.Clear();

                    ShowMonsterStatus(monster);
                    Num = player.PlayerTurn(monster, Key);
                    ShowStatusAndInventory(player);

                }
                Key = null;
                Console.Clear();
                while (Key == null)
                {
                    ShowMonsterStatus(monster);
                    Console.WriteLine(" ======================================================= \n" +
                              "|\t\t\t\t\t\t\t|");

                    switch (Num)
                    {
                        case 0:
                            player.NormalAttack();
                            break;
                        case 1:
                            player.HeavyAttack();
                            break;
                    }
                    ShowStatusAndInventory(player);
                    c = Console.ReadKey();
                    Key = c.Key.ToString();
                }
                Key = null;
                if (player.Damage != 0)
                {
                    while (Key == null)
                    {
                        Console.Clear();
                        monster.MonsterTakeDemage(player);
                        ShowStatusAndInventory(player);
                        c = Console.ReadKey();
                        Key = c.Key.ToString();
                    }
                }
                else
                {

                }
                Key = null;

                if (monster.HP <= 0)
                {
                First:
                    Console.Clear();
                    Console.WriteLine(" =======================================================\n" +
                              "|\t\t\t\t\t\t\t|");
                    Console.WriteLine("|\t당신은 몬스터 {0}를 잡았습니다.\t\t|", monster.Name);
                    BattleFinish = false;
                    if (60 > rand.Next(1, 80))
                    {
                        Console.WriteLine("|\t{0}을(를) 얻었습니다.\t\t\t|", monster.Item);

                        if (player.Inventory.Count < 5)
                        {
                            if (Drop)
                            {
                                player.Inventory.Add(monster.Item);
                                Drop = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("|\t인벤토리가 가득차서 무언가를 버려야 합니다.\t|");
                            Console.WriteLine("|\t어떤것을 버리겠습니까?(1,2,3,4,5,6 중에 선택)\t|");
                            if (Drop)
                            {
                                player.Inventory.Add(monster.Item);
                            }

                            if (Drop == false)
                            {
                                if (DropItem != null)
                                {
                                    Console.WriteLine("|\t인벤토리의 \'{0}\' 아이템을 버립니다.\t|", DropItem);
                                }

                            }

                            Drop = false;
                        }
                    }

                    ShowStatusAndInventory(player);
                    if (player.Inventory.Count < 6)
                    {
                        while (Key != "Enter")
                        {
                            c = Console.ReadKey();
                            Key = c.Key.ToString();
                        }
                        Key = null;
                    }

                    else
                    {

                    Second:
                        Numc = Console.ReadKey();
                        string number = Numc.Key.ToString();

                        switch (number)
                        {
                            case "D1":
                                DropItem = player.Inventory[0];
                                player.Inventory.RemoveAt(0);

                                break;
                            case "D2":
                                DropItem = player.Inventory[1];
                                player.Inventory.RemoveAt(1);

                                break;
                            case "D3":
                                DropItem = player.Inventory[2];
                                player.Inventory.RemoveAt(2);

                                break;
                            case "D4":
                                DropItem = player.Inventory[3];
                                player.Inventory.RemoveAt(3);

                                break;
                            case "D5":
                                DropItem = player.Inventory[4];
                                player.Inventory.RemoveAt(4);

                                break;
                            case "D6":
                                DropItem = player.Inventory[5];
                                player.Inventory.RemoveAt(5);

                                break;
                            default:
                                goto Second;
                                break;
                        }
                        Console.Clear();
                        goto First;
                    }

                }
                else
                {
                    Console.Clear();
                    monster.MonsterStatusShow();
                    monster.MonsterTurn();
                    player.TakeDemage(monster);
                    ShowStatusAndInventory(player);
                    while (Key != "Enter")
                    {
                        c = Console.ReadKey();
                        Key = c.Key.ToString();
                    }
                    Key = null;
                    if (player.HP <= 0)
                    {
                        BattleFinish = false;
                        break;
                    }

                }

            }
        }

    }
    public class Player
    {
        public string Name;
        public int MaxHP;
        public int HP;
        public int MaxMP;
        public int MP;
        public int STR;
        public int Damage;
        public int DEX;
        public int Hit;
        public int INT;
        public int AttackNumber;
        public string[] SkillName;
        public List<string> Inventory = new List<string>();

        public virtual void NormalAttack()
        {

        }
        public virtual void HeavyAttack()
        {

        }
        public virtual int PlayerTurn(Monster monster, string Key)
        {
            int Num = 0;
            return Num;
        }
        public virtual void TakeDemage(Monster monster)
        {

        }
    }
    public class Warrior : Player
    {
        int Num = 0;
        int[] Nums = new int[2] { 1, 0 };
        public Warrior()
        {
            this.Name = "전사";
            this.MaxHP = 50;
            this.HP = MaxHP;
            this.MaxMP = 0;
            this.MP = MaxMP;
            this.STR = 7;
            this.DEX = 4;
            this.INT = 2;
            this.SkillName = new string[] { "횡베기\t\t\t\t\t\t|", "더 강한 횡베기\t\t\t\t\t|" };

        }
        public override void NormalAttack()
        {

            Console.WriteLine("|\t전사는 횡베기를 시전했다.\t\t\t|");
            Damage = STR * 2;
            Hit = DEX * 10;
            AttackNumber = 1;
        }
        public override void HeavyAttack()
        {

            Console.WriteLine("|\t전사는 힘을 모아 횡베기를 시전했다.\t\t|");
            Damage = STR * 4;
            Hit = DEX * 5;
            AttackNumber = 1;
        }

        public override void TakeDemage(Monster monster)
        {

            Random rand = new Random();
            if (4 * ((DEX * 5) - monster.Hit) > rand.Next(1, 101))
            {
                Console.WriteLine("|\t{0}는(은) {1}의 공격을 회피했습니다.  \t|", Name, monster.Name);
            }
            else
            {
                Console.WriteLine("|\t{0}는(은) {1}의 피해를 입었습니다.\t\t|", Name, monster.Damage);
                HP = HP - monster.Damage;
            }


        }

        public override int PlayerTurn(Monster monster, string Key)
        {

            if (Key != "Enter")
            {
                switch (Key)
                {
                    case "UpArrow":
                        if (Num != 0)
                        {
                            Nums[Num] = 0;
                            Nums[--Num] = 1;
                        }
                        break;
                    case "DownArrow":
                        if (Num != 1)
                        {
                            Nums[Num] = 0;
                            Nums[++Num] = 1;
                        }
                        break;

                }

            }

            Console.WriteLine(" =======================================================\n" +
                              "|\t\t\t\t\t\t\t|");
            Console.WriteLine("|\t어떤 행동을 하시겠습니까\t\t\t|");
            for (int i = 0; i < Nums.Length; i++)
            {
                switch (Nums[i])
                {
                    case 0:
                        Console.Write("|\t\t\t\t\t\t\t|\n|      ");
                        break;
                    case 1:
                        Console.Write("|\t\t\t\t\t\t\t|\n|   ▶ ");
                        break;
                    default:
                        break;
                }
                Console.WriteLine(SkillName[i]);
            }
            return Num;
        }

    }
    public class Thief : Player
    {
        int Num = 0;
        int[] Nums = new int[2] { 1, 0 };
        public Thief()
        {
            this.Name = "도적";
            this.MaxHP = 40;
            this.HP = MaxHP;
            this.MaxMP = 0;
            this.MP = MaxMP;
            this.STR = 3;
            this.DEX = 6;
            this.INT = 2;
            this.SkillName = new string[] { "한번 베기\t\t\t\t\t|", "두번 베기\t\t\t\t\t|" };

        }
        public override void NormalAttack()
        {

            Console.WriteLine("|\t도적은 한번 베기를 시전했다.\t\t\t|");
            Damage = STR * 2;
            Hit = DEX * 10;
            AttackNumber = 1;
        }

        public override void HeavyAttack()
        {

            Console.WriteLine("|\t도적은 빠른 속도로 두번 베기를 시전했다.\t|");
            Damage = STR * 2;
            Hit = DEX * 5;
            AttackNumber = 2;
        }

        public override void TakeDemage(Monster monster)
        {

            Random rand = new Random();
            if (4 * ((DEX * 5) - monster.Hit) > rand.Next(1, 101))
            {
                Console.WriteLine("|\t{0}는(은) {1}의 공격을 회피했습니다.  \t|", Name, monster.Name);
            }
            else
            {
                Console.WriteLine("|\t{0}는(은) {1}의 피해를 입었습니다.\t\t|", Name, monster.Damage);
                HP = HP - monster.Damage;
            }
        }

        public override int PlayerTurn(Monster monster, string Key)
        {

            if (Key != "Enter")
            {
                switch (Key)
                {
                    case "UpArrow":
                        if (Num != 0)
                        {
                            Nums[Num] = 0;
                            Nums[--Num] = 1;
                        }
                        break;
                    case "DownArrow":
                        if (Num != 1)
                        {
                            Nums[Num] = 0;
                            Nums[++Num] = 1;
                        }
                        break;

                }

            }

            Console.WriteLine(" =======================================================\n" +
                              "|\t\t\t\t\t\t\t|");
            Console.WriteLine("|\t어떤 행동을 하시겠습니까\t\t\t|");
            for (int i = 0; i < Nums.Length; i++)
            {
                switch (Nums[i])
                {
                    case 0:
                        Console.Write("|\t\t\t\t\t\t\t|\n|      ");
                        break;
                    case 1:
                        Console.Write("|\t\t\t\t\t\t\t|\n|   ▶ ");
                        break;
                    default:
                        break;
                }
                Console.WriteLine(SkillName[i]);
            }
            return Num;
        }

    }
    public class Wizard : Player
    {
        int Num = 0;
        int[] Nums = new int[2] { 1, 0 };
        public Wizard()
        {
            this.Name = "마법사";
            this.MaxHP = 30;
            this.HP = MaxHP;
            this.MaxMP = 20;
            this.MP = MaxMP;
            this.STR = 2;
            this.DEX = 3
                ;
            this.INT = 5;
            this.SkillName = new string[] { "스태프 휘두르기\t\t\t\t\t|", "마나탄 발사\t\t\t\t\t|" };
        }
        public override void NormalAttack()
        {

            Console.WriteLine("|\t마법사은 스태프 휘두르기를 시전했다.\t\t|");
            Damage = STR * 2;
            Hit = DEX * 20;
            AttackNumber = 1;
        }

        public override void HeavyAttack()
        {
            if (MP <= 0)
            {
                Console.WriteLine("|\t마나탄을 발사할려고 했지만 마나가 없습니다.\t|");
                Damage = 0;
            }
            else
            {
                Console.WriteLine("|\t마법사는 마나를 모아 마나탄 발사를 시전했다.\t|");
                Damage = INT * 3;
                Hit = DEX * 10;
                MP = MP - 5;
                AttackNumber = 1;
            }

        }

        public override void TakeDemage(Monster monster)
        {

            Random rand = new Random();
            if (4 * ((DEX * 5) - monster.Hit) > rand.Next(1, 101))
            {
                Console.WriteLine("|\t{0}는(은) {1}의 공격을 회피했습니다.\t|", Name, monster.Name);
            }
            else
            {
                Console.WriteLine("|\t{0}는(은) {1}의 피해를 입었습니다.\t\t|", Name, monster.Damage);
                HP = HP - monster.Damage;
            }

        }

        public override int PlayerTurn(Monster monster, string Key)
        {

            if (Key != "Enter")
            {
                switch (Key)
                {
                    case "UpArrow":
                        if (Num != 0)
                        {
                            Nums[Num] = 0;
                            Nums[--Num] = 1;
                        }
                        break;
                    case "DownArrow":
                        if (Num != 1)
                        {
                            Nums[Num] = 0;
                            Nums[++Num] = 1;
                        }
                        break;

                }

            }

            Console.WriteLine(" =======================================================\n" +
                              "|\t\t\t\t\t\t\t|");
            Console.WriteLine("|\t어떤 행동을 하시겠습니까\t\t\t|");
            for (int i = 0; i < Nums.Length; i++)
            {
                switch (Nums[i])
                {
                    case 0:
                        Console.Write("|\t\t\t\t\t\t\t|\n|      ");
                        break;
                    case 1:
                        Console.Write("|\t\t\t\t\t\t\t|\n|   ▶ ");
                        break;
                    default:
                        break;
                }
                Console.WriteLine(SkillName[i]);
            }
            return Num;

        }
    }



    public class Monster
    {
        public string Name;
        public int MaxHP;
        public int HP;
        public int STR;
        public int Damage;
        public int DEX;
        public int Hit;
        public string Item;

        public void MonsterNormalAttack()
        {
            Console.WriteLine("|\t{0}가(이) 일반 공격을 시도합니다.\t\t|", Name);
            Damage = STR * 1;
            Hit = DEX * 10;
        }
        public void MonsterHeavyAttack()
        {
            Console.WriteLine("|\t{0}가(이) 강한 공격을 시도합니다.\t\t|", Name);
            Damage = STR * 2;
            Hit = DEX * 5;
        }
        public void MonsterTakeDemage(Player player)
        {
            Random rand = new Random();

            List<int> ints = new List<int>();
            for (int i = 0; i < player.AttackNumber; i++)
            {
                if (4 * ((DEX * 10) - player.Hit) > rand.Next(1, 101))
                {
                    ints.Add(0);
                    //Console.WriteLine("|\t{0}는(은) {1}의 공격을 회피했습니다.  \t|", Name, player.Name);
                }
                else
                {
                    HP = HP - player.Damage;
                    if (HP < 0)
                    {
                        HP = 0;
                    }
                    ints.Add(1);
                    //Console.WriteLine("|\t{0}는(은) {1}의 피해를 입었습니다.\t\t|", Name, player.Damage);

                }
            }
            MonsterStatusShow();
            for (int i = 0; i < player.AttackNumber; i++)
            {
                if (ints[0] == 0)
                {
                    Console.WriteLine("|\t{0}는(은) {1}의 공격을 회피했습니다.  \t|", Name, player.Name);
                    ints.RemoveAt(0);
                }
                else if (ints[0] == 1)
                {
                    Console.WriteLine("|\t{0}는(은) {1}의 피해를 입었습니다.\t\t|", Name, player.Damage);
                    ints.RemoveAt(0);
                }

            }
        }
        public void MonsterTurn()
        {


            Random rand = new Random();
            int x = rand.Next(1, 101);
            if (x > 80)
            {
                MonsterNormalAttack();
            }
            else
            {
                MonsterHeavyAttack();
            }
        }

        public void MonsterStatusShow()
        {

            Console.WriteLine("{0} :몬스터", Name);
            Console.WriteLine("{0}/{1}: MAXHP/HP", MaxHP, HP);
            Console.Write("{" + STR + ":힘}\n{" + DEX + ":민첩}");
            Console.WriteLine("\n =======================================================\n" +
                              "|\t\t\t\t\t\t\t|");
        }
    }

    public class Slim : Monster
    {
        public Slim()
        {
            this.Name = "슬라임";
            this.MaxHP = 10;
            this.HP = MaxHP;
            this.STR = 1;
            this.DEX = 2;
            this.Item = "미끄러운 점액";
        }
    }
    public class Wolf : Monster
    {
        public Wolf()
        {
            this.Name = "늑대";
            this.MaxHP = 15;
            this.HP = MaxHP;
            this.STR = 2;
            this.DEX = 3;
            this.Item = "늑대의 가죽";
        }
    }
    public class Goblin : Monster
    {
        public Goblin()
        {
            this.Name = "고블린";
            this.MaxHP = 20;
            this.HP = MaxHP;
            this.STR = 3;
            this.DEX = 4;
            this.Item = "고블린 장신구";
        }
    }
    public class Bandit : Monster
    {
        public Bandit()
        {
            this.Name = "산적";
            this.MaxHP = 30;
            this.HP = MaxHP;
            this.STR = 4;
            this.DEX = 5;
            this.Item = "산적의 두건";
        }
    }
}
