using System;
using System.Numerics;

namespace JJJ6
{
    internal class Program
    {
        static void Double(int a)
        {
            a *= 2;
        }
        // 참조의 의한 전달로 main 내부의 변수에 영향을 주게 설계
        static void DoubleRef(ref int a)
        {
            a *= 2;
        }
        
        static void Double2(int[] array)
        {
            array[0] *= 2;
        }

        // num에 divisor를 나눴을 때 값과 나머지 값을 반환하고 싶다.
       /*
        * static void Divide(int num, int divisor, ref float value, ref float other)
        { 
            value = num / divisor;
            other = num % divisor;
        }
       */

                 // out 키워드 = 출력 전용 매개변수
       // 함수 내에서 무조건 값이 대입 되는 것을 강제한다. ( = 누락을 막기 위한 ref의 강제형)
        static void Divide(int num, int divisor, out float value, out float other)
        {
            value = num / divisor;
            other = num % divisor;
        }

        // 0으로 나눌 수 없기에 만든 예외처리 함수 오버로딩
        static bool Divide(int num, int divisor, out int value)
        {
            if (divisor == 0)
            {
                value = 0; // 강제적으로 넣어줘야한다.
                return false;
            }

            value = num / divisor;
            return true;
        }

                      // 가변 길이 배열 params
        // 내가 대입하는 매개변수의 개수의 따라 int 배열의 길이가 결정된다.
        static int SumArray(params int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        static void OutArray(params int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"배열의 {i+1}번째 요소는 {array[i]}이다.");
            }    

        }

        static void Four(int a, int b)
        {
            Console.WriteLine($"{a} + {b}의 값은 {a + b}이다.");
            Console.WriteLine($"{a} - {b}의 값은 {a - b}이다.");
            Console.WriteLine($"{a} * {b}의 값은 {a * b}이다.");
            Console.WriteLine($"{a} / {b}의 값은 {(float)a / b}이다.");
        }


        static void Main(string[] args)
        {
            // 1교시
            #region 
            /* 배열 (Array)
            // 여러개의 값을 담을 수 있는 변수

            int[] array = null; // 값을 넣지 않아도 최초 값은 null로 선언된다.
            array = new int[] { 10, 20, 30, 40, 50 };


            // 배열은 값형 변수가 아닌, 참조형 변수이다. 참조 값이 없다는 뜻의 null로 시작한다.
            // 배열에 값을 대입시 열거된 메모리의 첫번째 주소를 받아 참조한다.

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            // 길이 4의 string 배열 선언
            // 아래는 배열을 생성한 것이지 초기화 한 것이 아니다.

            string[] inventory = new string[4];
            inventory[0] = "AA";
            inventory[1] = "BB";

            // 배열은 내부값을 초기화하지 않으면 초기 값이 자동 대입된다. 
            
            foreach(string item in inventory)
            {
                Console.WriteLine(item);
            }
            
            // 배열의 선언과 동시에 초기화
            // 항상 index의 범위를 조심하자. 범위를 넘으면 out of range 예외가 발생한다.

            byte[] array2 = new byte[4] {1,2,3,4};
            // byte[] array2 = {1,2,3,4}; new 없이 바로 선언해도 무관하다
            

            // Console.WriteLine(array2[4]); 배열의 범위를 넘은 경우, 에러가 발생한다. 

            // array2가 가지고 있는 값은 배열의 첫번째 주소이다.
            // array2가 가지고 있는 값은 array2의 값을 가지고 있다.
            // 따라서 두 변수의 값은 메모리를 '참조'하고 있다.

            byte[] array3 = array2;

            array3[0] = 100;

            Console.WriteLine(array2[0]);
            Console.WriteLine(array3[0]);
            // 참조형 변수이기 때문에 두 배열 모두 [0]의 값이 변하게 된다. (= 참조하는 주소가 같으면 동위성을 갖는다.)


            // Q. 길이 4의 string 배열을 선언한 후 사용자에게서 이름을 입력 받아 배열에 대입하자

            string[] name = new string[4];

            for(int i = 0; i<name.Length; i++)
            {
                Console.Write($"{i+1}번째 이름을 입력하세요 : ");
                name[i] = Console.ReadLine();
                Console.WriteLine();
            }
            foreach (string zone in name)
            {
                Console.WriteLine(zone);
            }
            Console.WriteLine();

            // Q. 길이 3의 int형 배열을 만들고 내부 정수를 모두 더한 값을 출력해보자.

            int[] num = new int[3];
            for (int i = 0; i < num.Length; i++)
            {
                Console.Write($"더하고 싶은 {i+1}번째 숫자를 입력하세요.");
                num[i] = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            Console.Write($"{num[0]}과 {num[1]}과 {num[2]}를 더한 값은 : ");
            Console.WriteLine(num[0] + num[1] + num[2]);


                             // 배열을 쓰는 이유
            // 1. 여러개의 값을 하나의 변수로 접근, 관리할 수 있다. (각기 다른 변수로 선언하면 반복문을 사용할 수 없다.)
            // 2. 반복문을 이용해 내부 값을 전부 순회할 수 있다.
            // 3. 몇개의 값이 들어있는지 등도 알수 있다.

            int score1 = 100;
            int score2 = 90;
            int score3 = 70;
            int totalscore = score1 + score2 + score3;
*/
            #endregion

            // 배열을 초기화하는 3가지 방법
            int[] arr1 = new int[3] { 1, 2, 3 }; // 명확한 서술. (통상 사용하는 방법 = 협업을 위함)
            int[] arr2 = new int[] { 1, 2, 3 }; // 배열 크기를 생략해도 자동으로 잡아준다.
            int[] arr3 = {1,2,3}; // 자료형도 잡아준다.

            // 배열은 원래부터 참조형 변수다.
            // 실제 값을 가지고 있는 것이 아니라 값이 있는 주소를 가지고 있다.
            // 따라서 매개변수로 전달 되는 값은 실제 값이 있는 주소다.
            Double2(arr1); // = arr1[0] *2
            Console.WriteLine(arr1[0]);



            // 값에 의한 매개변수 전달
            // main에 있는 변수에 영향을 주지 않는다. (통상적 함수 형태)

            int number = 10;
            Double(number);
            Console.WriteLine(number);
   
                            // 참조에 의한 매개변수 전달
            // 주소를 참조한 것이기에 main 내부 변수에 영향을 준다. (ref, out)

            DoubleRef(ref number);
            Console.WriteLine(number);

            
            // ref와 out 키워드가 있다면 함수를 호출할 때, 매개 변수의 형태를 같게 잡아줘야한다.

            int num = 60;
            int divosor = 17;
            float value = 0;
            float other = 0;
            
            // Divide(num, divosor, ref value, ref other);

            // Divide 함수를 볼 때 out 키워드가 붙어 있으면 값을 반환해주는 것을 알 수 있다.
            Divide(num, divosor, out value, out other);
            Console.WriteLine($"{num}/{divosor} = {value}");
            Console.WriteLine($"{num}%{divosor} = {other}");

                            // 가변 길이 매개변수 (params)
            // 매개 변수로 쓰일 배열의 길이가 명확하지 않을 때, 사용하는 키워드.

            int n1 = 2;
            int n2 = 4;
            int n3 = 5;
            SumArray(n1);
            SumArray(n1,n2);
            SumArray(n1,n2,n3);

            // 매개 변수를 전달하는 3가지 방법
            // ref : 값을 참조형으로 받는다.
            // out : 해당 매개변수에 값이 대입 됨을 보장한다. (null을 대입하는 것은 불가능하기에 오버라이딩으로 별개의 형태로 만들어줘야한다.)
            // params : 가변 길이 형태로 값을 대입 받는다. (= 오버라이딩을 최소화하기 위한 키워드)


            // Q1. 원하는만큼 문자열을 대입 받아 출력하는 함수를 만들자.

            int[] testArr = new int[] {1,2,3,4,5,6,7,8,9};
            OutArray(testArr);


            // Q2. 숫자를 2개 대입 했을 때, 사칙연산의 결과를 반환하는 함수를 만들자. (+,-,*,/)

            Console.WriteLine("사칙 연산을 수행할 값 두가지를 입력하시오.");
            Console.Write("첫번째 값 : ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("첫번째 값 : ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine();


            Four(a, b);


            // Divide 함수는 나누기의 성공 여부를 검사한다.
            int value2 = 0;

            if (Divide(10, 1, out value2))
            {
                Console.WriteLine(value2);
            }
            else
                Console.WriteLine("나누기가 실패했다.");

        }
    }
}
