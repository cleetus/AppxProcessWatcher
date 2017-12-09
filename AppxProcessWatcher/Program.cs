using System;
using System.Diagnostics;

namespace AppxProcessWatcher
{
    class Program
    {

        //System.Windows.Form.Timer
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Process[] p = System.Diagnostics.Process.GetProcessesByName("node"); //.GetProcesses();//
            
            foreach( Process x in p )
            {
                try
                {
                    Console.WriteLine("Start Time:  {0}, Process:  {1}, Memory: {2}, Is Responding: {3}", x.StartTime, x.ProcessName, x.PagedMemorySize64, x.Responding);
                    if (x.StartTime < DateTime.Now.AddMinutes(-940)) {
                        Console.WriteLine("\n-----------\nKilling this process:  Start Time:  {0}, Process:  {1}, Memory: {2}, Is Responding: {3}\n--------------\n", x.StartTime, x.ProcessName, x.PagedMemorySize64, x.Responding);
                        x.Kill();
                        System.Threading.Thread.Sleep(2000);
                    }//Console.Read();
                } catch(Exception ex) {
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
