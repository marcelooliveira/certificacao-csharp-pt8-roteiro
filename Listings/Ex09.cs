using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Listings
{
    class Ex09
    {
        private async void GetData(WebResponse response)
        {
            string urlText;
            var sr = new StreamReader(response.GetResponseStream());
            urlText = await sr.ReadToEndAsync();
        }
    }
}
