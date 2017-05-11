using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIMethods : MonoBehaviour {
    private List<string> m_possibleErrors;
    private System.Random m_errorRnd;

    // Use this for initialization
    void Start () {
        m_possibleErrors = new List<string>();
        m_possibleErrors.Add("Out of memory !");
        m_possibleErrors.Add("DB connection lost!");
        m_possibleErrors.Add("NullPointerException - Did you forget to add a reference ?");
        m_possibleErrors.Add("Request timed out - retry in 500 seconds ...");

        m_errorRnd = new System.Random();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.AddComponent<Rigidbody>();

        sphere.transform.position = new Vector3(0, 10, 0);

        HTMLLogger.Instance.Log(LogCategory.GUI, "Sphere was spawned!", "");
    }

    public void TriggerError() {
        int random = m_errorRnd.Next(0, 3);

        string errorMsg = m_possibleErrors[random];

        // Get a stack-trace in .NET without a thrown excpetion - be careful, this operation is slow !
        // Don't use for stuff that get logged every frame !!!
        System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
        HTMLLogger.Instance.Log(LogCategory.ERROR, errorMsg, stackTrace.ToString());
    }
}
