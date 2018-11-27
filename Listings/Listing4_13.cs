using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Listings
{
    class Listing4_13 //HttpWebRequest
    {
        static void XMain(string[] args)
        {
            WebRequest requisicao = WebRequest.Create("http://www.caelum.com.br");
            WebResponse resposta = requisicao.GetResponse();
            using (StreamReader leitorResposta =
                new StreamReader(resposta.GetResponseStream()))
            {
                string textoDoSite = leitorResposta.ReadToEnd();
                Console.WriteLine(textoDoSite);
            }
        }
    }
}