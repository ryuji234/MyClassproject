using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace RyuClass6
{
    internal class Class5
    {
        const int BOARD_SIZE_X = 2;
        const int BOARD_SIZE_Y = 2;
        //  {슬라이드 퍼즐 보드판 출력함수
        static void BoardMap(int[,] z,int GC)
        {       
            Console.WriteLine("=======================");
            for (int i = 0; i < BOARD_SIZE_Y; i++)
            {
                Console.WriteLine();
                Console.Write("\t");
                for (int j = 0; j < BOARD_SIZE_X; j++)
                {
                    switch (z[i, j])
                    {
                        case BOARD_SIZE_X * BOARD_SIZE_Y:
                            Console.Write("X".PadRight(3, ' '));
                            break;

                        default:
                            Console.Write("{0}".PadRight(5, ' '), z[i, j]);
                            break;
                    }


                }
                Console.WriteLine();

            }
            Console.WriteLine("\n");
            Console.WriteLine("=======================");
            Console.WriteLine("이동 횟수: {0}", GC);

        }
        //  }슬라이드 퍼즐 보드판 출력함수



        public static void Main()
        {
            int GameCount = 0;
            int No = -1;
            int Yes = 1;
            
            int NineLocationX = 0;
            int NineLocationY = 0;
            int[] Array = new int[BOARD_SIZE_X * BOARD_SIZE_Y]; 
            int[,] Board = new int[BOARD_SIZE_X, BOARD_SIZE_Y];
            Random randon= new Random();
            int k = 0;
            int x = 0;
            int IsOverLaped;
            int IsGameOver = No;
            int IsAllCollect = No;
            // { 슬라이드 보드에 1~보드 크기까지 숫자 난수 입력
            while(x<BOARD_SIZE_X*BOARD_SIZE_Y)
            {
                IsOverLaped = No;
                k = randon.Next(1, BOARD_SIZE_X * BOARD_SIZE_Y + 1);
                for (int i = 0; i < x; i++)
                {
                    if (Array[i] == k)
                    {
                        IsOverLaped = Yes;
                        break;
                    }
                   
                }
                if(IsOverLaped == No)
                {
                    Array[x] = k;
                    x++;
                }
                else { continue; }
            }
            x = 0;
            for (int i = 0; i < BOARD_SIZE_X; i++)
            {

                for (int j = 0; j < BOARD_SIZE_Y; j++)
                {
                    if (Array[x] == BOARD_SIZE_X* BOARD_SIZE_Y)
                    {
                        NineLocationX= j;
                        NineLocationY= i;
                    }
                    Board[j,i] = Array[x];
                    x++;
                }
            }
            // } 슬라이드 보드에 1~보드 크기까지 숫자 난수 입력
            // { 게임 시작
            while (IsGameOver == No)
            {
                BoardMap(Board, GameCount);
                Console.WriteLine("이동할 방향을 선택해 주세요");
                string Move = Console.ReadLine();
                
                Console.Clear();
                switch (Move)
                {
                    case "w":
                        if (NineLocationX > 0)
                        {
                            Board[NineLocationX, NineLocationY] = Board[--NineLocationX, NineLocationY];
                            Board[NineLocationX, NineLocationY] = BOARD_SIZE_X * BOARD_SIZE_Y;
                            GameCount++;
                        }
                        break;
                    case "s":
                        if (NineLocationX < BOARD_SIZE_X - 1)
                        {
                            Board[NineLocationX, NineLocationY] = Board[++NineLocationX, NineLocationY];
                            Board[NineLocationX, NineLocationY] = BOARD_SIZE_X * BOARD_SIZE_Y;
                            GameCount++;
                        }
                        break;
                    case "d":
                        if (NineLocationY < BOARD_SIZE_Y - 1)
                        {
                            Board[NineLocationX, NineLocationY] = Board[NineLocationX, ++NineLocationY];
                            Board[NineLocationX, NineLocationY] = BOARD_SIZE_X * BOARD_SIZE_Y;
                            GameCount++;
                        }
                        break;
                    case "a":
                        if (NineLocationY > 0)
                        {
                            Board[NineLocationX, NineLocationY] = Board[NineLocationX, --NineLocationY];
                            Board[NineLocationX, NineLocationY] = BOARD_SIZE_X * BOARD_SIZE_Y;
                            GameCount++;
                        }
                        break;
                    default:
                        Console.WriteLine("못된 입력입니다.");
                        
                        break;
                }   //  Switch: 'X' 이동
                    //  {게임 승리 조건 검사
                int count = 1;
                for (int i = 0; i < BOARD_SIZE_Y; i++)
                {
                    for (int j = 0; j < BOARD_SIZE_X; j++)
                    {
                        if (Board[i,j] != count)
                        {
                            IsAllCollect = No;
                            break;
                        }
                        else
                        {
                            IsAllCollect = Yes;
                            count++;
                        }
                    }
                    if( IsAllCollect == No)
                    {
                        break;
                    }
                }
                if(IsAllCollect == Yes)
                {
                    Console.WriteLine("승리하셨습니다!!!!!");
                    IsGameOver = Yes;
                }
                    //  }게임 승리 조건 검사
            }
            BoardMap(Board, GameCount);
            // } 게임 시작
        }
    }
}
