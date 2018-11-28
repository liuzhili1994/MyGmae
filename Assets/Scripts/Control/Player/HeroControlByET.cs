using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

namespace Control
{
    public class HeroControlByET : MonoBehaviour
    {

        private ETCJoystick heroMoveJoystick;
        private CharacterController cc;
        public float moveSpeed = 5;
        private HeroAniPlay ani;
        public float gravityFlo;
         

        void Start() {
            heroMoveJoystick = ETCInput.GetControlJoystick(GlobalData.HEROMOVEJOYSTICKNAME);
            cc = GetComponent<CharacterController>();
            ani = GetComponent<HeroAniPlay>();

            heroMoveJoystick.onMove.AddListener(OnMove);
            heroMoveJoystick.onMoveEnd.AddListener(OnMoveEnd);
            
        }
       
        void OnMove(Vector2 v) {

           // Debug.Log(v);
            float joyStickX = v.x;
            float joyStickY = v.y;

            if (joyStickX != 0 || joyStickY != 0)
            {
                //面向前方
                transform.LookAt(new Vector3(transform.position.x - joyStickX, transform.position.y, transform.position.z - joyStickY));
                //向前移动
                //transform.Translate(transform.forward * Time.deltaTime * moveSpeed,Space.World);  //使用该方法主角将无视碰撞 （弃用）
                cc.Move(transform.forward * Time.deltaTime * moveSpeed);
                ani.SetAniState(AniType.Run);
                //模拟重力
                transform.position = new Vector3(transform.position.x,transform.position.y - gravityFlo,transform.position.z);
            }
        }

        void OnMoveEnd()
        {
            ani.SetAniState(AniType.Idle);
        }

        void OnDisable() {
            
            heroMoveJoystick.onMove.RemoveAllListeners();
            heroMoveJoystick.onMoveEnd.RemoveAllListeners();
        }


        void OnDestroy() {
            heroMoveJoystick.onMove.RemoveAllListeners();
            heroMoveJoystick.onMoveEnd.RemoveAllListeners();
        }

    }
}

