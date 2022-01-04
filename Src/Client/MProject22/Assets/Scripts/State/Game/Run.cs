using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : State
{
    // Start is called before the first frame update
    public override void OnEnter()
    {
        //Debug.Log("Run OnEnter");
        AppManager.Instance.BubbleManager.GetComponent<BubbleManager>().SetVisible(true);
    }

    public override void OnLeave()
    {
        AppManager.Instance.BubbleManager.GetComponent<BubbleManager>().SetVisible(false);
        //Debug.Log("Run OnLeave");

    }

    public override void OnUpdate()
    {

    }
}
