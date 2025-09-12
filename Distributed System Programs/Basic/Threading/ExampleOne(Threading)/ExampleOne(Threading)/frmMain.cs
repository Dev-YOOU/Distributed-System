using System;
using System.Windows.Forms;
using System.Threading; /*The namespace containing the Thread Class*/

namespace ExampleOne_Threading_
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnStartThread_Click(object sender, EventArgs e)
        {
            Thread thrdRunComputation = new Thread(longComputation); /*Defining a Thread Class that Execute longComputaion method*/
            thrdRunComputation.Start(); /*Running The Thread "Chnage the Thread state to ThreadState.Running") */
        }
        private void longComputation()
        {
            while (true) ; /*Infinit loop to represent long computation*/
        }        
    }
}