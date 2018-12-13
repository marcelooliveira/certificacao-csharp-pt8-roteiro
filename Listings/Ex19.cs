using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Listings
{
    class Ex19
    {
        public Ex19()
        {

        }

        string dataFileUri;
        string dataFileId;
        void A()
        {
            WebResponse response;
            StreamReader reader;
            WebRequest request = WebRequest.Create(dataFileUri);
            using (response = request.GetResponse())
            {
                reader = new StreamReader(response.GetResponseStream());
                response.Close();
            }
            using (StreamWriter writer = new StreamWriter(dataFileId + ".dat"))
            {
                writer.Write(reader.ReadToEnd());
            }
        }

        void B()
        {
            FileWebRequest request = FileWebRequest.Create(dataFileUri) as FileWebRequest;
            using (FileWebResponse response = request.GetResponse() as FileWebResponse)
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            using (StreamWriter writer = new StreamWriter(dataFileId + ".dat"))
            {
                writer.Write(reader.ReadToEnd());
            }
        }

        void C()
        {
            WebRequest request = WebRequest.Create(dataFileUri);
            using (WebResponse response = request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamWriter writer = new StreamWriter(responseStream);
                writer.Write(dataFileId + ".dat");
            }
        }

        void D()
        {
            WebRequest request = WebRequest.Create(dataFileUri);
            using (WebResponse response = request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            using (StreamWriter writer = new StreamWriter(dataFileId + ".dat"))
            {
                writer.Write(reader.ReadToEnd());
            }
        }
    }


}
