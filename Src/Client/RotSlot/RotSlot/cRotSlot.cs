using System;
using System.Collections.Generic;
using System.Text;

namespace RotSlot
{
    interface IEntityID
    {
        public int GetID();
    }

    abstract class cID : IEntityID
    {
        int mID;
        public cID(int id)
        {
            mID = id;
        }

        public int GetID()
        {
            return mID;
        }
    }

    class cSlot<T> : cID where T : class
    {
        T mItem = null;

        public cSlot(int id)
            : base(id)
        {
        }
        public void Set(T item)
        {
            mItem = item;
        }

        public T GetItem()
        {
            return mItem;
        }

        public void ReSet()
        {
            mItem = null;
        }
        public override string ToString()
        {
            if (mItem == null)
                return "E";

            return mItem.ToString();
        }
    }

    //odd-to-even 
    enum E_COLS_TYPE
    {
        NONE = -1,
        ODD,      // 홀
        EVEN,     // 짝
        MAX
    }

    class cColsSlot<T> : cID where T : class
    {
        List<cSlot<T>> mSlots = new List<cSlot<T>>();

        E_COLS_TYPE mColsType = E_COLS_TYPE.ODD;

        public cColsSlot(int id, int slot_nums)
            : base(id)
        {
            if (slot_nums % 2 == 0)
            {
                //짝수다
                mColsType = E_COLS_TYPE.EVEN;
            }

            for (int i = 0; i < slot_nums; i++)
            {
                mSlots.Add(new cSlot<T>(i));
            }
        }

        public E_COLS_TYPE GetColsType()
        {
            return mColsType;

            //if ( mSlots.Count % 2 == 0 )
            //{
            //    return E_COLS_TYPE.EVEN;
            //}

            //return E_COLS_TYPE.ODD;
        }

        public cSlot<T> GetSlotByIDX(int slot_idx)
        {
            return mSlots[slot_idx];
        }

        public cSlot<T> GetSlotByID(int slot_id)
        {
            foreach (cSlot<T> slot in mSlots)
            {
                if (slot.GetID() == slot_id)
                    return slot;
            }

            return null;
        }

        public int GetCount()
        {
            return mSlots.Count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("ID: ");
            sb.Append(GetID());
            sb.Append(" ");

            for (int i = 0; i < mSlots.Count; i++)
            {
                if (i != 0)
                    sb.Append(",");

                sb.Append(mSlots[i].ToString());
            }
            return sb.ToString();
        }
    }


    enum E_SLOT_CHK_DIR
    {
        LEFT = 0,
        RIGHT = 1,
        UP_LEFT = 2,
        UP_RIGHT = 3,
        DOWN_LEFT = 4,
        DOWN_RIGHT = 5,
        MAX
    }

    class cRotSlot<T> where T : class
    {
        int mRowCnt = 8;
        int mColCnt = 8;

        cRotQueue<cColsSlot<T>> mRotQueue = null;

        public cRotSlot()
        {
            Init();
        }

        void Init()
        {
            mRotQueue = new cRotQueue<cColsSlot<T>>(mRowCnt);
            MakeSlots();
        }

        void MakeSlots()
        {
            for (int i = 0; i < mRowCnt; i++)
            {
                cColsSlot<T> cs = new cColsSlot<T>(i, (i % 2 == 0) ? mColCnt : mColCnt - 1);
                mRotQueue.Set(i, cs);
            }
        }
        protected cColsSlot<T> GetColsSlot(int idx)
        {
            return mRotQueue.GetItemByIDX(idx);
        }
        protected cColsSlot<T> GetColsSlot(cPoint<int> point)
        {
            return mRotQueue.GetItemByIDX(point.y);
        }

        protected int GetColsSlotCount()
        {
            return mRotQueue.GetCount();
        }

        protected cSlot<T> GetSlot(int x, int y)
        {
            cColsSlot<T> colsSlot = mRotQueue.GetItemByIDX(y);
            return colsSlot == null ? null : colsSlot.GetSlotByIDX(x);
        }
        protected cSlot<T> GetSlot(cPoint<int> point)
        {
            cColsSlot<T> colsSlot = GetColsSlot(point);// mRotQueue.GetItemByIDX(point.y);
            return colsSlot == null ? null : colsSlot.GetSlotByIDX(point.x);
        }

        public void SetItem(int x, int y, T item)
        {
            GetSlot(x, y).Set(item);
        }

        public void SetItem(cPoint<int> point, T item = null)
        {
            GetSlot(point.x, point.y).Set(item);
        }

        public void SetItemByID(int cols_id, int slot_id, T item)
        {
            try
            {
                mRotQueue.GetItemByID(cols_id).GetSlotByID(slot_id).Set(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return;
        }

        public void Print()
        {
            Console.WriteLine(mRotQueue.ToString());
        }
        public void ForWard()
        {
            mRotQueue.ForWard();
        }
        public void BackWard()
        {
            mRotQueue.BackWard();
        }
    }

    class cBubbleSlot : cRotSlot<cBubble>
    {
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


        //static Dictionary<E_SLOT_CHK_DIR, cPoint<int>> ChkOffset =
        //    new Dictionary<E_SLOT_CHK_DIR, cPoint<int>>()
        //    {
        //        {E_SLOT_CHK_DIR.LEFT , new cPoint<int>(-1,0) } ,
        //        {E_SLOT_CHK_DIR.RIGHT , new cPoint<int>(1,0) } ,
        //        {E_SLOT_CHK_DIR.UP_LEFT , new cPoint<int>(-1,-1) } ,
        //        {E_SLOT_CHK_DIR.UP_RIGHT , new cPoint<int>(0,-1) } ,

        //        //홀수
        //        {E_SLOT_CHK_DIR.UP_LEFT , new cPoint<int>(0,-1) } ,
        //        {E_SLOT_CHK_DIR.UP_RIGHT , new cPoint<int>(1,-1) } ,
        //    };

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

        private bool ChkDropStartBubble( cPoint<int> pos , cColsSlot<cBubble> cols_slot , cBubble bb)
        {
            // HACK 수정해야함.....
            for (int i = (int)E_SLOT_CHK_DIR.LEFT ; i <= (int)E_SLOT_CHK_DIR.UP_RIGHT; i++)
            {
                cPoint<int> new_pos = new cPoint<int>(pos.x + ChkOffSet[cols_slot.GetColsType()][(E_SLOT_CHK_DIR)i].x,
                                        pos.y + ChkOffSet[cols_slot.GetColsType()][(E_SLOT_CHK_DIR)i].y);

                cBubble newbb = GetBubble(new_pos);

                if (newbb != null)
                    return false;
            }

            return true;
        }


        private void GetFindDropBubble()
        {
            cCalcQueue cq = new cCalcQueue();
            for(int i = 0;  i < GetColsSlotCount() ; i++ )
            {
                cColsSlot<cBubble> colsSlot = GetColsSlot(i);
                for( int slotIdx = 0; slotIdx < colsSlot.GetCount() ; slotIdx++ )
                {
                    cPoint<int> pos = new cPoint<int>(slotIdx, i);

                    cBubble bb = GetBubble( pos );

                    if (bb == null)
                        continue;

                    // 버블을 찾으면
                    if( ChkDropStartBubble(  pos , colsSlot , bb ) )
                    {
                        Console.WriteLine("GetFindDropBubble : [{0}] [{1} , {2}]", bb.GetType() , pos.x , pos.y);
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

            });
        }

        private void QueueAct(cCalcQueue cq , Action<cCalcQueue , cBubble , cPoint<int>> act )
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
                calcTarget.SetComplete();
            }
        }

        public void Pang(cPoint<int> pos)
        {
            if (!ExistBubble(pos))
                return;

            cCalcQueue cq = new cCalcQueue();

            cq.Add(pos);

            QueueAct(cq , 
                ( cq , stBubble , new_pos  ) => {

                    cBubble newbb = GetBubble(new_pos);
                    if (newbb != null)
                    {
                        if (stBubble.IsSameType(newbb))
                        {
                            cq.Add(new_pos);
                        }
                    }
                } );

            // null Setting
            foreach (int key in cq.GetQueue().Keys)
            {
                if (cq.GetQueue()[key].calcState == E_CALC_STATE.COMPLETE)
                    SetItem(cq.GetQueue()[key]);
            }

            // 연결이 끊어진 구슬 떨구기 

            GetFindDropBubble();

            //int k = 0;
            //k = 100;
        }



    }
}
