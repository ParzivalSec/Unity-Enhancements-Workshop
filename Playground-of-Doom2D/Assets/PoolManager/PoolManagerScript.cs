using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManagerScript : MonoBehaviour {

    // Test Prefabs for creating and destroying objects with or without the use of the PoolManager.
    public GameObject spawnable;
    // The amount of particles to create and destroy each frame.
    public int particleCount = 1000;

    // List of all particles in the object pool.
    List<GameObject> particles = new List<GameObject>();
    // Information on whether the particle at a specific index is currently in use.
    List<bool> particlesReady = new List<bool>();

    // For efficiency, remember the last used index instead of counting from the start each time.
    int lastIndex = 0;

    // Enable/Disable the test program.
    bool start = false;
    // Enable/Disable the PoolManager usage.
    bool doPM = false;

    // Use this for initialization
    void Start () {
        // Create as many objects as you want to have in your object pool ONCE.
		for(int i = 0; i < particleCount; ++i)
        {
            GameObject obj = (GameObject)Instantiate(spawnable, new Vector3(0.0f, 0.0f, 0.0f), new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
            // Add them to the pool and set their state to ready.
            particles.Add(obj);
            particlesReady.Add(true);
            // Upon finishing object creatiion, deactivate the object so it isn't updated and rendered!
            obj.SetActive(false);
        }
	}

	// Update is called once per frame
	void Update () {
        // Use your mouse to control the program: LMB starts/stops the test program, RMB enables/disables the usage of the PoolManager.
        if (Input.GetMouseButtonDown(0))
        {
            start = !start;
        }
        if (Input.GetMouseButtonDown(1))
        {
            doPM = !doPM;
            if(doPM)
            {
                Debug.Log("Now using the PoolManager.");
            }
            else
            {
                Debug.Log("Now using Instantiate/Destroy.");
            }
        }
        // The test program creates a number of object each frame.
        // All objects will automatically disable themselves
        if(start)
        {
            if(doPM)
            {
                // "Create" as many objects as you have in your pool. They are not actually created but rather just activated, which is more efficient.
                for (int i = 0; i < particleCount; ++i)
                {
                    GameObject obj = ActivateParticle();
                }
                for (int i = 0; i < particleCount; ++i)
                {
                    DisableParticle(i);
                }
            }
            else
            {
                // Instantiate as many objects as the number of objects in the pool. For each object, memory is allocated.
                for (int i = 0; i < particleCount; ++i)
                {
                    GameObject obj = (GameObject)Instantiate(spawnable, new Vector3(0.0f, 0.0f, 0.0f), new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
                    Destroy(obj);
                }
            }
        }
    }
    
    // The function looks for the next free object in the pool and enables it.
    GameObject ActivateParticle()
    {
        GameObject obj = null;
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
            obj = particles[lastIndex];
            break;
        }
        return obj;
    }

    // This function disables the particle at the index and sets it ready to be used again.
    void DisableParticle(int index)
    {
        particlesReady[index] = true;
        particles[index].SetActive(false);
    }
}
