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
            RemotingConfiguration.RegisterActivatedClientType(typeof(Mathmatics), "tcp://localhost:8080/Squaring");
            /*
             To create an instance of a client-activated object on the server, you must know its Type and it must be
             registered on the server end by using the RegisterActivatedServiceType method. To obtain a proxy for a
             new instance of the client-activated object, the client must first register a channel with ChannelServices
             and then activate the object by calling new.
             To activate a client-activated object type with the new keyword, you must first register the object type
             on the client end using the RegisterActivatedClientType method. Calling the RegisterActivatedClientType 
             method gives the remoting infrastructure the location of the remote application where new attempts to create it.
             */
            Mathmatics math = new Mathmatics();
            int y = math.square(10);
            MessageBox.Show(y.ToString());
        }

        private void frmMainClient_Load(object sender, EventArgs e)
        {
            ChannelServices.RegisterChannel(new TcpChannel());            
        }
    }
}