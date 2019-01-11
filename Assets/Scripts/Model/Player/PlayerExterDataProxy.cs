using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class PlayerExterDataProxy : PlayerExterData
    {
        private static PlayerExterDataProxy instance = null;


        public PlayerExterDataProxy(float exp, float maxExp, float level, float killEnemyCount, float gold, float diamond) 
            : base(exp,maxExp, level, killEnemyCount, gold, diamond)
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Debug.LogError("不允许存在两个实例PlayerExterDataProxy");
            }
        }


        public static PlayerExterDataProxy GetInstance() {
            if (instance == null)
            {
                Debug.LogError("请现实例化PlayerExterDataProxy");
            }

            return instance;
        }


        #region 操作经验值

        public void IncreaseExp(float exp) {
            this.Exp += exp;
            //判断是否需要升级
            UpgradeRule.GetInstance().UpgradeCondition(this.Exp);
        }

        public float GetCurrentExp() {
            return this.Exp;
        }

        public float GetMaxExp() {
            return this.MaxExp;
        }

        public void SetCurrentLevelMaxExp(float maxExp) {
            this.MaxExp = maxExp;
        }


        #endregion


        #region 操作升级

        public void IncreaseLevel()
        {
            ++this.Level;
            //升级之后需要  满血，然后设置下一级的  最大经验值
            UpgradeRule.GetInstance().AddLevelProcessData(this.Level);
        }

        public float GetCurrentLevel()
        {
            return this.Level;
        }
        

        #endregion

    }

}
