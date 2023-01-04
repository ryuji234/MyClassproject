using System;

namespace WhatIsDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /**
             * 함수에서 return은 그 값을 반환한다.
             * void는 반환하는 값이 없는 것이다.
             */
            //if(/* 게임 종료 조건*/)
            //{
            //    return 0;
            //}
            //return 0;       // 모든 조건에서 return 해야지 조건이 만족한다.
            Description desc = new Description();

            desc.Hi();
        }

    }
}