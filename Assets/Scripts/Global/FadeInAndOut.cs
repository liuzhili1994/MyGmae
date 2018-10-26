using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


namespace Global
{
    /// <summary>
    /// 屏幕的淡入淡出效果
    /// </summary>
    public class FadeInAndOut : MonoBehaviour
    {

        public static FadeInAndOut Instance;

        //public GameObject fadeInAndOutObj;
        public DOTweenAnimation dt;//动画组件

        

        private void Awake()
        {
            Instance = this;
            FadeToClear();
            //播完一次动画  就将该物体隐藏掉
            dt.tween.onComplete += () => { dt.gameObject.SetActive(false); };
        }

        /// <summary>
        /// 屏幕淡出
        /// </summary>
        public void FadeToClear() {
            dt.gameObject.SetActive(true);
            dt.DOPlayForward();
        }

        /// <summary>
        /// 屏幕淡入
        /// </summary>
        public void FadeToBlack()
        {
            dt.gameObject.SetActive(true);
            dt.DOPlayBackwards();
        }

       
    }
}

