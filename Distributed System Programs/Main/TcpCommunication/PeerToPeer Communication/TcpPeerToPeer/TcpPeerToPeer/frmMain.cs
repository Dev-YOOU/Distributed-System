using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;

namespace TcpPeerToPeer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Client();
        }
        /// <summary>
        /// Connect to host in the txtPeerAddress.Text and Write the message in txtMessageToSend.Text after
        /// Converting the message to array of bytes.
        /// </summary>
        void Client()
        {
            TcpClient tcpClient = new TcpClient(txtPeerAddress.Text,8080);
            tcpClient.GetStream().Write(Encoding.Unicode.GetBytes(txtMessageToSend.Text), 
                0, Encoding.Unicode.GetByteCount(txtMessageToSend.Text));
            /*
             Note that the Encoding.Unicode.GetByteCount will return number of bytes for the string in the txtMessageToSend.Text
             */
        }            

        private void frmMain_Load(object sender, EventArgs e)
        {
            new Thread(Server).Start();
        }

        /// <summary>
        /// We execute this method by thread because we want the application always to receive messages and send when ever we want
        /// </summary>
        void Server()
        {
            TcpListener tcpListener = new TcpListener(8080);
            tcpListener.Start(10);
            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                while (tcpClient.GetStream().DataAvailable == false) ;/*this while to stay here until data received */
                byte[] receivedData = new byte[tcpClient.Available];/*when data received create new array of bytes
                                                                     with Avialable bytes count in the buffer */
                tcpClient.GetStream().Read(receivedData, 0, receivedData.Length);
                EndPoint endPoint = tcpClient.Client.RemoteEndPoint;
                string strngReceived = ((IPEndPoint)endPoint).Address.ToString()+":       ";
                strngReceived+=Encoding.Unicode.GetString(receivedData);
                Invoke(new InvokeListBox(InvokeLstMessages), strngReceived);/*we use the invoke method to let 
                                                                             the main thread executes the InvokeLstMessages
                                                                             (we talk about this in Thread Example Three)
                                                                             */
            }
        }

        private void InvokeLstMessages(string y)
        {
            lstMessages.Items.Add(y);
        }       

        delegate void InvokeListBox(string x);

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }        
    }
}
/*
  By peer to peer I mean that the same copy of program will be in the two machines that communicating, the difference is in that the 
  machine one will connect to the Ip address of the machine two and machine two will connect the ipaddress of the machine one but the 
  port is the same So I'll enter the ip address in txtPeerAddress before I Click Send.
 */

/*we use tow method one to connect and send and call it directly in a button btnSend when we want to send and another method 
 Server this method excutes by thread because we want our program always receive messages as soon as they sent*/