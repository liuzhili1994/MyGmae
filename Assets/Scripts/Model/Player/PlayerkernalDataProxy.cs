using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class PlayerkernalDataProxy : PlayerKernalData
    {
        private static PlayerkernalDataProxy instance = null;
        public PlayerkernalDataProxy(float hp, float magic, float attack, float defence, float agile,
           float maxHp, float maxMagic, float maxAttack, float maxDefence, float maxAgile,
           float weaponAttack, float weaponDefence, float propAgile) : base(hp, magic, attack, defence, agile,
            maxHp, maxMagic, maxAttack, maxDefence, maxAgile,
             weaponAttack,  weaponDefence,  propAgile)
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Debug.LogError("单例模式不允许有两个实例");
            }
        }
        /// <summary>
        /// 获取该类实例
        /// </summary>
        /// <returns></returns>
        public static PlayerkernalDataProxy GetInstance() {
            if (instance != null)
            {
                return instance;
            }
            else
            {
                Debug.Log("请在调用该单例之前，实例化对象");
                return null;
            }
        }

        public void DisplayAllInfo() {
            this.Hp = this.Hp;
            this.Magic = this.Magic;
            this.Attack = this.Attack;
            this.Defence = this.Defence;
            this.Agile = this.Agile;

            this.MaxHp = this.MaxHp;
            this.MaxAttack = this.MaxAttack;
            this.MaxMagic = this.MaxMagic;
            this.MaxDefence = this.MaxDefence;
            this.MaxAgile = this.MaxAgile;
        }


        #region 血量操作

        public void IncreaseHp(float increaseHp) {
            this.Hp += increaseHp;
            if (this.Hp >= this.MaxHp)
            {
                this.Hp = MaxHp;
            }

            //生命值影响到其他属性
            UpdateAgile();
            UpdateDefence();
            UpdateAgile();
        }

        public void DecreaseHp(float decreaseHp) {
            this.Hp -= (decreaseHp + this.Defence+ this.WeaponDefence);
            if (this.Hp <= 0)
            {
                this.Hp = 0;
            }
            //生命值影响到其他属性
            UpdateAttack();
            UpdateDefence();
            UpdateAgile();
        }

        public float GetCurrentHp() {
            return this.Hp;
        }

        public void IncreaseMaxHp(float hp) {
            this.MaxHp += hp;
        }

        public float GetMaxHp() {
            return this.MaxHp;
        }

        #endregion


        #region 蓝量操作

        public void IncreaseMagic(float mp)
        {
            this.Magic += mp;
            if (this.Magic >= this.MaxMagic)
            {
                this.Magic = MaxMagic;
            }
        }

        public void DecreaseMagic(float mp)
        {
            this.Magic -= mp;
            if (this.Magic <= 0)
            {
                this.Magic = 0;
            }
        }

        public float GetCurrentMagic()
        {
            return this.Magic;
        }

        public void IncreaseMaxMagic(float mp)
        {
            this.MaxMagic += mp;
        }

        public float GetMaxMagic()
        {
            return this.MaxMagic;
        }

        #endregion


        #region 攻击力操作
        /// <summary>
        /// 更新武器攻击力
        /// </summary>
        /// <param name="attack">新的武器的攻击力</param>
        public void UpdateAttack(float attack = 0) {
            if (attack == 0)//说明仅仅是因为血量或者升级了  才变更的攻击力
            {
                this.Attack = this.MaxAttack / 2 * (this.Hp / this.MaxHp) + WeaponAttack;
            }
            else  //说明此时更换了武器  
            {
                this.Attack = this.MaxAttack / 2 * (this.Hp / this.MaxHp) + attack;
                this.WeaponAttack = attack;
            }

            if (this.Attack >= this.MaxAttack)
            {
                this.Attack = this.MaxAttack;
            }
        }

        public float GetCurrentAttack()
        {
            return this.Attack;
        }

        public void IncreaseMaxAttack(float attack)
        {
            this.MaxAttack += attack;
        }

        public float GetMaxAttack()
        {
            return this.MaxAttack;
        }

        #endregion


        #region 防御力操作
        /// <summary>
        /// 更新防御力
        /// </summary>
        /// <param name="defence">新的武器的防御力</param>
        public void UpdateDefence(float defence = 0)
        {
            if (defence == 0)//说明仅仅是因为血量或者升级了  才变更的防御力
            {
                this.Defence = this.MaxDefence / 2 * (this.Hp / this.MaxHp) + WeaponDefence;
            }
            else  //说明此时更换了武器  
            {
                this.Defence = this.MaxDefence / 2 * (this.Hp / this.MaxHp) + defence;
                this.WeaponDefence = defence;
            }
            if (this.Defence >= this.MaxDefence)
            {
                this.Defence = this.MaxDefence;
            }
        }

        public float GetCurrentDefence()
        {
            return this.Defence;
        }

        public void IncreaseMaxDefence(float defence)
        {
            this.MaxDefence += defence;
        }

        public float GetMaxDefence()
        {
            return this.MaxDefence;
        }

        #endregion


        #region 敏捷操作
        /// <summary>
        /// 更新敏捷
        /// </summary>
        /// <param name="agile">新的道具的敏捷力</param>
        public void UpdateAgile(float agile = 0)
        {
            if (agile == 0)//说明仅仅是因为血量或者防御力变了  才变更的防御力
            {
                this.Agile = this.MaxAgile / 2 * (this.Hp / this.MaxHp) - this.Defence + this.PropAgile;
            }
            else  //说明此时更换了道具
            {
                this.Agile = this.MaxAgile / 2 * (this.Hp / this.MaxHp) - this.Defence + agile;
                this.PropAgile = agile;
            }
            if (this.Agile >= this.MaxAgile)
            {
                this.Agile = this.MaxAgile;
            }
        }

        public float GetCurrentAgile()
        {
            return this.Agile;
        }

        public void IncreaseMaxAgile(float agile)
        {
            this.MaxAgile += agile;
        }

        public float GetMaxAgile()
        {
            return this.MaxAgile;
        }

        #endregion
    }

}
