using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyuClass9
{

        

        public class Monster
        {
            protected string name;
            protected int hp;
            protected int damage;
            protected int defence;


            public void Move(string name)
            {
                Console.WriteLine("{0}가 움직인다.", name);
            }
            public void Attack(string name, int damage)
            {
                Console.WriteLine("{0}가 {1}의 공격력으로 공격 했다.", name, damage);
            }
            public void MoveAndAttack()
            {
                this.Move(name);
                this.Attack(name, damage);
            }
        }

    class Slim : Monster
    {
        public string Name 
        {
            get { return this.name; }
            private set { this.name = value; } // private set을 해주면 이름이 변경되지 않는다. // value 라는 키워드가 임시변수를 해준다.
        }
        public string Getname()
        {
            return this.name;
        }
            public Slim()
            {
                this.name = "푸른 슬라임";
                this.hp = 100;
                this.damage = 10;
                this.defence = 1;
            }
            //public void MoveAndAttack()
            //{
            //    this.Move(this.name);
            //    this.Attack(this.name, this.damage);
            //}

    }
    class wolf : Monster
    {
        public wolf()
        {
            this.name = "하얀 늑대";
            this.hp = 200;
            this.damage = 20;
            this.defence = 2;
        }
            //public void MoveAndAttack()
            //{
            //    this.Move(this.name);
            //    this.Attack(this.name, this.damage);
            //}

    }
    
}
