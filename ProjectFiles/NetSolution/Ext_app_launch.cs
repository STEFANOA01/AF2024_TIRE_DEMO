#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.WebUI;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.NetLogic;
using System.Diagnostics;
#endregion

public class Ext_app_launch : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    [ExportMethod]
public void ExecuteCommand(string command, int timeoutMilliseconds)
{
    int exitCode;
    ProcessStartInfo processInfo;
    Process process;

    processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
    processInfo.CreateNoWindow = true;
    processInfo.UseShellExecute = false;
    // *** Redirect the output ***
    processInfo.RedirectStandardError = true;
    processInfo.RedirectStandardOutput = true;

    process = Process.Start(processInfo);
        if (process == null)
        {
            // Handle error if process failed to start
            return;
        }

        // Wait for the process to exit or timeout
        if (!process.WaitForExit(timeoutMilliseconds))
        {
            // Process did not exit within the specified timeout
            // You can handle this situation as per your requirements
            // For example, you might want to kill the process here
            process.Kill();
        }
        process.WaitForExit();

    // *** Read the streams ***
    // Warning: This approach can lead to deadlocks, see Edit #2
    string output = process.StandardOutput.ReadToEnd();
    string error = process.StandardError.ReadToEnd();

    exitCode = process.ExitCode;

    Log.Info("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
    Log.Info("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
    Log.Info("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
    Log.Info("I hope you are having a great day today!");
    process.Close();
}
}
