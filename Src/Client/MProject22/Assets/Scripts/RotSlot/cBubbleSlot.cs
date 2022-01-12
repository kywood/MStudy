using RotSlot;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBubbleSlot : cRotSlot<cBubble>{
    // META DATA -> res
    static Dictionary<E_COLS_TYPE, Dictionary<E_SLOT_CHK_DIR, cPoint<int>>> ChkOffSet =
        new Dictionary<E_COLS_TYPE, Dictionary<E_SLOT_CHK_DIR, cPoint<int>>>()
        {
                //홀수
                { E_COLS_TYPE.ODD , new Dictionary<E_SLOT_CHK_DIR, cPoint<int>>()
                {
                    {E_SLOT_CHK_DIR.LEFT , new cPoint<int>(-1,0) } ,
                    {E_SLOT_CHK_DIR.RIGHT , new cPoint<int>(1,0) } ,
                    {E_SLOT_CHK_DIR.UP_LEFT , new cPoint<int>(0,-1) } ,
                    {E_SLOT_CHK_DIR.UP_RIGHT , new cPoint<int>(1,-1) } ,
                    {E_SLOT_CHK_DIR.DOWN_LEFT , new cPoint<int>(0,1) } ,
                    {E_SLOT_CHK_DIR.DOWN_RIGHT , new cPoint<int>(1,1) } ,
                } } ,
                //짝수
                { E_COLS_TYPE.EVEN , new Dictionary<E_SLOT_CHK_DIR, cPoint<int>>()
                {
                    {E_SLOT_CHK_DIR.LEFT , new cPoint<int>(-1,0) } ,
                    {E_SLOT_CHK_DIR.RIGHT , new cPoint<int>(1,0) } ,
                    {E_SLOT_CHK_DIR.UP_LEFT , new cPoint<int>(-1,-1) } ,
                    {E_SLOT_CHK_DIR.UP_RIGHT , new cPoint<int>(0,-1) } ,
                    {E_SLOT_CHK_DIR.DOWN_LEFT , new cPoint<int>(-1,1) } ,
                    {E_SLOT_CHK_DIR.DOWN_RIGHT , new cPoint<int>(0,1) } ,
                } } ,
        };

    public cBubbleSlot(int row_cnt, int cols_cnt)
        : base(row_cnt, cols_cnt)
    {

    }

    private cBubble GetBubble(cPoint<int> pos)
    {
        //if (pos.x < 0 || pos.y < 0)
        //    return null;
        cSlot<cBubble> slot = GetSlot(pos);

        return slot == null ? null : slot.GetItem();
    }

    private bool Exist(cPoint<int> pos)
    {
        cSlot<cBubble> slot = GetSlot(pos);

        return (slot == null) ? false : true;
    }

    private bool ExistBubble(cPoint<int> pos)
    {
        cSlot<cBubble> slot = GetSlot(pos);

        if (slot.GetItem() != null)
            return true;

        return false;
    }

    private bool ChkDropStartBubble(cPoint<int> pos, cColsSlot<cBubble> cols_slot, cBubble bb)
    {
        // HACK 수정해야함.....
        for (int i = (int)E_SLOT_CHK_DIR.LEFT; i <= (int)E_SLOT_CHK_DIR.UP_RIGHT; i++)
        {
            cPoint<int> new_pos = new cPoint<int>(pos.x + ChkOffSet[cols_slot.GetColsType()][(E_SLOT_CHK_DIR)i].x,
                                    pos.y + ChkOffSet[cols_slot.GetColsType()][(E_SLOT_CHK_DIR)i].y);

            cBubble newbb = GetBubble(new_pos);

            if (newbb != null)
                return false;
        }

        return true;
    }


    private void GetFindDropBubble(List<cPoint<int>> out_drop)
    {
        cCalcQueue cq = new cCalcQueue();
        for (int i = 1; i < GetColsSlotCount(); i++)
        {
            cColsSlot<cBubble> colsSlot = GetColsSlot(i);
            for (int slotIdx = 0; slotIdx < colsSlot.GetCount(); slotIdx++)
            {
                cPoint<int> pos = new cPoint<int>(slotIdx, i);

                cBubble bb = GetBubble(pos);

                if (bb == null)
                    continue;

                // 버블을 찾으면
                if (ChkDropStartBubble(pos, colsSlot, bb))
                {
                    Console.WriteLine("GetFindDropBubble : [{0}] [{1} , {2}]", bb.GetType(), pos.x, pos.y);
                    cq.Add(pos);
                }
            }
        }

        QueueAct(cq, (cq, stBubble, new_pos) => {
            cBubble newbb = GetBubble(new_pos);
            if (newbb != null)
            {
                cq.Add(new_pos);
            }
        } , out_drop);
    }

    private void QueueAct(cCalcQueue cq, Action<cCalcQueue, cBubble, cPoint<int>> act , List<cPoint<int>> out_list = null )
    {
        while (!cq.IsComplete())
        {
            cCalcTarget calcTarget = cq.Pop();

            cColsSlot<cBubble> colsSlot = GetColsSlot(calcTarget);
            cBubble stBubble = GetBubble(calcTarget);

            // stBubble == null;
            // 부모자식 개념 탑재
            E_COLS_TYPE colsType = colsSlot.GetColsType();

            for (int i = 0; i < (int)E_SLOT_CHK_DIR.MAX; i++)
            {
                cPoint<int> new_pos = new cPoint<int>(calcTarget.x + ChkOffSet[colsType][(E_SLOT_CHK_DIR)i].x,
                                                        calcTarget.y + ChkOffSet[colsType][(E_SLOT_CHK_DIR)i].y);

                //act.Invoke(cq, stBubble, new_pos);
                act.Invoke(cq, stBubble, new_pos);
            }

            Console.WriteLine("RESULT POS = {0} , {1}", calcTarget.x, calcTarget.y);

            if( out_list != null )
            {
                out_list.Add(calcTarget);
            }

            //out_list != null ? out_list.Add(calcTarget) : 
            //out_drop.Add(calcTarget);

            calcTarget.SetComplete();
        }
    }

    public bool CheckStay(cPoint<int> pos)
    {
        cColsSlot<cBubble> colsSlot = GetColsSlot(pos);

        E_COLS_TYPE colsType = colsSlot.GetColsType();

        for (E_SLOT_CHK_DIR i = E_SLOT_CHK_DIR.UP_LEFT; i <= E_SLOT_CHK_DIR.UP_RIGHT; i++)
        {
            cPoint<int> new_pos = new cPoint<int>(pos.x + ChkOffSet[colsType][i].x,
                                                    pos.y + ChkOffSet[colsType][i].y);

            if (new_pos.y < 0)
                return true;

            cBubble newbb = GetBubble(new_pos);
            if (newbb != null)
            {
                return true;
            }

        }
        return false;
    }

    //public void Pang(cPoint<int> pos)
    //{
    //    if (!ExistBubble(pos))
    //        return;

    //    cCalcQueue cq = new cCalcQueue();

    //    cq.Add(pos);

    //    QueueAct(cq,
    //        (cq, stBubble, new_pos) => {

    //            cBubble newbb = GetBubble(new_pos);
    //            if (newbb != null)
    //            {
    //                if (stBubble.IsSameType(newbb))
    //                {
    //                    cq.Add(new_pos);
    //                }
    //            }
    //        });

    //    // null Setting
    //    foreach (int key in cq.GetQueue().Keys)
    //    {
    //        if (cq.GetQueue()[key].calcState == E_CALC_STATE.COMPLETE)
    //            SetItem(cq.GetQueue()[key]);
    //    }

    //    // 연결이 끊어진 구슬 떨구기 
    //    GetFindDropBubble();
    //}


    public void Pang(cPoint<int> pos , List<cPoint<int> > out_pang , List<cPoint<int>> out_drop)
    {
        if (!ExistBubble(pos))
            return;

        out_pang.Clear();
        out_drop.Clear();

        cCalcQueue cq = new cCalcQueue();

        cq.Add(pos);

        QueueAct(cq,
            (cq, stBubble, new_pos) => {

                cBubble newbb = GetBubble(new_pos);
                if (newbb != null)
                {
                    if (stBubble.IsSameType(newbb))
                    {
                        cq.Add(new_pos);
                    }
                }
            });

        if (cq.GetCalcStateCount(E_CALC_STATE.COMPLETE) >= 3)
        {
            // null Setting
            foreach (int key in cq.GetQueue().Keys)
            {
                if (cq.GetQueue()[key].calcState == E_CALC_STATE.COMPLETE)
                {
                    out_pang.Add(cq.GetQueue()[key]);
                    SetItem(cq.GetQueue()[key]);
                }
            }
        }

        // 연결이 끊어진 구슬 떨구기 
        GetFindDropBubble(out_drop);

        //int k = 0;
        //k = 100;
    }



}