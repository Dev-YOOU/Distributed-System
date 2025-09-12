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

namespace ChatProgramUDP
{
    delegate void InvocationParameterizedMethod(string Message);
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// In the event load of the Form frmMain instantiate a new UdpClient and start the Receiver method that
        /// will always receive the data from the address 224.100.0.1
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            udpClient = new UdpClient(8090);
            Thread thrdStart= new Thread(Receiver);
            thrdStart.IsBackground = true;
            thrdStart.Start();
        }

        /// <summary>
        /// Send the message to ipaddress 224.100.0.1 in port 8090
        /// </summary>
        private void btnSend_Click(object sender, EventArgs e)
        {
            udpClient.Send(Encoding.Unicode.GetBytes(txtMessageToSend.Text),
                Encoding.Unicode.GetByteCount(txtMessageToSend.Text), new IPEndPoint(IPAddress.Parse("224.100.0.1"), 8090));
            txtMessageToSend.Clear();
            txtMessageToSend.Focus();
        }

        /// <summary>
        /// always receive data the JoinMulticastGroup method will make the udpClient receive any data sent to 
        /// ipaddress 224.100.0.1 
        /// </summary>
        private void Receiver()
        {
            udpClient.JoinMulticastGroup(IPAddress.Parse("224.100.0.1"));
            while (true)
            {                
                IPEndPoint ipEndPoint = null;
                byte[] Data = udpClient.Receive(ref ipEndPoint);
                String strngData = Encoding.Unicode.GetString(Data);
                strngData = ipEndPoint.Address.ToString()+":   " + strngData;                
                this.Invoke(new InvocationParameterizedMethod(InvokeLstMessages), strngData);
            }            
        }

        private void InvokeLstMessages(string Message)
        {
            lstMessages.Items.Add(Message);
        }       

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            lstMessages.Height = this.Height - (4 * btnSend.Height);
        }

        UdpClient udpClient;
    }
}
/*
 This program will Receive data always and send data when you Click the Button btnSend
 */