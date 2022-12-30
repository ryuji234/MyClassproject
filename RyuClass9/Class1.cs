using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading
using static Button;

namespace RyuClass9
{
    internal class Class1
    {
        static void Main()
        {
            //Parent parent = new Parent();
            //parent.Say();
            //parent.Run();
            //parent.walk(); 

            //Child child = new Child();
            //child.Say();
            //child.Run();    
            //child.walk();

            //StoreButton storeButton= new StoreButton();
            //storeButton.OnClickButton();

            //QuestButton questButton= new QuestButton();
            //questButton.OnClickButton();

            Slim slim= new Slim();
            // slim.Name = "이거 사실 슬라임 아닌데";
            Console.WriteLine("[Main]슬라임 클래스에서 필드를 가져옴 ->{0}", slim.Name);
            Task.Delay(300).Wait(); //딜레이 걸어주는 함수
            foreach(char charactor_ in apearencestr)
            {
                Console.Write("{0}", charactor_);
                Task.Delay(300).Wait();
            }

        }
    }
}
