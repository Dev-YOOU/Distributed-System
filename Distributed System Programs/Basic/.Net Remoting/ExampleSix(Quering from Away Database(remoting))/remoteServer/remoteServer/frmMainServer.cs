using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using remotingLibrary;

namespace remoteServer
{
    public partial class frmMainServer : Form
    {
        public frmMainServer()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            ChannelServices.RegisterChannel(new TcpChannel(8080));
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(DataProvider), "DataServer", WellKnownObjectMode.SingleCall);
            btnStartServer.Enabled = false;
        }
    }
}