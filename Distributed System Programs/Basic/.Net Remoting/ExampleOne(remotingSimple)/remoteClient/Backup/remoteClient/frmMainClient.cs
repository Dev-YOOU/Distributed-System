using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Net;
using remotingLibrary;

namespace remoteClient
{
    public partial class frmMainClient : Form
    {
        public frmMainClient()
        {
            InitializeComponent();
        }

        private void btnRequestService_Click(object sender, EventArgs e)
        {
            ChannelServices.RegisterChannel(new TcpChannel());/*The RegisterChannel method takes in the Channel inastance(Tcp,Http..).*/

            Mathmatics math = (Mathmatics)Activator.GetObject(typeof(Mathmatics), "tcp://localhost:8080/Squaring");/*Creates a proxy for 
                                                                                                                    the well-known object
                                                                                                                    indicated by the 
                                                                                                                    specified type and URL.*/
            /*
             * Parameters
             type
             The type of the well-known object to which you want to connect. 
             url
             The URL of the well-known object. 

             *Return Value
              A proxy that points to an endpoint served by the requested well-known object. 
             */

            int y = math.square(10);
            /*Call the method against the proxy this will call the remote object in the server*/

            MessageBox.Show(y.ToString());
            /*Show the returned value*/
        }
    }
}
/*This program will call the remote object which in the server (the code will execute in the server and the return value will return to 
 here
 Note that if Click the button btnRequestService more than once this will throw exception because we can't register more than one channel
 with the same name.*/