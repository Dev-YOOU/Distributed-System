namespace ExampleTwo_Aborting_Thread_
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartThread = new System.Windows.Forms.Button();
            this.btnAbortThread = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartThread
            // 
            this.btnStartThread.Location = new System.Drawing.Point(12, 12);
            this.btnStartThread.Name = "btnStartThread";
            this.btnStartThread.Size = new System.Drawing.Size(81, 23);
            this.btnStartThread.TabIndex = 0;
            this.btnStartThread.Text = "Start Thread";
            this.btnStartThread.UseVisualStyleBackColor = true;
            this.btnStartThread.Click += new System.EventHandler(this.btnStartThread_Click);
            // 
            // btnAbortThread
            // 
            this.btnAbortThread.Location = new System.Drawing.Point(99, 12);
            this.btnAbortThread.Name = "btnAbortThread";
            this.btnAbortThread.Size = new System.Drawing.Size(86, 23);
            this.btnAbortThread.TabIndex = 1;
            this.btnAbortThread.Text = "Abort Thread";
            this.btnAbortThread.UseVisualStyleBackColor = true;
            this.btnAbortThread.Click += new System.EventHandler(this.btnAbortThread_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 68);
            this.Controls.Add(this.btnAbortThread);
            this.Controls.Add(this.btnStartThread);
            this.Name = "frmMain";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartThread;
        private System.Windows.Forms.Button btnAbortThread;
    }
}

