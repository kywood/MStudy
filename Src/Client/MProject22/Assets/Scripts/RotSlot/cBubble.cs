using System;
using System.Collections.Generic;
using System.Text;

namespace RotSlot
{

    public enum E_BUBBLE_TYPE
    {
        NONE = 0,
        RED = 1,
        BLUE = 2,
        YELLOW = 3,
        GREEN = 4,
        PURPLE = 5,
        MAX
    }

    public class cBubbleHelper
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
            else if (type == E_BUBBLE_TYPE.PURPLE)
                return new cBubbleGreen();

            return null;
        }
    }

    public abstract class cBubble
    {
        E_BUBBLE_TYPE mType;
        protected void SetBubbleType (E_BUBBLE_TYPE type)
        {
            mType = type;
        }

        public override string ToString()
        {
            return mType.ToString();
        }

        public E_BUBBLE_TYPE GetBubbleType()
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

    public class cBubbleRed : cBubble
    {
        public cBubbleRed()
        {
            SetBubbleType(E_BUBBLE_TYPE.RED);
        }
    }
    public class cBubbleBlue : cBubble
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

    public class cBubbleGreen : cBubble
    {
        public cBubbleGreen()
        {
            SetBubbleType(E_BUBBLE_TYPE.GREEN);
        }
    }

    public class cBubblePurple : cBubble
    {
        public cBubblePurple()
        {
            SetBubbleType(E_BUBBLE_TYPE.PURPLE);
        }
    }


}
