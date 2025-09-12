using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace remotingLibrary
{
    public class DataProvider : MarshalByRefObject
    {
        public DataSet GetData(string selectCommand)
        {            
            OleDbConnection oleDbCon = new OleDbConnection(@"provider=Microsoft.Jet.oledb.4.0;Data source="
                + Application.StartupPath+@"\me.mdb");
            oleDbCon.Open();
            OleDbDataAdapter oleDataAdapter = new OleDbDataAdapter(selectCommand, oleDbCon);
            DataSet dataset = new DataSet();
            oleDataAdapter.Fill(dataset, "students");
            MessageBox.Show("the command from client is :"+selectCommand );
            return dataset;
        }
    }
}
