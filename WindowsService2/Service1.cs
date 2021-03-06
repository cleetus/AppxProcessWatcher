﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AppxProcessWatcherService
{
    public partial class Service1 : ServiceBase
    {
        public System.Threading.Timer AppxTimer;
        EventLog AppxAPILog;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (!EventLog.SourceExists("AppxAPI"))
            {
                //An event log source should not be created and immediately used.
                //There is a latency time to enable the source, it should be created
                //prior to executing the application that uses the source.
                //Execute this sample a second time to use the new source.
                EventLog.CreateEventSource("AppxAPI", "AppxAPILog");
                // The source is created.  Exit the application to allow it to be registered.
                //return;
            }

            // Create an EventLog instance and assign its source.
            AppxAPILog = new EventLog();
            AppxAPILog.Source = "AppxAPI";

            try
            {


                // Write an informational entry to the event log.    
                AppxAPILog.WriteEntry("AppxApi Watcher Started");
                //int interval = 10000;//Default
                //int.TryParse(System.Configuration.ConfigurationManager.AppSettings.Get("timer_interval"), out interval);//60000;
                TimeSpan tsInterval = new TimeSpan(0, 0, 3);
                AppxTimer = new System.Threading.Timer(new System.Threading.TimerCallback(AppxTimer_Elapsed), null, tsInterval, tsInterval);

            }
            catch (Exception ex)
            {
                AppxAPILog.WriteEntry(ex.Message);
            }

        }

        private void AppxTimer_Elapsed(object state)
        {
            throw new NotImplementedException();
        }

        protected override void OnStop()
        {
            AppxTimer.Dispose();
            AppxAPILog.WriteEntry("AppxApi Watcher Stopped");
        }

        public void AppxTimer_Elasped(object sender)
        {
            AppxAPILog.WriteEntry("AppxApi - Checking for processes");
            /*
            Process[] p = null;
            string process_name = "appxapi";

            try
            {
                AppxAPILog.WriteEntry("AppxApi - Checking for processes");          
                process_name = System.Configuration.ConfigurationManager.AppSettings.Get("process_name");
                p = System.Diagnostics.Process.GetProcessesByName(process_name);
            } catch(Exception ex)
            {
                AppxAPILog.WriteEntry(ex.Message);
            }

            foreach (Process x in p)
            {
                try
                {
                    AppxAPILog.WriteEntry(String.Format("Process:  {0}, Memory: {1}, Is Responding: {2}", x.ProcessName, x.PagedMemorySize64, x.Responding));
                    //Console.Read();
                    int kill_process_age_minutes = -20;
                    int.TryParse(System.Configuration.ConfigurationManager.AppSettings.Get("timer_interval"), out kill_process_age_minutes);
                    if (x.StartTime < DateTime.Now.AddMinutes(kill_process_age_minutes))
                    {
                        AppxAPILog.WriteEntry(String.Format("Killing this process:  Start Time:  {0}, Process:  {1}, Memory: {2}, Is Responding: {3}, PID: {4}", x.StartTime, x.ProcessName, x.PagedMemorySize64, x.Responding, x.Id));
                        x.Kill();
                        //System.Threading.Thread.Sleep(2000);
                    }//Console.Read();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.ToString());
                    AppxAPILog.WriteEntry(ex.Message);
                }
            }
            */
        }

    }
}

