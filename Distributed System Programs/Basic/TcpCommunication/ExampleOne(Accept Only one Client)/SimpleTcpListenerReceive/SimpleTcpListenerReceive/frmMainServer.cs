using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;/*We need this namespace to use IpEndPoint and IpAddress classes...*/
using System.Net.Sockets;/*We need this namespace to use TcpListener and TcpClient and UdpClient classes ...*/

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
            IPAddress localIpAddress = IPAddress.Parse("0.0.0.0");/*instantiate an IpAddress instance  with IP Address 0.0.0.0
                                                                   which means all available network interfaces*/

            IPEndPoint localIpEndPoint = new IPEndPoint(localIpAddress, 8080);/*instantiate an IpEndPint instance with
                                                                               Ip Address we just make in the pervious step and 
                                                                               with port number 8080*/

            TcpListener listenerServer = new TcpListener(localIpEndPoint);/*instantiate a TcpListener instance wth IpEndPoint we just 
                                                                           made in previous step (which contain IP address 0.0.0.0 and 
                                                                           port number 8080)*/

            /*Note that the listenerServer instance need only local IpEndPoint because it is instance of class TcpListener and the class TcpListener
             do not connect to remote computers it just listen on the local IpEndPoint for incoming connections and pass it to TcpClient
             as illustrated by next steps(TcpListener needs Only local IpEndPoint to listen on)*/
            
            listenerServer.Start();/*This method make Bind (Bind means select port number and network interface that the listener will listen on)
                                    and also this method make start Listen(Listen for incominc connections and placing connections in pending Queue)
                                    this method is overloaded so it can have integer as a parameter that define the maximum length of pending Queue*/


            MessageBox.Show(((IPEndPoint)listenerServer.Server.LocalEndPoint).Address.ToString());/*Show the local IpEndPoint that the server instance
                                                                                                   Binded to it*/

            /*Note That the we use the property Server of the instance listenerServer which return a Socket instance the reason we do that  that the property
             LocalEndPoint does not exists in the listenerServer instance because it is instance of class TcpListener which does not contais property LocalEndPoint
             */

            /*Note that we make cast to (IPEndPoint) because the property LocalEndPoint will returnt EndPoint instance an if we want to access
             the properties and methods of the IPEndPoint class we must make the cast.
             */

            /*Note that if we try the next line :             
            MessageBox.Show(((IPEndPoint)listenerServer.Server.RemoteEndPoint).Address.ToString());
            an exception will be thrown because that as we say that the instance listenerServer from class TcpListener do not have Remot IpEndPoint
            only local IpEndPoint Listening on.
             */

            TcpClient receiverClient = listenerServer.AcceptTcpClient();/*Accept a connection from the pending Queue and return a TcpClient instance
                                                                       that is connected to the TcpClient instance in the Remote machine(the other 
                                                                       away computer that make the connection) and while they are connected (the 
                                                                       remote instance in the remote machine and this instance(receiverClient) ) they
                                                                       can send to each other and receive from each other*/

            MessageBox.Show(((IPEndPoint)receiverClient.Client.LocalEndPoint).Address.ToString()+"Local");/*This MessageBox will show the Local IPEndPoint
                                                                                                           which I will receive Messages from it when I make
                                                                                                           Read()
                                                                                                           */

            MessageBox.Show(((IPEndPoint)receiverClient.Client.RemoteEndPoint).Address.ToString()+"Remote");/*This MessageBox will show the Remote IPEndPoint
                                                                                                            which I will Send Messages to it when I make 
                                                                                                            Write()*/

            byte[] receivedBytes = new byte [1024];/*Dfine an array of bytes that will used to receive data and send data (we can only send bytes
                                                    array to network and receive only bytes array from the network*/

            
            int count = receiverClient.GetStream().Read(receivedBytes, 0, receivedBytes.Length);/*First The GetStream method will return NetworkStream 
                                                                                                 instance needed to Write or read data to the buffer
                                                                                                 * Second The Read method This method reads data into the 
                                                                                                 buffer parameter and returns the number of bytes successfully read
                                                                                                 and has three parametrs first the 
                                                                                                 An array of type Byte that is the location in memory to 
                                                                                                 store data read from the NetworkStream
                                                                                                 second The location in buffer to begin storing the data to(0 means from the 
                                                                                                 begining of the array) 
                                                                                                 Third The number of bytes to read from the NetworkStream.
                                                                                                 */

            /*Note that this method will block the thread that call this until the method receive data of the remote client closed so it's better to 
             make this method call in separate thread to let the UI (frmMainServer) responsive to mouse and keyboard events (for example if I want
             to exit program and users of programs if they see the program not responding the kill the process from task manager)*/

            string receivedString = Encoding.Unicode.GetString(receivedBytes);/*Now I have received the data as array of  bytes if I Encode this bytes from
                                                                               string to bytes in the remote client by Encoding.Unicode.GetBytes("the string")
                                                                               here I can get the string again by Encoding.Unicode.GetString([] byte)*/

            MessageBox.Show(receivedString);/*This MessageBox shows the received data*/
        }
    }
}

/*You can see from this program that I can only accept one client because if I try to Click btnStartListening button again an Exception will
 be thrown because this will istantiate a new instance that will listen to the same port number and this is not allowed(only one application 
 can listen to port in the OS) there are number of solutions like :
 * Define the instance of the class TcpListener public and move the code from TcpClient receiverClient = listenerServer.AcceptTcpClient(); to
 another button so every time I press the new button I accept new Client
 * Another solution and more efficient one and we will see it in the next example is to move the code not to button but to a method and run
 this method in by thread (Next Example show this way) this is efficient because now the thread will not block in the Read method as in 
 this example*/