using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicElement : MonoBehaviour {

    private HTMLLogger m_logger;

	// Use this for initialization
	void Start () {

        // Get a stack-trace in .NET without a thrown excpetion - be careful, this operation is slow !
        // Don't use for stuff that get logged every frame !!!
        System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace(true);
        HTMLLogger.Instance.Log(LogCategory.GAMEPLAY, "GameLogicElement started up!", t.ToString());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
