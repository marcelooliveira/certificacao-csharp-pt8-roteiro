using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace Listings
{
    class Listing4_28 //Web Service
    {
        static void Main(string[] args)
        {
            using (MeuServicoClient servicoClient = new MeuServicoClient())
            {
                Console.WriteLine(servicoClient.GetValor(1));
            }
            Console.ReadKey();
        }
    }

    [ServiceContract]
    public interface IMeuServico
    {
        [OperationContract]
        string GetValor(int chave);
    }

    internal class MeuServicoClient : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        internal bool GetValor(int v)
        {
            throw new NotImplementedException();
        }
    }

    public class MeuServico : IMeuServico
    {
        public string GetValor(int chave)
        {
            string resultado = "chave inválida";
            switch (chave)
            {
                case 0:
                    resultado = "Resultado 1";
                    break;
                case 1:
                    resultado = "Resultado 2";
                    break;
                case 2:
                    resultado = "Resultado 3";
                    break;
            }
            return resultado;
        }
    }
}
