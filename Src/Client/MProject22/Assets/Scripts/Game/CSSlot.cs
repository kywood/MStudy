using RotSlot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSSlot : MonoBehaviour
{
    cBubbleSlot mRotSlot;
    cColsSlot<cBubble> mColsSlot;
    cSlot<cBubble> mSlot;

    //public GameObject Bubble;

    public void Init(cBubbleSlot rotSlot, cColsSlot<cBubble> colsSlot  , cSlot<cBubble> slot )
    {
        mRotSlot = rotSlot;
        mColsSlot = colsSlot;
        mSlot = slot;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // 구술이 붙을지 지나 갈지
        if ( AppManager.Instance.GetStateManager().IsGameState(StateManager.E_GAME_STATE.RUN) && 
            mRotSlot.CheckStay( new cPoint<int>(mSlot.GetID() , mColsSlot.GetID()) ) 
            )
        {
            AppManager.Instance.BubbleManager.GetComponent<BubbleManager>().SetVisible(false);

            Debug.Log(collision.name + " " + mColsSlot.GetID() + " " + mSlot.GetID());

            cBubble bb = cBubbleHelper.Factory(E_BUBBLE_TYPE.GREEN);

            mSlot.Set(bb);

            Pool pool = ResPools.Instance.GetPool(MDefine.eResType.Bubble);

            GameObject BubbleGO = pool.GetAbleObject();

            CSBubble cb = BubbleGO.GetComponent<CSBubble>();
            cb.SetBubble(bb);
            cb.transform.localScale = new Vector3(Defines.G_SLOT_RADIUS * 2, Defines.G_SLOT_RADIUS * 2, 0.0f);

            cb.transform.position = this.transform.position;

            SpriteRenderer sr = cb.GetComponent<SpriteRenderer>();

            sr.color = ConstData.GetBubbleProperty(E_BUBBLE_TYPE.GREEN).mColor;

            AppManager.Instance.GetStateManager().SetGameState(StateManager.E_GAME_STATE.RUN_RESULT);
        }

        
    }

}
