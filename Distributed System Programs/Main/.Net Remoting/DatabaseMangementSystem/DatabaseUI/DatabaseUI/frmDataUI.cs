using System;
using System.Data;
using System.Windows.Forms;
using DatabaseInterfaceNamespace;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace DatabaseUI
{
    public partial class frmDataUI : Form
    {
        public frmDataUI()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();

        private void btnGetTable_Click(object sender, EventArgs e)
        {
            bool Update= false;
            if (cmbUpdate.Text == "Update")
                Update = true;
            btnUpdate.Enabled = Update;
            IDatabaseMangement dbms =(IDatabaseMangement) Activator.GetObject(typeof(IDatabaseMangement),
                "tcp://localhost:8080/DatabaseServer");            

            switch(cmbTables.Text)
            {
                case "Students":
                    ds = dbms.GetStudents(txtUserName.Text, txtPassword.Text, Update);
                    break;
                case "Subjects":
                    ds = dbms.GetSubjects(txtUserName.Text, txtPassword.Text, Update);
                    break;
                case "Degrees":
                    ds = dbms.GetDegrees(txtUserName.Text, txtPassword.Text, Update);
                    break;
                default :
                    ds = dbms.GetStudents(txtUserName.Text, txtPassword.Text, Update);
                    break;
            }
            dgvData.DataSource = ds;
            dgvData.DataMember = ds.Tables[0].TableName;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IDatabaseMangement dbms = (IDatabaseMangement)Activator.GetObject(typeof(IDatabaseMangement),
                "tcp://localhost:8080/DatabaseServer");

            switch (cmbTables.Text)
            {
                case "Students":
                    dbms.updateStudents(ds);
                    break;
                case "Subjects":
                    dbms.updateSubjects(ds);
                    break;
                case "Degrees":
                    dbms.updateDegrees(ds);
                    break;
                default:
                    dbms.updateStudents(ds);
                    break;
            }
            btnUpdate.Enabled = false;
        }
        
        private void frmDataUI_Load(object sender, EventArgs e)
        {
            ChannelServices.RegisterChannel(new TcpChannel());
            btnUpdate.Enabled = false;
            cmbTables.SelectedIndex = 0;
            cmbUpdate.SelectedIndex = 0;
        }
    }
}