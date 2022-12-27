using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 1.3개의 정수 중에서 최대값을 찾는 함수 Maximum(x,y,z)를 정의할 것
 * 2.화면에 "Hello"를 출력하는 SayHello() 함수를 작성.
 *      -int 타입 매개변수 받아서 그 횟수만큼 "Hello"를 반복해서 출력.
 * 3.다른 두 변이 주어 졌을때 직각 삼각형의 빗변을 계산하는 함수 Hypot()를 정의할 것.
 *      -매개변수는 2개 타입은 double 형
 *      -리턴 타입도 double 형
 * 4.주어진 숫자가 소수인지 여부를 찾는 함수 Prime()을 작성
 *      -판별할 값의 범위는 2~100 사이의 값 중에서 소수는 모두 출력
 *      
 * 5.사용자가 입력하는 전화번호에서 소괄호를 삭제한 형태로 출력하는 프로그램을 작성(함수 사용)
 *      -전화번호를 입력 받는다. -> 소괄호를 삭제한 형태로 출력한다.
 *      -quit 입력하면 프로그램을 종료한다.
 *      -프로그램 종료 전까지 전화번호를 입력 받는다.
 */
namespace RyuClass6
{
    internal class Class3
    {
        public static void Main()
        {
            double x, y;
            
            int Max = Maximum();
            Console.WriteLine("최댓값은:{0}", Max);
            SayHello();
            Prime(2, 100);
            Console.WriteLine();
            Console.WriteLine("두 변의 길이를 각각 적으시요");
            
            x = double.Parse(Console.ReadLine());
            y = double.Parse(Console.ReadLine());
            
            Hypot(x, y);
             //2자리에서 반올림
            
            Console.WriteLine();

            Phonenumber();
        }

        static int Maximum()
        {
            int x = int.Parse(Console.ReadLine()); 
            int y = int.Parse(Console.ReadLine()); 
            int z = int.Parse(Console.ReadLine());
            if (x>y)
            {
                if(x>z)
                {
                    return x;
                }
                else
                {
                    return z;
                }
            }
            else
            {
                if(y>z)
                {
                    return y;
                }
                else
                {
                    return z;
                }
            }
        }       // 3개의 정수의 최대값
        static void SayHello()
        {
            Console.WriteLine("몇번 출력하나요");
            int n = int.Parse(Console.ReadLine());
            for(int i=0; i<n; i++)
            {
                Console.WriteLine("Hello");
            }
        }       //숫자 만큼 Hello 출력
        static void Hypot(double x, double y)
        {
            double z = Math.Sqrt(x * x + y * y);
            Console.WriteLine("{0},{1}변의 빗변",x,y);
            Console.WriteLine("{0:F4}", z);
        }       //직각 삼각형 빗변 출력

        static void Prime(int x, int y)
        {
            
            Console.WriteLine($"{x} {y}사이의 소수는:");
            bool check = false;
            for(int i = x ; i < y ; i++)
            {
                for( int j = 2 ; j < i; j++)
                {
                    if(i % j != 0)
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                        break;
                    }
                }
                if (i == 2)
                {
                    Console.Write("{0},", i);
                }
                else if(check)
                {
                    Console.Write("{0},", i);
                }
            }   
        }

        static void Phonenumber()
        {
            
            while (true)
            {

                Console.WriteLine();
                Console.WriteLine("전화번호를 입력하세요:(종료:quit)");
                String number = Console.ReadLine();
                if(number == "quit")
                {
                    break;
                }       // loop 탈출
                else
                {
                    char[] numberOnly = new char[number.Length];
                    int x = 0;
                    foreach (char c in number)
                    {
                        numberOnly[x] = c;
                        x++;

                    }   //문자열 한단어씩 배열 저장

                    for (int i = 0; i < numberOnly.Length - 1; i++)
                    {
                        if (numberOnly[i] == '(' || numberOnly[i] == ')')
                        {
                            numberOnly[i] = ' ';
                        }   // 소괄호 소거
                    }
                    for (int i = 0; i < numberOnly.Length; i++)
                    {
                        if(numberOnly[i] != ' ')
                        {
                            Console.Write(numberOnly[i]);
                        }
                        
                    }
                }
            }
            
            
        }

    }
}
