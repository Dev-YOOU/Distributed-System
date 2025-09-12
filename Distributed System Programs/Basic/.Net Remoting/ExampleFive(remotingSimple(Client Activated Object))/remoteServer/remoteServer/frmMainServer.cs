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
            RemotingConfiguration.ApplicationName = "Squaring";/*Gets or sets the name of a remoting application*/
            RemotingConfiguration.RegisterActivatedServiceType(typeof(Mathmatics));/*Registers a specified object type
                                                                                    on the service end as a type that can 
                                                                                    be activated on request from a client. */


        }
    }
}