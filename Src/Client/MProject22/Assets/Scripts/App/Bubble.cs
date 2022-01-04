using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public void Awake()
    {
        transform.localScale = new Vector3(Defines.G_SLOT_RADIUS * 2,
            Defines.G_SLOT_RADIUS * 2, 0.0f);
    }

    public void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.CompareTo("WB") == 0)
        {
            //Debug.Log(collision.gameObject.name);
            AppManager.Instance.GetStateManager().SetGameState(StateManager.E_GAME_STATE.SHOOT_READY);
        }
    }


}
