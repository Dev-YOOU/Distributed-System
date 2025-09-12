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
            UdpClient udpClient = new UdpClient(8080);/*If we want to receive Messages we must intialize the udpClient instance
                                                       with port number here*/

            IPEndPoint ipEndPoint = null;/*Define an instance with a null value*/

            byte[] bMessage = udpClient.Receive(ref ipEndPoint);/*The Receive method will block until a datagram arrives from a 
                                                                 remote host. When data is available, the Receive method will read 
                                                                 the first enqueued datagram and return the data portion as a byte array.
                                                                 This method populates the ipEndPint instance parameter with the IPAddress 
                                                                 and port number of the sender. */


            MessageBox.Show(Encoding.ASCII.GetString(bMessage)+ipEndPoint.Address.ToString());/*Show the message received and the 
                                                                                               IpAddress of the sender*/
            udpClient.Close();
        }
    }
}
/*
 Note that this program will block in the receive method untill the datagram received
 */