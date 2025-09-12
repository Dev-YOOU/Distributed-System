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
using remotingLibrary;

namespace remoteServer
{
    public partial class frmMainServer : Form
    {
        public frmMainServer()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            TcpChannel tcpChannnel = new TcpChannel(8080);/*Provides a channel implementation that uses the 
                                                           TCP protocol to transmit messages.*/
            /*
            Channels are used by the .NET Framework remoting infrastructure to transport remote calls. When a client makes a call
            to a remote object, the call is serialized into a message that is sent by a client channel and received by a server 
            channel. It is then deserialized and processed. Any returned values are transmitted by the server channel and
            received by the client channel.
             */
            ChannelServices.RegisterChannel(tcpChannnel);/*The RegisterChannel method takes in the Channel inastance(Tcp,Http..).*/
            /*
             You cannot register two channels with the same name in a AppDomain. By default, the name of a HttpChannel is "http"
             and the name of a TcpChannel is "tcp." Therefore, if you want to register two channels of the same type, you must 
             specify a different name for one of them through configuration properties.
             */
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Mathmatics), "Squaring", WellKnownObjectMode.SingleCall);
            /*Registers an object Type on the service end as a well-known type, using the given parameters
             * parameters
             type
             The object Type. 

             objectUri
             The object URI. 

             mode
             The activation mode of the well-known object type being registered. 
            
             * Explain:
             Any client that knows the URI of a registered well-known object can obtain a proxy for the object by registering
             the channel it prefers with ChannelServices, and activating the object by calling the Activator.GetObject method.
             */

        }
    }
}
/*
 This program register the class Mathmatics from namespace remotingLibrary in the dll remotingLibrary to instantiated in the server
 and return value of int to where it called.
 */