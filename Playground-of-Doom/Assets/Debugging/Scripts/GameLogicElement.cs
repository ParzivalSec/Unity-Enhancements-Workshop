using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicElement : MonoBehaviour {

    private HTMLLogger m_logger;

	// Use this for initialization
	void Start () {
        m_logger = new HTMLLogger("log.html");

        m_logger.Info(LogCategory.SYSTEM, "Out of Memory!");
        m_logger.Info(LogCategory.NETWORKING, "DB connection lost");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
