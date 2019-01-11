using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

namespace Model
{
    public class PlayerExterData
    {
        public static event UpdateUIInfo UpdateUIExterDataInfo;

        #region 字段

        private float exp;
        private float maxExp;
        private float level;
        private float killEnemyCount;
        private float gold;
        private float diamond;

        

        #endregion


        #region 属性

        public float Exp
        {
            get
            {
                return exp;
            }

            set
            {
                exp = value;
                UpdateUIExterDataInfo(new KeyValueForUIDel() { Key = "exp", Value = exp });
            }
        }

        public float Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
                UpdateUIExterDataInfo(new KeyValueForUIDel() { Key = "level", Value = level });
            }
        }

        public float KillEnemyCount
        {
            get
            {
                return killEnemyCount;
            }

            set
            {
                killEnemyCount = value;
                UpdateUIExterDataInfo(new KeyValueForUIDel() { Key = "killEnemyCount", Value = killEnemyCount });
            }
        }

        public float Gold
        {
            get
            {
                return gold;
            }

            set
            {
                gold = value;
                UpdateUIExterDataInfo(new KeyValueForUIDel() { Key = "gold", Value = gold });
            }
        }

        public float Diamond
        {
            get
            {
                return diamond;
            }

            set
            {
                diamond = value;
                UpdateUIExterDataInfo(new KeyValueForUIDel() { Key = "diamond", Value = diamond });
            }
        }

        public float MaxExp
        {
            get
            {
                return maxExp;
            }

            set
            {
                maxExp = value;
                UpdateUIExterDataInfo(new KeyValueForUIDel() { Key = "maxExp", Value = maxExp });
            }
        }




        #endregion

        #region 方法

        public PlayerExterData(float exp, float maxExp, float level,float killEnemyCount,float gold,float diamond) {
            this.Exp = exp;
            this.MaxExp = maxExp;
            this.Level = level;
            this.KillEnemyCount = killEnemyCount;
            this.Gold = gold;
            this.Diamond = diamond;
        }

        #endregion

    }
}
