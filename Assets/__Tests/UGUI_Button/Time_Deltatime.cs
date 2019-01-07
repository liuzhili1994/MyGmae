using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Deltatime : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Time.deltaTime);
        //Debug.Log(Time.time);
        Debug.Log("Time.frameCount / " + Time.frameCount);
        
	}
}
