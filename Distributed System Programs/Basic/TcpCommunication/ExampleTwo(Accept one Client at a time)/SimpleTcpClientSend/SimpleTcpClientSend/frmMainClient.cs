using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;/*We need this namespace to use IpEndPoint and IpAddress classes...*/
using System.Net.Sockets;/*We need this namespace to use TcpListener and TcpClient and UdpClient classes ...*/

namespace SimpleTcpClientSend
{
    public partial class frmMainClient : Form
    {
        public frmMainClient()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPAddress remoteIPAddress = IPAddress.Parse("192.168.0.2");/*instantiate an IpAddress instance  with IP Addres 192.168.0.2*/

            IPEndPoint remoteIPEndPoint = new IPEndPoint(remoteIPAddress, 8080);/*instantiate an IPEndPoint instance with the IpAddress instantiated
                                                                                 in the previous step and port number 8080*/
            TcpClient senderClient = new TcpClient();/*instantiate a TcpClient instance */

            senderClient.Connect(remoteIPEndPoint);/*this method establish connection with a remote machine */

            byte[] bytesToSend = Encoding.Unicode.GetBytes("Hello");

            senderClient.GetStream().Write(bytesToSend, 0, bytesToSend.Length);/*First The GetStream method will return NetworkStream 
                                                                               instance
                                                                                * *Second The Write method starts at the specified offset
                                                                               and sends size bytes from the contents of buffer to the network.  
                                                                                */
        }
    }
    /*
     we change the server implementaion now every time I Click the btnConnect button the server always show the 
     message but only one message at a time not like the previous example only one time it will show the message
     */
}