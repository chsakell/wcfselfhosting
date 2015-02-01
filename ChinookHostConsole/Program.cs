using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ChinookWcfService;
using System.ServiceModel.Description;

namespace ChinookHostConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create two different URIs to serve as the base address
            // One for http requests and another for net.tcp
            Uri httpUrl = new Uri("http://localhost:8090/ChinookHttpService");
            Uri netTcpUrl = new Uri("net.tcp://localhost:8080/ChinookHttpService");

            //Create ServiceHost to host the service in the console application
            ServiceHost host = new ServiceHost(typeof(ChinookWcfService.ChinookService), httpUrl,netTcpUrl);
            
            //Enable metadata exchange - you need this so others can create proxies
            //to consume your WCF service
            ServiceMetadataBehavior serviceMetaBehavior = new ServiceMetadataBehavior();
            serviceMetaBehavior.HttpGetEnabled = true;
            host.Description.Behaviors.Add(serviceMetaBehavior);
            //Start the Service
            host.Open();

            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.ReadKey();
            host.Close();
        }
    }
}
