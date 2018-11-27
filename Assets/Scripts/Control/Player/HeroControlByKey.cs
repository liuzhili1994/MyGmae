using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Control
{
    public class HeroControlByKey : MonoBehaviour
    {
        private HeroAniPlay ani;

        KeyCode attack = KeyCode.A;
        // Use this for initialization
        void Start()
        {
            ani = GetComponent<HeroAniPlay>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(attack))
            {
                ani.SetAniState(Global.ManAniType.Attack3,true);
            }
        }
    }
}

