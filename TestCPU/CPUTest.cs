using System;
using System.Management;
using System.Threading;

namespace TestCPU
{
    public class CPUTest
    {
        public static void GetLoadProcentage()
        {
            ManagementObjectSearcher cpuMonitor =
                new ManagementObjectSearcher("SELECT LoadPercentage  FROM Win32_Processor");

            while (true)
            {
                foreach (ManagementObject objcpu in cpuMonitor.Get())
                {
                    var percent = Convert.ToSingle(objcpu["LoadPercentage"]);

                    Console.Clear();
                    Console.WriteLine($"percent: {percent} {percent.GetType()}");

                }
                Thread.Sleep(100);
            }
        }

        public static void GetSerialNaumberCPU()
        {
            string id = string.Empty;

            ManagementClass managementClass = new ManagementClass("Win32_Processor");

            ManagementObjectCollection cpuMonitor = managementClass.GetInstances();

            foreach (ManagementObject mo in cpuMonitor)
            {

                id = mo.Properties["processorID"].Value.ToString();
                break;
            }

            Console.WriteLine(id);
        }
    }
}
