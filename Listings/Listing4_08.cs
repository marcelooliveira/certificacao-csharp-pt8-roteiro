using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Listings
{
    class Listing4_08 //Using FileInfo
    {
        static void XMain(string[] args)
        {
            string filePath = "Arquivo.txt";
            File.WriteAllText(path: filePath, contents: "Texto inicial do arquivo");
            FileInfo info = new FileInfo(filePath);
            Console.WriteLine("Nome {0}", info.Name);
            Console.WriteLine("Caminho completo: {0}", info.FullName);
            Console.WriteLine("Último acesso: {0}", info.LastAccessTime);
            Console.WriteLine("Tamanho: {0}", info.Length);
            Console.WriteLine("Atributos: {0}", info.Attributes);
            Console.WriteLine("Tornar o arquivo somente-leitura");
            info.Attributes |= FileAttributes.ReadOnly;
            Console.WriteLine("Atributos: {0}", info.Attributes);
            Console.WriteLine("Remover o arquivo somente-leitura");
            info.Attributes &= ~FileAttributes.ReadOnly;
            Console.WriteLine("Atributos: {0}", info.Attributes);
        }
    }
}
