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
        Bubble.SetActive(visible);
    }


}
