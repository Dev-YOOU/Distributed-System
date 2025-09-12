using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace MultiServer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            new Thread(Listener).Start();
            btnStartServer.Enabled = false;
        }
        private void Listener()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any,8080);
            tcpListener.Start();
            while (true)
            {
                new Thread(HandelClient).Start(tcpListener.AcceptTcpClient());               
            }
        }
        private void HandelClient(object o)
        {
            TcpClient tcpClient = (TcpClient)o;
            NetworkStream networkStream = tcpClient.GetStream();
            while (networkStream.DataAvailable == false) ;/*Wait to receive data */
            byte[] FileRequested = new byte[tcpClient.Available];/*Create an array of bytes of size same as bytes in buffer*/
            networkStream.Read(FileRequested, 0, FileRequested.Length);/*receive the data*/
            byte[] FileToSend = File.ReadAllBytes(
                Encoding.Unicode.GetString(FileRequested, 0, FileRequested.Length));/*The ReadAllBytes method of static class 
                                                                                     File read the file 
                                                                                     to array of bytes with name FileToSend 
                                                                                     Read method has one parameter 
                                                                                     that is the file path*/
            networkStream.Write(FileToSend,0,FileToSend.Length);/* 
                                                                 Write the bytes of the file to network stream
                                                                 */
            networkStream.Close();
            tcpClient.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
/*
 In this program we let every Client handeled by separate thread at the same time this program read a file path read this file and
 send the file to the client sent the path of the file
 */