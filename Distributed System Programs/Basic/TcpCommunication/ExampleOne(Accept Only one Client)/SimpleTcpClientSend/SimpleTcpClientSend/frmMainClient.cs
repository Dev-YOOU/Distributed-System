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
            IPAddress remoteIPAddress = IPAddress.Parse("192.168.0.2");/*instantiate an IpAddress instance  with IP Addres 192.168.0.2
                                                                        this ip is the ip we want to connect to .
                                                                        Here the statci method Parse return an IPAddress instace contains
                                                                        the Ip address passed to it as string*/

            IPEndPoint remoteIPEndPoint = new IPEndPoint(remoteIPAddress, 8080);/*instantiate an IPEndPoint instance with the IpAddress instantiated
                                                                                 in the previous step and port number 8080*/
            TcpClient senderClient = new TcpClient();/*instantiate a TcpClient instance without connecting this Class have an overloaded constructor
                                                      that accep the ipaddress and port number to make connecttion on*/

            senderClient.Connect(remoteIPEndPoint);/*this method establish connection with a remote machine with Ip address and port number
                                                    contained in the remoteIPEndPoint instance if there's no application listening on the 
                                                    port number 8080 in the machine with ip address 192.168.0.2 an exception will be thrown
                                                    but if there's a listening application a connection will established and we can now send
                                                    and received data with this connection*/

            byte[] bytesToSend = Encoding.Unicode.GetBytes("Hello");/*Encode a string and save as array fo bytes in bytesToSend*/

            senderClient.GetStream().Write(bytesToSend, 0, bytesToSend.Length);/*First The GetStream method will return NetworkStream 
                                                                               instance needed to Write or read data to the buffer 
                                                                               *Second The Write method starts at the specified offset
                                                                               and sends size bytes from the contents of buffer to the network.  
                                                                                */
        }
    }
}