using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Listings
{
    class Ex11
    {
        public Ex11()
        {

        }

        public void ViewMetadata(string filePath)
        {
            var bytes = File.ReadAllBytes(filePath);

            //. . .
        }
    }
}
