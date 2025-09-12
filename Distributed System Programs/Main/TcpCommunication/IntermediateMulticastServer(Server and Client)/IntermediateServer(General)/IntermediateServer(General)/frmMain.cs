using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace IntermediateServer_General_
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            new Thread(IntermediateServer).Start();/*start a new thread because I want the main UI (frmMain) free to handel mouse and 
                                                    keyboard events*/
            btnStart.Enabled = false;/*Start Only one thread (Starting more than one thread will throw exception becaue it will try to 
                                      listen to the same port)*/
        }

        private void IntermediateServer()
        {
            List<TcpClient> Clients =new List<TcpClient>();/*Here we define a List of TcpClient and name it Clients*/
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 8080);/*Local endpoint which the server will be binded to*/
            TcpListener Server = new TcpListener(localEndPoint);

            Server.Start();/*Bind and start Listening */
            
            while (true)
            {
                if (Server.Pending())/*if there's any connections in the connection queue*/
                {
                    Clients.Add(Server.AcceptTcpClient());/*Add the TcpClient from pending Queue to the list Clients*/
                }

                for (int i = 0; i < Clients.Count; i++)/*Iterate through the list Clients*/
                {                    
                    if (Clients[i].GetStream().DataAvailable)/*If any Client in the List Clients Send any Data*/
                    {
                        byte[] receivedData = new byte[Clients[i].Available];/*Define array of bytes of the size of avaialable data
                                                                              in the buffer*/
                        Clients[i].GetStream().Read(receivedData, 0, receivedData.Length);/*Read the data from network*/

                        IPEndPoint remoteEndPoint = (IPEndPoint)Clients[i].Client.RemoteEndPoint;/*Get the IpEndPoint of the remote Computer
                                                                                                  that Send data*/
                        string strngReceivedData = remoteEndPoint.Address.ToString()+":  " + Encoding.Unicode.GetString(receivedData);
                        /*strnReceivedData contains the IpAddress of the computer sent the message and the message*/

                        byte[] datatToSend = Encoding.Unicode.GetBytes(strngReceivedData);/*Convert the string to array of bytes*/
                        
                        for (int j = 0; j < Clients.Count; j++)/*Iterate through all of list Clients*/
                        {                            
                            try
                            {
                                Clients[j].GetStream().Write(datatToSend, 0, datatToSend.Length);/*try to send the message to all
                                                                                                  clients in the list Clients if 
                                                                                                  the client is not connected any 
                                                                                                  more an Exception will be thrown*/
                            }
                            catch (Exception ex)/*Catch the Exception*/
                            {
                                if (!Clients[j].Connected)/*If the Client not connected any more*/
                                {
                                    Clients.RemoveAt(j);/*Remove it from the List Clients*/
                                }
                            }
                        }
                    }                    
                }                
            }            
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
/*
Note that in this program we want to deal with all Clients with each other so we don't start a new thread for each one we just start one
 thread to deal with all clients and add the clients to a list then when one client send message we receive the message and conver it to
 string and add to it the address of the sender and send the message to all other clients in the list
 */