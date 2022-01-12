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
            bs.Pang(new cPoint<int>(3, 0));
            bs.Print();
            Console.WriteLine("\n");


        }
    }
}