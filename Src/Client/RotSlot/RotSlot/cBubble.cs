using System;
using System.Collections.Generic;
using System.Text;

namespace RotSlot
{

    enum E_BUBBLE_TYPE
    {
        NONE = 0,
        RED = 1,
        BLUE = 2,
        YELLOW = 3,
        GREEN = 4,
        MAX
    }

    class cBubbleHelper
    {
        public static cBubble Factory(E_BUBBLE_TYPE type )
        {
            if (type == E_BUBBLE_TYPE.RED)
                return new cBubbleRed();
            else if (type == E_BUBBLE_TYPE.BLUE)
                return new cBubbleBlue();
            else if (type == E_BUBBLE_TYPE.YELLOW)
                return new cBubbleYellow();
            else if (type == E_BUBBLE_TYPE.GREEN)
                return new cBubbleGreen();

            return null;
        }
    }

    abstract class cBubble
    {
        protected E_BUBBLE_TYPE mType;
        protected void SetBubbleType (E_BUBBLE_TYPE type)
        {
            mType = type;
        }

        public override string ToString()
        {
            return mType.ToString();
        }

        private E_BUBBLE_TYPE GetBubbleType()
        {
            return mType;
        }

        public bool IsSameType( cBubble bubble )
        {
            if (bubble == null)
                return false;

            if (mType == bubble.GetBubbleType())
                return true;

            return false;
        }
    }

    class cBubbleRed : cBubble
    {
        public cBubbleRed()
        {
            SetBubbleType(E_BUBBLE_TYPE.RED);
        }
    }
    class cBubbleBlue : cBubble
    {
        public cBubbleBlue()
        {
            SetBubbleType(E_BUBBLE_TYPE.BLUE);
        }
               
    }

    class cBubbleYellow : cBubble
    {
        public cBubbleYellow()
        {
            SetBubbleType(E_BUBBLE_TYPE.YELLOW);
        }
    }

    class cBubbleGreen : cBubble
    {
        public cBubbleGreen()
        {
            SetBubbleType(E_BUBBLE_TYPE.GREEN);
        }
    }


}
