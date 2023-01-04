using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace WhatisFuctionParameter
{
    internal class Potal
    {
        const int BOARD_SIZE_X = 15;
        const int BOARD_SIZE_Y = 15;
        const int MoveX = 1;
        const int MoveY = 1;

        //public static int[,] MakeMap()
        //{
        //    int[,] gameBoard = new int[BOARD_SIZE_Y, BOARD_SIZE_X];
        //    int CoinX;
        //    int CoinY;
            
        //    Random rand = new Random(); 
            
                
        //    for (int y = 0; y < BOARD_SIZE_Y; y++)
        //    {
        //        for (int x = 0; x < BOARD_SIZE_X; x++)
        //        {
        //            bool check = (0 < x && x < BOARD_SIZE_X - 1) && (0 < y && y < BOARD_SIZE_Y - 1);
        //            if (check)
        //            {
        //                gameBoard[x, y] = 0;
        //            }
        //            else
        //            {
        //                gameBoard[x, y] = -1;
        //            }

        //        }
        //    }
        //    for (int i = 0; i < 3; i++)
        //    {

        //        CoinX = rand.Next(1, BOARD_SIZE_X - 1);
        //        CoinY = rand.Next(1, BOARD_SIZE_Y - 1);
        //        if (CoinX == MoveX && CoinY == MoveY)
        //        {

        //        }
        //        else
        //        {
        //            gameBoard[CoinX, CoinY] = 3;

        //        }
        //    }
        //    switch (rand.Next(1, 5))
        //    {
        //        case 1:
        //            gameBoard[0, BOARD_SIZE_X / 2] = 2;
        //            break;
        //        case 2:
        //            gameBoard[BOARD_SIZE_Y - 1, BOARD_SIZE_X / 2] = 2;
        //            break;
        //        case 3:
        //            gameBoard[BOARD_SIZE_Y / 2, BOARD_SIZE_X - 1] = 2;
        //            break;
        //        case 4:
        //            gameBoard[BOARD_SIZE_Y / 2, 0] = 2;
        //            break;
        //    }
        //    return gameBoard;
        //}


        public static void Main()
        {
            
            int MoveX = 1;
            int MoveY = 1;
            int[,] gameBoard = new int[BOARD_SIZE_Y, BOARD_SIZE_X];
            bool CoinIsHere = false;
            int RoomX = 1;
            int RoomY = 1;
            int[,] RoomClear = new int[3, 5]; 
            RoomMaker room = new RoomMaker();
            gameBoard = room.RoomArray(RoomX, RoomY, RoomClear[RoomX, RoomY]);
            //gameBoard = MakeMap();          //맵 초기화
            Random rand = new Random();
            
            
            for (int y = 0; y < BOARD_SIZE_Y; y++)
            {
                for (int x = 0; x < BOARD_SIZE_X; x++)
                {
                    if (gameBoard[x, y] == 3)
                    {
                        CoinIsHere = true;
                        
                        break;
                    }
                    else 
                    { 
                        CoinIsHere = false;
                        
                    }
                }
                if (CoinIsHere == true)
                {
                    break;
                }
            }


            gameBoard[MoveX, MoveY] = 1;
            
            
            bool AllClear = true;

            while (AllClear)
            {
                Console.Clear();


                for (int y = 0; y < BOARD_SIZE_Y; y++)
                {
                    for (int x = 0; x < BOARD_SIZE_X; x++)
                    {
                        switch (gameBoard[y, x])
                        {
                            case -1:
                                Console.Write("■".PadRight(1, ' '));
                                break;
                            case 0:
                                Console.Write(".".PadRight(2, ' '));
                                break;
                            case 1:
                                Console.Write("*".PadRight(2, ' '));
                                break;
                            case 2:
                                if (CoinIsHere == false)
                                {
                                    Console.Write("○".PadRight(1, ' '));
                                    RoomClear[RoomX, RoomY] = 1;

                                }
                                else
                                {
                                    Console.Write("●".PadRight(1, ' '));
                                }
                                break;
                            case 3:
                                Console.Write("$".PadRight(2, ' '));
                                break;
                            default:
                                break;
                        }


                    }
                    Console.WriteLine();
                }
                int count = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (RoomClear[i, j] == 1)
                        {
                            count++;
                        }
                    }
                }
                if (count >= 10)
                {
                    AllClear = false;
                    
                }
                
                if(AllClear)
                {
                    Console.Write("어느 방향으로 움직일 것인가요(w,a,s,d로 움직임)");

                    ConsoleKeyInfo kr = Console.ReadKey();                          // 움직임 입력
                    char Move = kr.KeyChar;


                    switch (Move)
                    {
                        case 'w':
                            if (gameBoard[MoveX - 1, MoveY] == 0 || gameBoard[MoveX - 1, MoveY] == 3)
                            {
                                gameBoard[MoveX, MoveY] = 0;
                                gameBoard[--MoveX, MoveY] = 1;
                            }
                            else if (gameBoard[MoveX - 1, MoveY] == 2 && CoinIsHere == false)
                            {
                                //gameBoard = MakeMap();
                                gameBoard = room.RoomArray(RoomX, --RoomY, RoomClear[RoomX, RoomY]);
                                gameBoard[MoveX, MoveY] = 0;
                                gameBoard[MoveX + (BOARD_SIZE_Y - 3), MoveY] = 1;
                                MoveX = MoveX + (BOARD_SIZE_Y - 3);
                                //gameBoard[0, BOARD_SIZE_X / 2] = -1;
                                //gameBoard[BOARD_SIZE_Y - 1, BOARD_SIZE_X / 2] = 2;
                                // PassPotal= true;
                            }
                            else
                            {
                                Console.WriteLine("더이상 이동할 수 없습니다.");
                            }

                            break;
                        case 'a':
                            if (gameBoard[MoveX, MoveY - 1] == 0 || gameBoard[MoveX, MoveY - 1] == 3)
                            {
                                gameBoard[MoveX, MoveY] = 0;
                                gameBoard[MoveX, --MoveY] = 1;
                            }
                            else if (gameBoard[MoveX, MoveY - 1] == 2 && CoinIsHere == false)
                            {
                                gameBoard = room.RoomArray(--RoomX, RoomY, RoomClear[RoomX, RoomY]);
                                //gameBoard = MakeMap();
                                gameBoard[MoveX, MoveY] = 0;
                                gameBoard[MoveX, MoveY + (BOARD_SIZE_X - 3)] = 1;
                                MoveY = MoveY + (BOARD_SIZE_X - 3);
                                //gameBoard[BOARD_SIZE_Y / 2, 0] = -1;
                                //gameBoard[BOARD_SIZE_Y / 2, BOARD_SIZE_X - 1] = 2;
                                // PassPotal = true;
                            }
                            else
                            {
                                Console.WriteLine("더이상 이동할 수 없습니다.");
                            }

                            break;
                        case 's':
                            if (gameBoard[MoveX + 1, MoveY] == 0 || gameBoard[MoveX + 1, MoveY] == 3)
                            {
                                gameBoard[MoveX, MoveY] = 0;
                                gameBoard[++MoveX, MoveY] = 1;
                            }
                            else if (gameBoard[MoveX + 1, MoveY] == 2 && CoinIsHere == false)
                            {
                                gameBoard = room.RoomArray(RoomX, ++RoomY, RoomClear[RoomX, RoomY]);
                                //gameBoard = MakeMap();
                                gameBoard[MoveX, MoveY] = 0;
                                gameBoard[MoveX - (BOARD_SIZE_Y - 3), MoveY] = 1;
                                MoveX = MoveX - (BOARD_SIZE_Y - 3);
                                //gameBoard[BOARD_SIZE_Y - 1, BOARD_SIZE_X / 2] = -1;
                                //gameBoard[0, BOARD_SIZE_X / 2] = 2;
                                // PassPotal = true;
                            }
                            else
                            {
                                Console.WriteLine("더이상 이동할 수 없습니다.");
                            }

                            break;
                        case 'd':
                            if (gameBoard[MoveX, MoveY + 1] == 0 || gameBoard[MoveX, MoveY + 1] == 3)
                            {
                                gameBoard[MoveX, MoveY] = 0;
                                gameBoard[MoveX, ++MoveY] = 1;
                            }
                            else if (gameBoard[MoveX, MoveY + 1] == 2 && CoinIsHere == false)
                            {
                                gameBoard = room.RoomArray(++RoomX, RoomY, RoomClear[RoomX, RoomY]);
                                //gameBoard = MakeMap();
                                gameBoard[MoveX, MoveY] = 0;
                                gameBoard[MoveX, MoveY - (BOARD_SIZE_X - 3)] = 1;
                                MoveY = MoveY - (BOARD_SIZE_X - 3);
                                //gameBoard[BOARD_SIZE_Y / 2, BOARD_SIZE_X - 1] = -1;
                                //gameBoard[BOARD_SIZE_Y / 2, 0] = 2;
                                //PassPotal = true;
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
                            if (gameBoard[x, y] == 3)
                            {
                                CoinIsHere = true;                  // 동전이 남아있음
                                break;
                            }
                            else { CoinIsHere = false; }
                        }
                        if (CoinIsHere == true)
                        {
                            break;
                        }
                    }
                }
                
                
                


            }
            Console.WriteLine("모든 코인을 먹었습니다.  -끝-");

        }
    }
}
