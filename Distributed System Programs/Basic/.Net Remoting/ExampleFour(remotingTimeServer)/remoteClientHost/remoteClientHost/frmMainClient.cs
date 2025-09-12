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
using remotingLibraryInterface;

namespace remoteClientHost
{
    public partial class frmMainClient : Form
    {
        public frmMainClient()
        {
            InitializeComponent();
        }

        private void btnRequestService_Click(object sender, EventArgs e)
        {
            
            IServerTime serverTime = (IServerTime)Activator.GetObject(typeof(IServerTime), "tcp://localhost:8080/TimeServer");
            MessageBox.Show(serverTime.GetServerTime().ToString());/*Call method that return The time of the server*/
        }

        private void frmMainClient_Load(object sender, EventArgs e)
        {
            ChannelServices.RegisterChannel(new TcpChannel());
        }
    }
}