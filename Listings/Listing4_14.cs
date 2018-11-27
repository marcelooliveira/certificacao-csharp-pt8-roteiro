using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Listings
{
    class Listing4_14 //WebClient
    {
        static void XMain(string[] args)
        {
            WebClient cliente = new WebClient();
            string textoDoSite = cliente.DownloadString("http://www.caelum.com.br");
            Console.WriteLine(textoDoSite);
        }
    }
}
