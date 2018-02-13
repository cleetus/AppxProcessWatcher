using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;

namespace TestAPIWatcher
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            Process[] p = System.Diagnostics.Process.GetProcessesByName(ConfigurationManager.AppSettings.Get("process_name")); //.GetProcesses();//

            foreach (Process x in p)
            {
                try
                {
                    Console.WriteLine("Start Time:  {0}, Process:  {1}, Memory: {2}, Is Responding: {3}", x.StartTime, x.ProcessName, x.PagedMemorySize64, x.Responding);
                    Double min_age = Double.Parse(ConfigurationManager.AppSettings.Get("kill_process_age_minutes"));
                    if (x.StartTime < DateTime.Now.AddMinutes(min_age))
                    {
                        Console.WriteLine("\n-----------\nKilling this process:  Start Time:  {0}, Process:  {1}, Memory: {2}, Is Responding: {3}\n--------------\n", x.StartTime, x.ProcessName, x.PagedMemorySize64, x.Responding);
                        x.Kill();
                        System.Threading.Thread.Sleep(2000);
                    }//Console.Read();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            //Process[] runingProcess = Process.GetProcesses();
            //System.Management.ManagementObjectCollection moReturn;
            //ManagementObjectSearcher moSearch;
            //moReturn.Cast<ManagementBaseObject>().ToList().ForEach(mo => Process.GetProcessesByName(mo["Name"].ToString()).ToList().ForEach(proc => proc.Kill()));

            Console.Read();

        }
    }
}
