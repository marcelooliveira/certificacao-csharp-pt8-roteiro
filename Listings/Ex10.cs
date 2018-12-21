using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Listings
{
    class Ex10
    {
        public Ex10()
        {
            //using (FileStream fsSource = File.OpenRead(SourceFilePath))
            //using (FileStream fsHeader = File.OpenWrite(HeaderFilePath))
            //using (FileStream fsBody = File.OpenWrite(BodyFilePath))

            using (FileStream fsSource = File.OpenRead(SourceFilePath))
            using (FileStream fsHeader = File.OpenWrite(HeaderFilePath))
            using (FileStream fsBody = File.OpenWrite(BodyFilePath))
            {
                byte[] header = new byte[20];
                byte[] body = new byte[fsSource.Length - 20];

                fsSource.Read(header, 0, header.Length);
                fsHeader.Write(header, 0, body.Length);

                fsSource.Read(body, 0, body.Length);
                fsBody.Write(body, 0, body.Length);
            }
        }

        public string SourceFilePath { get; }
        public string HeaderFilePath { get; }
        public string BodyFilePath { get; }
    }
}
