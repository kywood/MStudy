using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum E_GAME_STATE
    {
        NONE , 
        READY,  // ready 
        SHOOT_READY ,
        RUN,
        RUN_RESULT,
        END,

        MAX
    }

    private Dictionary<E_GAME_STATE, State> mStateMap = new Dictionary<E_GAME_STATE, State>()
    {   
        {E_GAME_STATE.READY , new Ready() }   ,
        {E_GAME_STATE.SHOOT_READY , new ShootReady() }   ,
        {E_GAME_STATE.RUN , new Run() }   ,
        {E_GAME_STATE.RUN_RESULT , new RunResult() }   ,
        {E_GAME_STATE.END , new End() }   
    };


    private E_GAME_STATE mGameState = E_GAME_STATE.NONE;

    void Start()
    {
        
    }
    public void SetGameState(E_GAME_STATE gameState , Action<State> act = null )
    {
        if (mGameState == gameState)
            return;

        if (mGameState == E_GAME_STATE.NONE)
        {
            mGameState = gameState;
            mStateMap[gameState].OnEnter(act);
        }
        else
        {
            mStateMap[mGameState].OnLeave();
            mGameState = gameState;
            mStateMap[gameState].OnEnter(act);
        }
    }



    //public void SetGameState(E_GAME_STATE  gameState )
    //{
    //    if (mGameState == gameState)
    //        return;

    //    if (mGameState == E_GAME_STATE.NONE)
    //    {
    //        mGameState = gameState;
    //        mStateMap[gameState].OnEnter();
    //    }
    //    else
    //    {
    //        mStateMap[mGameState].OnLeave();
    //        mGameState = gameState;
    //        mStateMap[gameState].OnEnter();
    //    }
    //}

    public E_GAME_STATE GetGameState()
    {
        return mGameState;
    }

    public State GetGameStateValue()
    {
        return mStateMap[mGameState];
    }

    public bool IsGameState(E_GAME_STATE game_state  )
    {
        if (mGameState == game_state)
            return true;

        return false;
    }

    public void OnUpdate()
    {
        if (mGameState == E_GAME_STATE.NONE)
            return;

        mStateMap[mGameState].OnUpdate();
    }

}
