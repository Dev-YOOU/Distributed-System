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
            TcpChannel tcpChannnel = new TcpChannel(8080);            
            ChannelServices.RegisterChannel(tcpChannnel);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Invokations), "InvokationsTimes", WellKnownObjectMode.SingleCall);
            ((Button)sender).Enabled = false;/*Disable the button btnStartServer*/
        }
    }
}
/*
 Note in this program one time use the WellKnownObjectMode.SingleCall and one time use WellKnownObjectMode.Singleton and note the difference
 when you call the method more than one time by the client.
 */