#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.WebUI;
using FTOptix.CoreBase;
using FTOptix.Alarm;
using FTOptix.DataLogger;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.ODBCStore;
using FTOptix.RAEtherNetIP;
using FTOptix.Retentivity;
using FTOptix.CommunicationDriver;
using FTOptix.Core;
using FTOptix.OPCUAClient;
using FTOptix.OPCUAServer;
#endregion

[CustomBehavior]
public class MotorWithBehaviorTypeBehavior : BaseNetBehavior
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined behavior is started
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined behavior is stopped
    }

    [ExportMethod]
    public void StartMotor()
    {
        Node.Running = true;
        Node.CurSpeed = Node.SetSpeed;
    }
    [ExportMethod]
    public void StopMotor()
    {
        Node.Running = false;
        Node.CurSpeed = (Int32)0;
    }
    #region Auto-generated code, do not edit!
    protected new MotorWithBehaviorType Node => (MotorWithBehaviorType)base.Node;
#endregion
}
