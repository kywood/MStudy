using RotSlot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : DontDestroy<AppManager>
{
    StateManager _StateManager = null;

    public GameObject Pick;
    public GameObject BubbleManager;
    public GameObject Walls;
    
    public GameObject RotSlot;
    


    public float ShootForce = 10.0f;


    override protected void OnAwake()
    {
        base.OnAwake();
        Application.targetFrameRate = 60;
    }

    public StateManager GetStateManager()
    {
        return _StateManager;
    }

    override protected void OnStart()
    {
        base.OnStart();

        _StateManager = GetComponent<StateManager>();
        //HACK 20200812
        Debug.Log(Application.persistentDataPath);

        _StateManager.SetGameState(StateManager.E_GAME_STATE.READY);

        //cBubbleSlot bs = new cBubbleSlot();

        //bs.SetItem(4, 0, cBubbleHelper.Factory(E_BUBBLE_TYPE.RED));
        //bs.SetItem(4, 1, cBubbleHelper.Factory(E_BUBBLE_TYPE.RED));

        //Debug.Log(bs.ToString());

        //bs.ForWard();
        //Debug.Log(bs.ToString());

        //bs.Print();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        _StateManager.OnUpdate();
    }
}
