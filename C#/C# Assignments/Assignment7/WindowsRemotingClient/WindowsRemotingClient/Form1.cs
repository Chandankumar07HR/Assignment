using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RemotingServer;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace WindowsRemotingClient
{
    public partial class Form1 : Form
    {
        Service remoteobj = new Service();
        public Form1()
        {
            InitializeComponent();
            //channel and services registration 
            remoteobj = (Service)Activator.GetObject(typeof(Service),"tcp://localhost:8089/OurFirstRemoteService");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int n1 = Int32.Parse(txtnum1.Text);
            int n2 = Int32.Parse(txtnum2.Text);
            textresult.Text = (remoteobj.HighestNumber(n1, n2)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = firstname.Text;
            string s2 = lastname.Text;
            fullresult.Text = remoteobj.SayHello(s1, s2);
        }
    }
}
