using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Listings
{
    class Ex04
    {
        public enum Compass
        {
            North,
            South,
            East,
            West
        }
        [DataContract]
        public class Location
        {
            [DataMember]
            public string Label { get; set; }
            [DataMember]
            public Compass Direction { get; set; }
        }

        void DoWork()
        {
            var location = new Location { Label = "Test", Direction = Compass.West };
            Console.WriteLine(WriteObject(location,
                new DataContractJsonSerializer(typeof(Location))

            ));
        }

        private bool WriteObject(Location location, DataContractJsonSerializer dataContractJsonSerializer)
        {
            DataContractJsonSerializer x

            throw new NotImplementedException();
        }
    }
}
