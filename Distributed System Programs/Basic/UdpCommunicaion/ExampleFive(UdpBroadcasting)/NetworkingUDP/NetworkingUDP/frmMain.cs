using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Net.Sockets;

namespace NetworkingUDP
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        
        private void btnSend_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient();
            Byte[] bytes = Encoding.ASCII.GetBytes("Hello".ToCharArray());

            udpClient.Send(bytes, bytes.Length, new IPEndPoint(IPAddress.Parse("255.255.255.255"), 8080));/*Broadcast message to all clients
                                                                                                           in the subnet
                                                                                                           */
            udpClient.Close();
        }

       
    }
}