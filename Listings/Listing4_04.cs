using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Listings
{
    class Listing4_04 //Storing compressed files
    {
        static void XMain(string[] args)
        {
            using (FileStream fluxoArquivo = new FileStream("Texto.zip", FileMode.OpenOrCreate,
                FileAccess.Write))
            {
                using (GZipStream fluxoZip = new GZipStream(fluxoArquivo, CompressionMode.Compress))
                {
                    using (StreamWriter gravadorFluxo = new StreamWriter(fluxoZip))
                    {
                        gravadorFluxo.Write("Olá, Alura!");
                    }
                }
            }

            using (FileStream fluxoArquivo = new FileStream("Texto.zip", FileMode.Open, FileAccess.Read))
            {
                using (GZipStream fluxoZip = new GZipStream(fluxoArquivo, CompressionMode.Decompress))
                {
                    using (StreamReader leitorFluxo = new StreamReader(fluxoZip))
                    {
                        string mensagem = leitorFluxo.ReadToEnd();
                        Console.WriteLine("Texto lido: {0}", mensagem);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
