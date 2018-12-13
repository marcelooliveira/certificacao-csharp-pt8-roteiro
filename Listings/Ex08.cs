using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Listings
{
    class Ex08
    {
        public Task<byte[]> SendMessage(string url, int intA, int intB)
        {
            var client = new WebClient();
            //var nvc = new NameValueCollection { { "a", intA.ToString() }, { "b", intB.ToString() } };
            //return client.UploadValuesTaskAsync(new Uri(url), nvc);

            //var data = string.Format("a={0}&b={1}", intA, intB);
            //return client.UploadDataTaskAsync(new Uri(url), Encoding.UTF8.GetBytes(data));

            //var data = string.Format("a={0}&b={1}", intA, intB);
            //return client.UploadFileTaskAsync(new Uri(url), data);

            //var data = string.Format("a={0}&b={1}", intA, intB);
            //return client.UploadStringTaskAsync(new Uri(url), data);

            throw new NotImplementedException();
        }
    }
}
