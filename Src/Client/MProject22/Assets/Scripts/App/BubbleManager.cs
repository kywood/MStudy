using RotSlot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bubble;

    private void Awake()
    {
        SetVisible(false);
    }

    public void SetVisible( bool visible )
    {
        //Bubble.SetActive(visible);
        //Bubble bb = Bubble.GetComponent<Bubble>();
        //bb.SetBubbleType(ConstData.GetNextBubbleType());

        Bubble.GetComponent<Bubble>().SetVisible(visible);

    }

    public E_BUBBLE_TYPE GetNextBubbleType()
    {
        return (E_BUBBLE_TYPE)Random.Range((int)E_BUBBLE_TYPE.NONE + 1, (int)E_BUBBLE_TYPE.MAX - 1);
    }


}
