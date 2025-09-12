using System;
using System.Text;
using System.Windows.Forms;
using System.Threading; /*The namespace containing the Thread Class*/


namespace ExampleFour_ParameterizedThread_
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnStartParameterizedThread_Click(object sender, EventArgs e)
        {
            Thread thrdShowMessage = new Thread(ShowMessage);/*The method passed here must be one of two types
                                                              one : don't take any parametrs
                                                              second : take an object as a parameter
                                                              * but always do not return an value*/
            thrdShowMessage.Name = "thrShowMessage";/*Setting the name of the thread*/
            thrdShowMessage.Start("Hello from ");/*Here we pass the parameter to the method */
            //ShowMessage("Hello from ");
        }
        private void ShowMessage(Object O )
        {
            string strngIn = (string)O;/*casting the object to string*/
            MessageBox.Show(strngIn+Thread.CurrentThread.Name);/*Show the string receive plus thread name*/
        }
    }
}
/*
 Note that we can after pressing the button btnStartParameterizedThread access the form again withot click Ok button of the message
 This because the MessageBox in separate thread of the main thread try to call method ShowMessage directly on the button btnStartParameterizedThread
 Can you in this case access the form just uncomment lin 24 and comment line 23 and see the results.
 */