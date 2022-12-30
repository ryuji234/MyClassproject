using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RyuClass9
{
    public class WhatIsOverride
    {
        public void OverrideDesc()
        {
            /**
             * 메서드 오버라이드
             * 부모 클래스에 만든 메서드를 자식 클래스에서 다시 새롭게 만들어 사용하는 것을 메서드 오버라이드라고
             * 한다.
             * 
             * 메서드 오버라이드: 메서드 재정의
             * 클래스 관계를 따지는 상속 개념에서 부모 클래스에 이미 만든 메서드를 동일한 이름으로 자식 클래스에서ㅗ
             * 다시 정의(재정의)해서 사용한다는 개념이 메서드 오버라이드라고 한다.
             *  - 메서드 오버라이드는 메서드를 새롭게 정의하는 것
             *  - 오버라이드(Override), 오버라이딩(Overriding)이라는 표현은 동일하다.
             *  - 부모 클래스에 virtual 키워드로 선언해 놓은 메서드는 자식 클래스에서 override 키워드로
             *    재정의해서 사용 가능하다.
             *    
             * 메서드 오버로드와 오버라이드 
             * 처음 프로그래밍할 때 쉽게 혼동하는 단어가 바로 오버로드(OverLoad)와 오버라이드(Override)이다.
             * 오버로드는 여러 번 정의하는 것이고, 오버라이드는 다시 정의하는 것이다.
             * 
             * 가상 메서드
             * 메서드 오버라이드는 다른 표현 방식으로 가상(Virtual) 메서드라고 한다.
             */
        }       //OverrideDesc()

        public void PropertyDesc()
        {
            /**
             * 속성은 필드 값을 읽거나 쓰고 계산하는 방법을 제공하는 클래스 속성을 나타내는 멤버이다.
             * 아주 간단하게 클래스 속성을 변경하거나 알아보는 기능을 배워보자.
             * 
             * 속성
             * 클래스의 맴버 중에서 속성(Property)은 단어 그대로 클래스 속성(특징, 성격, 색상, 크기 등)을
             * 나타낸다. 속성은 괄호가 없는 메서드와 비슷하고 개체 필드 중에서 외부에 공개하고자 할 때 사용하는
             * 방법이다. 개체의 성질, 특징, 색상, 크기, 모양 등을 속성으로 외부에 공개할 때 사용한다.
             * 
             * 클래스 안에 선언된 필드 내용을 설정(Set) 하거나 참조(Get)할 때 사용하는 코드 블록을 속성이라고
             * 한다. 자동차 객체로 비유하자면 빨간색 스포츠카, 바퀴 4개 등으로 속성을 표현할 수 있다.
             * 
             * class [클래스 이름]
             * {
             *      public [리턴 타입] [속성 이름] {get : set}
             * }
             */
        }
    }       // class WhatIsOverride

}

public class Parent
{
    protected int num = 100;

    public virtual void Say()       // 부모 자식 클래스에 같은 이름을 쓰고 싶으면 부모에는 virtual 자식에는 override를 붙여야 한다.
    {
        Console.WriteLine("[부모] 안녕하세요.");
    }
    public virtual void Run()
    {
        Console.WriteLine("[부모] 달리다");
    }
    public virtual void walk()
    {
        Console.WriteLine("[부모] 걷다");
    }
    public virtual void walk(int count)
    {
        Console.WriteLine("[부모] {0}번 걷다");
    }
    public virtual void walk(string where_)
    {
        Console.WriteLine("[부모] {0}에서 걷다"); //오버로드: 한클래스 내에서 여러번 정의
    }
}       // class Parent

public class Child : Parent
{
    public override void Say()
    {
        Console.WriteLine("[자식] 안녕하세요");
    }
    public override void Run()
    {
        // Console.WriteLine("[자식] 달리다");
        base.Run();     //부모의 Run에 접근해서 사용
        Console.WriteLine("number: {0}", num); 
    }
    public override void walk()
    {
        Console.WriteLine("[자식] 걷다");
        Console.WriteLine("[자식] 걷다");
    }
    
    public override void walk(int count)
    {
        Console.WriteLine("[자식] {0}번 걷다",count); //오버라이드: 부모 클래스의 같은 함수를 자식클래스에서 재정의
    }
    public override void walk(string where_)
    {
        Console.WriteLine("[자식] {0}에서 걷다", where_); 
    }
}       // class Child

public class Button
{
    protected int _index = 0;

    public virtual void OnClickButton()
    {
        
        Console.WriteLine("{0}번 버튼을 눌렀음", this._index);

        // 이 버튼을 누르면 퀘스트 창이 열림.
    }       //OnClickButton

    public class StoreButton : Button
    {
        public override void OnClickButton()
        {
            _index = 1;
            base.OnClickButton();
            Console.WriteLine("이 버튼을 누르면 상점 창이 열림", _index );
        }
    }
    public class QuestButton : Button
    {
        public override void OnClickButton()
        {
            _index = 2;
            base.OnClickButton();
            Console.WriteLine("이 버튼을 누르면 퀘스트 창이 열림", _index);
        }
    }
}
