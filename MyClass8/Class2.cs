using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass8
{
    internal class Class2
    {
        public static void Main()
        {
            //  Class1 class2 = new Class1(123);

            // child child_ = new child();

            // child_.Printchild();

            //wolf monsterwolf = new wolf();
            //monsterwolf.MoveAndAttack();

            //Slim monsterslim = new Slim();
            //monsterslim.MoveAndAttack();
            Random random= new Random();
            Monster monster= new Monster();
            Player player= new player();
            bool PlayerDie = true;
            
            while(PlayerDie)
            {
                Console.WriteLine("============================");
                Console.WriteLine("어떤 몬스터와 싸우겠습니까?\n============================\n(1. 뜨아거, 2. 꾸왁스, 3. 나오하)");
                int x = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (x)
                {
                    case 1:
                        monster = new Type1();
                        break;
                    case 2:
                        monster = new Type2();
                        break;
                    case 3:
                        monster = new Type3();
                        break;
                }
                Console.WriteLine("{0}.{1}를 선택하셨습니다.", x, monster.Name);

                while (player.playerhp > 0 && monster.monsterhp > 0)
                {
                    player.PlayerTurn();
                    monster.Monsterdefend(player);
                    Console.WriteLine();
                    if (monster.monsterhp <= 0)
                    {
                        Console.WriteLine("축하합니다.{0}를(을) 잡았습니다.", monster.Name);
                        if(random.Next(1,101)>60)
                        {
                            Console.WriteLine("{0}를(을) 얻었습니다.", monster.monsteritem);
                        }
                        Console.WriteLine();
                        
                        break;
                    }
                    monster.MonsterTurn();
                    player.Playerdefend(monster);
                    Console.WriteLine();
                    if (player.playerhp <= 0)
                    {
                        Console.WriteLine("당신은 죽었습니다. - YOU DIE -");
                        PlayerDie = false;
                        break;
                    }

                }
            }
            


            //while(player.playerhp > 0 && monster.hp > 0)
            //{
            //    player.PlayerTurn();
            //    monster.Dodge();
            //    if(monster.hp <= 0)
            //    {
            //        break;
            //    }
            //    monster.MonsterTurn();
            //    player.PlayerDodge(x);
            //}



        }
    }
}
