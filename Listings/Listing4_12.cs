using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Listings
{
    class Listing4_12 //Csharp programs
    {
        static void XMain(string[] args)
        {
            DirectoryInfo diretorioInicio = new DirectoryInfo(@"..\..\..\..");

            string padraoBusca = "*.cs";
            EncontrarArquivos(diretorioInicio, padraoBusca);
            Console.ReadKey();
        }

        static void EncontrarArquivos(DirectoryInfo dir, string padraoBusca)
        {
            foreach (DirectoryInfo diretorio in dir.GetDirectories())
            {
                EncontrarArquivos(diretorio, padraoBusca);
            }

            FileInfo[] arquivosEncontrados = dir.GetFiles(padraoBusca);
            foreach (FileInfo fileInfo in arquivosEncontrados)
            {
                Console.WriteLine(fileInfo.FullName);
            }
        }

    }
}
