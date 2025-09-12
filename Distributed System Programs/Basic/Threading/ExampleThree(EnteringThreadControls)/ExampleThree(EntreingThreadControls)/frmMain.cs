using System;
using System.Windows.Forms;
using System.Threading;

namespace ExampleThree_EntreingThreadControls_
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnStartCounting_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.Name = "Main Thread";/*Get the current Thread that executes this code and set its
                                                       name to Main thread "note this is the main thread and the 
                                                       controls that I add is bounded to this Thread" */

            Thread thrdStartCounting = new Thread(StartCount);/*Dfine Thread to execute the StartCount*/
            thrdStartCounting.Name = "StartCount Thread";/*Setting the thrdStartCounting Thread to StartCount Thread*/
            thrdStartCounting.Start();/*Start the Thread*/
        }
        private void StartCount()
        {
            /*
            MessageBox.Show(Thread.CurrentThread.Name);
            Uncomment the MessageBox to Show the name of thread executing the StartCount method
            */


            /* The first way is to access control directly
             Accessing the lblcount this way is unsafe because the lblCount label is bound to 
             the main thread 
            while (true)
            {
                lblCount.Text = ((int.Parse(lblCount.Text)+1).ToString());
            }
             */

            /*The second way is to access control with Invoke method this way is safe
             because the Main thread is the thread that access control             
             */
            while (true)
            {
                string inParam = ((int.Parse(lblCount.Text) + 1).ToString());/*Get the next number of 
                                                                               the number in the Text property
                                                                               of lblCount*/

                /*InvokingLabel(inParam)
                 * This code is unsafe because the thread that execute the InvokingLabel method is the same 
                 * thread that execute StartCount method
                 */

                Invokation InvokelblCount = InvokingLabel;/*make instance of Invokation delegate and 
                                                           make it point to InvokingLabel method*/

                this.Invoke(InvokelblCount, inParam);/*put the thread main to execute the method 
                                                      that InvokelblCount delegate point to (InvokeingLabel)
                                                      with parameters that I pass it in the second parameter list */
            }
        }
        private void InvokingLabel(string num)/*The method that will execute by the Invoke method to access the 
                                               control*/
        {
            /*
             MessageBox.Show(Thread.CurrentThread.Name);
             Uncomment the MessageBox to Show the Name of the Thread that Execute InvokingLabel method             
             */

            lblCount.Text = num;
        }
        

        private void btnProcessKill_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();/*Get the current process and kill it with all
                                                                   it's threads*/
        }
        
        delegate void Invokation(string inParam);/*Define a delegate with the same signature(params and return values)
                                                  of the method we want the Invoke method to execute*/
    }
}