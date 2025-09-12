namespace ExampleThree_EntreingThreadControls_
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
            this.btnStartCounting = new System.Windows.Forms.Button();
            this.btnProcessKill = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartCounting
            // 
            this.btnStartCounting.Location = new System.Drawing.Point(12, 12);
            this.btnStartCounting.Name = "btnStartCounting";
            this.btnStartCounting.Size = new System.Drawing.Size(86, 23);
            this.btnStartCounting.TabIndex = 0;
            this.btnStartCounting.Text = "Start Counting";
            this.btnStartCounting.UseVisualStyleBackColor = true;
            this.btnStartCounting.Click += new System.EventHandler(this.btnStartCounting_Click);
            // 
            // btnProcessKill
            // 
            this.btnProcessKill.Location = new System.Drawing.Point(148, 12);
            this.btnProcessKill.Name = "btnProcessKill";
            this.btnProcessKill.Size = new System.Drawing.Size(75, 23);
            this.btnProcessKill.TabIndex = 1;
            this.btnProcessKill.Text = "Kill Process";
            this.btnProcessKill.UseVisualStyleBackColor = true;
            this.btnProcessKill.Click += new System.EventHandler(this.btnProcessKill_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(96, 72);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 94);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnProcessKill);
            this.Controls.Add(this.btnStartCounting);
            this.Name = "frmMain";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartCounting;
        private System.Windows.Forms.Button btnProcessKill;
        private System.Windows.Forms.Label lblCount;
    }
}

