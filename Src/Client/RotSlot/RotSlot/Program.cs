using System;
using System.Collections.Generic;
using System.Text;

namespace RotSlot
{
 

    class Program
    {
        static void Main(string[] args)
        {
            cBubbleSlot bs = new cBubbleSlot();
            bs.Print();
            Console.WriteLine("\n");

            // 밑에도 체크를 해야함 4,1이 안들어감
            //bs.SetItem(4, 0, cBubbleHelper.Factory(E_BUBBLE_TYPE.RED));
            bs.SetItem(0, 0, cBubbleHelper.Factory(E_BUBBLE_TYPE.RED));
            bs.Print();
            Console.WriteLine("\n");

            bs.SetItem(3, 0, cBubbleHelper.Factory(E_BUBBLE_TYPE.RED));
            bs.Print();
            Console.WriteLine("\n");
            //Console.WriteLine("--------------PANG---------------");

            //bs.SetItem(5, 2, cBubbleHelper.Factory(E_BUBBLE_TYPE.BLUE));
            //bs.SetItem(5, 3, cBubbleHelper.Factory(E_BUBBLE_TYPE.BLUE));
            //bs.SetItem(5, 4, cBubbleHelper.Factory(E_BUBBLE_TYPE.BLUE));
            //bs.SetItem(5, 5, cBubbleHelper.Factory(E_BUBBLE_TYPE.BLUE));
            //bs.SetItem(4, 5, cBubbleHelper.Factory(E_BUBBLE_TYPE.RED));

            bs.Print();
            Console.WriteLine("\n");
            Console.WriteLine("--------------PANG---------------");

            // Pang
            //bs.Pang(new cPoint<int>(3, 0));
            bs.Print();
            Console.WriteLine("\n");

            bs.ForWard();
            bs.ForWard();
            bs.ForWard();

            bs.Print();
            Console.WriteLine("\n");

            bs.Pang(new cPoint<int>(3, 3));
            bs.Print();
            Console.WriteLine("\n");

            // 무형 함수
            Action<int, int> ma =
            (int a , int b) =>
            {
                Console.WriteLine("a:" + a + " b:" + b);
            };

            ma.Invoke(10, 20);



            List<Action<int, int>> li = new List<Action<int, int>>();

            li.Add(ma);
            li.Add(ma);
            li.Add(ma);
            li.Add((int a, int b) =>
            {
                Console.WriteLine("a:" + a + " b:" + b);
            });
            li.Add(ma);
            li.Add(ma);
            li.Add((int a, int b) =>
            {
                Console.WriteLine("a:" + a + " b:" + b);
            });
            li.Add(ma);




            //foreach(Action<int, int> act in li)
            //{
            //    act.Invoke(10, 100);
            //}

        }
    }
}