using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace remotingLibrary
{
    public class Invokations : MarshalByRefObject
    {
        public int Count(string sender)
        {
            invokationCount++;/*Increase the invokationCount every method call*/
            MessageBox.Show("The server has been called from: " + sender);            
            return invokationCount;/*Return the number of invokation times*/
        }
        int invokationCount;/*Define a public variable to indicate if the server reinstatiated every
                             method call or not*/
    }
}
