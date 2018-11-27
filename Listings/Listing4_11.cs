using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Listings
{
    class Listing4_11 //Using Path
    {
        static void XMain(string[] args)
        {
            string documentoDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nomeCompleto = documentoDir + "\\test.txt";

            string nomeDir = Path.GetDirectoryName(nomeCompleto);
            string nomeArquivo = Path.GetFileName(nomeCompleto);
            string extensao = Path.GetExtension(nomeCompleto);
            string extensaoXyz = Path.ChangeExtension(nomeCompleto, ".xyz");
            string novoTeste = Path.Combine(nomeDir, "novoTeste.txt");
            Console.WriteLine("Nome completo: {0}", nomeCompleto);
            Console.WriteLine("Diretorio: {0}", nomeDir);
            Console.WriteLine("Nome do arquivo: {0}", nomeArquivo);
            Console.WriteLine("Extensão do arquivo: {0}", extensao);
            Console.WriteLine("Arquivo com extensão xyz: {0}", extensaoXyz);
            Console.WriteLine("Novo teste: {0}", novoTeste);
        }
    }
}
