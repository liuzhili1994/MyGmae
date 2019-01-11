using Model;
using Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kernel;

public class TestModelScript : MonoBehaviour {

    public Text[] txts;

    private void Awake()
    {
        PlayerKernalData.updateUIKernalInfoEvent += PlayerKernalData_updateUIInfoEvent;
        PlayerExterData.UpdateUIExterDataInfo += PlayerKernalData_updateUIInfoEvent;
     }

    private void PlayerKernalData_updateUIInfoEvent(KeyValueForUIDel keyValue)
    {
        //hp, magic, attack, defence, agile,
        // maxHp, maxMagic, maxAttack, maxDefence, maxAgile,
        //  weaponAttack,  weaponDefence,  propAgile
        //switch (keyValue.Key)
        //{
        //    case "hp":

        //        break;
        //    case "magic":

        //        break;
        //    case "attack":

        //        break;
        //    case "defence":

        //        break;
        //    case "agile":

        //        break;
        //    case "maxHp":

        //        break;
        //    case "maxMagic":

        //        break;
        //    case "maxAttack":

        //        break;
        //    case "maxDefence":

        //        break;
        //    case "maxAgile":

        //        break;

        foreach (var item in txts)
        {
            if (item.name == keyValue.Key)
            {
                item.text = keyValue.Value.ToString();
            }
        }
           
        
    }

    // Use this for initialization
    void Start () {
        PlayerkernalDataProxy playerkernalDataProxy = new PlayerkernalDataProxy(100,100,10,5,45,100,100,10,5,50,0,0,0);
        PlayerExterDataProxy playerExterDataProxy = new PlayerExterDataProxy(0,100,0,0,0,0);
        //PlayerkernalDataProxy.GetInstance().DisplayAllInfo();

        ConfigMgr configMgr = new ConfigMgr(Application.dataPath + "/XML/HelloXML.xml");


	}

    public void IncreaseHP() {
        PlayerkernalDataProxy.GetInstance().IncreaseHp(10);
    }

    public void DecreaseHP()
    {
        PlayerkernalDataProxy.GetInstance().DecreaseHp(10);
    }

    public void IncreaseLevel() {
        PlayerExterDataProxy.GetInstance().IncreaseLevel();
    }

    public void IncreaseExp(float exp) {
        PlayerExterDataProxy.GetInstance().IncreaseExp(exp);
    }
}
