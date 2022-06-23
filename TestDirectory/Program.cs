using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Text;
using System.Threading;

namespace TestDirectory
{
    class Program
    {
        static string dir1 = @"C:\Users\v.brazhnik\Pictures\Фасады ламината";
        static string dir2 = @"C:\Users\v.brazhnik\Pictures\Результаты2Фасадов";
        static void Main(string[] args)
        {

            ManagementObjectSearcher ramMonitor = 
                new ManagementObjectSearcher("SELECT TotalVisibleMemorySize,FreePhysicalMemory FROM Win32_OperatingSystem");

            while (true)
            {
                foreach (ManagementObject objram in ramMonitor.Get())
                {
                    ulong totalRam = Convert.ToUInt64(objram["TotalVisibleMemorySize"]);
                    ulong busyRam = totalRam - Convert.ToUInt64(objram["FreePhysicalMemory"]);
                    Console.WriteLine("{0} %",(busyRam * 100) / totalRam);
                }
                Thread.Sleep(500);
            }
            

            //string[] files = Directory.GetDirectories(dir2);

            //string s = "";
            //foreach (string file in files)
            //{
            //    DirectoryInfo di = new DirectoryInfo(file);
            //    s += di.Name + "\n";
            //}

            //File.WriteAllText("not3.txt", s);

            //foreach (string path in files)
            //{
            //    FileInfo fileinfo = new FileInfo(path);

            //    string nameNewCatalog = dir2 + "\\" + System.IO.Path.GetFileNameWithoutExtension(path);

            //    DirectoryInfo dirInfo = new DirectoryInfo(nameNewCatalog);

            //    if (!dirInfo.Exists)
            //    {
            //        dirInfo.Create();
            //    }

            //    if (fileinfo.Exists)
            //    {
            //        fileinfo.CopyTo(nameNewCatalog + $"\\{System.IO.Path.GetFileNameWithoutExtension(path)}.png", true);
            //    }

            //    string[] files2 = Directory.GetFiles(nameNewCatalog);

            //    foreach (string path2 in files2)
            //    {
            //        FileInfo fileinfo2 = new FileInfo(path2);
            //        fileinfo.CopyTo(fileinfo2.Directory.FullName + "\\" + "11.png");
            //        fileinfo.MoveTo(fileinfo2.Directory.FullName + "\\" + "22.png");
            //    }

            //    FileInfo fileInfo3 = new FileInfo(nameNewCatalog + $"\\{System.IO.Path.GetFileNameWithoutExtension(path)}.png");

            //    if (fileInfo3.Exists)
            //    {
            //        fileInfo3.Delete();
            //    }
            //}
        }
    }
}
