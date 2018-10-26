using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Global;

namespace View
{
    public class LoadingScene_View : MonoBehaviour
    {
        AsyncOperation async;
        
        public UnityEngine.UI.Slider ProgressSlider;
        // Use this for initialization
        void Start()
        {
             
            if (ProgressSlider)
                ProgressSlider.value = 0;

            StartCoroutine("LoadingScene");
        }

        IEnumerator LoadingScene() {
            //Debug.Log(GetType() + " / " + GlobalData.NextScene);
            async = SceneManager.LoadSceneAsync(GlobalData.NextScene);
            async.allowSceneActivation = false;//此属性为fasle时，场景加载完成后async.progress会停在0.9f

            //场景加载完成回调
            async.completed += Async_completed;
            yield return async;

        }

        private void Async_completed(AsyncOperation obj)
        {
            
        }

        private void Update()
        {
            
            if (async.progress <= 0.9f)
            {
                ProgressSlider.value += 0.01f;
            }

            if (ProgressSlider.value >= 0.9f)
            {
                ProgressSlider.value = 1;
                async.allowSceneActivation = true;
            }
        }

        
    }
}

