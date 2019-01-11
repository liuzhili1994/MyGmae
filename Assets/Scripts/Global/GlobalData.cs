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

    public enum AniType {
        Idle,
        Run,
        Attack3,
        Attack1,
        Attack2,
    }

    /// <summary>
    /// 主角攻击方式委托
    /// </summary>
    public delegate void HeroAttackDel(AniType attackType);

    public delegate void UpdateUIInfo(KeyValueForUIDel keyValue);

    public class KeyValueForUIDel {
        private string key;
        private float value;

        public string Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }

        public float Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

    }
}

