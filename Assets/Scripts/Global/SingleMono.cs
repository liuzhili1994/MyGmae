using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    /// <summary>
    /// 单例基类，继承该类将会是一个单例类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleMono<T> : MonoBehaviour where T : SingleMono<T>
    {

        public static T Instance { get; set; }

        protected virtual void Awake()
        {
            Instance = this as T;
        }


    }
}

