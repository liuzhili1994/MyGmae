using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Btn_Click : MonoBehaviour {
    private Button testBtn1;
    private Button testBtn2;
    private Button testBtn3;
    private Button testBtn4;

    private EventTrigger testBtn33;

    // Use this for initialization
    void Start () {
        testBtn1 = transform.Find("testBtn1").GetComponent<Button>();
        testBtn2 = transform.Find("testBtn2").GetComponent<Button>();
        testBtn3 = transform.Find("testBtn3").GetComponent<Button>();
        testBtn4 = transform.Find("testBtn4").GetComponent<Button>();

        testBtn33 = testBtn3.GetComponent<EventTrigger>();

        testBtn1.onClick.AddListener(Btn1Click);
        testBtn2.onClick.AddListener(delegate() {
            this.Btn2Click("我是参数");
        });

        //通过EventTrigger 组件来实现
        EventTrigger.Entry entryPointerEnter = new EventTrigger.Entry();
        entryPointerEnter.eventID = EventTriggerType.PointerEnter;
        entryPointerEnter.callback = new EventTrigger.TriggerEvent();
        entryPointerEnter.callback.AddListener(OnPointerEnter);
        testBtn33.triggers.Add(entryPointerEnter);

        EventTrigger.Entry PointerExit = new EventTrigger.Entry();
        PointerExit.eventID = EventTriggerType.PointerExit;
        PointerExit.callback = new EventTrigger.TriggerEvent();
        PointerExit.callback.AddListener(OnPointerExit);
        testBtn33.triggers.Add(PointerExit);


        EventTrigger.Entry PointeClick = new EventTrigger.Entry();
        PointeClick.eventID = EventTriggerType.PointerClick;
        PointeClick.callback = new EventTrigger.TriggerEvent();
        PointeClick.callback.AddListener(OnPointeClick);
        testBtn33.triggers.Add(PointeClick);
    }

    private void OnPointeClick(BaseEventData arg0)
    {
        Debug.Log("PointerClick...EventSystem");
    }

    private void OnPointerExit(BaseEventData arg0)
    {
        Debug.Log("PointerExit...EventSystem");
    }

    private void OnPointerEnter(BaseEventData arg0)
    {
        Debug.Log("PointerEnter...EventSystem");
    }

    void Btn1Click() {
        Debug.Log("Btn1");
    }

    void Btn2Click(string s)
    {
        Debug.Log("Btn2 +" + s);

    }

    void Btn3Click()
    {
        Debug.Log("Btn3");
    }

    void Btn4Click()
    {
        Debug.Log("Btn4");
    }

    public void Btn3PointerEnter() {
        Debug.Log("Btn3  +  PointerTrigger + 鼠标放到上面");
    }

    
}
