using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject WT;
    public GameObject WL;
    public GameObject WR;
    public GameObject WB;

    public Color WColor;


    private void Start()
    {
        ((SpriteRenderer)(WT.GetComponent<SpriteRenderer>())).color = WColor;

        ((SpriteRenderer)(WB.GetComponent<SpriteRenderer>())).color = WColor;
        ((SpriteRenderer)(WL.GetComponent<SpriteRenderer>())).color = WColor;
        ((SpriteRenderer)(WR.GetComponent<SpriteRenderer>())).color = WColor;

    }

}
