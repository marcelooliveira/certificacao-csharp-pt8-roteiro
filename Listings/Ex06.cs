using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Listings
{
    class Ex06
    {
        void Metodo()
        {
            using (StreamReader sr = new StreamReader("log.txt"))
            {
                try
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.Write(e.ToString());
                    throw;
                }
            }
        }
    }
}
