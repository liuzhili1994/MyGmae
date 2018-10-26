using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Global
{
    public class SceneLoadMgr
    {
        private static SceneLoadMgr instance;

        public static SceneLoadMgr Instance
        {
            get
            {
                if (instance == null)
                    instance = new SceneLoadMgr();
                return instance;
            }
        }

        public void EnterNextScene(string nextScenName) {
            GlobalData.NextScene = nextScenName ;
            SceneManager.LoadScene(GlobalData.LOADING_SCENE);
        }
    }
}

