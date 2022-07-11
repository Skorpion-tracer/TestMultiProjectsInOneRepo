using CPUTaskManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Timers;
using TestCPU;

namespace TestDirectory
{
    class Program
    {
        //static string dir1 = @"C:\Users\v.brazhnik\Pictures\Фасады ламината";
        //static string dir2 = @"C:\Users\v.brazhnik\Pictures\Результаты2Фасадов";

        static int[] array = new int[200];

        static void Main(string[] args)
        {

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

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
