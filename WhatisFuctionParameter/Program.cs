using System;


namespace WhatisFuctionParameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Description desc = new Description();

            //int number1 = 10;
            //int number2 = 20;

            //desc.ValueTypeParam(number1, number2);
            //Console.WriteLine("[Main] first {0} second {1}", number1, number2);

            //desc.refTypeParam(ref number1,ref number2);
            //Console.WriteLine("[Main] first {0} second {1}", number1, number2);

            //int number;
            //desc.OutTypeParam(out number);
            //Console.WriteLine("[Main] number: {0}", number);

            //string strNumber = "90";
            //int intNumber;
            //int.TryParse(strNumber, out intNumber); //숫자형태의 문자열을 받아 인트로 변화를 시도하고 변화가 성공하면 숫자를 넣는다. // 숫자로 변환이 실패하면 에러가 일어나는 것이 아닌 0을 넣어준다.


            //Console.WriteLine("{0}", intNumber + 10); //WriteLine는 지정한 만큼 매개변수를 받는다. 가변형이다.

            desc.FlexibleTypeParam(1, 2, 3);
            desc.ArrayParam(new int[] { 1,2,3 });

        }
    }
}