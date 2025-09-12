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
            DataProvider dataProvider = (DataProvider)Activator.GetObject(typeof(DataProvider), "tcp://localhost:8080/DataServer");
            DataSet dataSet = dataProvider.GetData("Select DepartmentID,DepartmentName,CollegeName from Departments,colleges where Departments.CollegeID = Colleges.CollegeID");            
            dgvReceivedData.DataSource = dataSet;
            dgvReceivedData.DataMember = dataSet.Tables[0].TableName;
            dgvReceivedData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void frmMainClient_Load(object sender, EventArgs e)
        {
            ChannelServices.RegisterChannel(new TcpChannel(),false);            
        }
    }
}