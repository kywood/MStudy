using RotSlot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Defines;

public class CSBubble : MonoBehaviour
{
    cBubble mBubble = null;

    E_MOVING_STATE mMovingState = E_MOVING_STATE.STOP;


    public void SetBubble(cBubble bubble)
    {
        mMovingState = E_MOVING_STATE.STOP;

        mBubble = bubble;

        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        sp.color = ConstData.GetBubbleProperty(bubble.GetBubbleType()).mColor;

        Color c = ConstData.GetBubbleProperty(bubble.GetBubbleType()).mColor;

        Debug.Log(bubble.GetBubbleType());
        Debug.Log(c.ToString());
    }

    public void SetMoving()
    {
        mMovingState = E_MOVING_STATE.MOVE;
    }

     void ReSetMoving()
    {
        mMovingState = E_MOVING_STATE.STOP;
    }

    public void ReSet()
    {
        mBubble = null;
    }

    public void OnUpdate()
    {
        if(mMovingState == E_MOVING_STATE.MOVE)
        {
            Vector3 cv = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            cv.y -= 0.05f;
            transform.position = cv;
        }
    }

    public void SetActive( bool active )
    {
        if( active == false )
        {
            ReSetMoving();
        }
        gameObject.SetActive(active);
    }

    public bool IsEqBubble(cBubble bb )
    {
        return mBubble.IsEqID(bb.GetID());
    }

}
