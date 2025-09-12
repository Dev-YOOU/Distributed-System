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

namespace remoteServerHost
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
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(TimeOfServer), "TimeServer", WellKnownObjectMode.SingleCall);
            btnStartServer.Enabled = false;
        }    
    }
    public class TimeOfServer : MarshalByRefObject, IServerTime/*Inherits from class MarshalByRefObject and Interface IServerTime*/
    {
        public DateTime GetServerTime()/*Implement the method in the Interface IServerTime*/
        {
            return DateTime.Now;/*Return the current time*/
        }
    }
    
}