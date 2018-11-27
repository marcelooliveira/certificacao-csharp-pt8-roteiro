using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Listings
{
    class Listing4_27 //XML DOM
    {
        static void XMain(string[] args)
        {
            string xmlDocument =
                "<Filme>" +
                    "<Diretor>Quentin Tarantino</Diretor>" +
                    "<Titulo>Pulp Fiction</Titulo>" +
                    "<Minutos>154</Minutos>" +
                "</Filme>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlDocument);

            var rootElement = doc.DocumentElement;

            // garantindo que é um elemento válido
            if (rootElement.Name != "Filme")
            {
                Console.WriteLine("Não é um filme!");
            }
            else
            {
                string diretor = rootElement["Diretor"].FirstChild.Value;
                Console.WriteLine("", diretor);
                string titulo = rootElement["Titulo"].FirstChild.Value;
                Console.WriteLine("Diretor: {0} \r\nTitulo: {1}", diretor, titulo);
            }
        }
    }
}
