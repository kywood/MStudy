using RotSlot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstData;

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


    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.name.CompareTo(Defines.E_WALL_NM.WB.ToString()) == 0)
        //{
        //    //Debug.Log(collision.gameObject.name);
        //    AppManager.Instance.GetStateManager().SetGameState(StateManager.E_GAME_STATE.SHOOT_READY);
        //}

        //Debug.Log("T:" + collision.name);

        


        if (AppManager.Instance.GetStateManager().IsGameState(StateManager.E_GAME_STATE.RUN) == false)
        {
            return;
        }

        if (collision.name.CompareTo(ConstData.GetPreFabProperty(E_PREFAB_TYPE.SLOT).mNM ) != 0 )
        {
            return;
        }

        CSSlot csSlot = collision.gameObject.GetComponent<CSSlot>();

        cPoint<int> stay_idx = new cPoint<int>();

        cPoint<int> out_top_stay_pos_idx = new cPoint<int>();
        List<cPoint<int>> out_stay_pos_idx_list = new List<cPoint<int>>();



        if (csSlot.GetcBubbleSlot().FindStaySlot(
                new cPoint<int>( csSlot.GetcSlot().GetID() , csSlot.GetcSlot().GetParentID()
            ),
            out_top_stay_pos_idx,
            out_stay_pos_idx_list
            ) == true)
        {

            if (out_stay_pos_idx_list.Count <= 0)
            {
                stay_idx = out_top_stay_pos_idx;
            }
            else
            {
                // 나온 결과 로  sort 해서 1등 뽑기..
                // collision --> out_stay_pos_idx_list  == > distance 1 등인거
                //out_stay_pos_idx_list
            }

            CSRotSlot csRotSlot = AppManager.Instance.GetRotSlot().GetComponent<CSRotSlot>();
            cBubbleSlot bubbleSlot = csRotSlot.GetBubbleSlot();

            cSlot<cBubble> cSlot = bubbleSlot.GetSlotByIDX(stay_idx);

            //cSlot 으로 실제 GameObject slot 를 찾는다.
            CSSlot finalCsSlot = csRotSlot.GetCSSclot(cSlot);

            BubbleManager bubbleManager = AppManager.Instance.BubbleManager.GetComponent<BubbleManager>();

            bubbleManager.SetVisible(false);

            Bubble bubble = bubbleManager.GetBubble();

            //AppManager.Instance.BubbleManager.GetComponent<BubbleManager>().SetVisible(false);
            Debug.Log(collision.name + " " + cSlot.GetParentID() + " " + cSlot.GetID());

            cBubble bb = cBubbleHelper.Factory(bubble.GetBubbleType(), new cPoint<int>(cSlot.GetID(), cSlot.GetParentID() ));
            cSlot.Set(bb);

            Pool pool = ResPools.Instance.GetPool(MDefine.eResType.Bubble);

            GameObject BubbleGO = pool.GetAbleObject();

            CSBubble cb = BubbleGO.GetComponent<CSBubble>();
            cb.SetBubble(bb);


            //HACK
            //cb.transform.localScale = new Vector3(Defines.G_SLOT_RADIUS * 2, Defines.G_SLOT_RADIUS * 2, 0.0f);
            cb.transform.position = finalCsSlot.transform.position;


            //HACK 
            //무형 함수
            AppManager.Instance.GetStateManager().SetGameState(StateManager.E_GAME_STATE.RUN_RESULT,
                (State state) =>
                {
                    ((RunResult)state).SetCsSlot(finalCsSlot);
                });

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name.CompareTo(Defines.E_WALL_NM.WB.ToString()) == 0)
        {
            //Debug.Log(collision.gameObject.name);
            AppManager.Instance.GetStateManager().SetGameState(StateManager.E_GAME_STATE.SHOOT_READY);
        }


    }


}
