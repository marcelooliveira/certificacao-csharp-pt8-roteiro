using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Listings
{
    class Listing4_10 //The Directorylnfo class
    {
        static void XMain(string[] args)
        {
            DirectoryInfo localDir = new DirectoryInfo("NovoDiretorio");
            localDir.Create();
            if (localDir.Exists)
                Console.WriteLine("Diretório criado com sucesso");
            localDir.Delete();
            Console.WriteLine("Diretório removido com sucesso");
        }
    }
}
