using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableScript : MonoBehaviour {

    public bool log = false;
    // TTL means time to live -> a counter after which the object destroys itself.
    public bool useTTL = false;
    float ttl = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(useTTL)
        {
            ttl -= Time.deltaTime;
            if (ttl < 0)
                Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(log)
            Debug.Log(name + " collided.");
    }
}
