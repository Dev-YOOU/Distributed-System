namespace Client
{
    partial class frmMainClient
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
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtFileRequested = new System.Windows.Forms.TextBox();
            this.lstFetchedFiles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Location = new System.Drawing.Point(12, 12);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(86, 23);
            this.btnSendRequest.TabIndex = 0;
            this.btnSendRequest.Text = "Send Request";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(104, 15);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(168, 20);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.Text = "127.0.0.1";
            // 
            // txtFileRequested
            // 
            this.txtFileRequested.Location = new System.Drawing.Point(12, 50);
            this.txtFileRequested.Name = "txtFileRequested";
            this.txtFileRequested.Size = new System.Drawing.Size(260, 20);
            this.txtFileRequested.TabIndex = 2;
            this.txtFileRequested.Text = "C:\\Head.pdf";
            // 
            // lstFetchedFiles
            // 
            this.lstFetchedFiles.FormattingEnabled = true;
            this.lstFetchedFiles.Location = new System.Drawing.Point(12, 76);
            this.lstFetchedFiles.Name = "lstFetchedFiles";
            this.lstFetchedFiles.Size = new System.Drawing.Size(260, 173);
            this.lstFetchedFiles.TabIndex = 3;
            // 
            // frmMainClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lstFetchedFiles);
            this.Controls.Add(this.txtFileRequested);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnSendRequest);
            this.Name = "frmMainClient";
            this.Text = "Main Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainClient_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtFileRequested;
        private System.Windows.Forms.ListBox lstFetchedFiles;
    }
}

