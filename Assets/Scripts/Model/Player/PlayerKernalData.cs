using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

namespace Model
{
    public class PlayerKernalData
    {
        public static event UpdateUIInfo updateUIKernalInfoEvent;

        #region 字段

        private float hp;
        private float magic;
        private float attack;
        private float defence;
        private float agile;

        private float maxHp;
        private float maxMagic;
        private float maxAttack;
        private float maxDefence;
        private float maxAgile;

        private float weaponDefence;
        private float weaponAttack;
        private float propAgile;

        #endregion

        #region 属性
        public float Hp
        {
            get
            {
                return hp;
            }

            set
            {
                hp = value;
                updateUIKernalInfoEvent(new KeyValueForUIDel() { Key = "hp",Value = hp});
            }
        }

        public float Magic
        {
            get
            {
                return magic;
            }

            set
            {
                magic = value;
                updateUIKernalInfoEvent(new KeyValueForUIDel() { Key = "magic", Value = magic });
            }
        }

        public float Attack
        {
            get
            {
                return attack;
            }

            set
            {
                attack = value;
                updateUIKernalInfoEvent(new KeyValueForUIDel() { Key = "attack", Value = attack });
            }
        }

        public float Defence
        {
            get
            {
                return defence;
            }

            set
            {
                defence = value;
                updateUIKernalInfoEvent(new KeyValueForUIDel() { Key = "defence", Value = defence });
            }
        }

        public float Agile
        {
            get
            {
                return agile;
            }

            set
            {
                agile = value;
                updateUIKernalInfoEvent(new KeyValueForUIDel() { Key = "agile", Value = agile });
            }
        }

        public float MaxHp
        {
            get
            {
                return maxHp;
            }

            set
            {
                maxHp = value;
                updateUIKernalInfoEvent(new KeyValueForUIDel() { Key = "maxHp", Value = maxHp });
            }
        }

        public float MaxMagic
        {
            get
            {
                return maxMagic;
            }

            set
            {
                maxMagic = value;
                updateUIKernalInfoEvent(new KeyValueForUIDel() { Key = "maxMagic", Value = maxMagic });
            }
        }

        public float MaxAttack
        {
            get
            {
                return maxAttack;
            }

            set
            {
                maxAttack = value;
                updateUIKernalInfoEvent(new KeyValueForUIDel() { Key = "maxAttack", Value = maxAttack });
            }
        }

        public float MaxDefence
        {
            get
            {
                return maxDefence;
            }

            set
            {
                maxDefence = value;
                updateUIKernalInfoEvent(new KeyValueForUIDel() { Key = "maxDefence", Value = maxDefence });
            }
        }

        public float MaxAgile
        {
            get
            {
                return maxAgile;
            }

            set
            {
                maxAgile = value;
                updateUIKernalInfoEvent(new KeyValueForUIDel() { Key = "maxAgile", Value = maxAgile });
            }
        }

        public float WeaponDefence
        {
            get
            {
                return weaponDefence;
            }

            set
            {
                weaponDefence = value;
            }
        }

        public float WeaponAttack
        {
            get
            {
                return weaponAttack;
            }

            set
            {
                weaponAttack = value;
            }
        }

        public float PropAgile
        {
            get
            {
                return propAgile;
            }

            set
            {
                propAgile = value;
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public PlayerKernalData(float hp, float magic, float attack, float defence, float agile,
           float maxHp, float maxMagic, float maxAttack, float maxDefence, float maxAgile,
           float weaponAttack,float weaponDefence,float propAgile) {
            this.Hp = hp;
            this.Magic = magic;
            this.Attack = attack;
            this.Defence = defence;
            this.Agile = agile;

            this.MaxHp = maxHp;
            this.MaxMagic = maxMagic;
            this.MaxAttack = maxAttack;
            this.MaxDefence = maxDefence;
            this.MaxAgile = maxAgile;

            this.WeaponAttack = weaponAttack;
            this.WeaponDefence = weaponDefence;
            this.PropAgile = propAgile;
        }
        #endregion

    }

}
