using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class State
{

    public virtual void OnEnter()
    {

    }

    public virtual void OnEnter( Action<State> act )
    {
        if( act != null )
        {
            act.Invoke(this);
        }

        OnEnter();
    }

    public virtual void OnLeave()
    {

    }

    public virtual void OnUpdate()
    {

    }

    //public virtual void SetEnterParam( List<Object> param )
    //{

    //}

}
