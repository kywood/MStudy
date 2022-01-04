using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RunResult : State
{
    // Start is called before the first frame update

    float timer;
    int waitingTime;



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

    public override void OnUpdate()
    {
        //Thread.Sleep(1 * 1000);
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            //Action
            AppManager.Instance.GetStateManager().SetGameState(StateManager.E_GAME_STATE.SHOOT_READY);
            timer = 0;
        }

        

    }
}
