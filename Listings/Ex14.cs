using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace Listings
{
    class Ex14
    {
        public Ex14()
        {
        }

        void A()
        {
            WebClient client = new WebClient();
            byte[] employeeData = client.DownloadData("http://localhost:2588/EmployeeService.svc/GetEmployee/1");

            using (Stream stream = new MemoryStream(employeeData))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
                Employee retrievedEmployee = xmlSerializer.Deserialize(stream) as Employee;
            }
        }

        void B()
        {
            WebClient client = new WebClient();
            byte[] employeeData = client.DownloadData("http://localhost:2588/EmployeeService.svc/GetEmployee/1");

            using (Stream stream = new MemoryStream(employeeData))
            {
                DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(Employee));
                Employee retrievedEmployee = dataContractSerializer.ReadObject(stream) as Employee;
            }
        }

        void C()
        {
            WebClient client = new WebClient();
            byte[] employeeData = client.DownloadData("http://localhost:2588/EmployeeService.svc/GetEmployee/1");

            using (Stream stream = new MemoryStream(employeeData))
            {
                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(Employee));
                Employee retrievedEmployee = dataContractJsonSerializer.ReadObject(stream) as Employee;
            }
        }

        void D()
        {
            WebClient client = new WebClient();
            byte[] employeeData = client.DownloadData("http://localhost:2588/EmployeeService.svc/GetEmployee/1");

            using (Stream stream = new MemoryStream(employeeData))
            {
                NetDataContractSerializer netDataContractSerializer = new NetDataContractSerializer();
                Employee retrievedEmployee = netDataContractSerializer.ReadObject(stream) as Employee;
            }

        }
    }

    internal class NetDataContractSerializer
    {
        internal Employee ReadObject(Stream stream)
        {
            throw new NotImplementedException();
        }
    }

    internal class Employee
    {
    }
}
