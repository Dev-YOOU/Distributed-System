using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace udpSendReceiveSecond
{
    public partial class frmMainSecond : Form
    {
        public frmMainSecond()
        {
            InitializeComponent();
        }

        private void btnSendReceive_Click(object sender, EventArgs e)
        {
            UdpClient client = new UdpClient(8080);

            client.Send(Encoding.Unicode.GetBytes("Hello from second")
                , Encoding.Unicode.GetByteCount("Hello from second")
                ,new IPEndPoint(IPAddress.Parse("192.168.0.5"),8080));/*Send to computer 192.168.0.5
                                                                       and port number 8080*/

            IPEndPoint ipEndPoint = null;/*Define a null IpEndPoint instance*/

            byte[] received = client.Receive(ref ipEndPoint);/*Receive in the port 8080 defined in the constructor*/

            MessageBox.Show(Encoding.Unicode.GetString(received));/*Show the message*/
        }
    }
}
/*
 Note that if we try to run this program and Click btnSendReceive Button then Run the other program both programs will be block in the
 Receive method. 
 This is because we will send data here and ther's no receiver the message will lost then in the other program whe we run it and Click
 ReceiveSend Button the program will be block in the Receive method and this will blcok in the Receive method (because it send the message
 and the message lost)and every program will wait for the Other.
 
 * So we must first Click the Button ReceiveSend then Click the Button SendReceive.
 
 * The Solution is in the next program
 */