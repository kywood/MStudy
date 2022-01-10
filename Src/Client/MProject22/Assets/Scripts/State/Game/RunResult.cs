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


        List<cPoint<int>> out_pang = new List<cPoint<int>>();
        List< cPoint<int>> out_drop = new List<cPoint<int>>();

        mCsSlot.Pang(out_pang, out_drop);


        Debug.Log(" =======  out_pang ============== ");
        foreach ( cPoint<int> pos in out_pang)
        {
            Debug.Log(pos.ToString());
        }

        Debug.Log(" =======  out_drop ============== ");
        foreach (cPoint<int> pos in out_drop)
        {
            Debug.Log(pos.ToString());
        }

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
