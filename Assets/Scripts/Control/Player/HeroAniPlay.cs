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
        /// <summary>
        /// 当前动画片段
        /// </summary>
        private AnimationClip currentAni;
        /// <summary>
        /// 普通攻击的段数
        /// </summary>
        public int attackTotal = 3;
        /// <summary>
        /// 当前普通攻击第几段
        /// </summary>
        private int attackCount ;
        /// <summary>
        /// 当前播放的动画  是不是只播放一次（idle ，run等动画可以重复播放，攻击，放技能只能播放一次）
        /// </summary>
        private bool playOnce = false;
        //可以强制跳过当前动作
        private bool canForceSwitch = true;
        // Use this for initialization
        void Start()
        {
            ani = transform.GetComponent<Animation>();
            SetAniState(AniType.Idle);
            StartCoroutine("UpdateAni");
        }

        /// <summary>
        /// 修改动画
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="playOnce"></param>
        public void SetAniState(AniType ani, bool playOnce = false) {
            if (!canForceSwitch) return;
            string aniName = "";
            if (ani == AniType.Attack3)
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
                    if (currentAni.name.StartsWith("Attack3"))
                    {
                        this.ani[currentAni.name].speed = 2.5f;
                    }
                }
            }
            this.playOnce = playOnce;
        }

        /// <summary>
        /// 播放动画
        /// </summary>
        /// <returns></returns>
        IEnumerator UpdateAni() {
            while (true)
            {
                if (currentAni == null) yield break;
                if (playOnce)
                {
                    ani.CrossFade(currentAni.name);
                    playOnce = false;
                    canForceSwitch = false;
                    //攻击一次回到待机状态
                    yield return new WaitForSeconds(currentAni.length/2.5f);
                    canForceSwitch = true;
                    SetAniState(AniType.Idle);
                }
                else
                {
                    //attackCount = 0;
                    ani.CrossFade(currentAni.name);
                }
                yield return new WaitForSeconds(0.1f);
            }
        }

        
    }
}

