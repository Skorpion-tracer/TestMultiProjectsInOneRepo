using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Timers;

namespace CPUTaskManager
{
    public class CPUTask
    {
        protected static PerformanceCounter cpuCounter;
        static List<PerformanceCounter> cpuCounters = new List<PerformanceCounter>();
        static int cores = 0;
        public static void Run()
        {
            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
            {
                cores = cores + int.Parse(item["NumberOfCores"].ToString());
            }

            int procCount = System.Environment.ProcessorCount;
            for (int i = 0; i < procCount; i++)
            {
                System.Diagnostics.PerformanceCounter pc = new System.Diagnostics.PerformanceCounter("Processor", "% Processor Time", i.ToString());
                cpuCounters.Add(pc);
            }

            //Thread c = new Thread(ConsumeCPU);
            //c.IsBackground = true;
            //c.Start();

            try
            {
                System.Timers.Timer t = new System.Timers.Timer(500);
                t.Elapsed += new ElapsedEventHandler(TimerElapsed);
                t.Start();
                Thread.Sleep(10000);
            }
            catch (Exception e)
            {
                Console.WriteLine("catched exception");
            }
            Console.ReadLine();

        }

        public static void ConsumeCPU()
        {
            int percentage = 60;
            if (percentage < 0 || percentage > 100)
                throw new ArgumentException("percentage");
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                // Make the loop go on for "percentage" milliseconds then sleep the 
                // remaining percentage milliseconds. So 40% utilization means work 40ms and sleep 60ms
                if (watch.ElapsedMilliseconds > percentage)
                {
                    Thread.Sleep(100 - percentage);
                    watch.Reset();
                    watch.Start();
                }
            }
        }

        public static void TimerElapsed(object source, ElapsedEventArgs e)
        {
            float cpu = cpuCounter.NextValue();
            float sum = 0;
            foreach (PerformanceCounter c in cpuCounters)
            {
                sum = sum + c.NextValue();
            }
            sum = sum / (cores);
            Console.WriteLine(string.Format("CPU Value 1: {0:F2}, cpu value 2: {1}", sum, cpu));
        }

    }
}
