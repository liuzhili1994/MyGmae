using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
namespace Control
{
    public class HeroAniPlay : MonoBehaviour
    {
        private Animation ani;
        public AnimationClip[] animationClips;

        private AnimationClip currentAni;
        public int attackTotal = 3;
        private int attackCount ;
        private bool playOnce = false;
        //可以强制跳过当前动作
        private bool canForceSwitch = true;
        // Use this for initialization
        void Start()
        {
            ani = transform.GetComponent<Animation>();
            SetAniState(ManAniType.Idle);
        }

        public void SetAniState(ManAniType ani, bool playOnce = false) {
            if (!canForceSwitch) return;
            string aniName = "";
            if (ani == ManAniType.Attack3)
            {
                aniName = ani.ToString() + "_" + (attackCount% attackTotal + 1);
                attackCount++;
            }
            else
            {
                aniName = ani.ToString();
            }  

            foreach (var item in animationClips)
            {
                if (item.name == aniName)
                {
                    currentAni = item;
                }
            }
            this.playOnce = playOnce;
        }


        private void SetStateDelay() {
            canForceSwitch = true;
            SetAniState(ManAniType.Idle);
        }
        

        // Update is called once per frame
        void Update()
        {
            if (currentAni == null)  return;
            if (playOnce)
            {
                ani.CrossFade(currentAni.name);
                playOnce = false;
                canForceSwitch = false;
                //攻击一次回到待机状态
                Invoke("SetStateDelay",currentAni.length);
            }
            else
            {
                ani.CrossFade(currentAni.name);
            }    
            
        }
    }
}

