using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace remotingLibrary
{
    public class Mathmatics : MarshalByRefObject
    {
        public int square(int x)
        {
            MessageBox.Show("The Client has requested the serever with value " + x.ToString());
            x = x * x;
            return x;
        }
    }
}
