using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Listings
{
    class Listing4_07 //Drive information
    {
        static void XMain(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Nome:{0} ", drive.Name);
                if (drive.IsReady)
                {
                    Console.WriteLine(" Tipo:{0}", drive.DriveType);
                    Console.WriteLine(" Formato:{0}", drive.DriveFormat);
                    Console.WriteLine(" Espaço livre:{0}", drive.TotalFreeSpace);
                }
                else
                {
                    Console.Write(" Drive não está pronto");

                }
                Console.WriteLine();
            }
        }
    }
}
