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
            Console.WriteLine(service.SayHello("Remote"));
            Console.WriteLine(service.HighestNumber(20, 25));
            Console.Read();

        }
    }
}
