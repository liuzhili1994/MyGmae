using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

namespace Control
{
    public class HeroControlByET : MonoBehaviour
    {

        private ETCJoystick heroMoveJoystick;
        public float moveSpeed = 5;

        void Start() {
            heroMoveJoystick = ETCInput.GetControlJoystick(GlobalData.HEROMOVEJOYSTICKNAME);

            
            heroMoveJoystick.onMove.AddListener(OnMove);
            heroMoveJoystick.onMove.AddListener(OnMoveEnd);
            
        }
       
        void OnMove(Vector2 v) {

           // Debug.Log(v);
            float joyStickX = v.x;
            float joyStickY = v.y;

            if (joyStickX != 0 || joyStickY != 0)
            {
                transform.LookAt(new Vector3(transform.position.x - joyStickX, transform.position.y, transform.position.z - joyStickY));

                transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            }
        }

        void OnMoveEnd(Vector2 v)
        {

        }

        void OnDisable() {
            
            heroMoveJoystick.onMove.RemoveAllListeners();
            heroMoveJoystick.onMove.RemoveAllListeners();
        }


        void OnDestroy() {
           
            heroMoveJoystick.onMove.RemoveAllListeners();
            heroMoveJoystick.onMove.RemoveAllListeners();
        }

    }
}

