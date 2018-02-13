using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TestAppx
{
    public partial class TestAppx : ServiceBase
    {
        EventLog AppxAPILog;

        public TestAppx()
        {
            InitializeComponent();
            // Create an EventLog instance and assign its source.
            AppxAPILog = new EventLog();
            AppxAPILog.Source = "AppxAPI";
        }

        protected override void OnStart(string[] args)
        {
            AppxAPILog.WriteEntry("AppxApi Watcher Started");
            TestAppxTimer.Interval = 1000;//interval;
            TestAppxTimer.Enabled = true;
            TestAppxTimer.Start();
        }

        protected override void OnStop()
        {
            AppxAPILog.WriteEntry("AppxApi Watcher Stopped");
        }

        private void TestAppxTimer_Tick(object sender, EventArgs e)
        {
            AppxAPILog.WriteEntry("AppxApi Timer Ticked");
        }
    }
}
