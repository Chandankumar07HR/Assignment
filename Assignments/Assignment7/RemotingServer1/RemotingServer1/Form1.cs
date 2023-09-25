using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;

namespace RemotingServer1
{
    public class Service : MarshalByRefObject
    {
        public string SayHello(string s)
        {
            return "Hello" + s;
        }
        public int HighestNumber(int n1, int n2)
        {
            int maxnumber = (Math.Max(n1, n2));
            Console.WriteLine("Remote Call Executed..");
            return maxnumber;
        }

    }
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void Sender(object sender, EventArgs e)
        {
            //create a new channel for communication
            //HttpChannel c = new HttpChannel(85);
            TcpChannel tc = new TcpChannel(8080);

            //register the channel
            ChannelServices.RegisterChannel(tc);

            //configure all known services
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Service), "OurFirstRemoteService", WellKnownObjectMode.Singleton);
            MessageBox.Show("Server Services started at Port No: 85...");
            MessageBox.Show("Press any Key to Stop the Server Services..");
            Console.ReadLine();
        }
    }
}
