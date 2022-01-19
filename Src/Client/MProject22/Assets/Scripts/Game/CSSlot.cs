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


    public void Pang(List<cBubble> out_pang, List<cBubble> out_drop)
    {
        mRotSlot.PangByID(new cPoint<int>(mSlot.GetID(), mColsSlot.GetID()), out_pang, out_drop);
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        // 구술이 붙을지 지나 갈지
        if ( AppManager.Instance.GetStateManager().IsGameState(StateManager.E_GAME_STATE.RUN) && 
            mRotSlot.CheckStay( new cPoint<int>(mSlot.GetID() , mColsSlot.GetID()) ) 
            )
        {
            // 슬롯의 IDX 가 0일때는 제일위니까 붙는다.

            BubbleManager bubbleManager = AppManager.Instance.BubbleManager.GetComponent<BubbleManager>();

            bubbleManager.SetVisible(false);

            Bubble bubble = bubbleManager.GetBubble();

            //AppManager.Instance.BubbleManager.GetComponent<BubbleManager>().SetVisible(false);
            Debug.Log(collision.name + " " + mColsSlot.GetID() + " " + mSlot.GetID());

            cBubble bb = cBubbleHelper.Factory(bubble.GetBubbleType() , new cPoint<int>(mSlot.GetID() , mColsSlot.GetID() ));
            mSlot.Set(bb);

            Pool pool = ResPools.Instance.GetPool(MDefine.eResType.Bubble);

            GameObject BubbleGO = pool.GetAbleObject();

            CSBubble cb = BubbleGO.GetComponent<CSBubble>();
            cb.SetBubble(bb);


            //HACK
            //cb.transform.localScale = new Vector3(Defines.G_SLOT_RADIUS * 2, Defines.G_SLOT_RADIUS * 2, 0.0f);
            cb.transform.position = this.transform.position;
                        

            //HACK 
            //무형 함수
            AppManager.Instance.GetStateManager().SetGameState(StateManager.E_GAME_STATE.RUN_RESULT , 
                (State state) => {
                    ((RunResult)state).SetCsSlot(this);
                });

        }
        
    }

}
