using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using RemotingServer1;

namespace RemotingClient1
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            //create channel with port
            //HttpChannel c1 = new HttpChannel(8002);
            TcpChannel c1 = new TcpChannel(8002);

            //register channel
            ChannelServices.RegisterChannel(c1);

            //create a service class object
            Service service = (Service)Activator.GetObject(typeof(Service),
                "tcp://localhost:8080/OurFirstRemoteService");

            //"tcp://localhost:8089/OurFirstRemoteService"
            //start calling the functions of the service class
            Console.WriteLine("enter service name");
            string name = Console.ReadLine();
            Console.WriteLine(service.SayHello("service name is "+ name));
            Console.WriteLine("Enter the number 1: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number 2: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("The highest number is"+ service.HighestNumber(num1, num2));
            Console.Read();

        }
    }
}
