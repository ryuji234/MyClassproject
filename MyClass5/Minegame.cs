using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass5
{
    internal class Minegame
    {
        /**
             * 지뢰 찾기 
             * 10*10 보드에 지뢰를 숨김(N%확률로 지뢰 매설)
             * debug mode 에서 지뢰가 아닛 곳은 .(닷), 지뢰인 곳은 #(샵)으로 표현
             * play mode 에서 확인 되지 않은 곳은 전부 □(스퀘어)로 표현
             * 첫 턴에 지회를 밟으면 해당 칸에 지뢰를 치워 줌
             * */
        public static void Main()
        {
            Random randomMine= new Random();
            const int MINE_PERCETAGE = 30;
            const int BOARD_SIZE_X = 10;
            const int BOARD_SIZE_Y = 10;

            bool isDebugMode = false;
            bool isGameOver = false;
            bool isPlayerwin = false;
            int playerTurnCnt = 0;

            /*
             * 10*10 보드에 지뢰 초기화 한다
             * 
             * gameBoard 상태
             *  지뢰: MINE_PERCENTAGE 미만의 값
             *  빈 칸: MINE_PERCETAGE 이상의 값
             *  
             *  playBoard 상태
             *   -2: 지뢰 없음
             *   -1: 초기값
             *   n: 주변 9타일 이내 지뢰 수 (0일 경우 ■ 표기, 양수일 경우 정수 표기)
             *   
             *   mineCntBoard 상태
             *   -1: 지뢰 있음
             *   n: 주변 9타일 이내에 지뢰 수
             *   */
            int[,] gameBoard = new int[BOARD_SIZE_Y, BOARD_SIZE_X];
            int[,] playBoard = new int[BOARD_SIZE_Y, BOARD_SIZE_X];
            int[,] mineCntMap = new int[BOARD_SIZE_Y, BOARD_SIZE_X];
            for(int y = 0; y <BOARD_SIZE_Y;y++ )
            {
                for(int x = 0; x<BOARD_SIZE_X;x++)
                {
                    gameBoard[y,x] = randomMine.Next(1,100);
                    playBoard[y, x] = -1;
                    if (gameBoard[y,x] < MINE_PERCETAGE)
                    {
                        mineCntMap[y,x] = -1;
                    }   // if: 지뢰가 셋업된 경우
                    else
                    {
                        mineCntMap[y, x] = 0;
                    }   // else: 지뢰가 없는 경우
                }
            }   // loop: 지뢰를 초기화 하는 경우

            // 게임 시작

            while(isGameOver == false)
            {
                //{ 현제 보드의 상태를 플레이 시점으로 보여준다.
                for(int y = 0; y < BOARD_SIZE_Y;y++)
                {
                    for(int x = 0; x<BOARD_SIZE_X;x++)
                    {
                        switch(playBoard[y,x]) 
                        {
                            case -2:
                                Console.Write("X".PadRight(3, ' '));
                                break;
                            case -1:
                                Console.Write("□".PadRight(2, ' '));
                                break;
                            case 0:
                                Console.Write("■".PadRight(2, ' '));
                                break;
                            default:
                                Console.Write("{0}".PadRight(5, ' '), playBoard[y, x]);
                                break;
                                
                        }   // switch
                    }   //loop
                    Console.WriteLine();
                }
                Console.WriteLine();
                //} 현재 보드의 상태를 플레이 시점으로 보여준다.

                int PlayerX = 0;
                int PlayerY = 0;
                bool isLocationVaild = false;
                //  {플레이어 좌표 입력
                while(isLocationVaild == false)
                {
                    Console.Write("[플레이어] x 좌표 입력: ");
                    int.TryParse(Console.ReadLine(), out PlayerX);
                    Console.Write("[플레이어] y 좌표 입력: ");
                    int.TryParse(Console.ReadLine(), out PlayerY);

                    // 플레이어가 입력한 좌표의 유효성을 검사한다.
                    isLocationVaild =
                        ( 0 <= PlayerX && PlayerX <BOARD_SIZE_X)&&
                        (0 <=PlayerY&& PlayerY <BOARD_SIZE_Y);
                    if(isLocationVaild == false)
                    {
                        Console.WriteLine("{0} {1}", "[System] 해당 좌표는 유효하지 않습니다.",
                            "다른 좌표를 입력하세요 \n");
                        continue;
                    }   //if: 좌표를 잘못 입력한 경우
                    // 좌표를 제대로 입력한 경우만 이 아래로 코드가 진행됨, 왜냐하면 유효하지 않은 경우 위에서
                    // continue 만나기 때문에

                    // 플레이 보드에서 선택 가능한지 검사한다.
                    isLocationVaild = isLocationVaild && playBoard[PlayerY, PlayerX].Equals(-1);
                    if(isLocationVaild == false)
                    {
                        Console.WriteLine("{0} {1}", "[System] 해당 좌표는 이미 오픈되어있습니다.",
                            "다른 좌표를 입력하세요. \n");
                        continue;
                    }
                    // 좌표를 제대로 입력한 경우만 이 아래로 코드가 진행됨, 왜냐하면 유효하지 않은 경우 위에서
                    // continue 만나기 때문에
                }   //loop
                playerTurnCnt++;
                //  }플레이어 좌표 입력

                // 현제 첫 턴이라면 해당 좌표에 지뢰가 있어도 지워준다.
                if(playerTurnCnt.Equals(1))
                {
                    gameBoard[PlayerY, PlayerX] = MINE_PERCETAGE + 1;
                    mineCntMap[PlayerY, PlayerX] = 0;
                    playBoard[PlayerY, PlayerX] = -1;

                    // { 지뢰의 수를 세어 지도를 생성한다.
                    for(int y= 0; y<BOARD_SIZE_Y;y++)
                    {
                        for(int x = 0; x< BOARD_SIZE_X;x++)
                        {
                            //지뢰가 없는 곳은 넘어간다.
                            if (mineCntMap[y,x].Equals(-1) == false) { continue; }

                            //지뢰가 주변 9타일에 수를 1씩 추가한다.
                            bool isSearchTileValid = false;
                            for(int searchY = y -1; searchY <=y+1;searchY++)
                            {
                                for(int searchX = x-1;searchX <=x+1;searchX++)
                                {
                                    isSearchTileValid = 
                                        (0 <= searchX && searchX < BOARD_SIZE_X)&&
                                        (0 <= searchY && searchY < BOARD_SIZE_Y);
                                    if(isSearchTileValid == false) { continue; }
                                    // 9타일 서치 중에 지뢰가 있다면 패스한다.
                                    if (mineCntMap[searchY,searchX].Equals(-1)) { continue; }

                                    mineCntMap[searchY, searchX]++;
                                }
                            }       // loop: 지뢰 주변 9타일을 순회하는 루프
                        }
                    }       // loop: 게임 보드를 순회하는 루프
                    // } 지뢰의 수를 세어 지도를 생성한다.
                }   //if: 첫 턴인 경우

                //{ 선택한 좌표에서 지뢰를 검사한다.
                if (gameBoard[PlayerY, PlayerX] < MINE_PERCETAGE)
                {
                    isGameOver = true;
                    isPlayerwin = false;
                    playBoard[PlayerY,PlayerX] = -2;
                }       //if: 지뢰를 선택한 경우
                else
                {

                }       //else: 지뢰가 아닌 , 빈 타일을 선택한 경우
                //} 선택한 좌표에서 지뢰를 검사한다.
            }   //loop: 게임 루프
        }
    }
}
