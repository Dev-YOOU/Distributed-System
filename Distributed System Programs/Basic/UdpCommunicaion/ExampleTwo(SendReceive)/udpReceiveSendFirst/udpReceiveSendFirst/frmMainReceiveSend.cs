using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace udpReceiveSendFirst
{
    public partial class frmMainReceiveSend : Form
    {
        public frmMainReceiveSend()
        {
            InitializeComponent();
        }

        private void btnReceiveSend_Click(object sender, EventArgs e)
        {
            UdpClient client = new UdpClient(8080);/*Receive in port number 8080*/

            IPEndPoint ipEndPoint = null;

            byte[] received = client.Receive(ref ipEndPoint);

            client.Send(Encoding.Unicode.GetBytes("Hello from first")
                ,Encoding.Unicode.GetByteCount("Hello from first")
                ,new IPEndPoint (IPAddress.Parse("192.168.0.2"),8080));/*Send to 198.168.0.2 and port 8080*/

            MessageBox.Show(Encoding.Unicode.GetString(received));/*Show the message received*/
        }
    }
}

/* 
 Note this program will receive data then send data you should note that if we try to run this program without any sender the send method
 will never raech because the program will block in the receive method..
 
 */