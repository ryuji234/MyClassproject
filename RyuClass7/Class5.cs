using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyuClass7
{
    internal class Class5
    {
            
        public static void Main()
        {
            RCP.Rcp();
        }       //Main()
    }       //Class Class5
    public static class RCP
    {

        public static void Rcp()
        {
            Console.WriteLine("가위 바위 보!");
            Console.Write("유저: ");
            string User = Console.ReadLine();
            string Ai = AI();
            Console.WriteLine($"AI: {Ai}");
            // {가위 바위 보 비교
            if (User ==Ai)
            {
                Console.WriteLine("비겼습니다.");
            }
            else
            {
                switch (User)
                {
                    case "가위":
                        Console.WriteLine((Ai == "보") ? "이겼습니다." : "졌습니다.");
                        break;
                    case "바위":
                        Console.WriteLine((Ai == "가위") ? "이겼습니다." : "졌습니다.");
                        break;
                    case "보":
                        Console.WriteLine((Ai == "바위") ? "이겼습니다." : "졌습니다.");
                        break;

                }       //switch
            }
            // }가위 바위 보 비교

            //else if (User == "바위")
            //{
            //    if(Ai == "가위")
            //    {
            //        Console.WriteLine("이겼습니다.");
            //    }
            //    else if(Ai == "보")
            //    {
            //        Console.WriteLine("졌습니다.");
            //    }
            //}
            //else if(User == "가위")
            //{
            //    if (Ai == "바위")
            //    {
            //        Console.WriteLine("졌습니다.");
            //    }
            //    else if (Ai == "보")
            //    {
            //        Console.WriteLine("이겼습니다.");
            //    }
            //}
            //else if (User == "보")
            //{
            //    if (Ai == "바위")
            //    {
            //        Console.WriteLine("이겼습니다.");
            //    }
            //    else if (Ai == "가위")
            //    {
            //        Console.WriteLine("졌습니다.");
            //    }
            //}
        }       // Rcp
        public static string AI()
        {
            string[] Ai = { "가위", "바위", "보" };
            int x;
            int y;
            string temp;
            Random random= new Random();
            for (int i = 0; i < 10; i++)
            {
                x = random.Next(0,Ai.Length);
                y = random.Next(0,Ai.Length);
                temp = Ai[x];
                Ai[x] = Ai[y];
                Ai[y] = temp;
            }
            return Ai[0];  
        }
    }       // Class RCP
}
