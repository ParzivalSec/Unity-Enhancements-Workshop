using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

/**
 * A list of available categories to log messages to
 * In a retail project we would read that from a config file
 *
 **/
public enum LogCategory
{
    GAMEPLAY,
    SYSTEM,
    NETWORKING,
    STATISTICS,
    ERROR,
    AUDIO,
    AI,
    WARNING,
    PHYSICS,
    GUI,
    INPUT
}

public sealed class HTMLLogger
{
    private string logFileDir = "C:\\LOGFILES_DOOM\\";
    private string m_logFile = "";
    private int traceCount = 0;
    private DateTime logFileDate;

    private static readonly HTMLLogger instance = new HTMLLogger();

    public static HTMLLogger Instance
    {
        get
        {
            return instance;
        }
    }

    public HTMLLogger()
    {
        logFileDate = DateTime.Now;
        m_logFile = logFileDir + logFileDate.ToString("yyyy-dd-MMMM_hh_mm") + "_log.html";
        WriteHTMLSkeleton();
        WriteButtonHeader();
    }

    public void Log(LogCategory category, string msg, string stackTrace)
    {
        // We use rotating log files to ensure one does not grow too big
        // Could also add a check for logfile size and more to be safe
        if (DateTime.Now >= logFileDate.AddHours(5)) {
            m_logFile = logFileDir + logFileDate.ToString("yyyy-dd-MMMM_hh-mm") + "_log.html";
        }

        string traceID = "trace" + traceCount;
        using (StreamWriter outputFile = new StreamWriter(m_logFile, true))
        {
            string logContainer = "<p class='{category}'> <span class='time'> {time} </span> <a onClick='hide(\"{traceID}\")'> STACK </a> {msg} </p>";
            logContainer = logContainer.Replace("{category}", category.ToString().ToLower());
            logContainer = logContainer.Replace("{time}", DateTime.Now.ToString());
            logContainer = logContainer.Replace("{traceID}", traceID);
            logContainer = logContainer.Replace("{msg}", msg);

            outputFile.WriteLine(logContainer);

            string stackTraceContainer = "<pre id='{traceID}'> {stackTrace} </pre>";
            stackTraceContainer = stackTraceContainer.Replace("{traceID}", traceID).Replace("{stackTrace}", stackTrace);

            outputFile.WriteLine(stackTraceContainer);
        }

        traceCount++;
    }

    private void WriteHTMLSkeleton()
    {
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

            outputFile.WriteLine(htmlHeader);
        }
    }

    private void WriteButtonHeader()
    {
        using (StreamWriter outputFile = new StreamWriter(m_logFile, true))
        {
            outputFile.WriteLine("<div class='Header'>");
            foreach (string category in Enum.GetNames(typeof(LogCategory)))
            {
                // In higher .NET versions (> 4.0) we could use string interpolation to replace the template parameters
                string button = "<input type='button' value='{category}' class='{category} Button' onClick='hide_class(\"{category}\")'>";
                button = button.Replace("{category}", category.ToLower());
                outputFile.WriteLine(button);
            }
            outputFile.WriteLine("</div>");
            outputFile.WriteLine("<h1> Playground of Doom - Logs - " + logFileDate.ToString() + " </h1>");
            outputFile.WriteLine("<p> Use the buttons above to toggle log categories. Expand stack-trace via Stack button </p>");
        }
    }
}
