using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    public class GlobalData
    {
        public static string NextScene = "";
        public static string PlayerName = "";
        public const string START_SCENE = "01_StartScene";
        public const string LOADING_SCENE = "LoadingScene";
        public const string LOGIN_SCENE = "02_LoginScene";
        public const string LEVELONE_SCENE = "03_LevelOne";
        public const string HEROMOVEJOYSTICKNAME = "HeroMoveJoystick";
    }

    /// <summary>
    /// 主角攻击方式委托
    /// </summary>
    public delegate void HeroAttack(string attackType);
}

