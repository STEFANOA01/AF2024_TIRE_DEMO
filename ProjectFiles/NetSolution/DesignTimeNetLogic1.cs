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
using FTOptix.AuditSigning;
using FTOptix.OPCUAClient;
#endregion

public class DesignTimeNetLogic1 : BaseNetLogic
{
    [ExportMethod]
    public void Method1()
    {
        var myFolder = Project.Current.Get<Folder>("Model/Variables");
        if (myFolder != null)
        {
            myFolder.Delete();
        }
        myFolder = InformationModel.Make<Folder>("Variables");
        Project.Current.Get("Model").Add(myFolder);
        for (int i = 1; i <= 10; i++)
        {
            var myVar = InformationModel.MakeVariable("Variable" + i, OpcUa.DataTypes.UInt16);
            myFolder.Add(myVar);
        }
    }
}
