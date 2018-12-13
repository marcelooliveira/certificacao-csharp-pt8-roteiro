using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Listings
{
    class Ex13
    {
        public Ex13()
        {
            //A.
            void A()
            {
                WebRequest request = HttpWebRequest.Create("http://server1/image1.jpg");
                StreamWriter writer = new StreamWriter(request.GetResponse().GetResponseStream());
                writer.WriteLine("C:\\file1.jpg");
                writer.Dispose();
            }
            //B.
            void B()
            {
                WebClient client = new WebClient();
                StreamWriter writer = new StreamWriter("C:\\file1.jpg");
                writer.Write(client.DownloadData("http://server1/image1.jpg"));
                writer.Dispose();
                client.Dispose();
            }
            //C.
            void C()
            {
                WebClient client = new WebClient();
                client.DownloadFile("http://server1/image1.jpg", "C:\\file1.jpg");
                client.Dispose();
            }
            ////D.
            void D()
            {
                WebRequest request = HttpWebRequest.Create("http://server1/image1.jpg");
                StreamWriter writer = new StreamWriter(request.GetResponse().GetResponseStream());
                writer.Write("C:\\file1.jpg");
                writer.Dispose();
            }
        }
    }
}
