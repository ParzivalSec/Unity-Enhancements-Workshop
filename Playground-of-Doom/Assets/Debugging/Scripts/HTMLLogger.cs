using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;

public enum LogCategory
{
    GAMEPLAY,
    SYSTEM,
    NETWORKING,
    STATISTICS,
}

public class HTMLLogger : MonoBehaviour
{
    private string m_logFile = "";

    public HTMLLogger(string logFile) {
        m_logFile = Application.dataPath + "/" + logFile;
        Debug.Log(m_logFile);
        WriteHTMLHeader();
    }

    public void Info(LogCategory category, string msg) {
        using (StreamWriter outputFile = new StreamWriter(m_logFile, true))
        {
            string logContainer = "<p class=" + category.ToString().ToLower() + "> " + msg + "</p>";

            outputFile.Write(logContainer);
        }
    }

    public void Warning(LogCategory category, string msg) {
    }

    public void Error(LogCategory category, string msg) {
    }

    private void WriteHTMLHeader() {
        // Write the string array to a new file named "WriteLines.txt".
        using (StreamWriter outputFile = new StreamWriter(m_logFile))
        {
            string htmlHeader =
                "<html>" +
                    "<head>" +
                        "<script language='javascript' src='log.js'></script>" +
                        "<link rel='stylesheet' href='log.css' />" +
                    "</head>" +
                    "<body>";

            outputFile.Write(htmlHeader);
        }
    }
}
