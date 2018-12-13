using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Listings
{
    class Ex15
    {
        public Ex15()
        {

        }
    }

    [DataContract()]
    public class Order
    {
        [DataMember()]
        public Int32 OrderID { get; set; }

        [DataMember(Name = "Customer")]
        public String CustomerName { get; set; }

        [DataMember()]
        private Int32 CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
