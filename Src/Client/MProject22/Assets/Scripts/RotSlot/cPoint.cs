using System;
using System.Collections.Generic;
using System.Text;

namespace RotSlot
{

    public class cPoint<T> where T : struct 
    {
        T _x;
        T _y;

        public cPoint( T x , T y )
        {
            this.x = x;
            this.y = y;
        }

        public T x
        {
            get { return _x; }
            set { _x = value; }
        }

        public T y
        {
            get { return _y; }
            set { _y = value; }
        }

        public String ToString()
        {
            return "X = " + x + " Y = " + y;
        }

    }
}
