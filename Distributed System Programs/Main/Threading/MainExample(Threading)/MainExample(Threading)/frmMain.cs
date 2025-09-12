using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MainExample_Threading_
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        Thread thrdCountMethod;/*Dfine the thread public to access it form different buttons*/

        private void btnStart_Click(object sender, EventArgs e)
        {
            thrdCountMethod = new Thread(StartCount);/*Initialize a thread and pass the method we 
                                                      want the thread to execut*/
            thrdCountMethod.Start();/*start the thread(changet it's state to running)*/
        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            thrdCountMethod.Suspend();/* Suspend Thread until calling resume method agaist 
                                      same thread object*/
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            thrdCountMethod.Resume();/*Resume the Thread when it's Suspended*/
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            thrdCountMethod.Abort();/*Send Abort request most of the time calling this 
                                     method cause thread to stopp(Except if its in blocking
                                     like waiting for network input)*/
        }

        private void btnThreadState_Click(object sender, EventArgs e)
        {
           MessageBox.Show(thrdCountMethod.ThreadState.ToString());/*After every button call this method to show
                                                                    the Thread stat (running or suspended ...)
                                                                    try it out*/
        }

        private void StartCount()
        {
            /*calculat the next number in the thread and access the control safely by the mean thread illustrated in 
             basic example*/
            while (true)
            {
                string nextNumber = (int.Parse(lblCount.Text)+1).ToString();
                InvokingLabel invokingLabel = InvokinglblCount;
                this.Invoke(invokingLabel,nextNumber);
            }
        }

        private void InvokinglblCount(string param)
        {
            /*This method will execute by the main thread because we call it with apointer to it with the method Invoke
             the explain in the basic example*/
            lblCount.Text = param;
        }

        delegate void InvokingLabel(string inParam);/*delegate that will point to the method that the Invoke method 
                                                     will execute*/        
    }
}