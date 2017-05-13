using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManagerScript : MonoBehaviour {

    public GameObject spawnablePM;
    public GameObject spawnableNoPM;
    public int particleCount = 1000;

    List<GameObject> particles = new List<GameObject>();
    List<bool> particlesReady = new List<bool>();

    int lastIndex = 0;

    bool start = false;
    bool doPM = false;

    // Use this for initialization
    void Start () {
		for(int i = 0; i < particleCount; ++i)
        {
            GameObject obj = (GameObject)Instantiate(spawnablePM, new Vector3(0.0f, 0.0f, 0.0f), new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
            particles.Add(obj);
            particles[i].SendMessage("SetIndex", i);
            particlesReady.Add(true);
            obj.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            start = !start;
        }
        if (Input.GetMouseButtonDown(1))
        {
            doPM = !doPM;
        }
        if(start)
        {
            if(doPM)
            {
                for (int i = 0; i < particleCount; ++i)
                {
                    ActivateParticle();
                }
            }
            else
            {
                GameObject obj;
                for (int i = 0; i < particleCount; ++i)
                {
                    obj = (GameObject)Instantiate(spawnableNoPM, new Vector3(0.0f, 0.0f, 0.0f), new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
                }
            }
        }
    }
    
    void ActivateParticle()
    {
        for (int i = 0; i < particleCount; ++i)
        {
            ++lastIndex;
            if (lastIndex >= particleCount)
            {
                lastIndex = 0;
            }
            if (!particlesReady[lastIndex]) { continue; }
            particlesReady[lastIndex] = false;
            particles[lastIndex].SetActive(true);
            break;
        }
    }

    void DisableParticle(int index)
    {
        particlesReady[index] = true;
        particles[index].SetActive(false);
    }
}
