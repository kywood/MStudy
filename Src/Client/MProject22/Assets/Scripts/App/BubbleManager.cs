using RotSlot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstData;

public class BubbleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bubble;

    Dictionary<E_BUBBLE_TYPE, Sprite> mBubbleSprite = new Dictionary<E_BUBBLE_TYPE, Sprite>();

    private void Awake()
    {
        foreach ( E_BUBBLE_TYPE bubble_type in ConstData.GetBubblePropertys().Keys)
        {
            cBubbleProperty bpro = ConstData.GetBubbleProperty(bubble_type);
            mBubbleSprite.Add(bubble_type, Resources.Load<Sprite>(bpro.mImgPath));
        }

        SetVisible(false);
    }

    public Sprite GetSprite(E_BUBBLE_TYPE bubble_type )
    {
        return mBubbleSprite[bubble_type];
    }

    public void SetVisible( bool visible )
    {
        //Bubble.SetActive(visible);
        //Bubble bb = Bubble.GetComponent<Bubble>();
        //bb.SetBubbleType(ConstData.GetNextBubbleType());
        //Bubble.GetComponent<Bubble>().SetVisible(visible);
        GetBubble().SetVisible(visible);
    }

    public Bubble GetBubble()
    {
        return Bubble.GetComponent<Bubble>();
    }

    public E_BUBBLE_TYPE GetNextBubbleType()
    {
        return (E_BUBBLE_TYPE)Random.Range((int)E_BUBBLE_TYPE.NONE + 1, (int)E_BUBBLE_TYPE.MAX - 1);
    }


}
