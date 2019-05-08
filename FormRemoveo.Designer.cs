namespace Removeo
{
    partial class FormRemoveo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRemoveo));
            this.buttonActivate = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonDeactivate = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonUpdateDomains = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonEditCustomDomains = new System.Windows.Forms.ToolStripMenuItem();
            this.disableDNSCacheServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCheckAds = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCheckTrackers = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCheckMalware = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCheckScams = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCheckTelemetry = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonActivate
            // 
            this.buttonActivate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.buttonActivate.Location = new System.Drawing.Point(12, 27);
            this.buttonActivate.Name = "buttonActivate";
            this.buttonActivate.Size = new System.Drawing.Size(263, 35);
            this.buttonActivate.TabIndex = 0;
            this.buttonActivate.Text = "Activate / Repair Removeo";
            this.buttonActivate.Click += new System.EventHandler(this.ButtonActivateClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 120);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(287, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelStatus
            // 
            this.labelStatus.ForeColor = System.Drawing.Color.Blue;
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(272, 17);
            this.labelStatus.Spring = true;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonDeactivate
            // 
            this.buttonDeactivate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.buttonDeactivate.Location = new System.Drawing.Point(12, 68);
            this.buttonDeactivate.Name = "buttonDeactivate";
            this.buttonDeactivate.Size = new System.Drawing.Size(263, 35);
            this.buttonDeactivate.TabIndex = 0;
            this.buttonDeactivate.Text = "Deactivate Removeo";
            this.buttonDeactivate.Click += new System.EventHandler(this.ButtonDeactivate_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(287, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonUpdateDomains,
            this.buttonEditCustomDomains,
            this.disableDNSCacheServiceToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // buttonUpdateDomains
            // 
            this.buttonUpdateDomains.Name = "buttonUpdateDomains";
            this.buttonUpdateDomains.Size = new System.Drawing.Size(212, 22);
            this.buttonUpdateDomains.Text = "Update domains file";
            this.buttonUpdateDomains.Click += new System.EventHandler(this.ButtonUpdateDomains_Click);
            // 
            // buttonEditCustomDomains
            // 
            this.buttonEditCustomDomains.Name = "buttonEditCustomDomains";
            this.buttonEditCustomDomains.Size = new System.Drawing.Size(212, 22);
            this.buttonEditCustomDomains.Text = "Edit custom domains";
            this.buttonEditCustomDomains.Click += new System.EventHandler(this.ButtonEditCustomDomains_Click);
            // 
            // disableDNSCacheServiceToolStripMenuItem
            // 
            this.disableDNSCacheServiceToolStripMenuItem.Name = "disableDNSCacheServiceToolStripMenuItem";
            this.disableDNSCacheServiceToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.disableDNSCacheServiceToolStripMenuItem.Text = "Disable DNS Client Service";
            this.disableDNSCacheServiceToolStripMenuItem.Click += new System.EventHandler(this.disableDNSCacheServiceToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonCheckAds,
            this.buttonCheckTrackers,
            this.buttonCheckMalware,
            this.buttonCheckScams,
            this.buttonCheckTelemetry});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // buttonCheckAds
            // 
            this.buttonCheckAds.CheckOnClick = true;
            this.buttonCheckAds.Name = "buttonCheckAds";
            this.buttonCheckAds.Size = new System.Drawing.Size(180, 22);
            this.buttonCheckAds.Tag = "ads";
            this.buttonCheckAds.Text = "Ads";
            this.buttonCheckAds.Click += new System.EventHandler(this.ButtonCheckClick);
            // 
            // buttonCheckTrackers
            // 
            this.buttonCheckTrackers.CheckOnClick = true;
            this.buttonCheckTrackers.Name = "buttonCheckTrackers";
            this.buttonCheckTrackers.Size = new System.Drawing.Size(180, 22);
            this.buttonCheckTrackers.Tag = "trackers";
            this.buttonCheckTrackers.Text = "Trackers";
            this.buttonCheckTrackers.Click += new System.EventHandler(this.ButtonCheckClick);
            // 
            // buttonCheckMalware
            // 
            this.buttonCheckMalware.CheckOnClick = true;
            this.buttonCheckMalware.Name = "buttonCheckMalware";
            this.buttonCheckMalware.Size = new System.Drawing.Size(180, 22);
            this.buttonCheckMalware.Tag = "malware";
            this.buttonCheckMalware.Text = "Malwares";
            this.buttonCheckMalware.Click += new System.EventHandler(this.ButtonCheckClick);
            // 
            // buttonCheckScams
            // 
            this.buttonCheckScams.CheckOnClick = true;
            this.buttonCheckScams.Name = "buttonCheckScams";
            this.buttonCheckScams.Size = new System.Drawing.Size(180, 22);
            this.buttonCheckScams.Tag = "scams";
            this.buttonCheckScams.Text = "Fraud";
            this.buttonCheckScams.Click += new System.EventHandler(this.ButtonCheckClick);
            // 
            // buttonCheckTelemetry
            // 
            this.buttonCheckTelemetry.CheckOnClick = true;
            this.buttonCheckTelemetry.Name = "buttonCheckTelemetry";
            this.buttonCheckTelemetry.Size = new System.Drawing.Size(180, 22);
            this.buttonCheckTelemetry.Tag = "telemetry";
            this.buttonCheckTelemetry.Text = "Telemetry";
            this.buttonCheckTelemetry.Click += new System.EventHandler(this.ButtonCheckClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.websiteToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.websiteToolStripMenuItem.Text = "Website";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.WebsiteToolStripMenuItem_Click);
            // 
            // FormRemoveo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 142);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonDeactivate);
            this.Controls.Add(this.buttonActivate);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormRemoveo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Removeo";
            this.Load += new System.EventHandler(this.FormRemoveoLoad);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonActivate;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.Button buttonDeactivate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonUpdateDomains;
        private System.Windows.Forms.ToolStripMenuItem buttonEditCustomDomains;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonCheckAds;
        private System.Windows.Forms.ToolStripMenuItem buttonCheckTrackers;
        private System.Windows.Forms.ToolStripMenuItem buttonCheckMalware;
        private System.Windows.Forms.ToolStripMenuItem buttonCheckScams;
        private System.Windows.Forms.ToolStripMenuItem buttonCheckTelemetry;
        private System.Windows.Forms.ToolStripMenuItem disableDNSCacheServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
    }
}

