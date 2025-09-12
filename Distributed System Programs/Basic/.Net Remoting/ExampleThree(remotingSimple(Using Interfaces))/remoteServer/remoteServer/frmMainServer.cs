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
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Mathmatics), "Squaring", WellKnownObjectMode.SingleCall);
            /*
             In the typeof we pass the Class not the interface as argument
             */
            btnStartServer.Enabled = false;
        }
    }
    public class Mathmatics : MarshalByRefObject, IMathmatics/*Inherit from the Class MarshalByRefObject and IMathmatics Inteface*/
    {
        public int Square(int x)/*Implement the methods of the Interface*/
        {
            MessageBox.Show("The Client has requested the serever with value " + x.ToString());
            x = x * x;
            return x;
        }
    }
}