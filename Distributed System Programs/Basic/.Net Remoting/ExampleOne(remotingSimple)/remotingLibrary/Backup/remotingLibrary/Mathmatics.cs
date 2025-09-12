using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace remotingLibrary
{
    public class Mathmatics : MarshalByRefObject
    {
        public int square(int x)/*Define one method that accept integer and square it and return the result */
        {
            MessageBox.Show("The Client has requested the serever with value " + x.ToString());/*This method will be shown in the server*/
            x = x * x;
            return x;/*This value will return to where we call the method*/
        }
    }
}
/*
 Here we build on class that we will register in the server and call this class remotely this class must inherit from MarshalByRefObject
 Class
 */
