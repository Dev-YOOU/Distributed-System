using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Net;
using remotingLibrary;

namespace remoteClient
{
    public partial class frmMainClient : Form
    {
        public frmMainClient()
        {
            InitializeComponent();
        }

        private void btnRequestService_Click(object sender, EventArgs e)
        {
            Invokations Inv = (Invokations)Activator.GetObject(typeof(Invokations), "tcp://localhost:8080/InvokationsTimes");

            MessageBox.Show(Inv.Count(Dns.GetHostName()).ToString());/*Call the method count pass the name of this computer as
                                                                      argument*/
        }

        private void frmMainClient_Load(object sender, EventArgs e)
        {
            ChannelServices.RegisterChannel(new TcpChannel(),false);/*We call the RgisterChannel here because we want to register it
                                                                     one time and Invoke the Remote method more than one time by clicking
                                                                     btnRequestService*/
        }
    }
}
/*
 Note in this program the differnce when you change the  WellKnownObjectMode.Singlecall to  WellKnownObjectMode.Singleton in the RemotConfiguration
 class with the RegisterWellKnownServiceType method in the server
 */