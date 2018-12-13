using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Listings
{
    class Ex05
    {
        private string text;
        private async void GetDataAsync(WebResponse response)
        {
            var streamReader = new StreamReader(response.GetResponseStream());
            text = await streamReader.ReadLineAsync();
        }
    }
}
