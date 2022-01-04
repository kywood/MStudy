using RotSlot;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ConstData
{
    public class cBubbleProperty
    {
        public Color mColor;
        public E_BUBBLE_TYPE mBubbleType;

        public cBubbleProperty(E_BUBBLE_TYPE bubble_type)
        {
            mBubbleType = bubble_type;
        }

        public cBubbleProperty(E_BUBBLE_TYPE bubble_type, Color color)
            //: base(bubble_type)
        {
            mBubbleType = bubble_type;
            mColor = color;
        }
    }

    private static Dictionary<E_BUBBLE_TYPE, cBubbleProperty> mBubblePropertys = new Dictionary<E_BUBBLE_TYPE, cBubbleProperty>()
    {
        { E_BUBBLE_TYPE.RED  , new cBubbleProperty(E_BUBBLE_TYPE.RED , new Color(1,0,0) ) },
        { E_BUBBLE_TYPE.BLUE , new cBubbleProperty(E_BUBBLE_TYPE.BLUE , new Color(0,0,1) ) },
        { E_BUBBLE_TYPE.YELLOW  , new cBubbleProperty(E_BUBBLE_TYPE.YELLOW , new Color(0.8f,0.8f,0.0f) ) },
        { E_BUBBLE_TYPE.GREEN  , new cBubbleProperty(E_BUBBLE_TYPE.GREEN , new Color(0.2f,0.5f,0.6f) ) },
        { E_BUBBLE_TYPE.PURPLE  , new cBubbleProperty(E_BUBBLE_TYPE.PURPLE , new Color(0.0f,0.8f,0.4f) ) }
    };

    public static cBubbleProperty GetBubbleProperty(E_BUBBLE_TYPE bubble_type)
    {
        return mBubblePropertys[bubble_type];
    }

    public static E_BUBBLE_TYPE GetNextBubbleType()
    {
        return (E_BUBBLE_TYPE)UnityEngine.Random.Range((int)E_BUBBLE_TYPE.NONE + 1, (int)E_BUBBLE_TYPE.MAX - 1);
    }

}
