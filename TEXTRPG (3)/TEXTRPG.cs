using System.Numerics;
using System.Runtime.ExceptionServices;

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
            Acheck1 = BigChance + 5 * (player.STR - 5);
            Bcheck = Chance + 7 * (player.DEX - 5);


            string[] EventSelect = new string[3] { "A.주먹으로 바위를 친다{힘 필요}(성공확률:{" + Acheck.ToString() + "}%)", "B.피한다{민첩 필요}(성공확률:{" + Bcheck.ToString() + "}%)", "C.지켜본다." };
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            bool EventEnd = true;
            ConsoleKeyInfo c;
            string Key = null;
            while (EventEnd)
            {
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n==================================================");
                Console.WriteLine("\n\t당신 머리위로 바위가 떨어지고 있습니다.\n\t뭔가 하지 않으면 피해를 입습니다.");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("\n\t   ");
                            break;
                        case 1:
                            Console.Write("\n\t ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);
                }
                Console.WriteLine("\n==================================================");

                if (Key == "Enter")
                {
                    switch (Num)
                    {
                        case 0:

                            if (Acheck > rand.Next(1, 101))
                            {
                                if (Acheck1 > rand.Next(1, 101))
                                {
                                    Console.WriteLine("\t대성공!!!\n\t당신은 아무런 피해없이 바위를 파괴했습니다.");
                                }
                                else
                                {
                                    Console.WriteLine("\t성공!\n\t당신은 바위를 파괴하는데 성공했습니다. 하지만 피해가 없지는 않군요\n\t(힘이 1 감소합니다.)");
                                    --status[0];
                                    --player.STR;
                                }

                            }
                            else
                            {
                                Console.WriteLine("\t아... 바위를 부수기에는 힘이 부족했습니다.\n\t(체력이 10 감소합니다.)");
                                player.HP = player.HP - 10;
                            }
                            break;
                        case 1:
                            if (Bcheck > rand.Next(1, 101))
                            {
                                Console.WriteLine("\t성공!\n\t당신은 신속하게 바위를 피하는데 성공했습니다.");
                            }
                            else
                            {
                                Console.WriteLine("\t아... 바위를 피하기에는 너무 느렸습니다.\n\t(체력이 10 감소합니다.)");
                                player.HP = player.HP - 10;
                            }
                            break;
                        case 2:
                            Console.WriteLine("\t당신은 그냥 바위를 맞았습니다.\n\t(체력이 10 감소합니다.)");
                            player.HP = player.HP - 10;
                            break;
                        default:
                            Console.WriteLine("\t잘못된 선택으로 바위를 맞았습니다.\n\t(체력이 10 감소합니다.)");
                            player.HP = player.HP - 10;
                            break;
                    }
                    Console.WriteLine("\n==================================================");
                    EventEnd = false;
                    Key = null;
                }

                Console.WriteLine("당신의 캐릭터:{0}", player.Name);
                Console.WriteLine("MAXHP/HP: {0}/{1}", player.HP, player.MaxHP);
                Console.WriteLine("MAXMP/MP: {0}/{1}", player.MP, player.MaxMP);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("{" + statusname[i] + ":" + status[i].ToString() + "}\n");
                }
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
            string[] EventSelect = new string[3] { "A.샘물을 마셔본다.", "B.샘물로 몸을 씻는다.", "C.샘물을 챙긴다." };
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
                Console.WriteLine("\n==================================================");
                Console.WriteLine("\n\t당신은 요정의 샘을 발견했습니다.\n\t어떻게 하시겠습니까.");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("\n\t   ");
                            break;
                        case 1:
                            Console.Write("\n\t ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);
                }

                Console.WriteLine("\n==================================================");

                if (Key == "Enter")
                {

                    switch (Num)
                    {
                        case 0:
                            Console.WriteLine("\t요정의 샘물을 마신 당신의 지능이 올라갑니다.");
                            ++status[2];
                            ++player.INT;
                            break;

                        case 1:
                            Console.WriteLine("\t요정의 샘물로 몸을 씻으니 상처가 회복됩니다.");
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
                                    Console.WriteLine("\t당신은 요정의 샘물을 얻었습니다.");
                                    player.Inventory.Add("요정의 샘물");
                                    //player.Inventory.Add(String.Format("요정의 샘물{0}", count));
                                    Drop = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\t인벤토리가 가득차서 무언가를 버려야 합니다.");
                                Console.WriteLine("\t어떤것을 버리겠습니까?(1,2,3,4,5,6 중에 선택)");
                                if (Drop)
                                {
                                    player.Inventory.Add("요정의 샘물");
                                    //player.Inventory.Add(String.Format("요정의 샘물{0}", count));
                                }

                                if (Drop == false)
                                {
                                    if (DropItem != null)
                                    {
                                        Console.WriteLine("\t인벤토리의 \'{0}\' 아이템을 버립니다.", DropItem);
                                    }

                                }
                                Drop = false;
                            }



                            break;

                    }

                    Console.WriteLine("\n==================================================");
                    EventEnd = false;


                }
                Console.WriteLine("당신의 캐릭터:{0}", player.Name);
                Console.WriteLine("MAXHP/HP: {0}/{1}", player.HP, player.MaxHP);
                Console.WriteLine("MAXMP/MP: {0}/{1}", player.MP, player.MaxMP);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("{" + statusname[i] + ":" + status[i].ToString() + "}\n");
                }

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
            string[] EventSelect = new string[3] { "A.불을 끄기위해 노력한다.", "B.물을 부어 불을 끈다.(요정의 샘물 필요)", "C.불은 불일 뿐, 신경 쓰지 않고 지나간다." };
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            bool EventEnd = true;
            ConsoleKeyInfo c;
            string Key = null;
            while (EventEnd)
            {
                EventUnlock = 1;
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n==================================================");
                Console.WriteLine("당신은 산길을 가던중 불이 피어오르는 것을 발견했습니다.\n어떻게 하시겠습니까?");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("\n\t   ");
                            break;
                        case 1:
                            Console.Write("\n\t ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);
                }
                Console.WriteLine("\n==================================================");

                if (Key == "Enter")
                {
                    switch (Num)
                    {
                        case 0:
                            player.HP = player.HP - 5;
                            if (player.HP <= 0)
                            {
                                Console.WriteLine("당신은 몸도 성치 않은데 불을 끌려고 하다가 전신에 불이 붙고 타죽고 말았습니다.\n정말 허무한 죽음이네요..");
                            }
                            else
                            {
                                Console.WriteLine("당신은 불을 끄기 위해 노력하였고 불을 끄는데 성공 하였습니다.\n하지만 불을 끄는 과정에서 조금의 화상을 입고 말았습니다.");
                                Console.WriteLine("(HP가 5 감소합니다.)");
                            }
                            EventEnd = false;
                            break;
                        case 1:
                            if (player.Inventory.Contains("요정의 샘물") == true)
                            {
                                Console.WriteLine("당신은 요정의 샘물을 사용하여 불을 끄는데 성공 하였습니다.");
                                player.Inventory.Remove("요정의 샘물");
                                EventEnd = false;
                            }
                            else
                            {
                                Console.WriteLine("당신은 요정의 샘물을 가지고 있지 않습니다. 다른 선택지를 고르세요");
                            }
                            break;
                        case 2:
                            Console.WriteLine("당신은 산에난 불을 보고도 그냥 지나쳐 갑니다.\n그 선택이 어떠한 결과를 가져올지도 모른체...");
                            EventUnlock = EventUnlock * 2;                          // 거대한 불 이벤트
                            EventEnd = false;
                            break;
                    }
                    Console.WriteLine("\n==================================================");
                    Key = null;
                }
                Console.WriteLine("당신의 캐릭터:{0}", player.Name);
                Console.WriteLine("MAXHP/HP: {0}/{1}", player.HP, player.MaxHP);
                Console.WriteLine("MAXMP/MP: {0}/{1}", player.MP, player.MaxMP);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("{" + statusname[i] + ":" + status[i].ToString() + "}\n");
                }
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
            string[] EventSelect = new string[3] { "A.어쩔수 없다. 빠르게 불길을 돌파한다.", "B.물을 부어 몸을 젹시고 빠르게 빠져나간다.", "C.불길 속에도 길이 있다. 정신을 집중하고 길을 찾는다.{지혜 필요}(성공확률:{" + Acheck.ToString() + "}" };
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            bool EventEnd = true;
            ConsoleKeyInfo c;
            string Key = null;
            while (EventEnd)
            {
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n==================================================");
                Console.WriteLine("당신은 지금 거대한 불길 속에 갇히고 말았습니다.\n과거에 끄지 않고 지나쳤던 불이 거대한 불이 되어 이런 일이 발생한 것 같습니다.\n어떻게 하시겠습니까?");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("\n\t   ");
                            break;
                        case 1:
                            Console.Write("\n\t ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);
                }
                Console.WriteLine("\n==================================================");
                if (Key == "Enter")
                {
                    switch (Num)
                    {
                        case 0:
                            player.HP = player.HP - 15;
                            if (player.HP <= 0)
                            {
                                Console.WriteLine("당신은 거대한 불길 속에서 어떻게든 살아남고자 노력했지만\n결국 거대한 불길에 삼켜져 죽고 말았습니다.");
                                Console.WriteLine("하지만 어쩌겠어요. 불이 난 것을 보고도 그냥 지나친 당신의 잘못 아니겠습니까.\n자업자득이네요.");
                            }
                            Console.WriteLine("당신을 운이 좋게도 거대한 불길 속에서 빠르게 탈출하여 살아남았습니다.\n하지만 몸에 많은 화상을 남기는 것을 피할 수는 없었습니다.");
                            Console.WriteLine("(HP가 15 감소합니다.)");
                            EventEnd = false;
                            break;
                        case 1:
                            if (player.Inventory.Contains("요정의 샘물") == true)
                            {
                                player.HP = player.HP - 5;
                                if (player.HP <= 0)
                                {
                                    Console.WriteLine("당신은 요정의 샘물로 몸을 적셔 거대한 불길에서 빠져 나오기위해 노력했지만\n이미 너무 많은 상처를 가지고 있던 당신에게 불길을 빠져나오는 것은 쉬운 일이 아니였습니다.\n정말 허무한 죽음이네요..");
                                }
                                else
                                {
                                    Console.WriteLine("당신은 요정의 샘물로 몸을 적셔 거대한 불길에서 빠져 나왔습니다.\n조금의 화상을 입었지만 살아남은 게 어딥니까");
                                }

                                player.Inventory.Remove("요정의 샘물");
                                EventEnd = false;
                            }
                            else
                            {
                                Console.WriteLine("당신은 요정의 샘물을 가지고 있지 않습니다. 다른 선택지를 고르세요");
                            }
                            break;
                        case 2:
                            if (Acheck > rand.Next(1, 101))
                            {
                                Console.WriteLine("성공!\n당신은 명석한 머리로 불길에서 탈출로를 찾아냈고\n피해 없이 불길에서 빠져 나왔습니다.");
                            }
                            else
                            {
                                player.HP = player.HP - 15;
                                if (player.HP <= 0)
                                {
                                    Console.WriteLine("실패...\n당신은 불길속에서 탈출로를 찾는데 실패하였고\n결국 거대한 불길에 삼켜져 죽고 말았습니다.");
                                    Console.WriteLine("하지만 어쩌겠어요. 불이 난 것을 보고도 그냥 지나친 당신의 잘못 아니겠습니까.\n자업자득이네요.");
                                }
                                else
                                {
                                    Console.WriteLine("실패...\n당신은 불길속에서 탈출로를 찾는데 실패하였고\n몸에 많은 화상을 남기는 것을 피할 수는 없었습니다.");
                                    Console.WriteLine("(HP가 15 감소합니다.)");

                                }
                            }
                            EventEnd = false;
                            break;
                    }
                    Console.WriteLine("\n==================================================");
                    Key = null;
                }
                Console.WriteLine("당신의 캐릭터:{0}", player.Name);
                Console.WriteLine("MAXHP/HP: {0}/{1}", player.HP, player.MaxHP);
                Console.WriteLine("MAXMP/MP: {0}/{1}", player.MP, player.MaxMP);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("{" + statusname[i] + ":" + status[i].ToString() + "}\n");
                }
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
            string[] EventSelect = new string[3] { "A.불쌍한 노인이다. 집까지 데려다준다.", "B.저 노인이 가지고 있는 물건이 탐이 난다. 물건을 빼앗자", "C.내 코가 석 자인데, 노인을 도울 여력이 어디 있는가, 그냥 지나친다." };
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            bool EventEnd = true;
            ConsoleKeyInfo c;
            string Key = null;
            EventUnlock = 1;
            while (EventEnd)
            {
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n==================================================");
                Console.WriteLine("당신은 길 건너편에서 길을 해메고 있는 노인을 발견했습니다.\n노인의 손에는 몸에 좋다는 식물이 들려있습니다.\n어떻게 하시겠습니까?");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("\n\t   ");
                            break;
                        case 1:
                            Console.Write("\n\t ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);
                }
                Console.WriteLine("\n==================================================");
                if (Key == "Enter")
                {
                    switch (Num)
                    {
                        case 0:
                            Console.WriteLine("당신은 노인을 도와 노인이 집에 찾아갈 수 있게 도와주었습니다.\n노인은 이 은혜를 잊지 않을 것이라고 말했습니다.");
                            EventUnlock = EventUnlock * 3;
                            EventEnd = false;
                            break;
                        case 1:
                            Console.WriteLine("당신은 노인에게서 몸에 좋다는 식물을 빼았아 먹어버리고, 달아났습니다.\n저 멀리서 노인이 이 원한을 잊지 않을 것이라고 소리칩니다.");
                            Console.WriteLine("(힘이 1 상승합니다.)");
                            ++player.STR;
                            ++status[0];
                            EventUnlock = EventUnlock * 5;
                            EventEnd = false;
                            break;
                        case 2:
                            Console.WriteLine("당신은 노인을 지나치고 자신이 갈 길을 걷습니다.");
                            EventEnd = false;
                            break;
                    }
                    Console.WriteLine("\n==================================================");
                    Key = null;
                }
                Console.WriteLine("당신의 캐릭터:{0}", player.Name);
                Console.WriteLine("MAXHP/HP: {0}/{1}", player.HP, player.MaxHP);
                Console.WriteLine("MAXMP/MP: {0}/{1}", player.MP, player.MaxMP);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("{" + statusname[i] + ":" + status[i].ToString() + "}\n");
                }
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
            int Acheck, Acheck1, Bcheck;
            Random rand = new Random();
            Acheck = Chance + 7 * (player.STR - 5);
            Bcheck = Chance + 7 * (player.DEX - 5);
            string[] EventSelect = new string[3] { "A.산적을 위협하여 도망가게 한다.{힘 필요}(성공확률:{" + Acheck.ToString() + "}%)", "B.산적에게서 빠르게 도망친다.{민첩 필요}(성공확률:{" + Bcheck.ToString() + "}%)", "C.미끄러운 점액을 던지고, 도망친다." };
            int[] SelectNumber = new int[3] { 1, 0, 0 };
            int Num = 0;
            bool EventEnd = true;
            bool BattleStart = false;
            ConsoleKeyInfo c;
            string Key = null;
            while (EventEnd)
            {
                Console.WriteLine("\n{0}일차", count);
                Console.WriteLine("\n==================================================");
                Console.WriteLine("당신은 길을 걷던중 갑작스럽게 산적과 조우하게 되었습니다.\n어떻게 하시겠습니까?");
                for (int i = 0; i < SelectNumber.Length; i++)
                {
                    switch (SelectNumber[i])
                    {
                        case 0:
                            Console.Write("\n\t   ");
                            break;
                        case 1:
                            Console.Write("\n\t ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(EventSelect[i]);
                }
                Console.WriteLine("\n==================================================");
                if (Key == "Enter")
                {
                    if (eventcheck % 3 == 0)
                    {
                        Console.WriteLine("\"잠깐! 당신 생김새를 보니 우리 아버지에게 도움을 주신 분인 것 같은데?\"");
                        Console.WriteLine("산적은 과거 당신이 도와준 노인의 아들이였습니다.\n 산적은 그 은혜에 보답하여 당신을 그냥 보내줍니다.");
                        EventEnd = false;
                        eventcheck = eventcheck / 3;
                    }
                    else
                    {
                        switch (Num)
                        {
                            case 0:
                                if (Acheck > rand.Next(1, 101))
                                {
                                    Console.WriteLine("성공!\n산적은 당신의 위협에 겁을 먹고 도망쳐 버렸습니다.");
                                }
                                else
                                {
                                    Console.WriteLine("실패..\n산적은 당신의 위협을 비웃고 칼을 뽑아 듭니다.\n - 전투 시작 -");
                                    BattleStart = true;
                                }
                                EventEnd = false;
                                break;
                            case 1:
                                if (Bcheck > rand.Next(1, 101))
                                {
                                    Console.WriteLine("성공!\n당신은 빠른발로 산적에게서 도망쳤습니다.");
                                }
                                else
                                {
                                    Console.WriteLine("실패..\n당신은 산적에서 도망치는데 실패했습니다. 산적이 칼을 뽑아 듭니다.\n - 전투 시작 -");
                                    BattleStart = true;
                                }
                                EventEnd = false;
                                break;
                            case 2:
                                if (player.Inventory.Contains("미끄러운 점액") == true)
                                {
                                    Console.WriteLine("당신은 미끄러운 점액을 산적에게 던졌고, 산적은 미끄러운 점액 때문에 도망치는 당신을 따라가지 못합니다.");
                                    player.Inventory.Remove("미끄러운 점액");
                                    EventEnd = false;
                                }
                                else
                                {
                                    Console.WriteLine("당신은 미끄러운 점액을 가지고 있지 않습니다. 다른 선택지를 고르세요");
                                }
                                break;
                        }
                    }

                    Console.WriteLine("\n==================================================");
                    Key = null;
                }
                Console.WriteLine("당신의 캐릭터:{0}", player.Name);
                Console.WriteLine("MAXHP/HP: {0}/{1}", player.HP, player.MaxHP);
                Console.WriteLine("MAXMP/MP: {0}/{1}", player.MP, player.MaxMP);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("{" + statusname[i] + ":" + status[i].ToString() + "}\n");
                }
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
                    Monster monster = new Bandit();
                    battle(player, monster);
                }
            }
        }
        public void num7(Player player) // 숲속의 생명체(전투 이벤트)
        {
            
        }
        public void num8(Player player) // 고블린과의 거래(일반 이벤트, 전투 이벤트,아이템 사용(늑대의 가죽))
        {

        }
        public void num9(Player player) // 함정이 설치된 장신구 걸이(일반 이벤트, 아이템 사용(고블린 장신구),한번만 나옴)
        {

        }
        public void num10(Player player) // 행상인과의 거래(일반 이벤트,아이템 사용(늑대 가죽, 산적의 두건))
        {

        }
        public void ShowStatusAndInventory(Player player)
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("당신의 캐릭터:{0}", player.Name);
            Console.WriteLine("MAXHP/HP: {0}/{1}", player.HP, player.MaxHP);
            Console.WriteLine("MAXMP/MP: {0}/{1}", player.MP, player.MaxMP);
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


        public void battle(Player player, Monster monster)
        {
            int[] status = new int[] { player.STR, player.DEX, player.INT };
            bool BattleFinish = true;
            bool Drop = true;
            string DropItem = null;
            Random rand = new Random();
            Console.WriteLine("\n==================================================\n\n\n");
            Console.WriteLine("\t몬스터 {0}와 의 전투를 시작합니다.", monster.Name);
            Console.WriteLine("\n\n\n==================================================\n");
            ConsoleKeyInfo c;
            ConsoleKeyInfo Numc;
            string Key = null;
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
                
                player.PlayerTurn();
                monster.MonsterTakeDemage(player);
                ShowStatusAndInventory(player);
                while (Key != "Enter")
                {
                    c = Console.ReadKey();
                    Key = c.Key.ToString();
                }
                Key = null;
                Console.Clear();
                if (monster.HP <= 0)
                {
                First:
                    Console.WriteLine("\n==================================================\n\n\n");
                    Console.WriteLine("\t당신은 몬스터 {0}를 잡았습니다.", monster.Name);
                    BattleFinish = false;
                    if(60>rand.Next(1,60))
                    {
                        Console.WriteLine("\t{0}을(를) 얻었습니다.", monster.Item);
                        Console.WriteLine("\n\n");
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
                            Console.WriteLine("\t인벤토리가 가득차서 무언가를 버려야 합니다.");
                            Console.WriteLine("\t어떤것을 버리겠습니까?(1,2,3,4,5,6 중에 선택)");
                            if (Drop)
                            {
                                player.Inventory.Add(monster.Item);
                            }

                            if (Drop == false)
                            {
                                if (DropItem != null)
                                {
                                    Console.WriteLine("\t인벤토리의 \'{0}\' 아이템을 버립니다.", DropItem);
                                }

                            }
                            Console.WriteLine("\n\n");
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
                    //BattleFinish = false;
                    //while (Key != "Enter")
                    //{
                    //    c = Console.ReadKey();
                    //    Key = c.Key.ToString();
                    //}
                    //Key = null;
                    
                }
                else
                {
                    
                    
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
                    //else
                    //{
                    //    while (Key != "Enter")
                    //    {
                    //        c = Console.ReadKey();
                    //        Key = c.Key.ToString();
                    //    }
                    //    Key = null;

                    //}
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
        public virtual void PlayerTurn()
        {
        }
        public virtual void TakeDemage(Monster monster)
        {

        }
    }
    public class Warrior : Player
    {
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
            this.SkillName = new string[] { "횡베기", "더 강한 횡베기" };

        }
        public void NormalAttack()
        {
            Console.WriteLine("\n==================================================\n\n\n");
            Console.WriteLine("\t전사는 횡베기를 시전했다.");
            Damage = STR * 2;
            Hit = DEX * 10;
            AttackNumber = 1;
        }
        public void HeavyAttack()
        {
            Console.WriteLine("\n==================================================\n\n\n");
            Console.WriteLine("\t전사는 힘을 모아 횡베기를 시전했다.");
            Damage = STR * 4;
            Hit = DEX * 5;
            AttackNumber = 1;
        }

        public override void TakeDemage(Monster monster)
        {

            Random rand = new Random();
            if (4 * ((DEX * 5) - monster.Hit) > rand.Next(1, 101))
            {
                Console.WriteLine("\t{0}는(은) {1}의 공격을 회피 하였습니다.", Name, monster.Name);
            }
            else
            {
                Console.WriteLine("\t{0}는(은) {1}의 피해를 입었습니다.", Name, monster.Damage);
                HP = HP - monster.Damage;
            }
            if (HP > 0)
            {
                Console.Write("\t{0}의 현재 남은 HP:{1}", Name, HP);
                for (int i = (HP / 10) + 1; i > 0; i--)
                {
                    Console.Write("■");
                }
            }
            else
            {
                HP = 0;
                Console.Write("\t{0}의 현재 남은 HP:{1}\n", Name, HP);
            }
            Console.WriteLine("\n\n");
        }

        public override void PlayerTurn()
        {

            int Num = 0;
            int[] Nums = new int[2] { 1, 0 };


            ConsoleKeyInfo c;
            string Key;
            bool turnEnd = true;
            while (turnEnd)
            {
                Console.Clear();
                Console.WriteLine("\n==================================================\n\n\n");
                Console.WriteLine("\t어떤 행동을 하시겠습니까");
                for (int i = 0; i < Nums.Length; i++)
                {
                    switch (Nums[i])
                    {
                        case 0:
                            Console.Write("\n\t   ");
                            break;
                        case 1:
                            Console.Write("\n\t ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(SkillName[i]);
                }
                Console.WriteLine("\n\n\n==================================================\n");
                Console.WriteLine("당신의 캐릭터:{0}", Name);
                Console.WriteLine("MAXHP/HP: {0}/{1}", HP, MaxHP);
                Console.WriteLine("MAXMP/MP: {0}/{1}", MP, MaxMP);

                Console.Write("{힘:" + STR + "}\n{민첩:" + DEX + "}\n{지혜:" + INT + "}\n");
                Console.Write("인벤토리: ");

                for (int i = 0; i < Inventory.Count; i++)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("{0}.{1}", i + 1, Inventory[i]);
                    }
                    else
                    {

                        Console.WriteLine("          {0}.{1}", i + 1, Inventory[i]);
                    }
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
                    Key = null;
                }
                else if (Key == "Enter")
                {
                    Console.Clear();
                    switch (Num)
                    {
                        case 0:
                            NormalAttack();
                            break;
                        case 1:
                            HeavyAttack();
                            break;
                        default:
                            break;
                    }
                    Key = null;
                    turnEnd = false;
                }
            }

        }

    }
    public class Thief : Player
    {
        public Thief()
        {
            this.Name = "도적";
            this.MaxHP = 40;
            this.HP = MaxHP;
            this.MaxMP = 0;
            this.MP = MaxMP;
            this.STR = 4;
            this.DEX = 7;
            this.INT = 2;
            this.SkillName = new string[] { "한번 베기", "두번 베기" };

        }
        public void NormalAttack()
        {
            Console.WriteLine("\n==================================================\n\n\n");
            Console.WriteLine("\t도적은 한번 베기를 시전했다.");
            Damage = STR * 2;
            Hit = DEX * 10;
            AttackNumber = 1;
        }

        public void HeavyAttack()
        {
            Console.WriteLine("\n==================================================\n\n\n");
            Console.WriteLine("\t도적은 빠른 속도로 두번 베기를 시전했다.");
            Damage = STR * 2;
            Hit = DEX * 5;
            AttackNumber = 2;
        }
        
        public override void TakeDemage(Monster monster)
        {

            Random rand = new Random();
            if (4 * ((DEX * 5) - monster.Hit) > rand.Next(1, 101))
            {
                Console.WriteLine("\t{0}는(은) {1}의 공격을 회피 하였습니다.", Name, monster.Name);
            }
            else
            {
                Console.WriteLine("\t{0}는(은) {1}의 피해를 입었습니다.", Name, monster.Damage);
                HP = HP - monster.Damage;
            }
            if (HP > 0)
            {
                Console.Write("\t{0}의 현재 남은 HP:{1}", Name, HP);
                for (int i = (HP / 10) + 1; i > 0; i--)
                {
                    Console.Write("■");
                }
            }
            else
            {
                HP = 0;
                Console.Write("\t{0}의 현재 남은 HP:{1}\n", Name, HP);
            }
            Console.WriteLine("\n\n");
        }

        public override void PlayerTurn()
        {

            int Num = 0;
            int[] Nums = new int[2] { 1, 0 };
            

            ConsoleKeyInfo c;
            string Key;
            bool turnEnd = true;
            while (turnEnd)
            {
                Console.Clear();
                Console.WriteLine("\n==================================================\n\n\n");
                Console.WriteLine("\t어떤 행동을 하시겠습니까");
                for (int i = 0; i < Nums.Length; i++)
                {
                    switch (Nums[i])
                    {
                        case 0:
                            Console.Write("\n\t   ");
                            break;
                        case 1:
                            Console.Write("\n\t ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(SkillName[i]);
                }
                Console.WriteLine("\n\n\n==================================================\n");
                Console.WriteLine("당신의 캐릭터:{0}", Name);
                Console.WriteLine("MAXHP/HP: {0}/{1}", HP, MaxHP);
                Console.WriteLine("MAXMP/MP: {0}/{1}", MP, MaxMP);

                Console.Write("{힘:" + STR + "}\n{민첩:" + DEX + "}\n{지혜:" + INT + "}\n");
                Console.Write("인벤토리: ");

                for (int i = 0; i < Inventory.Count; i++)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("{0}.{1}", i + 1, Inventory[i]);
                    }
                    else
                    {

                        Console.WriteLine("          {0}.{1}", i + 1, Inventory[i]);
                    }
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
                    Key = null;
                }
                else if (Key == "Enter")
                {
                    Console.Clear();
                    switch (Num)
                    {
                        case 0:
                            NormalAttack();
                            break;
                        case 1:
                            HeavyAttack();
                            break;
                        default:
                            break;
                    }
                    Key = null;
                    turnEnd = false;
                }
            }

        }

    }
    public class Wizard : Player
    {
        public Wizard()
        {
            this.Name = "마법사";
            this.MaxHP = 30;
            this.HP = MaxHP;
            this.MaxMP = 20;
            this.MP = MaxMP;
            this.STR = 2;
            this.DEX = 4;
            this.INT = 7;
            this.SkillName = new string[] { "스태프 휘두르기", "마나탄 발사" };
        }
        public void NormalAttack()
        {
            Console.WriteLine("\n==================================================\n\n\n");
            Console.WriteLine("\t마법사은 스태프 휘두르기를 시전했다.");
            Damage = STR * 2;
            Hit = DEX * 10;
            AttackNumber = 1;
        }

        public void HeavyAttack()
        {
            Console.WriteLine("\n==================================================\n\n\n");
            Console.WriteLine("\t마법사는 마나를 모아 마나탄 발사를 시전했다.");
            Damage = INT * 3;
            Hit = DEX * 5;
            AttackNumber = 1;
        }

        public override void TakeDemage(Monster monster)
        {

            Random rand = new Random();
            if (4 * ((DEX * 5) - monster.Hit) > rand.Next(1, 101))
            {
                Console.WriteLine("\t{0}는(은) {1}의 공격을 회피 하였습니다.", Name, monster.Name);
            }
            else
            {
                Console.WriteLine("\t{0}는(은) {1}의 피해를 입었습니다.", Name, monster.Damage);
                HP = HP - monster.Damage;
            }
            if (HP > 0)
            {
                Console.Write("\t{0}의 현재 남은 HP:{1}", Name, HP);
                for (int i = (HP / 10) + 1; i > 0; i--)
                {
                    Console.Write("■");
                }
            }
            else
            {
                HP = 0;
                Console.Write("\t{0}의 현재 남은 HP:{1}\n", Name, HP);
            }
            Console.WriteLine("\n\n");
        }

        public override void PlayerTurn()
        {

            int Num = 0;
            int[] Nums = new int[2] { 1, 0 };


            ConsoleKeyInfo c;
            string Key;
            bool turnEnd = true;
            while (turnEnd)
            {
                Console.Clear();
                Console.WriteLine("\n==================================================\n\n\n");
                Console.WriteLine("\t어떤 행동을 하시겠습니까");
                for (int i = 0; i < Nums.Length; i++)
                {
                    switch (Nums[i])
                    {
                        case 0:
                            Console.Write("\n\t   ");
                            break;
                        case 1:
                            Console.Write("\n\t ▶ ");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(SkillName[i]);
                }
                Console.WriteLine("\n\n\n==================================================\n");
                Console.WriteLine("당신의 캐릭터:{0}", Name);
                Console.WriteLine("MAXHP/HP: {0}/{1}", HP, MaxHP);
                Console.WriteLine("MAXMP/MP: {0}/{1}", MP, MaxMP);

                Console.Write("{힘:" + STR + "}\n{민첩:" + DEX + "}\n{지혜:" + INT + "}\n");
                Console.Write("인벤토리: ");

                for (int i = 0; i < Inventory.Count; i++)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("{0}.{1}", i + 1, Inventory[i]);
                    }
                    else
                    {

                        Console.WriteLine("          {0}.{1}", i + 1, Inventory[i]);
                    }
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
                    Key = null;
                }
                else if (Key == "Enter")
                {
                    Console.Clear();
                    switch (Num)
                    {
                        case 0:
                            NormalAttack();
                            break;
                        case 1:
                            if(MP <= 0)
                            {
                                Console.WriteLine("마나가 부족하여 공격에 실패 했습니다.");
                            }
                            else
                            {
                                HeavyAttack();
                            }                     
                            break;
                        default:
                            break;
                    }
                    Key = null;
                    turnEnd = false;
                }
            }

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
            Console.WriteLine("\t{0}가(이) 일반 공격을 시도합니다.\n", Name);
            Damage = STR * 1;
            Hit = DEX * 10;
        }
        public void MonsterHeavyAttack()
        {
            Console.WriteLine("\t{0}가(이) 강한 공격을 시도합니다.\n", Name);
            Damage = STR * 2;
            Hit = DEX * 5;
        }
        public void MonsterTakeDemage(Player player)
        {
            Random rand = new Random();
            for (int i = 0; i < player.AttackNumber; i++)
            {

                if (4 * ((DEX * 10) - player.Hit) > rand.Next(1, 101))
                {
                    Console.WriteLine("\t{0}는(은) {1}의 공격을 회피 하였습니다.", Name, player.Name);
                }
                else
                {
                    Console.WriteLine("\t{0}는(은) {1}의 피해를 입었습니다.", Name, player.Damage);
                    HP = HP - player.Damage;
                }
            }
            if (HP > 0)
            {
                Console.Write("\t{0}의 현재 남은 HP:{1}", Name, HP);
                for (int i = (HP / 10) + 1; i > 0; i--)
                {
                    Console.Write("■");
                }
            }
            else
            {
                HP = 0;
                Console.Write("\t{0}의 현재 남은 HP:{1}", Name, HP);
            }
            Console.WriteLine("\n\n");
        }
        public void MonsterTurn()
        {
            Console.WriteLine("\n==================================================\n\n\n");

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
            Console.WriteLine("\n\n\n==================================================\n");
            Console.WriteLine("몬스터의 이름:{0}", Name);
            Console.WriteLine("MAXHP/HP: {0}/{1}", HP, MaxHP);
            

            Console.Write("{힘:" + STR + "}\n{민첩:" + DEX + "}\n");
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
