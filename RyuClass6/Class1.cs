using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyuClass6
{
    internal class Class1
    {
        static int _number1 = 1;        //글로벌 변수
        static int _number2 = 3;

        public static void Main()
        {
            int num1 = 10;
            int num2 = -11;
            int Plus1 = Plus(num1, num2);
            Console.WriteLine(Plus1);
            number(num1, num2);

            Multi();
            Multi("반갑습니다.");
            Multi("또 만나요.", 3);
            int n = 10;
            int f =Factorial(n);
            Console.WriteLine($"{f}");

            int number1 = 10;       //글로벌 변수와 로컬 변수가 동시에 존재하면 로컬 변수가 이미 있기 때문에 글로벌 변수를 찾지 않는다.
            int number2 = 30;
            Swap( _number1, _number2);
            Console.WriteLine("Mian의 number 값은? {0}, {1}", _number1, _number2);
        }

        static void Swap( int intValue1,  int intValue2)
        {
            Console.WriteLine("바뀌기 전의 값 {0}, {1}", intValue1, intValue2);
            int temp;
            temp = intValue1;
            intValue1 = intValue2;
            intValue2 = temp;

            Console.WriteLine("바뀐 후의 값 {0}, {1}", intValue1, intValue2);
        }

        static int Plus( int x, int y)
        {
            
            return x + y;
        }

        static void number( int num1, int num2)
        {
            int Big = 0;
            int small = 0;
            if( num1 >= num2)
            {
                Big = num1;
                small = num2;
            }
            else
            {
                Big = num2;
                small = num1;
            }
            if(num1<0)
            {
                num1 = num1*(-1);
            }   //num1가 음수인 경우
            if (num2 <0)
            {
                num2 = num2*(-1);
            }   //num2가 음수인 경우

            Console.WriteLine($"큰값: {Big} 작은값: {small} 절대값: {num1}, {num2}");

        }

        static void FunctionOverLoading()
        {
            /**
             * 함수 오버로드: 다중 정의
             * 클래스 하나에 매개변수를 달리해서 이름이 동일한 함수 여러 개를 정의할 수 있는데, 이를 함수 오버로드라고
             * 한다, 우리말로는 여러번 정의한다는 의미이다.
             */
        }

        //! 숫자를 받아서 출력하는 함수
        /*
         * @param number int type number of print
         */
        static void GetNumber( int number)
        {
            Console.WriteLine($"Int32: {number}");
        }

        static void GetNumber(long number)
        {
            Console.WriteLine($"Int64: {number}");
            Console.WriteLine($"8바이트 정수: {number}");
        }
        
        static void Multi()
        {
            Console.WriteLine("안녕하세요.");
        }
        
        static void Multi(string message)
        {
            Console.WriteLine(message);
        }

        static void Multi(string message, int count)
        {
            for( int i = 0; i < count;i++ )
            {
                Console.WriteLine(message);
            }
        }

        static void RecursionFunction()
        {
            /*
             * 재귀 함수 
             * 함수에서 함수 자신을 호출하는 것을 재귀(Recursion) 또는 재귀 함수라고 한다.
             */
        }
        
        static int Factorial(int n)
        {
            if(n==0 || n==1)     //여기서 탈출함
            {
                return 1;
            }

            Console.WriteLine("n의 값은{0}", n);
            return n * Factorial(n - 1);        // 여기서 재귀 호출했음.
        }   // 빠른 계산에는 사용하지만, 게임을 만들때에는 메모리를 많이 쓰기 때문에 사용하지 않는다.

        static void FunctionScope()
        {
            /**
             * 함수 범위: 전역 변수와 지역 변수
             * 클래스와 같은 레벨에서 선언된 변수를 전역 변수(Global variable) 또는 필드(Field)라고 하며,
             * 함수 레벨에서 선언된 변수를 지역 변수(Local variable)라고 한다. 이때 동일한 이름으로 변수를
             * 전역 변수와 함수 내의 지역 변수로 선언할 수 있다. 함수 내에서는 함수 범위에 있는 지역 변수를 사용하고,
             * 함수 범위 내에 선언된 변수가 없으면 전역 변수 내에 선언된 변수를 사용한다.
             * 단, C#에서는 전역 변수가 아닌 필드라는 단어를 주로 사용하며, 전역 변수는 언더스코어(_) 또는 m_ 접두사를
             * 붙이는 경향이 있다.
             */
        }

        static void ArrowFunction()
        {
            /*
             * 화살표 함수 
             * 화살표 모양의 연산자인 화살표 연산자(=>)를 사용하여 메서드 코드를 줄일 수 있다. 이를 화살표 함수
             * (Arrow function)라고 한다. 프로그래밍에서 화살표 함수 또는 화살표 메서드는 람다 식(Lambda expression)의
             * 또다른 이름이다.
             * 화살표 함수를 사용하면 함수를 줄여서 표현할 수 있다. 함수 도유의 표현을 줄여서 사용하면 처음에는 어색할 수 있다.
             * 하지만 이 방식에 익숙해지면 차후에는 코드의 간결함을 유지할 수 있다.
             */ //모르면 안써도됨
        }

        
    }
}
