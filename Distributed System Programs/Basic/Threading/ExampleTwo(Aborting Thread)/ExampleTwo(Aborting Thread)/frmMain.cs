using System;
using System.Windows.Forms;
using System.Threading;

namespace ExampleTwo_Aborting_Thread_
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        Thread thrdRunComputaion;

        private void btnStartThread_Click(object sender, EventArgs e)
        {
            thrdRunComputaion = new Thread(longComputaion);
            MessageBox.Show(thrdRunComputaion.ThreadState.ToString()); /*The Message will be "Unstarted"*/
            thrdRunComputaion.Start();
            MessageBox.Show(thrdRunComputaion.ThreadState.ToString()); /*The Message will be "Running"*/
        }

        private void btnAbortThread_Click(object sender, EventArgs e)
        {
            thrdRunComputaion.Abort(); /*Thrwo ThreadAbortException that Requesting Aborting the thread*/
            MessageBox.Show(thrdRunComputaion.ThreadState.ToString()); /*The Message will be "AbortRequested"*/
        }

        private void longComputaion()
        {
            while (true) ;
        }
    }
}