using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class UpgradeRule 
    {
        private static UpgradeRule instance;

        public static UpgradeRule GetInstance() {
            if (instance == null)
            {
                instance = new UpgradeRule();
            }
            return instance;
        }


        public void UpgradeCondition(float currentExp) {
            
            float currentLevel = PlayerExterDataProxy.GetInstance().GetCurrentLevel();

            Debug.Log(currentExp + " / " + currentLevel);
            if (currentExp >= 0 && currentExp < 100)
            {
                return;
            }
            else if (currentExp >= 100 && currentExp < 300 && currentLevel == 0)
            {
                PlayerExterDataProxy.GetInstance().IncreaseLevel();
            }
            else if (currentExp >= 300 && currentExp < 500 && currentLevel == 1)
            {
                PlayerExterDataProxy.GetInstance().IncreaseLevel();
            }
            else if (currentExp >= 500 && currentExp < 1000 && currentLevel == 2)
            {
                PlayerExterDataProxy.GetInstance().IncreaseLevel();
            }
            else if (currentExp >= 1000 && currentExp < 3000 && currentLevel == 3)
            {
                PlayerExterDataProxy.GetInstance().IncreaseLevel();
            }
            else if (currentExp >= 3000 && currentExp < 5000 && currentLevel == 4)
            {
                PlayerExterDataProxy.GetInstance().IncreaseLevel();
            }
        }

        /// <summary>
        /// 升级之后进行的数值操作
        /// </summary>
        public void AddLevelProcessData(float level) {
            switch (level.ToString())
            {
                case "1":
                    AddLevelProcessData(300,10,10,10,10,10);
                    break;
                case "2":
                    AddLevelProcessData(500, 10, 10, 10, 10, 10);
                    break;
                case "3":
                    AddLevelProcessData(1000, 10, 10, 10, 10, 10);
                    break;
                case "4":
                    AddLevelProcessData(3000, 10, 10, 10, 10, 10);
                    break;
                default:
                    break;
            }
        }

        public void AddLevelProcessData(float maxExp,float maxHp,float maxMagic,float maxAttack,float maxDefence,float maxAgile) {
            PlayerExterDataProxy.GetInstance().SetCurrentLevelMaxExp(maxExp);
            PlayerkernalDataProxy.GetInstance().IncreaseMaxHp(maxHp);
            PlayerkernalDataProxy.GetInstance().IncreaseMaxMagic(maxMagic);
            PlayerkernalDataProxy.GetInstance().IncreaseMaxAttack(maxAttack);
            PlayerkernalDataProxy.GetInstance().IncreaseMaxDefence(maxDefence);
            PlayerkernalDataProxy.GetInstance().IncreaseMaxAgile(maxAgile);
            PlayerkernalDataProxy.GetInstance().DisplayAllInfo();//更新面板

            PlayerkernalDataProxy.GetInstance().IncreaseHp(PlayerkernalDataProxy.GetInstance().GetMaxHp());
            PlayerkernalDataProxy.GetInstance().IncreaseMagic(PlayerkernalDataProxy.GetInstance().GetMaxMagic());
        }
    }
}

