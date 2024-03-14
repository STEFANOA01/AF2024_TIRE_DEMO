#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.OPCUAServer;
using FTOptix.RAEtherNetIP;
using FTOptix.Retentivity;
using FTOptix.CommunicationDriver;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.OmronEthernetIP;
using FTOptix.Alarm;
using FTOptix.OPCUAClient;
#endregion

public class ClockLogic : BaseNetLogic
{
	public override void Start()
	{
		periodicTask = new PeriodicTask(UpdateTime, 1000, LogicObject);
		periodicTask.Start();
	}

	public override void Stop()
	{
		periodicTask.Dispose();
		periodicTask = null;
	}

	private void UpdateTime()
	{
		LogicObject.GetVariable("Time").Value = DateTime.Now;
		LogicObject.GetVariable("UTCTime").Value = DateTime.UtcNow;
	}

	private PeriodicTask periodicTask;
}
