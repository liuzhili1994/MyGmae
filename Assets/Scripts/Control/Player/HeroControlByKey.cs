using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

namespace Control
{
    public class HeroControlByKey : MonoBehaviour
    {
        
        public static event HeroAttackDel attackEvent;
        KeyCode attack = KeyCode.J;
        KeyCode skill1 = KeyCode.K;
        KeyCode skill2 = KeyCode.L;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(attack))
            {
                //heroAttack.SetAniState(Global.ManAniType.Attack3,true);
                attackEvent.Invoke(AniType.Attack3);
            }
            if (Input.GetKeyDown(skill1))
            {
                attackEvent.Invoke(AniType.Attack1);
            }
            if (Input.GetKeyDown(skill2))
            {
                attackEvent.Invoke(AniType.Attack2);
            }
        }
    }
}

