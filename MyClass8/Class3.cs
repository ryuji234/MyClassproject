using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Threading;

namespace MyClass8
{

    

    public class Player
    {
        public string playername;
        public int playerhp;
        public int playerdefence;
        public int playerdamage;
        public int playerDex;
        public int playerattack;
        public int playerhit;

        public void PlayernormalAttack( string name, int damage, ref int attack, int Dex, ref int hit)
        {
            Console.WriteLine("{0} 가(이) 일반 공격을 시도한다.\n", name);
            attack = damage;
            hit = Dex;
        }                   // 플레이어의 일반 공격
        public void PlayerHeavyAttack(string name, int damage, ref int attack, int Dex, ref int hit)
        {
            Console.WriteLine("{0} 가(이) 강한 공격을 시도한다.\n", name);

            attack = 2*damage;
            hit = Dex / 2;
        }                   // 플레이어의 강한 공격
        public void PlayerDodge(string name,int Dex,int defence, Monster mon,ref int hp)
        {
            if (Dex > mon.monsterhit)
            {
                Random random = new Random();
                if ((Dex - mon.monsterhit) * 10 > random.Next(1, 101))
                {
                    Console.WriteLine("피했습니다.\n");
                }
                else 
                {
                    Console.WriteLine("{0} 가(이) {1}의 피해를 입었습니다.\n", name, mon.monsterattack - defence);
                    hp = hp - (mon.monsterattack - defence);
                    
                }
            }
            else
            {
                Console.WriteLine("{0} 가(이) {1}의 피해를 입었습니다.\n", name, mon.monsterattack - defence);
                hp = hp - (mon.monsterattack - defence);              
            }
            
            if(hp>0)
            {
                Console.Write("현재 남은 HP:{0}\n", hp);
                for (int i = (hp / 10) + 1; i > 0; i--)
                {
                    Console.Write("■");
                }
            }
            else 
            { 
                hp = 0;
                Console.Write("{0}의 현재 남은 HP:{0}\n",name, hp);
            }

        }           // 플레이어의 공격 회피
        public void PlayerTurn()
        {
            Console.WriteLine("어떻게 하시겠습니까?");
            Console.WriteLine("1.일반 공격 2.강한 공격");

            int x =int.Parse(Console.ReadLine());
            Console.Clear();
            switch (x)
            {
                case 1:
                    PlayernormalAttack(playername, playerdamage,ref playerattack, playerDex,ref playerhit);
                    break;
                case 2:
                    PlayerHeavyAttack(playername, playerdamage, ref playerattack, playerDex, ref playerhit);
                    break;
            }
        }           // 플레이어의 행동
        public void Playerdefend(Monster mon)
        {
            PlayerDodge(playername,playerDex,playerdefence,mon,ref playerhp);
        }           //플레이어의 방어

        //public void PlayerAttack(string Attackername, int Attackerdamage )
        //{

        //    Console.WriteLine("{0}가 {1}의 공격을 했다.\n", Attackername, Attackerdamage);

        //}
        //public void PlayerHeavyAttack(string Attackername, int Attackerdamage)
        //{
        //    Console.WriteLine("{0}가 강한 공격을 사용했다.");

        //}
        //public void PlayerAttacked(int speed, string name, int defence, int damage, ref int hp)
        //{
        //    Random random = new Random();
        //    if (speed > random.Next(1, 101))
        //    {
        //        Console.WriteLine("피했습니다.\n");
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0}가 {1}의 피해를 입었다.\n", name, damage - defence);
        //        hp = hp - (damage - defence);    
        //    }
        //    Console.WriteLine("남은 HP:{0}\n", hp);
        //}

        //public void PlayerAttacking()
        //{
        //    PlayerAttack(playername, playerdamage);
        //}

        //public void PlayerDodge(int x)
        //{
        //    Monster mon = new Monster();




        //    switch (x)
        //    {
        //        case 1:
        //            mon = new Type1();
        //            break;
        //        case 2:
        //            mon = new Type2();
        //            break;
        //        case 3:
        //            mon = new Type2();
        //            break;
        //    }


        //    PlayerAttacked(playerspeed, playername, playerdefence, mon.damage, ref playerhp);
        //}
        //public void PlayerTurn()
        //{
        //    Console.WriteLine("플레이어의 차례");
        //    PlayerAttacking();
        //}
    }

    public class Monster 
    {
        public string monstername;
        public int monsterhp;
        public int monsterdefence;
        public int monsterdamage;
        public int monsterDex;
        public int monsterattack;
        public int monsterhit;
        public string monsteritem;



        public void MosternormalAttack(string name, int damage, ref int attack, int Dex, ref int hit)
        {
            Console.WriteLine("{0} 가(이) 일반 공격을 시도한다.\n", name);
            attack = damage;
            hit = Dex;
        }
        public void MosterHeavyAttack(string name, int damage, ref int attack, int Dex, ref int hit)
        {
            Console.WriteLine("{0} 가(이) 강한 공격을 시도한다.\n", name);

            attack = 2 * damage;
            hit = Dex / 2;
        }
        public void MosterDodge(string name, int Dex, int defence, Player mon, ref int hp)
        {
            if (Dex > mon.playerhit)
            {
                Random random = new Random();
                if ((Dex - mon.playerhit) * 10 > random.Next(1, 101))
                {
                    Console.WriteLine("피했습니다.\n");
                }
                else 
                {
                    Console.WriteLine("{0} 가(이) {1}의 피해를 입었습니다.\n", name, mon.playerattack - defence);
                    hp = hp - (mon.playerattack - defence);
                    
                }
            }
            else
            {
                Console.WriteLine("{0} 가(이) {1}의 피해를 입었습니다.\n", name, mon.playerattack - defence);
                hp = hp - (mon.playerattack - defence);
            }
            if (hp > 0)
            {
                Console.Write("{0}의 현재 남은 HP:{1}\n", name, hp);
                for (int i = (hp / 10) + 1; i > 0; i--)
                {
                    Console.Write("■");
                }
            }
            else
            {
                hp = 0;
                Console.Write("{0}의 현재 남은 HP:{1}\n", name, hp);
            }
        }
        public void MonsterTurn()
        {
          

            Random rand = new Random();
            int x = rand.Next(1,101);
            if( x>80)
            {
                MosterHeavyAttack(monstername, monsterdamage, ref monsterattack, monsterDex, ref monsterhit);
            }
            else
            {
                MosternormalAttack(monstername, monsterdamage, ref monsterattack, monsterDex, ref monsterhit);
            }
                       
                      
            
        }
        public void Monsterdefend(Player pla)
        {
            MosterDodge(monstername, monsterDex, monsterdefence, pla, ref monsterhp);
        }



    }
    class Type1 : Monster
    {
        public Type1()
        {
            this.monstername = "뜨아거";
            this.monsterhp = 30;
            this.monsterdefence = 2;
            this.monsterdamage = 6;
            this.monsterDex = 16;
            this.monsterattack = 0;
            this.monsterhit = 0;
            this.monsteritem = "뜨아거의 불";
            
        }
    }

    
    class Type2 : Monster
    {
        public Type2()
        {
            this.monstername = "꾸왁스";
            this.monsterhp = 30;
            this.monsterdefence = 3;
            this.monsterdamage = 5;
            this.monsterDex = 15;
            this.monsterattack = 0;
            this.monsterhit = 0;
            this.monsteritem = "꾸왁스의 부리";
        }
    }
    class Type3 : Monster
    {
        public Type3()
        {
            this.monstername = "나오하";
            this.monsterhp = 30;
            this.monsterdefence = 4;
            this.monsterdamage = 4;
            this.monsterDex = 14;
            this.monsterattack = 0;
            this.monsterhit = 0;
            this.monsteritem = "나오하의 털";
        }
    }

    class player : Player
    {
        public player()
        {
            
            this.playername = "주인공"; 
            this.playerhp = 40;
            this.playerdefence = 1;
            this.playerdamage = 7;
            this.playerDex = 18;
            this.playerattack = 0;
            this.playerhit = 0;

        }
    }


}
