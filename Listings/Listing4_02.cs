using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Listings
{
    class Listing4_02 //FileStream and IDisposable
    {
        static void XMain()
        {
            // Gravando no arquivo

            //FileStream fluxoSaida = new FileStream("ArquivoSaida.txt",
            //    FileMode.OpenOrCreate, FileAccess.Write);
            //string mensagemSaida = "Olá, Alura!";

            //var bytesMensagemSaida = Encoding.UTF8.GetBytes(mensagemSaida);
            //fluxoSaida.Write(bytesMensagemSaida, 0, bytesMensagemSaida.Length);
            //fluxoSaida.Close();

            using (FileStream fluxoSaida = new FileStream("ArquivoSaida.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                string mensagemSaida = "Olá, Alura!";
                byte[] bytesMensagemSaida = Encoding.UTF8.GetBytes(mensagemSaida);
                fluxoSaida.Write(bytesMensagemSaida, 0, bytesMensagemSaida.Length);
            }

            FileStream fluxoEntrada = new FileStream("ArquivoSaida.txt", FileMode.Open, FileAccess.Read);

            long tamanhoArquivo = fluxoEntrada.Length;
            var bytesLidos = new byte[tamanhoArquivo];
            fluxoEntrada.Read(bytesLidos, 0, (int)tamanhoArquivo);
            string texto = Encoding.UTF8.GetString(bytesLidos);
            fluxoEntrada.Close();
            Console.WriteLine("Mensagem lida: {0}", texto);

            Console.ReadKey();

        }
    }
}