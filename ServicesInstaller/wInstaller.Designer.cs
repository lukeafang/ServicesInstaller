namespace ServicesInstaller
{
    partial class wInstaller
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
            this.lblServiceName = new System.Windows.Forms.Label();
            this.cbServiceName = new System.Windows.Forms.ComboBox();
            this.lblServiceVersion = new System.Windows.Forms.Label();
            this.txtServiceVersion = new System.Windows.Forms.TextBox();
            this.lblInstallerVersion = new System.Windows.Forms.Label();
            this.btnServiceInstall = new System.Windows.Forms.Button();
            this.btnServiceUninstall = new System.Windows.Forms.Button();
            this.txtServiceStatus = new System.Windows.Forms.TextBox();
            this.lblServiceStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblServiceName
            // 
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.Location = new System.Drawing.Point(16, 20);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(77, 13);
            this.lblServiceName.TabIndex = 0;
            this.lblServiceName.Text = "Service Name:";
            // 
            // cbServiceName
            // 
            this.cbServiceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbServiceName.FormattingEnabled = true;
            this.cbServiceName.Location = new System.Drawing.Point(99, 17);
            this.cbServiceName.Name = "cbServiceName";
            this.cbServiceName.Size = new System.Drawing.Size(100, 21);
            this.cbServiceName.TabIndex = 1;
            this.cbServiceName.SelectedIndexChanged += new System.EventHandler(this.cbServiceName_SelectedIndexChanged);
            // 
            // lblServiceVersion
            // 
            this.lblServiceVersion.AutoSize = true;
            this.lblServiceVersion.Location = new System.Drawing.Point(48, 47);
            this.lblServiceVersion.Name = "lblServiceVersion";
            this.lblServiceVersion.Size = new System.Drawing.Size(45, 13);
            this.lblServiceVersion.TabIndex = 2;
            this.lblServiceVersion.Text = "Version:";
            // 
            // txtServiceVersion
            // 
            this.txtServiceVersion.Enabled = false;
            this.txtServiceVersion.Location = new System.Drawing.Point(99, 44);
            this.txtServiceVersion.Name = "txtServiceVersion";
            this.txtServiceVersion.Size = new System.Drawing.Size(100, 20);
            this.txtServiceVersion.TabIndex = 3;
            // 
            // lblInstallerVersion
            // 
            this.lblInstallerVersion.AutoSize = true;
            this.lblInstallerVersion.Location = new System.Drawing.Point(13, 279);
            this.lblInstallerVersion.Name = "lblInstallerVersion";
            this.lblInstallerVersion.Size = new System.Drawing.Size(56, 13);
            this.lblInstallerVersion.TabIndex = 4;
            this.lblInstallerVersion.Text = "Version: {}";
            // 
            // btnServiceInstall
            // 
            this.btnServiceInstall.Location = new System.Drawing.Point(19, 111);
            this.btnServiceInstall.Name = "btnServiceInstall";
            this.btnServiceInstall.Size = new System.Drawing.Size(88, 37);
            this.btnServiceInstall.TabIndex = 5;
            this.btnServiceInstall.Text = "Install";
            this.btnServiceInstall.UseVisualStyleBackColor = true;
            this.btnServiceInstall.Click += new System.EventHandler(this.btnServiceInstall_Click);
            // 
            // btnServiceUninstall
            // 
            this.btnServiceUninstall.Location = new System.Drawing.Point(113, 111);
            this.btnServiceUninstall.Name = "btnServiceUninstall";
            this.btnServiceUninstall.Size = new System.Drawing.Size(88, 37);
            this.btnServiceUninstall.TabIndex = 6;
            this.btnServiceUninstall.Text = "Uninstall";
            this.btnServiceUninstall.UseVisualStyleBackColor = true;
            this.btnServiceUninstall.Click += new System.EventHandler(this.btnServiceUninstall_Click);
            // 
            // txtServiceStatus
            // 
            this.txtServiceStatus.Enabled = false;
            this.txtServiceStatus.Location = new System.Drawing.Point(99, 70);
            this.txtServiceStatus.Name = "txtServiceStatus";
            this.txtServiceStatus.Size = new System.Drawing.Size(100, 20);
            this.txtServiceStatus.TabIndex = 8;
            // 
            // lblServiceStatus
            // 
            this.lblServiceStatus.AutoSize = true;
            this.lblServiceStatus.Location = new System.Drawing.Point(53, 70);
            this.lblServiceStatus.Name = "lblServiceStatus";
            this.lblServiceStatus.Size = new System.Drawing.Size(40, 13);
            this.lblServiceStatus.TabIndex = 7;
            this.lblServiceStatus.Text = "Status:";
            // 
            // wInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 305);
            this.Controls.Add(this.txtServiceStatus);
            this.Controls.Add(this.lblServiceStatus);
            this.Controls.Add(this.btnServiceUninstall);
            this.Controls.Add(this.btnServiceInstall);
            this.Controls.Add(this.lblInstallerVersion);
            this.Controls.Add(this.txtServiceVersion);
            this.Controls.Add(this.lblServiceVersion);
            this.Controls.Add(this.cbServiceName);
            this.Controls.Add(this.lblServiceName);
            this.Name = "wInstaller";
            this.Text = "Services Installer";
            this.Shown += new System.EventHandler(this.wInstaller_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.ComboBox cbServiceName;
        private System.Windows.Forms.Label lblServiceVersion;
        private System.Windows.Forms.TextBox txtServiceVersion;
        private System.Windows.Forms.Label lblInstallerVersion;
        private System.Windows.Forms.Button btnServiceInstall;
        private System.Windows.Forms.Button btnServiceUninstall;
        private System.Windows.Forms.TextBox txtServiceStatus;
        private System.Windows.Forms.Label lblServiceStatus;
    }
}

