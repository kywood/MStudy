using RotSlot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    private E_BUBBLE_TYPE mBubbleType = E_BUBBLE_TYPE.NONE;
    public void Awake()
    {
        //transform.localScale = new Vector3(Defines.G_SLOT_RADIUS * 2,
        //    Defines.G_SLOT_RADIUS * 2, 0.0f);
    }

    public void Start()
    {
        
    }

    public E_BUBBLE_TYPE GetBubbleType()
    {
        return mBubbleType;
    }

    public void SetBubbleType( E_BUBBLE_TYPE bubble_type )
    {
        mBubbleType = bubble_type;

        SpriteRenderer sp = GetComponent<SpriteRenderer>();

        sp.sprite = AppManager.Instance.GetBubbleManager().GetSprite(bubble_type);

        //Color c = ConstData.GetBubbleProperty(bubble_type).mColor;
        //sp.color = ConstData.GetBubbleProperty(bubble_type).mColor;

        //GameObject NewObj = Util.AddChildWithOutScaleLayer(parent, Instantiate(Resources.Load(preFabsPath) as GameObject));

        //sp.sprite = Resources.Load< Sprite>(ConstData.GetBubbleProperty(bubble_type).mImgPath);

        //Instantiate(Resources.Load("Imgs/Bubble/1.png")) as 


        Debug.Log(bubble_type);
        //Debug.Log(c.ToString());


    }
        
    public void SetVisible(bool value)
    {
        gameObject.SetActive(value);
        if( value == true )
        {
            Pick pick =AppManager.Instance.Pick.GetComponent<Pick>();

            transform.position = pick.ShootBody.transform.position;


            SetBubbleType(ConstData.GetNextBubbleType());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.CompareTo(Defines.E_WALL_NM.WB.ToString()) == 0)
        {
            //Debug.Log(collision.gameObject.name);
            AppManager.Instance.GetStateManager().SetGameState(StateManager.E_GAME_STATE.SHOOT_READY);
        }
    }


}
