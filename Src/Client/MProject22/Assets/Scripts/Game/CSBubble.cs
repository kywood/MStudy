using RotSlot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSBubble : MonoBehaviour
{
    cBubble mBubble = null;


    public void SetBubble(cBubble bubble)
    {
        mBubble = bubble;

        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        sp.color = ConstData.GetBubbleProperty(bubble.GetBubbleType()).mColor;

        Color c = ConstData.GetBubbleProperty(bubble.GetBubbleType()).mColor;

        Debug.Log(bubble.GetBubbleType());
        Debug.Log(c.ToString());

    }

    public void ReSet()
    {
        mBubble = null;
    }

}
