using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Listings
{
    class Listing4_16 //HttpClient
    {
        static async Task XMain(string[] args)
        {
            try
            {
                string textoWeb = await LerPaginaWeb("http://www.caelum.com.br");
                Console.WriteLine(textoWeb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Requisição falhou");
            }
        }

        static async Task<string> LerPaginaWeb(string uri)
        {
            HttpClient cliente = new HttpClient();
            return await cliente.GetStringAsync(uri);
        }
    }
}
