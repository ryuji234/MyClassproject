using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass5
{
    /*
     * 5X5 보드 (사이즈 줘도 ok)
□ □ □ □ □
□옷 . . □
□ . . . □
□ . . . □
□ □ □ □ □
.(닷)은 빈 곳,□는 벽을 의미

w,a,s,d 입력 받아서

빈 곳중에 아무곳이나 사람(이모티콘 또는 옷)을 초기화 해서
w,a,s,d 입력 받아서 빈 곳을 자유롭게 이동하는 프로그램 작성.
- 사람은 빈 곳을 다닐 수 있음.
- 사람은 벽을 넘어다닐 수 없음.
제출기한은 9시 출근하기 전까지
     */
    internal class Homework1
    {
        public static void Main()
        {
            const int BOARD_SIZE_X = 10;
            const int BOARD_SIZE_Y = 10;
            int MoveX = 1;
            int MoveY = 1;
            int[,] gameBoard = new int[BOARD_SIZE_Y, BOARD_SIZE_X];

            for (int y = 0; y < BOARD_SIZE_Y; y++)
            {
                for(int x = 0; x < BOARD_SIZE_X; x++)
                {
                    bool check = (0 < x && x < BOARD_SIZE_X-1) && (0 < y && y < BOARD_SIZE_Y-1);
                    if(check)
                    {
                        gameBoard[x, y] = 0;
                    }
                    else 
                    {
                        gameBoard[x, y] = -1;
                    }

                }
            }
            gameBoard[MoveX, MoveY] = 1;
            for (int y = 0; y < BOARD_SIZE_Y; y++)
            {
                for (int x = 0; x < BOARD_SIZE_X; x++)
                {
                    switch (gameBoard[y, x])
                    {
                        case -1:
                            Console.Write("□".PadRight(2, ' '));
                            break;
                        case 0:
                            Console.Write(".".PadRight(3, ' '));
                            break;
                        case 1:
                            Console.Write("*".PadRight(3, ' '));
                            break;
                        default:
                            break;
                    }


                }
                Console.WriteLine();
            }

            while (true)
            {
                Console.WriteLine("어느 방향으로 움직일 것인가요");
                string Move = Console.ReadLine();
                Console.Clear();
                switch (Move)
                {
                    case "w":
                        if (MoveX > 1)
                        {
                            gameBoard[MoveX, MoveY] = 0;
                            gameBoard[--MoveX, MoveY] = 1;
                        }
                        else
                        {
                            Console.WriteLine("더이상 이동할 수 없습니다.");
                        }
                        
                        break;
                    case "a":
                        if (MoveY > 1)
                        {
                            gameBoard[MoveX, MoveY] = 0;
                            gameBoard[MoveX, --MoveY] = 1;
                        }
                        else
                        {
                            Console.WriteLine("더이상 이동할 수 없습니다.");
                        }

                        break;
                    case "s":
                        if (MoveX < BOARD_SIZE_X - 2)
                        {
                            gameBoard[MoveX, MoveY] = 0;
                            gameBoard[++MoveX, MoveY] = 1;
                        }
                        else
                        {
                            Console.WriteLine("더이상 이동할 수 없습니다.");
                        }

                        break;
                    case "d":
                        if (MoveY < BOARD_SIZE_Y - 2)
                        {
                            gameBoard[MoveX, MoveY] = 0;
                            gameBoard[MoveX, ++MoveY] = 1;
                        }
                        else
                        {
                            Console.WriteLine("더이상 이동할 수 없습니다.");
                        }

                        break;
                    default:
                        Console.WriteLine("잘못입력 하셨습니다.");
                        
                        break;

                }
                

                for (int y = 0; y < BOARD_SIZE_Y; y++)
                {
                    for (int x = 0; x < BOARD_SIZE_X; x++)
                    {
                        switch (gameBoard[y, x])
                        {
                            case -1:
                                Console.Write("□".PadRight(2, ' '));
                                break;
                            case 0:
                                Console.Write(".".PadRight(3, ' '));
                                break;
                            case 1:
                                Console.Write("*".PadRight(3, ' '));
                                break;
                            default:
                                break;
                        }


                    }
                    Console.WriteLine();
                }
            }
           

        }
        
         

    }
}
