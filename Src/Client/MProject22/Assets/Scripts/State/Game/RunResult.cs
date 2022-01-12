using RotSlot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RunResult : State
{
    // Start is called before the first frame update
    float timer;
    int waitingTime;

    CSSlot mCsSlot;

    public override void OnEnter()
    {
        //Debug.Log("Run OnEnter");
        //AppManager.Instance.BubbleManager.GetComponent<BubbleManager>().SetVisible(true);
        timer = 0.0f;
        waitingTime = 2;


        List<cBubble> out_pang = new List<cBubble>();
        List<cBubble> out_drop = new List<cBubble>();

        mCsSlot.Pang(out_pang, out_drop);


        if(out_pang.Count > 0)
        {
            Debug.Log(" =======  out_pang BEGIN ============== ");
            foreach (cBubble bb in out_pang)
            {
                Debug.Log(bb.ToString());
            }
            Debug.Log(" =======  out_pang END ============== ");

            Pool pool = ResPools.Instance.GetPool(MDefine.eResType.Bubble);

            foreach( int k in  pool.ResList.Keys )
            {
                CSBubble csBubble = pool.ResList[k].GetComponent<CSBubble>();

                foreach (cBubble bb in out_pang)
                {
                    if( csBubble.IsEqBubble(bb) )
                    {
                        pool.ResList[k].SetActive(false);                        
                    }
                    //Debug.Log(bb.ToString());
                }

                


            }

        }

        



        Debug.Log(" =======  out_drop BEGIN ============== ");
        foreach (cBubble bb in out_drop)
        {
            Debug.Log(bb.ToString());
        }
        Debug.Log(" =======  out_drop END ============== ");

        //    //AppManager.Instance.BubbleManager.GetComponent<BubbleManager>().SetVisible(false);
        //Debug.Log(collision.name + " " + mColsSlot.GetID() + " " + mSlot.GetID());



    }

    public override void OnLeave()
    {
        //AppManager.Instance.BubbleManager.GetComponent<BubbleManager>().SetVisible(false);
        //Debug.Log("Run OnLeave");

    }

    public void SetCsSlot( CSSlot csslot )
    {
        mCsSlot = csslot;
    }


    public override void OnUpdate()
    {
        //Thread.Sleep(1 * 1000);

        //if (mCsSlot == null)
        //    Debug.Log("==");
        //else
        //    Debug.Log(mCsSlot);

        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            //Action
            AppManager.Instance.GetStateManager().SetGameState(StateManager.E_GAME_STATE.SHOOT_READY);
            timer = 0;
        }

        

    }
}
