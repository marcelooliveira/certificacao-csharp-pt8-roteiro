using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Listings
{
    class Ex12
    {
        public Ex12()
        {
            void A()
            {
                string inputLine;
                using (StreamReader reader = new StreamReader("data.txt"))
                {
                    while ((inputLine = reader.ReadLine()) != null)
                        Console.WriteLine(inputLine);
                }
            }

            void B()
            {
                string inputLine;
                StreamReader reader = null;
                using (reader = new StreamReader("data.txt"))
                    while ((inputLine = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(inputLine);
                    }
            }

            void C()
            {
                string inputLine;
                StreamReader reader = new StreamReader("data.txt");
                while ((inputLine = reader.ReadLine()) != null)
                {
                    Console.WriteLine(inputLine);
                }
            }

            void D()
            {
                string inputLine;
                StreamReader reader = null;
                try
                {
                    reader = new StreamReader("data.txt");
                    while ((inputLine = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(inputLine);
                    }
                    reader.Close();
                    reader.Dispose();
                }
                finally
                {
                }

            }
        }
    }
}
