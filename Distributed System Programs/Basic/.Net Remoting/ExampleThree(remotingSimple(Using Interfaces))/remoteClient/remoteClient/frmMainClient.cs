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
            IMathmatics math = (IMathmatics)Activator.GetObject(typeof(IMathmatics), "tcp://localhost:8080/Squaring");
            /*
             Here we use the Interface to define a proxy
             */
            int y = math.Square(10);
            MessageBox.Show(y.ToString());
        }

        private void frmMainClient_Load(object sender, EventArgs e)
        {
            ChannelServices.RegisterChannel(new TcpChannel());
        }
    }
}