using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

namespace Control
{
    /// <summary>
    /// 主角攻击脚本 
    /// </summary>
    public class HeroAttack : MonoBehaviour
    {
        private HeroAniPlay ani;
        
        // Use this for initialization
        void Start()
        {
            ani = transform.GetComponent<HeroAniPlay>();
            HeroControlByKey.attackEvent += HeroControlByKey_attackEvent;
        }

        private void HeroControlByKey_attackEvent(AniType attackType)
        {
            ani.SetAniState(attackType,true);
        }
    }

}
