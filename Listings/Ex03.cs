using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Listings
{
    class Ex03
    {
        //[DataContract(Namespace = "http://www.contoso.com/2012/06")]
        //[DataMember(Order = 10)]
        //[DataMember]
        //[DataContract(Name = "http://www.contoso.com/2012/06")]
        //[DataMember(Name = "http://www.contoso.com/2012/06", Order = 10)]
        //[DataContract]
        //[DataMember(Name = "http://www.contoso.com/2012/06")]
        class Name
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
