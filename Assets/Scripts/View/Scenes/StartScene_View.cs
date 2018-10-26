using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Control;
using Global;

namespace View
{
    public class StartScene_View : MonoBehaviour
    {
        /// <summary>
        /// 开始游戏按钮
        /// </summary>
        [SerializeField]
        private Button startGameBtn;

        private void Start()
        {
            if (startGameBtn != null)
            {
                startGameBtn.onClick.AddListener(StartGame);
            }

            //开启淡入淡出效果
            FadeInAndOut.Instance.FadeToClear();
        }

        private void StartGame()
        {
            // 加载开始游戏场景
            StartScene_Control.Instance.EnterGame();
        }
    }
}

