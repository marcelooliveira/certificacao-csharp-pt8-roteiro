using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Listings
{
    class Listing4_09 //The Directory class
    {
        static void XMain(string[] args)
        {
            Directory.CreateDirectory("NovoDiretorio");
            if (Directory.Exists("NovoDiretorio"))
                Console.WriteLine("Diretório criado com sucesso");

            Directory.Delete("NovoDiretorio");

            Console.WriteLine("Diretório removido com sucesso");
        }
    }
}
