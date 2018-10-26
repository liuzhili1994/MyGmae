using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class LoginScene_Control :  SingleMono<LoginScene_Control>{

    public void ConfirmBtnClick(string name) {
        if (string.IsNullOrEmpty(name))
        {
            Debug.Log("名字不能为空。。。");
            return;
        }
        GlobalData.PlayerName = name;
        SceneLoadMgr.Instance.EnterNextScene(GlobalData.LevelOne_SCENE);
    }
}
