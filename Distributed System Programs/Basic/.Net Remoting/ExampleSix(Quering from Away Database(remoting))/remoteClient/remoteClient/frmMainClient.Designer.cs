namespace remoteClient
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
            this.btnRequestService = new System.Windows.Forms.Button();
            this.dgvReceivedData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceivedData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRequestService
            // 
            this.btnRequestService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequestService.Location = new System.Drawing.Point(360, 316);
            this.btnRequestService.Name = "btnRequestService";
            this.btnRequestService.Size = new System.Drawing.Size(101, 23);
            this.btnRequestService.TabIndex = 0;
            this.btnRequestService.Text = "Request Service";
            this.btnRequestService.UseVisualStyleBackColor = true;
            this.btnRequestService.Click += new System.EventHandler(this.btnRequestService_Click);
            // 
            // dgvReceivedData
            // 
            this.dgvReceivedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceivedData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceivedData.Location = new System.Drawing.Point(0, 0);
            this.dgvReceivedData.Name = "dgvReceivedData";
            this.dgvReceivedData.Size = new System.Drawing.Size(484, 361);
            this.dgvReceivedData.TabIndex = 1;
            // 
            // frmMainClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.btnRequestService);
            this.Controls.Add(this.dgvReceivedData);
            this.Name = "frmMainClient";
            this.Text = "Main Client";
            this.Load += new System.EventHandler(this.frmMainClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceivedData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRequestService;
        private System.Windows.Forms.DataGridView dgvReceivedData;
    }
}

