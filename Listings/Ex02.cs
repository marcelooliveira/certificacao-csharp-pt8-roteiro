using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Listings
{
    class Ex02
    {
        private string filename;

        public Ex02()
        {

        }

        void A()
        {
            var fs = File.ReadAllBytes(filename);
        }

        void B()
        {
            var fs = File.Open(filename, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
        }

        void C()
        {
            var fs = File.ReadAllLines(filename);
        }

        void D()
        {
            var fs = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        void E()
        {
            var fs = File.Open(filename, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Write);
        }
    }
}
