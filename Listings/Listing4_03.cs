using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Listings
{
    class Listing4_03 //StreamWriter and StreamReader
    {
        static void XMain(string[] args)
        {
            using (StreamWriter fluxoGravacao = new StreamWriter("ArquivoSaida.txt"))
            {
                fluxoGravacao.Write("Olá, Alura!");
            }

            using (StreamReader fluxoLeitura = new StreamReader("ArquivoSaida.txt"))
            {
                string texto = fluxoLeitura.ReadToEnd();
                Console.WriteLine("Texto lido: {0}", texto);
            }
            Console.ReadKey();
        }
    }
}
