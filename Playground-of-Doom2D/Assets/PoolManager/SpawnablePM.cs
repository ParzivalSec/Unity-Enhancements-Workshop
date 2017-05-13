using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnablePM : MonoBehaviour {

    GameObject pm;
    int index;

    // Use this for initialization
    void Start ()
    {
        pm = GameObject.Find("PoolManager");
    }
	
	// Update is called once per frame
	void Update ()
    {
        pm.SendMessage("DisableParticle", index);
    }

    void SetIndex(int i)
    {
        index = i;
    }
}
