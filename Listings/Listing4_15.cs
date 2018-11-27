using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Listings
{
    class Listing4_15 //WebClient async
    {
        static async Task XMain(string[] args)
        {
            string textoDoSite = await LerPaginaWeb("http://www.caelum.com.br");
            Console.WriteLine(textoDoSite);
        }

        static async Task<string> LerPaginaWeb(string uri)
        {
            WebClient cliente = new WebClient();
            return await cliente.DownloadStringTaskAsync(uri);
        }
    }
}
