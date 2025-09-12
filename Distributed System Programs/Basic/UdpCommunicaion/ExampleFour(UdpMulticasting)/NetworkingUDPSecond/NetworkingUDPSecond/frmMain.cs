using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace NetworkingUDPSecond
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient(8080);

            IPEndPoint ipEndPoint = null;

            udpClient.JoinMulticastGroup(IPAddress.Parse("224.0.0.0"));/*Any Message Sent to this address 
                                                                        the udpClient instance will receive it*/

            MessageBox.Show(Encoding.ASCII.GetString(udpClient.Receive(ref ipEndPoint)));
            MessageBox.Show(ipEndPoint.ToString());
            udpClient.Close();
        }
    }
}