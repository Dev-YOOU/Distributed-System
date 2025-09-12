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
                 
            MessageBox.Show(Encoding.ASCII.GetString(udpClient.Receive(ref ipEndPoint)));
            MessageBox.Show(ipEndPoint.ToString());
            udpClient.Close();
        }
    }
}