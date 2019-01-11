using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control
{
    public class EnemyHealth : MonoBehaviour
    {
        public float maxHP = 100;
        public float currentHP;

        public bool IsDie { get; private set; }

        // Use this for initialization
        void Start()
        {
            currentHP = maxHP;
        }

        public void BeHit(float damage) {
            this.currentHP -= damage;
            if (currentHP <= 0)
            {
                ToDie();
                return;
            }
            //被击反馈

        }

        public void ToDie() {

            IsDie = true;
            //播放死亡动画

            //播放完毕  死亡（destroy）
        }
    }

}
