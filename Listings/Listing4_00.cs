using System;
using System.IO;
using System.IO.Pipes;
using System.Net.Sockets;
using System.Text;

namespace Listings
{
    class Listing4_00 //Streams
    {
        static void XMain(string[] args)
        {
            FileStream fluxoArquivo = 
                new FileStream("Diretores.txt", FileMode.Open, FileAccess.Read);

            byte[] bytes = new byte[10];
            int posicao = 0;
            int tamanho = 10;
            fluxoArquivo.Read(bytes, posicao, tamanho);

            //as duas linhas abaixo foram inseridas agora
            fluxoArquivo.Seek(5, SeekOrigin.Current);
            fluxoArquivo.Read(bytes, posicao, tamanho);

            foreach (var caractere in bytes)
            {
                //Console.Write(caractere);
                Console.Write((char)caractere);
            }

            Console.ReadKey();

            Stream s1;
            BufferedStream s2;
            FileStream s3;
            MemoryStream s4;
            PipeStream s5;
            NetworkStream s6;

        }
    }
}