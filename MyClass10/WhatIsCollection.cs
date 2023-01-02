using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass10
{
    public class WhatIsCollection
    {
        public void CollectionDesc()
        {
            /**
             * 컬렉션 사용하기     // 변수를 여러개 묶어서 사용하는 것을 컬레션이라고 한다.
             * 배열처럼 특정 항목의 집햡을 리스트 또는 컬렉션이라고 한다.
             * 컬렉션은 배열, 리스트, 사전을 사용하여 관련 개체의 그룹을 만들고
             * 관리한다.
             * 
             * 배열과 컬렉션 
             * C#에서 배열(Array)과 컬렉션(Collection),리스트(List)는
             * 학습 레벨에서 동일하게 취급한다. 컬렉션 클래스는 데이터 항목의 
             * 집합을 메모리상에서 다루는 클래스로, 문자열 같은 간단한 형태도
             * 있다. 그리고 특정 클래스 형식의 집합 같은 복잡한 형태도 있다.
             * 
             * 3가지의 자주 쓰는 컬렉션 소개
             * 
             *  - 배열: 일반적으로 숫자처럼 간단한 데이터 형식을 저장한다.  // 크기가 고정되어 있어서 새로운 변수를 추가 할 수 없다.
             *  int[] number = new int[5];5칸의 배열을 4칸으로 줄이고 싶다면 새로운 배열을 만들어 빼고 싶은 값을 제외한 값을 새로운 배열에 넣어야 한다.
             *  
             *  - 리스트: 간단한 데이터 형식을 포함한 개체들을 저장한다.   //  리스트는 크기가 고정되어 있지 않아 원하는 크기로 바꿀수 있다. // 데이터의 삽입과 삭제가 존재할때 사용
             *  리스트 -> Linked List를 줄여서 말함      // 선형이다. //Single Linked List,Double Linked List가 존재 // 데이터 삽입, 삭제가 일어나는 경우(빈번 X)
             *  
             *  
             *  - 사전(Dictionary): 키와 값의 쌍으로 관리되는 개체들을 저장한다.   //자가균형이진탐색트리 구조이다. //선형보다 서치속도가 빠르다. //무작위 삽입, 삭제가 빈번한 경우 사용
             *  
             *  
             * 일반적으로 기본형 그룹을 배열로 보고, 새로운 타입(클래스)의 그룹을
             * 컬렉션으로 비교하기도 한다.
             * 
             *  - 배열: 정수형, 문자열, 등 집합을 나타낸다.
             *  - 컬렉션: 개체의 집합을 나타낸다. 리스트, 집합(Set), 맵, 사전도
             *           컬렉션과 같은 개념으로 사용한다.
             * 
             * 데이터를 그룹으로 묶어 관리할 때는 일반적으로 배열로 관리한다. 배열은
             * 크기가 고정되어 있다. 배열은 크기가 고정되어 있어 새로운 데이터를 
             * 추가할 수 없다. 이러한 단점을 제거한 것이 바로 컬렉션이다.
             * 
             *  - 컬렉션은 반복하여 사용할 수 있는 형식 안정성으로 크기를 동적으로
             *    변경할 수 있는 장점이 있다.
             *  - 컬렉션은 데이터를 조회, 정렬, 중복 제거, 이름과 값을 쌍으로 관리하는
             *    등 여러 장점이 있다.
             * 닷넷에서는 컬렉션과 관련한 여러 클래스를 제공한다.
             * 
             *  - Stack 클래스
             *  - Queue 클래스
             *  - ArrayList 클래스
             *  등이 있다.
             */

            Dictionary<string, int> inventory = new Dictionary<string, int>();    //인스턴스화

            inventory.Add("빨간 포션", 10);
            inventory.Add("강철 검",1);

            Console.WriteLine("Inventory item 출력 -> {0}", inventory["빨간 포션"]);
            
            List<int> intlist= new List<int>();
            intlist.Add(10);
            intlist.Add(3);
            intlist.Add(100);
            intlist.Add(77);

            intlist.Sort();
            intlist.Reverse();

            foreach(int number in intlist)      //
            {
                Console.WriteLine(number);
            }
        }       //CollectionDesc()

        struct Node // list의 변수 
        {
            int _index;
            int number;
            int adressNext;
            int adressPrev; // 주소가 2개 더블링크드리스트(Double Linked List)
            //주소가 1개면 싱글링크드리스트(Single Linked List)
        }
    }       //class WhatIsCollection
}
