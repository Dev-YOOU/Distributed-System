using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Net.Sockets;/*Neede to use UdpClient Class*/
using System.Net;

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
            UdpClient udpClient = new UdpClient();/*instantiated a new UdpClient*/
            Byte [] bytes = Encoding.ASCII.GetBytes("Hello");/*Convert a string to array of bytes*/
            /*-------------------------------------------------------------------------------------------------------*/
            /* The first way(using Connect method):*/
            //udpClient.Connect("localhost", 8080);
                                                   /*Connect to remote Computer 
                                                  Note that this method do not establish any connection
                                                  it's only define what computer to send messages to*/

                                                  
            //udpClient.Send(bytes, bytes.Length);/*Send Messages to remote Computer defined in the connect method*/
            /*--------------------------------------------------------------------------------------------------------*/


            /*--------------------------------------------------------------------------------------------------------*/
            /*The second way(using IpEndPint):*/
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Loopback, 8080);/*Instantiated a new IpEndPoint with
                                                                                  the adress and port number we want to
                                                                                  send to*/
            udpClient.Send(bytes, bytes.Length, remoteEndPoint);
            /*--------------------------------------------------------------------------------------------------------*/


            /*--------------------------------------------------------------------------------------------------------*/
            /*The Third way(directly)*/
            //udpClient.Send(bytes, bytes.Length, "localhost", 8080);
            /*--------------------------------------------------------------------------------------------------------*/

            udpClient.Close();
        }
    }
}
/*
 * Note that in this program whenver we click btnSend we send data even if we do not have a receiver no exception will be thrown 
 this is because the udp protocol is not reliable and thre's no aknowledgement or shakin mechanism
 */