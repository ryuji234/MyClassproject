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
        
        public int[,] RoomArray(int RoomX,int RoomY, int RoomClear)
        {
            
            int[,][,] Array = new int[5, 5][,];

            Array[0, 0] = Room(1, 0, 0, 0, RoomClear);        //동
            Array[0, 1] = Room(1, 0, 0, 0, RoomClear);        //동
            Array[1, 0] = Room(0, 1, 1, 0, RoomClear);        //서,남
            Array[1, 1] = Room(1, 1, 1, 1, RoomClear);        //동,서,남,북
            Array[1, 2] = Room(0, 0, 1, 1, RoomClear);        //남,북
            Array[1, 3] = Room(1, 0, 1, 1, RoomClear);        //동,남,북
            Array[1, 4] = Room(0, 0, 0, 1, RoomClear);        //북
            Array[2, 0] = Room(0, 0, 1, 0, RoomClear);        //남
            Array[2, 1] = Room(0, 1, 0, 1, RoomClear);        //서,북
            Array[2, 3] = Room(0, 1, 0, 0, RoomClear);        //서

            return Array[RoomX, RoomY];
        }
        public int[,] Room(int E, int W, int S, int N,int RoomClear)         // 동,서,남,북 다 열린맵
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
            if (RoomClear == 0)
            {
                for (int i = 0; i < 3; i++)
                {

                    CoinX = rand.Next(1, BOARD_SIZE_X - 1);
                    CoinY = rand.Next(1, BOARD_SIZE_Y - 1);

                    gameBoard[CoinX, CoinY] = 3;

                }
            }

            if ( E == 1) gameBoard[BOARD_SIZE_Y / 2, BOARD_SIZE_X - 1] = 2;                      //동
            
            if( W == 1) gameBoard[BOARD_SIZE_Y / 2, 0] = 2;                     //서

            if( S == 1) gameBoard[BOARD_SIZE_Y - 1, BOARD_SIZE_X / 2] = 2;                      //남

            if( N == 1) gameBoard[0, BOARD_SIZE_X / 2] = 2;                     //북
            
                       
            return gameBoard;
        }
        
    }
}
