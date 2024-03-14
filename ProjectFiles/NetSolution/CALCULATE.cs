#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.DataLogger;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.SQLiteStore;
using FTOptix.RAEtherNetIP;
using FTOptix.Store;
using FTOptix.Report;
using FTOptix.Retentivity;
using FTOptix.NetLogic;
using FTOptix.CommunicationDriver;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.S7TCP;
using FTOptix.WebUI;
using FTOptix.Alarm;
using FTOptix.EventLogger;
using FTOptix.ODBCStore;
using FTOptix.Modbus;
using FTOptix.OPCUAServer;
using FTOptix.OPCUAClient;
#endregion

public class CALCULATE : BaseNetLogic

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
    public void Sum()
    {
        var addend1 = (Int32)Project.Current.GetVariable("Model/Variables/Variable1").Value;
        var addend2 = (Int32)Project.Current.GetVariable("Model/Variables/Variable2").Value;
        Project.Current.GetVariable("Model/Variables/Variable3").Value = addend1 + addend2;
    }


}
