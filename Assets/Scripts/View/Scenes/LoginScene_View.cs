using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Control;


namespace View
{
    public class LoginScene_View : MonoBehaviour
    {
        public GameObject[] Players;
        
        public RawImage playerInfoImg;
        public Texture[] texture;
        public Button BoyBtn;
        public Button GirlBtn;

        public Button SubmitBtn;
        public InputField NameField;



        private void Start()
        {
            if (BoyBtn)
                BoyBtn.onClick.AddListener(delegate() { PlayerSelect(0); });
            if (GirlBtn)
                GirlBtn.onClick.AddListener(delegate() { PlayerSelect(1); });
            if (SubmitBtn)
                SubmitBtn.onClick.AddListener(delegate() {
                    LoginScene_Control.Instance.ConfirmBtnClick(NameField.text);
                });

            //初始化显示面板
            playerInfoImg.texture = texture[0];
            Players[0].SetActive(true);
            Players[1].SetActive(false);
        }

        private void PlayerSelect(int id) {

            //显示对应的info面板
            playerInfoImg.texture = texture[id];
            //显示对应的角色
            Players[id].SetActive(true);
            //隐藏其他的的角色
            for (int i = 0; i < Players.Length; i++)
            {
                if (i != id)
                    Players[i].SetActive(false);
            }
        }




    }

}
