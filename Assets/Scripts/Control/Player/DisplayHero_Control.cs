using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

namespace Control
{
    /// <summary>
    /// 人物展示控制脚本
    /// </summary>
    public class DisplayHero_Control : MonoBehaviour
    {
        private Animation showAni;

        //public List<AnimationClip> AniClips = new List<AnimationClip>();
        public AnimationClip[] AniClips;
        /// <summary>
        /// 计时器
        /// </summary>
        private float timer;

        private void Start()
        {
            showAni = GetComponent<Animation>();
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                timer = 0;
                PlayAni(Random.Range(0,AniClips.Length));
            }
        }


        internal void PlayAni(int id) {
            showAni.CrossFade(AniClips[id].name);
        }

    }

}
