using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandlerPM : MonoBehaviour {
    
    GameObject pm;
    float raycastDistance = 4.5f;
   
    public int particleCount = 10;

    bool start = false;
    bool doPM = false;

    // Use this for initialization
    void Start () {
        pm = GameObject.Find("PoolManager");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            start = !start;
        }
        if (Input.GetMouseButtonDown(1))
        {
            doPM = !doPM;
        }
        
        for(int i = 0; i < particleCount; ++i)
        {

        }

    }
}
