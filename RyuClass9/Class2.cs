using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyuClass9
{
    internal class Class2
    {
        const int BOARD_SIZE_X = 20;
        const int BOARD_SIZE_Y = 20;
        static int Score = 0;
        static int MoveX = 1;
        static int MoveY = 1;
        static int[,] gameBoard = new int[BOARD_SIZE_Y, BOARD_SIZE_X];
        
        
        public static void Map(int[,] Map)
        {
            Console.WriteLine("\t\t  ====================");
            Console.WriteLine("\t\t     Coin Detector    ");
            Console.WriteLine("\t\t  ====================");

            switch (Map[MoveX, MoveY])
            {
                case 1: //*
                    for (int y = 0; y < BOARD_SIZE_Y; y++)
                    {
                        Console.Write("\t");
                        for (int x = 0; x < BOARD_SIZE_X; x++)
                        {
                            switch (Map[y, x])
                            {
                                case -1:
                                    Console.Write("□".PadRight(1, ' '));
                                    break;
                                case 0:
                                    if (x >= MoveY - 2 && x <= MoveY + 2 && y >= MoveX - 2 && y <= MoveX + 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("■".PadRight(1, ' '));
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        Console.Write(" ".PadRight(2, ' '));
                                    }
                                    break;
                                case 1:
                                    if (x >= MoveY - 2 && x <= MoveY + 2 && y >= MoveX - 2 && y <= MoveX + 2)
                                    {
                                        Console.Write("*".PadRight(2, ' '));
                                    }
                                    else
                                    {
                                        Console.Write(" ".PadRight(2, ' '));
                                    }

                                    break;
                                case 2:
                                    if (x >= MoveY - 2 && x <= MoveY + 2 && y >= MoveX - 2 && y <= MoveX + 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("$".PadRight(2, ' '));
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        Console.Write(" ".PadRight(2, ' '));
                                    }
                                    break;                                                                        
                                default:
                                    break;
                            }
                        }
                        Console.WriteLine();

                    }
                    break;
                case 3: //▶
                    for (int y = 0; y < BOARD_SIZE_Y; y++)
                    {
                        Console.Write("\t");
                        for (int x = 0; x < BOARD_SIZE_X; x++)
                        {                           
                                switch (Map[y, x])
                                {
                                case -1:
                                    Console.Write("□".PadRight(1, ' '));
                                    break;
                                case 0:
                                    if (x >= MoveY&& x <= MoveY + 2 && y >= MoveX - 2 && y <= MoveX + 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("■".PadRight(1, ' '));
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        Console.Write(" ".PadRight(2, ' '));
                                    }
                                    break;                                                                   
                                case 2:
                                    if (x >= MoveY&& x <= MoveY + 2 && y >= MoveX - 2 && y <= MoveX + 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("$".PadRight(2, ' '));
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        Console.Write(" ".PadRight(2, ' '));
                                    }

                                    break;
                                case 3:
                                    
                                        Console.Write("▶".PadRight(1, ' '));                                   
                                    break;                                                                                                                                  
                                default:
                                    break;
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
                case 4: //◀
                    for (int y = 0; y < BOARD_SIZE_Y; y++)
                    {
                        Console.Write("\t");
                        for (int x = 0; x < BOARD_SIZE_X; x++)
                        {
                            switch (Map[y, x])
                            {
                                case -1:
                                    Console.Write("□".PadRight(1, ' '));
                                    break;
                                case 0:
                                    if (x >= MoveY - 2 && x <= MoveY&& y >= MoveX - 2 && y <= MoveX + 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("■".PadRight(1, ' '));
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        Console.Write(" ".PadRight(2, ' '));
                                    }
                                    break;                               
                                case 2:
                                    if (x >= MoveY - 2 && x <= MoveY&& y >= MoveX - 2 && y <= MoveX + 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("$".PadRight(2, ' '));
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        Console.Write(" ".PadRight(2, ' '));
                                    }

                                    break;                                                                  
                                case 4:                                    
                                        Console.Write("◀".PadRight(1, ' '));
                                    
                                    break;                                
                                default:
                                    break;
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
                case 5://▲
                    for (int y = 0; y < BOARD_SIZE_Y; y++)
                    {
                        Console.Write("\t");
                        for (int x = 0; x < BOARD_SIZE_X; x++)
                        {
                            switch (Map[y, x])
                            {
                                case -1:
                                    Console.Write("□".PadRight(1, ' '));
                                    break;
                                case 0:
                                    if (x >= MoveY - 2 && x <= MoveY + 2 && y >= MoveX -2 && y <= MoveX)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("■".PadRight(1, ' '));
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        Console.Write(" ".PadRight(2, ' '));
                                    }
                                    break;
                                case 1:
                                    if (x >= MoveY - 2 && x <= MoveY + 2 && y >= MoveX - 2 && y <= MoveX)
                                    {
                                        Console.Write("*".PadRight(2, ' '));
                                    }
                                    else
                                    {
                                        Console.Write(" ".PadRight(2, ' '));
                                    }

                                    break;
                                case 2:
                                    if (x >= MoveY - 2 && x <= MoveY + 2 && y >= MoveX - 2 && y <= MoveX)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("$".PadRight(2, ' '));
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        Console.Write(" ".PadRight(2, ' '));
                                    }

                                    break;                              
                                case 5:                                    
                                        Console.Write("▲".PadRight(1, ' '));
                                                                     
                                    break;                                
                                default:
                                    break;
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
                    case 6://▼
                    for (int y = 0; y < BOARD_SIZE_Y; y++)
                    {
                        Console.Write("\t");
                        for (int x = 0; x < BOARD_SIZE_X; x++)
                        {
                            switch (Map[y, x])
                            {
                                case -1:
                                    Console.Write("□".PadRight(1, ' '));
                                    break;
                                case 0:
                                    if (x >= MoveY - 2 && x <= MoveY + 2 && y >= MoveX&& y <= MoveX + 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("■".PadRight(1, ' '));
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        Console.Write(" ".PadRight(2, ' '));
                                    }
                                    break;
                                case 1:
                                    if (x >= MoveY - 2 && x <= MoveY + 2 && y >= MoveX&& y <= MoveX + 2)
                                    {
                                        Console.Write("*".PadRight(2, ' '));
                                    }
                                    else
                                    {
                                        Console.Write(" ".PadRight(2, ' '));
                                    }

                                    break;
                                case 2:
                                    if (x >= MoveY - 2 && x <= MoveY + 2 && y >= MoveX&& y <= MoveX + 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("$".PadRight(2, ' '));
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        Console.Write(" ".PadRight(2, ' '));
                                    }

                                    break;
                                case 6:
                                    Console.Write("▼".PadRight(1, ' '));

                                    break;
                                default:
                                    break;
                            }
                        }
                        Console.WriteLine();
                    }
                    break;


            }

            //for (int y = 0; y < BOARD_SIZE_Y; y++)
            //{
            //    Console.Write("\t");
            //    for (int x = 0; x < BOARD_SIZE_X; x++)
            //    {
            //        switch (Map[y, x])
            //        {
            //            case -1:
            //                Console.Write("□".PadRight(2, ' '));
            //                break;
            //            case 0:
            //                if (x >= MoveY - 2 && x <= MoveY + 2 && y >= MoveX - 2 && y <= MoveX + 2)
            //                {
            //                    Console.ForegroundColor = ConsoleColor.Yellow;
            //                    Console.Write("■".PadRight(2, ' '));
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                }
            //                else
            //                {
            //                    Console.Write(" ".PadRight(3, ' '));
            //                }
            //                break;
            //            case 1:
            //                if (x >= MoveY - 2 && x <= MoveY + 2 && y >= MoveX - 2 && y <= MoveX + 2)
            //                {
            //                    Console.Write("*".PadRight(3, ' '));
            //                }
            //                else
            //                {
            //                    Console.Write(" ".PadRight(3, ' '));
            //                }

            //                break;
            //                case 2:
            //                if (x >= MoveY - 2 && x <= MoveY + 2 && y >= MoveX - 2 && y <= MoveX + 2)
            //                {
            //                    Console.ForegroundColor = ConsoleColor.Green;
            //                    Console.Write("$".PadRight(3, ' '));
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                }
            //                else
            //                {
            //                    Console.Write(" ".PadRight(3, ' '));
            //                }

            //                break;
            //            case 3:
            //                if (x >= MoveY - 2 && x <= MoveY + 2 && y >= MoveX - 2 && y <= MoveX + 2)
            //                {
            //                    Console.Write("▶".PadRight(2, ' '));
            //                }
            //                else
            //                {
            //                    Console.Write(" ".PadRight(3, ' '));
            //                }

            //                break;
            //            case 4:
            //                if (x >= MoveY - 2 && x <= MoveY + 2 && y >= MoveX - 2 && y <= MoveX + 2)
            //                {
            //                    Console.Write("◀".PadRight(2, ' '));
            //                }
            //                else
            //                {
            //                    Console.Write(" ".PadRight(3, ' '));
            //                }

            //                break;
            //            case 5:
            //                if (x >= MoveY - 2 && x <= MoveY + 1 && y >= MoveX - 1 && y <= MoveX + 1)
            //                {
            //                    Console.Write("▲".PadRight(2, ' '));
            //                }
            //                else
            //                {
            //                    Console.Write(" ".PadRight(3, ' '));
            //                }

            //                break;
            //            case 6:
            //                if (x >= MoveY - 2 && x <= MoveY + 2 && y >= MoveX - 2 && y <= MoveX + 2)
            //                {
            //                    Console.Write("▼".PadRight(2, ' '));
            //                }
            //                else
            //                {
            //                    Console.Write(" ".PadRight(3, ' '));
            //                }
            //                break;
            //            default:
            //                break;
            //        }                   
            //    }
            //    Console.WriteLine();

            //}
            Console.WriteLine("\t현재 점수: {0}", Score);
        }
        public static void Main()
        {
            Random random= new Random();
            bool CoinIsHere = false;
            int CoinX = 0;
            int CoinY = 0;
            
            

            for (int y = 0; y < BOARD_SIZE_Y; y++)
            {
                for (int x = 0; x < BOARD_SIZE_X; x++)
                {
                    bool check = (0 < x && x < BOARD_SIZE_X - 1) && (0 < y && y < BOARD_SIZE_Y - 1);
                    if (check)
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
            
            Map(gameBoard);

            while (true)
            {
                for (int y = 0; y < BOARD_SIZE_Y; y++)
                {
                    for (int x = 0; x < BOARD_SIZE_X; x++)
                    {
                        if(gameBoard[x, y] == 2 )
                        {
                            CoinIsHere = true;
                            break;
                        }
                        else { CoinIsHere = false; }
                    }
                    if(CoinIsHere == true)
                    {
                        break;
                    }
                }
                if(CoinIsHere == false)
                {
                    for(int i=0;i < 3;i++)
                    {
                        Console.Clear();
                        CoinX = random.Next(1, BOARD_SIZE_X - 1);
                        CoinY = random.Next(1, BOARD_SIZE_Y - 1);
                        if( CoinX == MoveX && CoinY == MoveY)
                        {
                            ++Score;
                        }
                        else
                        {
                            gameBoard[CoinX, CoinY] = 2;
                        }
                        
                        Map(gameBoard);
                        Console.WriteLine("\t코인 생성중...");
                        Task.Delay(300).Wait();
                    }
                }
                Console.Clear();
                Map(gameBoard);
                Console.Write("\t");
                Console.Write("어느 방향으로 움직일 것인가요(w,a,s,d로 움직임)");



                ConsoleKeyInfo kr = Console.ReadKey();
                char Move = kr.KeyChar;

                switch (Move)
                {
                    case 'w':
                        if (MoveX > 1)
                        {
                            if (gameBoard[MoveX - 1, MoveY] == 2)
                            {
                                Score++;
                            }
                            gameBoard[MoveX, MoveY] = 0;
                            gameBoard[--MoveX, MoveY] = 5;
                        }
                        else
                        {
                            Console.WriteLine("더이상 이동할 수 없습니다.");
                        }

                        break;
                    case 'a':
                        if (MoveY > 1)
                        {
                            if (gameBoard[MoveX, MoveY - 1] == 2)
                            {
                                Score++;
                            }
                            gameBoard[MoveX, MoveY] = 0;
                            gameBoard[MoveX, --MoveY] = 4;
                        }
                        else
                        {
                            Console.WriteLine("더이상 이동할 수 없습니다.");
                        }
                        break;
                    case 's':
                        if (MoveX < BOARD_SIZE_X - 2)
                        {
                            if (gameBoard[MoveX + 1, MoveY] == 2)
                            {
                                Score++;
                            }
                            gameBoard[MoveX, MoveY] = 0;
                            gameBoard[++MoveX, MoveY] = 6;
                        }
                        else
                        {
                            Console.WriteLine("더이상 이동할 수 없습니다.");
                        }
                        break;
                    case 'd':
                        if (MoveY < BOARD_SIZE_Y - 2)
                        {
                            if (gameBoard[MoveX, MoveY + 1] == 2)
                            {
                                Score++;
                            }
                            gameBoard[MoveX, MoveY] = 0;
                            gameBoard[MoveX, ++MoveY] = 3;
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
                Map(gameBoard);
                if( Score>29)
                {
                    Console.WriteLine("\n\n\t\t    승리!!!!!    ");
                    break;
                }
            }
        }
    }
}
