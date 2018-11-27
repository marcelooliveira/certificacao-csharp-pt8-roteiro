using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Listings
{
    class Listing4_26 // XML elements
    {
        static void XMain(string[] args)
        {
            string xmlDocument =
                "<Filme>" +
                    "<Diretor>Quentin Tarantino</Diretor>" +
                    "<Titulo>Pulp Fiction</Titulo>" +
                    "<Minutos>154</Minutos>" +
                "</Filme>";

            using (StringReader stringReader = new StringReader(xmlDocument))
            {
                XmlTextReader reader = new XmlTextReader(stringReader);
                while (reader.Read())
                {
                    string description = string.Format("Type: {0} Name: {1} Value: {2}",
                        reader.NodeType.ToString(), reader.Name, reader.Value);
                    Console.WriteLine(description);
                }
            }
        }
    }
}
