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
    }

    public void ReSet()
    {
        mBubble = null;
    }

}
