using System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;


namespace RYU
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[,] twoarray = new int[3, 3];

            //for (int y = 0; y < 3; y++)
            //{
            //    for (int x = 0;x<3;x++)
            //    {
            //        if(x == y) { }
            //    }
            //}
            //int a=0,b = 0;
            //int[,] twoArray = new int[20,20];

            //a = Console.Read();

            //for(int i= 0;i<=a;++i)
            //{
            //    for(int j=0;j<b;++j)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //    ++b;
            //}
            //LAB 1.
            /**
            int[] Array = new int[100];
            int max = 0;
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                Array[i] = rand.Next(1, 101);
                Console.Write(Array[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
            for (int j = 0; j < 100; j++)
            {

                if (max <= Array[j])
                {
                    max = Array[j];
                }

            }

            Console.WriteLine("{0}", max);
            **/

            //LAB 2
            /**
            Random rand = new Random();
            int[] Array1 = new int[rand.Next(100,1001)];
            int tan = 0;

            for (int i = 0; i < Array1.Length; i++)
            {
                Array1[i] = rand.Next(1,101);
            }
            for (int k = 0; k < Array1.Length; k++)
            {
                if (Array1[k] != 0)
                {
                    Console.Write(Array1[k].ToString() + ", ");
                }
                if((k + 1) % 10==0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();

            for (int i = 0; i<Array1.Length -1;i++)
            {
                for(int j = 0;j<Array1.Length-1-i;j++) 
                {
                    
                    if (Array1[j] > Array1[j+1])
                    {
                        int temp = Array1[j];
                        Array1[j] = Array1[j+1];
                        Array1[j+1] = temp;
                    }
                }
            }
            for(int k =0;k<Array1.Length-1;k++)
            {
                
                if (Array1[k] != Array1[k + 1])
                {
                    if ((tan + 1) % 10 == 0)
                    {
                        Console.WriteLine();
                        tan = 0;
                    }
                    Console.Write(Array1[k].ToString() + ", ");
                    tan++;
                }
                
                
             
            }
            if (Array1[Array1.Length - 1] != Array1[Array1.Length - 2])
            {
                Console.Write(Array1[Array1.Length-1].ToString() + ", ");
            }
            **/
            //LAB 3

            int[] Array = new int[3];
            int ScoreNum = 0;
            float AverageScore = 0;

            for (int i = 0; i < Array.Length; i++)
            {
                Console.WriteLine("유저{0}의 국어점수를 입력하지오", i + 1);
                String Score = Console.ReadLine();
                bool check = int.TryParse(Score, out ScoreNum);
                if (check)
                {
                    Array[i] = ScoreNum;
                }
                else
                {
                    Console.WriteLine("다시 입력하시오");
                    i--;
                }
            }
            int AllScore = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                AllScore += Array[i];
            }
            float Average = AllScore;
            Average /= Array.Length;
            Console.WriteLine("총점{0}", AllScore);
            Console.WriteLine("평균{0:F}", Average);
        }
            
            
        /**
         * 다차원 배열
         * 2차원 배열, 3차원 배열처럼 차원이 2개 이상인 배열을 다차원 배열이라고 한다.
         * *C#에서 배열을 선언할 때는 콤마를 기준으로 차원을 구분한다.
         **/
        //int[] oneArray = new int[2] { 1, 2 };
        //int[,] twoArray = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
        //int[,,] threeArray = new int[2, 2, 2]
        //{
        //    { { 1, 2 }, { 3, 4 } },
        //    { { 1, 2 }, { 3, 4 } }
        //};

        //3행 3열짜리 배열에서 행과 열이 같으면 1, 다르면 0으로 추렬
        /**
         * 과제
         * LAB 1,2 코딩 했던 내용, 주석 달아서 해석해서 제출
         * -미완성인 경우 이해하고 있는 내용까지만이라도 적어서 제출할 것.
         * -어느 단계까지 도전을 했는지도 포함할 것.
         * -용량 등 필요없는 파일이 섞이지 않도록 주의할 것.
         * **/

    }
}