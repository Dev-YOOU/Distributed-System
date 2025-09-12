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

        private void frmMain_Load(object sender, EventArgs e)
        {           
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient();
            Byte[] bytes = Encoding.ASCII.GetBytes("Hello".ToCharArray());

            udpClient.Send(bytes, bytes.Length, new IPEndPoint(IPAddress.Parse("224.0.0.0"), 8080));/*Multicast the message to address
                                                                                                     224.0.0.0 the client joined to this
                                                                                                     group will receive message
                                                                                                     */
            udpClient.Close();
        }

       
    }
}