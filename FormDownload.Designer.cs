namespace Removeo
{
    partial class FormDownload
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
            this.downloadBar = new System.Windows.Forms.ProgressBar();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.downloadStatus = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // downloadBar
            // 
            this.downloadBar.Location = new System.Drawing.Point(0, 14);
            this.downloadBar.Name = "downloadBar";
            this.downloadBar.Size = new System.Drawing.Size(254, 24);
            this.downloadBar.Step = 5;
            this.downloadBar.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(256, 14);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(26, 24);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "X";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // downloadStatus
            // 
            this.downloadStatus.Location = new System.Drawing.Point(0, 38);
            this.downloadStatus.Name = "downloadStatus";
            this.downloadStatus.Size = new System.Drawing.Size(282, 12);
            this.downloadStatus.TabIndex = 3;
            this.downloadStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(0, 2);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(282, 12);
            this.fileName.TabIndex = 3;
            this.fileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 52);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.downloadStatus);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.downloadBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDownload";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar downloadBar;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label downloadStatus;
        private System.Windows.Forms.Label fileName;
    }
}