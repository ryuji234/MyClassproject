﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass10
{
    internal class WhatIsInterface
    {
        
            /**
             * 큰 규모의 프로그램일수록 뼈대를 구성하는 일이 중요하다. 인터페이스를 사용하면 
             * 전체 프로그램의 설계도에 대한 명세서를 작성할 수 있다. 이 강의에서는 프로그램의
             * 표준 규약을 정하고 따를 수 있도록 강제하는 인터레이스(InterFace)를 학습해
             * 보겠다. 인터페이스는 클래스에서 구현해야 하는 관련 기능의 정의가 포함된 개념
             * 이다. 
             * 인터페이스
             * 인터페이스는 클래스 또는 구조체에 포함될 수 있는 관련있는 매서드들을 묶어
             * 관리한다. 인터페이스는 명세서(규약, 표준) 역할을 한다. 인터페이스를 상속받아
             * 그 내용을 구현하는 클래스는 인터페이스에 선언된 멤버(속성, 메서드 등)가
             * 반드시 구현되어 있다는 보증을 한다. // 강제할 수 있다.
             * (컴퓨터가 다루는 여러 분야에서 혼용해서 사용)
             * (C#에서 제공하는 기능으로 써의 인터페이스)
             *  - 인터페이스는 interface 키워드를 사용하여 만든다. 인터페이스는 실행
             *      가능한 코드와 데이터를 포함하고 있다.
             *  - 추상 클래스처럼 다른 클래스에 멤버 이름을 미리 정의할 때 사용한다.
             *      추상 클래스와 다른 점은 맴버 내용을 구현하지 않고 멤버 이름만
             *      정의한다.
             *  - 인터페이스에는 메서드, 속성, 인덱서 및 이벤트를 정의할 수 있다.
             *  - 현실 세계에서 전 세계 표준과 같은 기능이다.
             *  - 단일 상속만 지원하는 클래스와 달리 인터페이스를 사용한 다중 상속이 
             *      가능하다.   
             *  - 인터페이스 멤버는 액세스 한정자를 붙이지 않으며 항상 public이고,
             *      virtual 및 static 키워드를 붙일 수 없다.
             *  - 인터페이스 내의 모든 멤버는 기본적으로 public 이다.
             *  - C#에서 인터페이스의 이르은 Icar, Ifood, Icomputer형태로 대문자
             *      I로 시작한다.
             *  - 인터페이스는 인스턴스화 되지 않는다. 클래스를 사용해서 인스턴스화 한다.  
             *  - 인터페이스는 계약(Contract)의미가 강하며 속석, 메서드, 이벤트,
             *      인덱서 등 구조를 미리 정의한다.
             *      추상 - 프로그램 자체가 유연해지는 것
             *      구체 - 정해진 프로그램대로 구현해야 하는 것
             *      추상 클래스 - 주제를 정의 해서 자기 마음대로 쓰는것
             */
            /**
             * 인터페이스를 사용한 다중 상속 구현하기
             * 다중 상속은 클래스 하나를 콤마로 구분해서 인터페이스 하나 이상을 상속하는 것을 
             * 의미한다.C#에서 킄래스는 클래스에 대한 단일 상속만 지원하는 대신,
             * 인터페이스는 클래스에 인터페이스를 하나 이상 상속할 수 있다.
             */
            /**
             * 인터페이스와 추상 클래스 비교하기
             * 인터페이스와 추상클래스를 비교해서 살펴보자.
             * 
             * 추상 클래스
             *  - 구현된 코드가 들어온다. 즉, 메서드 시그니쳐만 있는 것이 아니라 사용
             *      가능한 실제로 구현된 매서드도 들어온다.
             *  - 단일 상속: 기본 클래스에서 상속될 수 있다.
             *  - 각 맴버는 액세스 한정자를 갖는다.
             *  - 필드, 속성, 생성자, 소멸자, 메서드, 이벤트, 인덱서 등을 갖는다.
             *  
             * 인터페이스
             *  - 인터페이스는 규약이다.
             *  - 구현된 코드가 없다.
             *  - 다중 상속: 여러 가지 인터페이스에서 상속 가능하다.
             *  - 모든 멤버는 자동으로 public이다.
             *  - 속성, 메서드, 이벤트와 대리자를 멤버로 갖는다.
             *  대리자 : 함수스러운 무언가
             *  인터페이스는 인스턴스화 하지 않기 때문에 생성자, 소멸자가 필요 없다.
             *  
             */
        
    }       // class
    interface Icar  //인터페이스에는 몸체 없는 메서드만 존재 메서드에 아무것도 쓰지 않는다.
    {
        public void Go();    //Icar의 Go에서는 아무 내용이 없기 때문에 아주 추상적이다.  // 자동차가 앞으로 가라고 지시하는 함수
        public void back();
        //public void Go()
        //{
        //    // 기존에는 뭔가 내용을 정의했었음
        //    Console.WriteLine("자동차가 앞으로 간다.");
        //}
    }

    class car : Icar    // 클래스에서 상속받아서 사용한다. 단 인터페이스에 있는 모든 메서드를 사용해야 한다.
    {
        public virtual void Go()  // 추상적이다. // 구성요소가 없으면 에러      
        {
            Console.WriteLine("자동차가 앞으로 간다.");
            //Console.WriteLine("인터페이스를 사용할 때는 정의된 모든 멤버를 반드시 구현해야 한다.");
        }
        public virtual void back()
        {

        }


    }

    class Sonata : car
    {
        public override void Go()
        {
            base.Go();                                // 정의된 부분
            Console.WriteLine("소나타가 앞으로 간다.");
        }
    }

    interface IAnimal
    {
        void Eat();
    }
    interface IDog
    {
        void Yelp();
    }
    class Dog : IAnimal, IDog
    {
        public void Eat()
        {
            Console.WriteLine("먹다.");
        }
        public void Yelp()
        {
            Console.WriteLine("짖다.");
        }
    }
}