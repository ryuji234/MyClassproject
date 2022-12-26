using System;
using System.Numerics;


namespace MyClass5
{
    internal class TicTacTOe
    {
        /**
         * Tic-Tac-Toe 게임
         * 컴퓨터와 사람이 번갈아 가면서 o,x를 둔다.
         * 보드 크기는 3*3
         * 컴퓨터의 룰은 간단하게
         * 1. 중앙에 비었으면 중앙을 선점 하려고 한다.
         * 2. 이후에 빈자리 아무곳이나 적당히 찾아서 둔다.
         * */
        enum TicTacToePlayerType
        {
            NONE = 0, PLAYER, COMPUTER 
        }

        public static void Main()
        {
            int[,] gameBoard = new int[3, 3];
            int playerX, playerY = 0;
            bool isvalidLocation = false;
            bool isPlayerTurn = false;
            bool isGameOver = false;

            string playerIcon = string.Empty;
            string PlayerType = string.Empty;

            while (isGameOver == false)
            {
                isPlayerTurn = true;
                PlayerType = "[플레이어]";

                playerX = 0;
                playerY = 0;
                isvalidLocation = false;
                while (true)
                {
                    if (isvalidLocation == true) { break; }

                    Console.Write("[플레이어] (x) 좌표: ");
                    int.TryParse(Console.ReadLine(), out playerX);
                    Console.Write("[플레이어] (y) 좌표: ");
                    int.TryParse(Console.ReadLine(), out playerY);

                    if (gameBoard[playerY, playerX].Equals((int)TicTacToePlayerType.NONE))
                    {
                        gameBoard[playerY, playerX] = (int)(TicTacToePlayerType.PLAYER);
                        isvalidLocation = true;
                    }   //if: 보드가 빈 곳인 경우
                    else
                    {
                        Console.WriteLine("[System] 해당 좌표는 비어있지 않습니다. / 다른 좌표를 입력하세요");
                        isvalidLocation = false;
                    }   //else: 보드가 빈 곳이 아닌 경우
                }   //loop: 플레이어의 좌표 입력을 받는 루프

                // } 플레이어에게서 좌료를 입력 받는다.

                // { 플레이어의 턴 진행을 보드에 출력한다.
                for (int y = 0; y <= gameBoard.GetUpperBound(0); y++)
                {
                    Console.WriteLine("---|---|---");
                    for (int x = 0; x <= gameBoard.GetUpperBound(1); x++)
                    {
                        switch (gameBoard[y, x])
                        {
                            case (int)TicTacToePlayerType.PLAYER:
                                playerIcon = "O";
                                break;
                            case (int)TicTacToePlayerType.COMPUTER:
                                playerIcon = "X";
                                break;
                            default:
                                playerIcon = " ";
                                break;
                        }
                        Console.Write(" {0} ", playerIcon);

                        if (x == gameBoard.GetUpperBound(1)) { }
                        else { Console.Write("|"); }

                    }
                    Console.WriteLine();

                }
                Console.WriteLine("---|---|---");
                //loop: 틱택토 게임 루프

                Console.WriteLine();
                isGameOver = false;
                for (int y = 0; y <= gameBoard.GetUpperBound(0); y++)
                {
                    if (gameBoard[y, 0].Equals((int)TicTacToePlayerType.PLAYER) &&
                        gameBoard[y, 1].Equals((int)TicTacToePlayerType.PLAYER) &&
                        gameBoard[y, 2].Equals((int)TicTacToePlayerType.PLAYER))
                    {
                        isGameOver = true;
                    }
                    else { continue; }
                }
                for (int x = 0; x <= gameBoard.GetUpperBound(1); x++)
                {
                    if (gameBoard[0, x].Equals((int)TicTacToePlayerType.PLAYER) &&
                        gameBoard[1, x].Equals((int)TicTacToePlayerType.PLAYER) &&
                        gameBoard[2, x].Equals((int)TicTacToePlayerType.PLAYER))
                    {
                        isGameOver = true;
                    }
                    else { continue; }
                }   //loop: 세로 방향으로 검사하는 루프

                // 대각선 방향으로 검사
                if (gameBoard[0, 0].Equals((int)TicTacToePlayerType.PLAYER)&&
                    gameBoard[1, 1].Equals((int)TicTacToePlayerType.PLAYER)&&
                    gameBoard[2, 2].Equals((int)TicTacToePlayerType.PLAYER))
                {
                    isGameOver = true;
                }
                if (gameBoard[0, 2].Equals((int)TicTacToePlayerType.PLAYER) &&
                    gameBoard[1, 1].Equals((int)TicTacToePlayerType.PLAYER) &&
                    gameBoard[2, 0].Equals((int)TicTacToePlayerType.PLAYER))
                {
                    isGameOver = true;
                }

                // } 게임이 끝났는지 보드 검사

                // 게임이 끝난 경우 루프를 탈출한다.
                if (isGameOver) { break; }

                // 게임이 끝나지 않은 경우 턴을 교체한다.
                isPlayerTurn = false;
                PlayerType = "[컴퓨터]";
                bool isComputerDoing = false;

                Console.WriteLine("{0}의 턴", PlayerType);
                // 컴퓨터는 간단한 룰
                // { 1. 중앙이 비어 있으면 선점
                if(isComputerDoing == false)
                {
                    if (gameBoard[1, 1].Equals((int)TicTacToePlayerType.NONE))
                    {
                        gameBoard[1, 1] = (int)TicTacToePlayerType.COMPUTER;
                        isComputerDoing = true;
                    }
                    else { /* Do nothing*/ }
                }
                else { /* Do nothing*/ }
                // } 1. 중앙이 비어 있으면 선점

                // { 2. 적당히 빈 자리 찾아서 착수
                if (isComputerDoing == false)
                {
                    for (int y = 0; y <= gameBoard.GetUpperBound(0); y++)
                    {
                        for (int x = 0; x <= gameBoard.GetUpperBound(1); x++)
                        {
                            if (isComputerDoing == false &&
                                gameBoard[y, x].Equals((int)TicTacToePlayerType.NONE))
                            {
                                gameBoard[y, x] = (int)TicTacToePlayerType.COMPUTER;
                                isComputerDoing = true;
                            }   //if: 서치한 자리가 비어있는 경우
                            else { continue; }

                        }   // loop: Search horizontal
                    }   // loop: Search vertical
                }   // if : 컴퓨터가 아직 아무것도 하지 않은 경우
                else { /* Do nothing*/ }
                // } 2. 적당히 빈 자리 찾아서 착수

                // { 컴퓨터의 턴 진행을 보드에 출력한다.
               for(int y =0;y<= gameBoard.GetUpperBound(0);y++)
                {
                    Console.WriteLine("---|---|---");
                    for(int x = 0; x<= gameBoard.GetUpperBound(1);x++)
                    {
                        switch (gameBoard[y, x])
                        {
                            case (int)TicTacToePlayerType.PLAYER:
                                playerIcon = "O";
                                break;
                            case (int)TicTacToePlayerType.COMPUTER:
                                playerIcon = "X";
                                break;
                            default:
                                playerIcon = " ";
                                break;
                        }
                        Console.Write(" {0} ", playerIcon);

                        if(x == gameBoard.GetUpperBound(1)) { /* Do Nothing*/}
                        else { Console.Write("|"); }
                    }   //loop: 한 줄에서 출력할 내용을 연산한다.
                    Console.WriteLine();
                }   //loop
               Console.WriteLine("---|---|---");
                // } 컴퓨터의 턴 진행을 보드에 출력한다.
                isGameOver = false;

                for (int y = 0; y <= gameBoard.GetUpperBound(0); y++)
                {
                    if (gameBoard[y, 0].Equals((int)TicTacToePlayerType.COMPUTER) &&
                        gameBoard[y, 1].Equals((int)TicTacToePlayerType.COMPUTER) &&
                        gameBoard[y, 2].Equals((int)TicTacToePlayerType.COMPUTER))
                    {
                        isGameOver = true;
                    }
                    else { continue; }
                }   //loop: 가로 방향으로 검사하는 루프
                for (int x = 0; x <= gameBoard.GetUpperBound(1); x++)
                {
                    if (gameBoard[0, x].Equals((int)TicTacToePlayerType.COMPUTER) &&
                        gameBoard[1, x].Equals((int)TicTacToePlayerType.COMPUTER) &&
                        gameBoard[2, x].Equals((int)TicTacToePlayerType.COMPUTER))
                    {
                        isGameOver = true;
                    }
                    else { continue; }
                }   //loop: 세로 방향으로 검사하는 루프

                // 대각선 방향으로 검사
                if (gameBoard[0, 0].Equals((int)TicTacToePlayerType.COMPUTER) &&
                    gameBoard[1, 1].Equals((int)TicTacToePlayerType.COMPUTER) &&
                    gameBoard[2, 2].Equals((int)TicTacToePlayerType.COMPUTER))
                {
                    isGameOver = true;
                }
                if (gameBoard[0, 2].Equals((int)TicTacToePlayerType.COMPUTER) &&
                    gameBoard[1, 1].Equals((int)TicTacToePlayerType.COMPUTER) &&
                    gameBoard[2, 0].Equals((int)TicTacToePlayerType.COMPUTER))
                {
                    isGameOver = true;
                }

                if (isGameOver) { break; }
            }   // loop: 틱택토 게임 루프
                // { 게임이 끝났는지 보드 검사

            // } 게임이 끝났는지 보드 검사
            Console.WriteLine("{0}의 승리!", PlayerType);

        } 
        
    }
}
