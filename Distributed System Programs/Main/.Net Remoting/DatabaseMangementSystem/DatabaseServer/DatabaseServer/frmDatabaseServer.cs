using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using DatabaseInterfaceNamespace;
namespace DatabaseServer
{
    public partial class frmDatabaseServer : Form
    {
        public frmDatabaseServer()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            ChannelServices.RegisterChannel(new TcpChannel(8080));
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(DatabaseMangement), "DatabaseServer", WellKnownObjectMode.Singleton);
        }
    }
    public class DatabaseMangement : MarshalByRefObject, IDatabaseMangement
    {
        bool bUpdateStudents, bUpdateSubjects, bUpdateDegrees;
        OleDbConnection oleDbCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + Application.StartupPath + @"\StudentsDatabase.mdb");
        OleDbDataAdapter StudentsDataAdapter;
        OleDbDataAdapter subjectsDataAdapter;
        OleDbDataAdapter degreesDataAdapter;

        public DataSet GetStudents(string UserName, string Password, bool Update)
        {
            DataSet ds = new DataSet();
            if (!bUpdateStudents)
            {
                if ((UserName == "Manager" && Password == "1234") || (UserName == "" && Password == ""))
                {
                    bUpdateStudents = Update;
                    StudentsDataAdapter = new OleDbDataAdapter("Select * from students", oleDbCon);
                    StudentsDataAdapter.Fill(ds);
                    return ds;
                }
                ds.Tables.Add("Table1");
                ds.Tables[0].Columns.Add("Message");
                ds.Tables[0].Rows.Add("You are not authorized");
                return ds;
            }
            ds.Tables.Add("Table1");
            ds.Tables[0].Columns.Add("Message");
            ds.Tables[0].Rows.Add("The Table is locked for writing");
            return ds;
        }

        public DataSet GetSubjects(string UserName, string Password, bool Update)
        {
            DataSet ds = new DataSet();
            if (!bUpdateSubjects)
            {
                if ((UserName == "Manager" && Password == "1234") || (UserName == "" && Password == ""))
                {
                    bUpdateSubjects = Update;
                    subjectsDataAdapter = new OleDbDataAdapter("Select * from subjects", oleDbCon);
                    subjectsDataAdapter.Fill(ds);
                    return ds;
                }
                ds.Tables.Add("Table1");
                ds.Tables[0].Columns.Add("Message");
                ds.Tables[0].Rows.Add("You are not authorized");
                return ds;
            }
            ds.Tables.Add("Table1");
            ds.Tables[0].Columns.Add("Message");
            ds.Tables[0].Rows.Add("The Table is locked for writing");
            return ds;
        }

        public DataSet GetDegrees(string UserName, string Password, bool Update)
        {
            DataSet ds = new DataSet();
            if (!bUpdateDegrees)
            {
                if ((UserName == "Manager" && Password == "1234") || (UserName == "" && Password == ""))
                {
                    bUpdateDegrees = Update;
                    degreesDataAdapter = new OleDbDataAdapter("Select * from degrees", oleDbCon);
                    degreesDataAdapter.Fill(ds);
                    return ds;
                }
                ds.Tables.Add("Table1");
                ds.Tables[0].Columns.Add("Message");
                ds.Tables[0].Rows.Add("You are not authorized");
                return ds;
            }
            ds.Tables.Add("Table1");
            ds.Tables[0].Columns.Add("Message");
            ds.Tables[0].Rows.Add("The Table is locked for writing");
            return ds;
        }

        public void updateStudents(DataSet ds)
        {
            OleDbCommandBuilder CommandBuilder = new OleDbCommandBuilder(StudentsDataAdapter);
            StudentsDataAdapter.Update(ds);
            bUpdateStudents = false;
        }

        public void updateSubjects(DataSet ds)
        {
            OleDbCommandBuilder CommandBuilder = new OleDbCommandBuilder(subjectsDataAdapter);
            subjectsDataAdapter.Update(ds);
            bUpdateSubjects = false;
        }

        public void updateDegrees(DataSet ds)
        {
            OleDbCommandBuilder CommandBuilder = new OleDbCommandBuilder(degreesDataAdapter);
            degreesDataAdapter.Update(ds);
            bUpdateDegrees = false;
        }
    }
}