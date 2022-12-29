namespace ryuClass3
{
    /*
     * 1.사용자로부터 2개의 문자열을 읽어서 같은지 다른지 화면에 출력하는 프로그램 작성
     * Ex)
     *  첫번째 문자열: Hello
     *  두번째 문자열: World
     *  2개의 문자열은 다릅니다.
     *  - Equals 메서드를 사용하지 말것.
     *  
     *  2. 5개의 음료(콜라, 물, 스프라이트, 주스, 커피)를 판매하는 자판기 머신 구현
     *  사용자가 1부터 5 사이의 숫자를 입력함.
     *  선택한 음료를 출력함
     *  1~5 이외의 숫자를 선택하면 오류 메시지 출력함.
     *  Ex)  콜라, 물, 스프라이트, 주스, 커피 중에서 하나를 선택하세요.: 1
     *  콜라를 선택하였습니다.
     *  -프로그램 종료-
     *  
     *  3.배열 days[]를 아래와 같이 초기화하고 배열 요소의 값을 다음과 같이 출력하는 프로그램 작성
     *  - 배열 days[] 는 -> 31,29,31,30,31,30,31,31,30,31,30,31
     *  Ex)
     *  1월은 31일까지 입니다.
     *  2월은 29일까지 입니다.
     *  
     */
    internal class Program
    {
        static void Main(string[] args)
        {

            //1.
            //Console.Write("첫번째 문자열:");
            //string a = Console.ReadLine();
            //Console.Write("두번째 문자열:");
            //string b = Console.ReadLine();
            //bool check = a == b;
            //if (check)
            //{
            //    Console.WriteLine("2개의 문자열은 같습니다.");
            //}
            //else
            //{
            //    Console.WriteLine("2개의 문자열은 다릅니다.");
            //}

            //2.
            //Console.WriteLine("음료를 선택하시오\n1.콜라\n2.물\n3.스프라이트\n4.주스\n5.커피");
            //int num = int.Parse(Console.ReadLine());


            //switch (num)
            //{
            //    case 1:
            //        Console.WriteLine("콜라를 선택했습니다.\n-프로그램 종료-");
            //        break;
            //    case 2:
            //        Console.WriteLine("물를 선택했습니다.\n-프로그램 종료-");
            //        break;
            //    case 3:
            //        Console.WriteLine("스프라이트를 선택했습니다.\n-프로그램 종료-");
            //        break;
            //    case 4:
            //        Console.WriteLine("주스를 선택했습니다.\n-프로그램 종료-");
            //        break;
            //    case 5:
            //        Console.WriteLine("커피를 선택했습니다.\n-프로그램 종료-");
            //        break;
            //    default:
            //        Console.WriteLine("잘못된 선택입니다.");
            //        break;
            //}
            //3.
            int[] days = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            for(int i = 1; i < 13; ++i)
            {
                Console.WriteLine("{0}월은 {1}일까지 입니다.\n", i, days[i-1]);
            }



        }
    }
}