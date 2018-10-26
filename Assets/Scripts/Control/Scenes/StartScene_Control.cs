using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Control;
using Global;

namespace Control {
    public class StartScene_Control : SingleMono<StartScene_Control>
    {
        
        public void EnterGame() {
            //TODO 开始游戏，进入游戏场景
            Debug.Log(GetType() + " / EnterGame()");
            StartCoroutine("StartGame");
        }

        IEnumerator StartGame() {
            FadeInAndOut.Instance.FadeToBlack();
            yield return new WaitForSeconds(1.5f);
            //GlobalData.NextScene = GlobalData.LOGIN_SCENE;
            //SceneManager.LoadScene(GlobalData.LOADING_SCENE);
            SceneLoadMgr.Instance.EnterNextScene(GlobalData.LOGIN_SCENE);
        }

    }
}

