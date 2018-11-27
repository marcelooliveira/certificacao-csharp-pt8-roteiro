using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Listings
{
    class Listing4_05 //The File class
    {
        static void XMain(string[] args)
        {
            File.WriteAllText(path: "Arquivo.txt", contents: "Conteúdo inicial do arquivo");
            File.AppendAllText(path: "Arquivo.txt", contents: "- conteúdo adicionado depois");

            if (File.Exists("Arquivo.txt"))
                Console.WriteLine("Arquivo já existe");

            string conteudo = File.ReadAllText(path: "Arquivo.txt");

            Console.WriteLine("Conteúdo do arquivo: {0}", conteudo);
            File.Copy(sourceFileName: "Arquivo.txt", destFileName: "CopiaArquivo.txt");

            using (TextReader leitor = File.OpenText(path: "CopiaArquivo.txt"))
            {
                string texto = leitor.ReadToEnd();
                Console.WriteLine("Texto copiado: {0}", texto);
            }

            Console.ReadKey();
        }
    }
}
