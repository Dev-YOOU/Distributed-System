using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Client
{
    public partial class frmMainClient : Form
    {
        public frmMainClient()
        {
            InitializeComponent();
        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            new Thread(Client).Start();/*Here we start a new thread because if the file is too long we maintain the UI frmMainClient 
                                        responsive to mouse and keyboard events*/
        }

        private void Client()
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(txtAddress.Text, 8080);            
            NetworkStream networkStream = tcpClient.GetStream();
            networkStream.Write(Encoding.Unicode.GetBytes(txtFileRequested.Text)
                , 0, Encoding.Unicode.GetByteCount(txtFileRequested.Text));/*
                                                                            we enter the file path in txtFileRequested.Text
                                                                            and then send the file path to the server
                                                                            */
            while (networkStream.DataAvailable == false) ;/*wait until we receive data*/
            byte[] sFileRequested = new byte[tcpClient.ReceiveBufferSize];/*create an array of bytes and initialize the count with
                                                                           ReceiveBufferSize(we can also use tcpClient.GetStream().Available)*/

            FileStream fileStream = new FileStream(Application.StartupPath
                + txtFileRequested.Text.Substring(txtFileRequested.Text.LastIndexOf("\\")), FileMode.Create, FileAccess.ReadWrite);
            /*
             Instantiate a FileStream instance with the next parameters:
             * first:The path of the file
             * second:The FileMode for example create truncate
             * Third:FileAccess for example read or write or readwrite
             * 
             * Note that Application.StartupPath return the path of the execution file
             * Note that substring method will return the name of the file only without the path because we will substring the txtFileRequested
             * from the lastindex of \
            */
            while(true)/*In this file we read the file sent by the server*/
            {
                int Count = networkStream.Read(sFileRequested, 0, sFileRequested.Length);/*Read bytes from the buffer and place it in the array sFileRequested*/

                /*
                 Note that the data will be read from networkstream to sFileRequested and the number of bytes read is save in the count variable
                 */

                fileStream.Write(sFileRequested,0,Count);/*Write the bytes to the file by count */

                /*
                 Note that we use count variable not sFileRequested.Length because the bytes read from the buffer may be less than the ReceivedBufferSize which is the
                 the length of sFileRequested
                 */

                Array.Clear(sFileRequested, 0, sFileRequested.Length);/*clear the array*/
                if (Count == 0)/*if we try to read from networksream and theres no data */
                {
                    fileStream.Close();/*close filestream*/
                    break;/*break the while*/
                }
            }
            this.Invoke(new InvokeLstBox(InvokeLstFetchedFiles), txtFileRequested.Text);/*write the path of the file to listbox lstFetchedFiles
                                                                                         after completing reading files*/
            networkStream.Close();
            tcpClient.Close();            
        }

        private void InvokeLstFetchedFiles(string FileRequested)
        {
            lstFetchedFiles.Items.Add(txtFileRequested.Text);            
        }

        private void frmMainClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        delegate void InvokeLstBox(string Text);
    }    
}

/*
 This client will send the path of the file and receive the file as bytes
 */