using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace Client
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            tcpClient = new TcpClient();
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Parse(txtServer.Text), 8080);
            tcpClient.Connect(remoteIpEndPoint);
            thrdStartReceive = new Thread(StartReceive);
            thrdStartReceive.Start();
            btnConnect.Enabled = false;
        }
        private void StartReceive()
        {
            while (true)
            {
                NetworkStream networkStream = tcpClient.GetStream();
                while (networkStream.DataAvailable == false) ;
                byte[] receivedMessage = new byte[tcpClient.Available];
                networkStream.Read(receivedMessage, 0, receivedMessage.Length);
                Invoke(new InvokeLstBox(InvokeLstMessages), Encoding.Unicode.GetString(receivedMessage));
            }
        }
        private void InvokeLstMessages(string Message)
        {
            lstMessages.Items.Add(Message);
        }        

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            thrdStartReceive.Abort();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            NetworkStream networkStream = tcpClient.GetStream();
            networkStream.Write(Encoding.Unicode.GetBytes(txtMessageToSend.Text)
            , 0, Encoding.Unicode.GetByteCount(txtMessageToSend.Text));
        }

        TcpClient tcpClient;
        Thread thrdStartReceive;
        delegate void InvokeLstBox(string x);
    }
}
/*
In this program we connect to the server by Click btnConnect this will connect to the server with the address you write in txtServer
 and start a new thread to start listening for incoming messages and when we want to send messages we write the message in TextBox
txtMessageToSend and Click button btnSend this will send the message to the server Connected to it
 */