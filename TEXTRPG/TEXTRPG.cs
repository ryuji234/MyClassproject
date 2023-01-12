namespace TEXTRPG
{

    public class EVENT
    {
        public static int Chance = 40;
        public static int BigChance = 20;
        public static int Event = 0;
        public static int[] select = new int[3];
        public static int count = 1;
        public static string[] status = { "힘", "민첩", "지혜" };

        public void num1(ref int HP, int MaxHP, ref int MP, int MaxMP, ref int[] Status, string Name, List<string> Inventory) // 바위 굴러오는 이벤트(일반 이벤트)
        {


            int Acheck, Acheck1, Bcheck;
            Random rand = new Random();
            Acheck = Chance + 7 * (Status[0] - 5);
            Acheck1 = BigChance + 5 * (Status[0] - 5);
            Bcheck = Chance + 7 * (Status[1] - 5);


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
                if (Key != "Enter")
                {

                }
                else
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
                                    --Status[0];
                                }

                            }
                            else
                            {
                                Console.WriteLine("\t아... 바위를 부수기에는 힘이 부족했습니다.\n\t(체력이 10 감소합니다.)");
                                HP = HP - 10;
                            }
                            break;
                        case 1:
                            if (Bcheck > rand.Next(1, 101))
                            {
                                Console.WriteLine("당신은 신속하게 바위를 피하는데 성공했습니다.");
                            }
                            else
                            {
                                Console.WriteLine("\t아... 바위를 피하기에는 너무 느렸습니다.\n\t(체력이 10 감소합니다.)");
                                HP = HP - 10;
                            }
                            break;
                        case 2:
                            Console.WriteLine("\t당신은 그냥 바위를 맞았습니다.\n\t(체력이 10 감소합니다.)");
                            HP = HP - 10;
                            break;
                        default:
                            Console.WriteLine("\t잘못된 선택으로 바위를 맞았습니다.\n\t(체력이 10 감소합니다.)");
                            HP = HP - 10;
                            break;
                    }
                    Console.WriteLine("\n==================================================");
                    EventEnd = false;
                    Key = null;
                }

                Console.WriteLine("당신의 캐릭터:{0}", Name);
                Console.WriteLine("MAXHP/HP: {0}/{1}", HP, MaxHP);
                Console.WriteLine("MAXMP/MP: {0}/{1}", MP, MaxMP);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("{" + status[i] + ":" + Status[i].ToString() + "}\n");
                }
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
        public void num2(ref int HP, int MaxHP, ref int MP, int MaxMP, ref int[] Status, string Name, List<string> Inventory) // 요정의 샘(아이템을 얻는 이벤트)
        {


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
                            ++Status[2];
                            break;

                        case 1:
                            Console.WriteLine("\t요정의 샘물로 몸을 씻으니 상처가 회복됩니다.");
                            if (HP + 5 > MaxHP)
                            {
                                HP = HP + (MaxHP - HP);
                            }
                            else
                            {
                                HP = HP + 5;
                            }
                            break;
                        case 2:
                            if (Inventory.Count < 5)
                            {
                                if (Drop)
                                {
                                    Console.WriteLine("\t당신은 요정의 샘물을 얻었습니다.");
                                    Inventory.Add(String.Format("요정의 샘물{0}", count));
                                    Drop = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\t인벤토리가 가득차서 무언가를 버려야 합니다.");
                                Console.WriteLine("\t어떤것을 버리겠습니까?(1,2,3,4,5,6 중에 선택)");
                                if (Drop)
                                {
                         
                                    Inventory.Add(String.Format("요정의 샘물{0}", count));
                                }
                                
                                if (Drop == false)
                                {
                                    if(DropItem != null)
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
                Console.WriteLine("당신의 캐릭터:{0}", Name);
                Console.WriteLine("MAXHP/HP: {0}/{1}", HP, MaxHP);
                Console.WriteLine("MAXMP/MP: {0}/{1}", MP, MaxMP);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("{" + status[i] + ":" + Status[i].ToString() + "}\n");
                }

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
                if (Inventory.Count < 6) { }

                else
                {
                    Numc = Console.ReadKey();
                    string number = Numc.Key.ToString();

                    switch (number)
                    {
                        case "D1":
                            DropItem = Inventory[0];
                            Inventory.RemoveAt(0);

                            break;
                        case "D2":
                            DropItem = Inventory[1];
                            Inventory.RemoveAt(1);

                            break;
                        case "D3":
                            DropItem = Inventory[2];
                            Inventory.RemoveAt(2);

                            break;
                        case "D4":
                            DropItem = Inventory[3];
                            Inventory.RemoveAt(3);

                            break;
                        case "D5":
                            DropItem = Inventory[4];
                            Inventory.RemoveAt(4);

                            break;
                        case "D6":
                            DropItem = Inventory[5];
                            Inventory.RemoveAt(5);

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
        public void num3(ref int HP, int MaxHP, ref int MP, int MaxMP, ref int[] Status, string Name, List<string> Inventory) // 산불 이벤트(연계 이벤트 시작점)
        {
            string[] EventSelect = new string[3] { "", "", "" };
            Console.WriteLine("당신은 산길을 가던중 불이 피어오르는 것을 발견했습니다./n/t어떻게 하시겠습니까?");

        }
        public void num4(ref int HP, int MaxHP, ref int MP, int MaxMP, ref int[] Status, string Name, List<string> Inventory)
        {

        }
        public void num5(ref int HP, int MaxHP, ref int MP, int MaxMP, ref int[] Status, string Name, List<string> Inventory)
        {

        }
        public void num6(ref int HP, int MaxHP, ref int MP, int MaxMP, ref int[] Status, string Name, List<string> Inventory)
        {

        }
        public void num7(ref int HP, int MaxHP, ref int MP, int MaxMP, ref int[] Status, string Name, List<string> Inventory)
        {

        }
        public void num8(ref int HP, int MaxHP, ref int MP, int MaxMP, ref int[] Status, string Name, List<string> Inventory)
        {

        }
        public void num9(ref int HP, int MaxHP, ref int MP, int MaxMP, ref int[] Status, string Name, List<string> Inventory)
        {

        }
        public void num10(ref int HP, int MaxHP, ref int MP, int MaxMP, ref int[] Status, string Name, List<string> Inventory)
        {

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
        public int DEX;
        public int INT;
        public List<string> Inventory;
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
            this.Inventory = new List<string>();
        }
        public void NormalAttack()
        {

        }
    }
    public class Thief : Player
    {
        public Thief()
        {
            this.Name = "도적";
            this.MaxHP = 40;
            this.HP = MaxHP;
            this.MaxMP = 10;
            this.MP = MaxMP;
            this.STR = 4;
            this.DEX = 7;
            this.INT = 2;
            this.Inventory = new List<string>();
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
            this.Inventory = new List<string>();
        }
    }

    public class Monster
    {
        public string Name;
        public int MaxHP;
        public int HP;
        public int STR;
        public int DEX;
        public string Item;
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
