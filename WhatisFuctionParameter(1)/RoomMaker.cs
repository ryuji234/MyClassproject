using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhatisFuctionParameter
{
    internal class RoomMaker
    {
        private int BOARD_SIZE_X = 15;
        private int BOARD_SIZE_Y = 15;        
        private int CoinX;
        private int CoinY;
        private Random rand = new Random();
        private int MoveX = 1;
        private int MoveY = 1;
        
        public int[,] RoomCoinCheck(int RoomX, int RoomY,int RoomClear)
        {
            int[,][,] roomarray = RoomArray();
            int[,] gameBoard = new int[BOARD_SIZE_Y, BOARD_SIZE_X];
            while(true)
            {
                if (RoomClear == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {

                        CoinX = rand.Next(1, BOARD_SIZE_X - 1);
                        CoinY = rand.Next(1, BOARD_SIZE_Y - 1);

                        gameBoard[CoinX, CoinY] = 3;

                    }
                }
                return roomarray[RoomX, RoomY];
            }
            
        }

        public int[,][,] RoomArray()
        {
            
            
            int East, West, South, North;
            int[,][,] Array = new int[5, 5][,];
            int[,] DoorCheck = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    East = rand.Next(0, 2);
                    West = rand.Next(0, 2);
                    South = rand.Next(0, 2);
                    North = rand.Next(0, 2);


                    if (i == 0) 
                    {
                        North = 0; 
                    }                            //맨위칸이면 북쪽 포탈 없음
                    else
                    {
                        if (DoorCheck[j, i - 1] % 3 == 0) { North = 1; }        // 윗 룸의 남쪽 포탈이 있으면 북쪽 포탈 개방
                    }

                    if (i == 4) { South = 0; }                         //맨아래칸이면 남쪽 포탈 없음
                    else { }
                    if (j == 0) { West = 0; }                        //왼쪽이면 서쪽 포탈 없음
                    else
                    {
                        if (DoorCheck[j - 1, i] % 5 == 0) { West = 1; }       //왼쪽 룸의 동쪽 포탈이 있으면 서쪽 포탈 개방
                    }

                    if (j == 4) { East = 0; }                       //오른쪽이면 포탈 없음
                    else { }

                    if (East == 0 && West == 0 && South == 0 && North == 0)             //룸을 하나도 만들지 못했는가   //그럼 다시
                    {
                        j--;
                    }
                    else
                    {
                        Array[j, i] = Room(East, West, South, North);
                        DoorCheck[j, i] = ((3 * South) * (5 * East));
                    }
                    
                }
            }


            return Array;
        }


        public int[,] Room(int E, int W, int S, int N)         // 맵
        {
            int[,] gameBoard = new int[BOARD_SIZE_Y, BOARD_SIZE_X];
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
            //if (RoomClear == 0)
            //{
            //    for (int i = 0; i < 3; i++)
            //    {

            //        CoinX = rand.Next(1, BOARD_SIZE_X - 1);
            //        CoinY = rand.Next(1, BOARD_SIZE_Y - 1);

            //        gameBoard[CoinX, CoinY] = 3;

            //    }
            //}

            if ( E == 1) gameBoard[BOARD_SIZE_Y / 2, BOARD_SIZE_X - 1] = 2;                      //동
            
            if( W == 1) gameBoard[BOARD_SIZE_Y / 2, 0] = 2;                     //서

            if( S == 1) gameBoard[BOARD_SIZE_Y - 1, BOARD_SIZE_X / 2] = 2;                      //남

            if( N == 1) gameBoard[0, BOARD_SIZE_X / 2] = 2;                     //북
            
                       
            return gameBoard;
        }
        
    }
}
