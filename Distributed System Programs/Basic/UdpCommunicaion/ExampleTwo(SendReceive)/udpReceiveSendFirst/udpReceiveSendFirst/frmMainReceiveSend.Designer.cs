namespace udpReceiveSendFirst
{
    partial class frmMainReceiveSend
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
            this.btnReceiveSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReceiveSend
            // 
            this.btnReceiveSend.Location = new System.Drawing.Point(12, 12);
            this.btnReceiveSend.Name = "btnReceiveSend";
            this.btnReceiveSend.Size = new System.Drawing.Size(75, 37);
            this.btnReceiveSend.TabIndex = 0;
            this.btnReceiveSend.Text = "Receive Send";
            this.btnReceiveSend.UseVisualStyleBackColor = true;
            this.btnReceiveSend.Click += new System.EventHandler(this.btnReceiveSend_Click);
            // 
            // frmMainReceiveSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnReceiveSend);
            this.Name = "frmMainReceiveSend";
            this.Text = "Main Receive Send";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReceiveSend;
    }
}

