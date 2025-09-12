using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;/*We need this namespace to use IpEndPoint and IpAddress classes...*/
using System.Net.Sockets;/*We need this namespace to use TcpListener and TcpClient and UdpClient classes ...*/
using System.Threading;/*we need this namespace to use Thread class...*/

namespace SimpleTcpListenerReceive
{
    public partial class frmMainServer : Form
    {
        public frmMainServer()
        {
            InitializeComponent();
        }

        private void btnStartListening_Click(object sender, EventArgs e)
        {
            IPAddress localIpAddress = IPAddress.Parse("0.0.0.0");/*instantiate an IpAddress instance  with IP Address 0.0.0.0*/

            IPEndPoint localIpEndPoint = new IPEndPoint(localIpAddress, 8080);/*instantiate an IpEndPint instance with
                                                                               Ip Address we just make in the pervious step and 
                                                                               with port number 8080*/

            listenerServer = new TcpListener(localIpEndPoint);/*instantiate a TcpListener instance wth IpEndPoint we just 
                                                                           made in previous step (which contain IP address 0.0.0.0 and 
                                                                           port number 8080)*/

            listenerServer.Start();/*This method make Bind to "0.0.0.0" ipaddress and 8080 prot and start listening"*/

            Thread thrdAcceptClients = new Thread(AcceptClients);/*instantiate thread to run the method AcceptClients*/
            thrdAcceptClients.Start();/*Start the thread*/

            /*
             the reason we use thread here because we want maintain UI (the form frmMainServer) responsive (means can handel mouse and
             keyboard events.
             The user interface (UI) frmMainServer will be an responsive if we call AccepteClients directl with the line
             AcceptClients()
             Because three things 
             * The Infinite loop
             * The AcceptTcpClien method (This method blocks the calling thread until connection request come)             
             */

            btnStartListening.Enabled = false;/*Disable the button because we listen only one time*/

        }
        /// <summary>
        /// Accept connection and instantiate a thread to deal with this connections
        /// </summary>
        private void AcceptClients()
        {
            while (true)
            {
                TcpClient tempClient = listenerServer.AcceptTcpClient();/*Accept a connection from the pending Queue and return a TcpClient instance*/
                Thread thrdHandelClient = new Thread(HandelClient);/*instantiate a new thread for every accepted connection*/
                thrdHandelClient.Start(tempClient);
            }
        }

        /// <summary>
        /// Handel every connection here 
        /// </summary>
        /// <param name="O">
        /// Object O will receive the TcpClient.
        /// </param>
        private void HandelClient(Object O)
        {
            TcpClient receiverClient = (TcpClient)O;/*Cast the object to TcpClient*/
            byte[] receivedBytes = new byte[1024];
            int count = receiverClient.GetStream().Read(receivedBytes, 0, receivedBytes.Length);
            string receivedString = Encoding.Unicode.GetString(receivedBytes);
            MessageBox.Show(receivedString,((IPEndPoint)receiverClient.Client.RemoteEndPoint).Address.ToString());/*This MessageBox shows the received data
                                                                                                                   and the ip of the sender in the caption of
                                                                                                                   MessageBox*/            
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();/*kill the process(with all it's threads)*/
        }

        TcpListener listenerServer;
        /*Here I define an instance of TcpListener class in the class frmMainServer because I want to access it
                                    from the btnStartListen and access it from the mehtod AcceptClients*/
    }    
}

/*we can process more than one connection at a time by making every connection in separate thread as illustrated in this example
 every connection come a thread is instantiated to deal with it so we make the thrdAcceptClients only for accepting client connections
 and instantiate a new thread thrdHandelClient for every connection
 */