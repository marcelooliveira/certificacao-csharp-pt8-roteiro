using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Listings
{
    class Listing4_06 //Stream exceptions
    {
        static void XMain(string[] args)
        {
            try
            {
                string conteudo = File.ReadAllText(path: "Arquivo.txt");
                Console.WriteLine(conteudo);
            }
            catch (FileNotFoundException notFoundEx)
            {
                // Arquivo não encontrado
                Console.WriteLine(notFoundEx.Message);
            }
            catch (Exception ex)
            {
                // Outras exceções
                Console.WriteLine(ex.Message);
            }
        }
    }
}
