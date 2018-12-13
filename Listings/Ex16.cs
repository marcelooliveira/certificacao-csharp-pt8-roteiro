using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Listings
{
    class Ex16
    {
        public Ex16()
        {
            using (StreamWriter writer = new StreamWriter(@"C:\console.txt"))
            { 
                Console.SetOut(writer);
                using (FileStream stream = new FileStream(@"C:\file.txt", FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        while (reader.EndOfStream) Console.WriteLine(reader.ReadLine());
                    }
                }
            }
        }
    }
}
