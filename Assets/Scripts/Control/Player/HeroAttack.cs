using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
using System;

namespace Control
{
    /// <summary>
    /// 主角攻击脚本 
    /// </summary>
    public class HeroAttack : MonoBehaviour
    {
        private HeroAniPlay ani;
        
        // Use this for initialization
        void Start()
        {
            ani = transform.GetComponent<HeroAniPlay>();
            HeroControlByKey.attackEvent += HeroControlByKey_attackEvent;
            //一直查找附近的敌人
            InvokeRepeating("LookToNearestEnemy",2f,0.1f);
        }

        private void HeroControlByKey_attackEvent(AniType attackType)
        {
            ani.SetAniState(attackType,true);
        }


        private void Update()
        {
            

            
        }


        #region LookToEnemy

        //字段
        public Collider[] enemys;
        public float checkDis = 10f;
        public float minDis = 5f;

        public float rotToTargetSpeed = 1f;
        /// <summary>
        /// 检测最近敌人  并面朝敌人
        /// </summary>
        private void LookToNearestEnemy()
        {
            float dis = minDis;
            //layerMask 是忽略Enmey这一层      1 << LayerMask.NameToLayer("Enemy")意为 只检测“Enemy”这一层
            enemys =  Physics.OverlapSphere(transform.position, checkDis, 1 << LayerMask.NameToLayer("Enemy"));
            //附近没有敌人  return
            if (enemys.Length <= 0)
                return;
            for (int i = 0; i < enemys.Length; i++)
            {
                EnemyHealth enemy = enemys[i].GetComponent<EnemyHealth>();
                if (enemy!=null && enemy.IsDie)//当前敌人死掉了，跳出本次循环
                    continue;
                //执行到这一步说明敌人没死
                float currentDis = Vector3.Distance(transform.position,enemy.transform.position);
                if (currentDis < dis)
                {
                    dis = currentDis;
                    //有点跳，舍弃
                    //transform.LookAt(enemy.transform);
                    //获得朝向向量
                    Vector3 dir = enemy.transform.position - transform.position;
                    //只让主角沿y轴旋转（此时获得的朝向向量是跟transform.forward是平行的）
                    dir = new Vector3(dir.x,0,dir.z).normalized;
                    transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(dir,Vector3.up),Time.deltaTime * rotToTargetSpeed);
                }
               
            }

        }


        #endregion
    }

}
