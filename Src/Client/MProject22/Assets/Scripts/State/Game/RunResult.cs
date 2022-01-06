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
