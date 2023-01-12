using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    

    internal class TEXTRPGMain
    {
        
        static void battle(ref int HP, ref int SP, ref int[] Status) // 전투 (아직 미구현)
        {

        }
       

        static void Main(string[] args)
        {

            
            string[] StatusArrayName = { "힘", "민첩", "지혜" };           
            int Num = 0;
            Player player= new Player();
            int stage;
            Random rand = new Random();
            Console.WriteLine("\n\n\t====== 모험가 이야기 =====\n");
            Console.WriteLine("\t       -Enter- 입력  ");
            
            ConsoleKeyInfo c;
            string Key = null;
            c =Console.ReadKey();
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
                Console.WriteLine("\n==================================================\n\n\n");
                Console.WriteLine("\n\t당신의 모험가를 선택하시요");
                switch (Num)
                {
                     case 0:
                         Console.WriteLine("\t▶1.전사    2.도적    3.마법사");
                         break;
                     case 1:
                         Console.WriteLine("\t  1.전사  ▶2.도적    3.마법사");
                         break;
                     case 2:
                         Console.WriteLine("\t  1.전사    2.도적  ▶3.마법사");
                         break;
                }
                Console.WriteLine("\n\n\n==================================================\n");

                c = Console.ReadKey();
                Key = c.Key.ToString();
                switch (c.Key)
                {
                    case ConsoleKey.RightArrow:
                        if(Num < 2) Num++;                                               
                        break;
                    case ConsoleKey.LeftArrow:
                        if(Num > 0) Num--;                       
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

                stage = rand.Next(1, 101);
                               
                switch (1)
                {
                    case 0:
                        Event.num1(ref player.HP, player.MaxHP, ref player.MP, player.MaxMP, ref StatusArray, player.Name, player.Inventory);
                        break;
                    case 1:
                        Event.num2(ref player.HP, player.MaxHP, ref player.MP, player.MaxMP, ref StatusArray, player.Name, player.Inventory);
                        break;
                    case 2:
                        Event.num3(ref player.HP, player.MaxHP, ref player.MP, player.MaxMP, ref StatusArray, player.Name, player.Inventory);
                        break;
                    case 3:
                        Event.num4(ref player.HP, player.MaxHP, ref player.MP, player.MaxMP, ref StatusArray, player.Name, player.Inventory);
                        break;
                    case 4:
                        Event.num5(ref player.HP, player.MaxHP, ref player.MP, player.MaxMP, ref StatusArray, player.Name, player.Inventory);
                        break;
                    case 5:
                        Event.num6(ref player.HP, player.MaxHP, ref player.MP, player.MaxMP, ref StatusArray, player.Name, player.Inventory);
                        break;
                    case 6:
                        Event.num7(ref player.HP, player.MaxHP, ref player.MP, player.MaxMP, ref StatusArray, player.Name, player.Inventory);
                        break;
                    case 7:
                        Event.num3(ref player.HP, player.MaxHP, ref player.MP, player.MaxMP, ref StatusArray, player.Name, player.Inventory);
                        break;
                    case 8:
                        Event.num9(ref player.HP, player.MaxHP, ref player.MP, player.MaxMP, ref StatusArray, player.Name, player.Inventory);
                        break;
                    case 9:
                        Event.num10(ref player.HP, player.MaxHP, ref player.MP, player.MaxMP, ref StatusArray, player.Name, player.Inventory);
                        break;
                    default:
                        break;
                }
                
                if (player.HP <= 0)
                {
                    Console.WriteLine("\t당신은 죽었습니다.");
                    Environment.Exit(0);
                }
                ++EVENT.count;
                if (EVENT.count > 20)
                {
                    Console.WriteLine("\t당신은 20일동안 모험을 하면서 많은 경험을 했고 이제는 어떠한 위험에도 살아남을수 있는 모험가가 되었습니다.   -끝-");
                    Environment.Exit(0);
                }
              
                Console.Clear();
            }

        }
    }
}
