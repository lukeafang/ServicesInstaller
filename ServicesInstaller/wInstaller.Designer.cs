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
            this.txtServiceInstalled = new System.Windows.Forms.TextBox();
            this.lblServiceInstalled = new System.Windows.Forms.Label();
            this.txtServiceInstalledVersion = new System.Windows.Forms.TextBox();
            this.lblServiceInstalledVersion = new System.Windows.Forms.Label();
            this.txtServiceInstalledPath = new System.Windows.Forms.TextBox();
            this.lblServiceInstalledPath = new System.Windows.Forms.Label();
            this.txtProcessOutput = new System.Windows.Forms.TextBox();
            this.btnStopService = new System.Windows.Forms.Button();
            this.btnStartService = new System.Windows.Forms.Button();
            this.btnRestartService = new System.Windows.Forms.Button();
            this.btnReadEventLog = new System.Windows.Forms.Button();
            this.btnClearEventLog = new System.Windows.Forms.Button();
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
            this.txtServiceVersion.Location = new System.Drawing.Point(99, 44);
            this.txtServiceVersion.Name = "txtServiceVersion";
            this.txtServiceVersion.ReadOnly = true;
            this.txtServiceVersion.Size = new System.Drawing.Size(100, 20);
            this.txtServiceVersion.TabIndex = 3;
            // 
            // lblInstallerVersion
            // 
            this.lblInstallerVersion.AutoSize = true;
            this.lblInstallerVersion.Location = new System.Drawing.Point(12, 352);
            this.lblInstallerVersion.Name = "lblInstallerVersion";
            this.lblInstallerVersion.Size = new System.Drawing.Size(56, 13);
            this.lblInstallerVersion.TabIndex = 4;
            this.lblInstallerVersion.Text = "Version: {}";
            // 
            // btnServiceInstall
            // 
            this.btnServiceInstall.Location = new System.Drawing.Point(22, 185);
            this.btnServiceInstall.Name = "btnServiceInstall";
            this.btnServiceInstall.Size = new System.Drawing.Size(88, 37);
            this.btnServiceInstall.TabIndex = 5;
            this.btnServiceInstall.Text = "Install";
            this.btnServiceInstall.UseVisualStyleBackColor = true;
            this.btnServiceInstall.Click += new System.EventHandler(this.btnServiceInstall_Click);
            // 
            // btnServiceUninstall
            // 
            this.btnServiceUninstall.Location = new System.Drawing.Point(116, 185);
            this.btnServiceUninstall.Name = "btnServiceUninstall";
            this.btnServiceUninstall.Size = new System.Drawing.Size(88, 37);
            this.btnServiceUninstall.TabIndex = 6;
            this.btnServiceUninstall.Text = "Uninstall";
            this.btnServiceUninstall.UseVisualStyleBackColor = true;
            this.btnServiceUninstall.Click += new System.EventHandler(this.btnServiceUninstall_Click);
            // 
            // txtServiceStatus
            // 
            this.txtServiceStatus.Location = new System.Drawing.Point(99, 96);
            this.txtServiceStatus.Name = "txtServiceStatus";
            this.txtServiceStatus.ReadOnly = true;
            this.txtServiceStatus.Size = new System.Drawing.Size(100, 20);
            this.txtServiceStatus.TabIndex = 8;
            // 
            // lblServiceStatus
            // 
            this.lblServiceStatus.AutoSize = true;
            this.lblServiceStatus.Location = new System.Drawing.Point(53, 96);
            this.lblServiceStatus.Name = "lblServiceStatus";
            this.lblServiceStatus.Size = new System.Drawing.Size(40, 13);
            this.lblServiceStatus.TabIndex = 7;
            this.lblServiceStatus.Text = "Status:";
            // 
            // txtServiceInstalled
            // 
            this.txtServiceInstalled.Location = new System.Drawing.Point(99, 70);
            this.txtServiceInstalled.Name = "txtServiceInstalled";
            this.txtServiceInstalled.ReadOnly = true;
            this.txtServiceInstalled.Size = new System.Drawing.Size(100, 20);
            this.txtServiceInstalled.TabIndex = 10;
            // 
            // lblServiceInstalled
            // 
            this.lblServiceInstalled.AutoSize = true;
            this.lblServiceInstalled.Location = new System.Drawing.Point(44, 70);
            this.lblServiceInstalled.Name = "lblServiceInstalled";
            this.lblServiceInstalled.Size = new System.Drawing.Size(49, 13);
            this.lblServiceInstalled.TabIndex = 9;
            this.lblServiceInstalled.Text = "Installed:";
            // 
            // txtServiceInstalledVersion
            // 
            this.txtServiceInstalledVersion.Location = new System.Drawing.Point(99, 122);
            this.txtServiceInstalledVersion.Name = "txtServiceInstalledVersion";
            this.txtServiceInstalledVersion.ReadOnly = true;
            this.txtServiceInstalledVersion.Size = new System.Drawing.Size(100, 20);
            this.txtServiceInstalledVersion.TabIndex = 12;
            // 
            // lblServiceInstalledVersion
            // 
            this.lblServiceInstalledVersion.AutoSize = true;
            this.lblServiceInstalledVersion.Location = new System.Drawing.Point(6, 122);
            this.lblServiceInstalledVersion.Name = "lblServiceInstalledVersion";
            this.lblServiceInstalledVersion.Size = new System.Drawing.Size(87, 13);
            this.lblServiceInstalledVersion.TabIndex = 11;
            this.lblServiceInstalledVersion.Text = "Installed Version:";
            // 
            // txtServiceInstalledPath
            // 
            this.txtServiceInstalledPath.Location = new System.Drawing.Point(99, 148);
            this.txtServiceInstalledPath.Name = "txtServiceInstalledPath";
            this.txtServiceInstalledPath.ReadOnly = true;
            this.txtServiceInstalledPath.Size = new System.Drawing.Size(215, 20);
            this.txtServiceInstalledPath.TabIndex = 14;
            // 
            // lblServiceInstalledPath
            // 
            this.lblServiceInstalledPath.AutoSize = true;
            this.lblServiceInstalledPath.Location = new System.Drawing.Point(19, 148);
            this.lblServiceInstalledPath.Name = "lblServiceInstalledPath";
            this.lblServiceInstalledPath.Size = new System.Drawing.Size(74, 13);
            this.lblServiceInstalledPath.TabIndex = 13;
            this.lblServiceInstalledPath.Text = "Installed Path:";
            // 
            // txtProcessOutput
            // 
            this.txtProcessOutput.Location = new System.Drawing.Point(335, 13);
            this.txtProcessOutput.Multiline = true;
            this.txtProcessOutput.Name = "txtProcessOutput";
            this.txtProcessOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProcessOutput.Size = new System.Drawing.Size(483, 337);
            this.txtProcessOutput.TabIndex = 15;
            // 
            // btnStopService
            // 
            this.btnStopService.Location = new System.Drawing.Point(209, 233);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(88, 37);
            this.btnStopService.TabIndex = 17;
            this.btnStopService.Text = "Stop";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(115, 233);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(88, 37);
            this.btnStartService.TabIndex = 16;
            this.btnStartService.Text = "Start";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnRestartService
            // 
            this.btnRestartService.Location = new System.Drawing.Point(21, 233);
            this.btnRestartService.Name = "btnRestartService";
            this.btnRestartService.Size = new System.Drawing.Size(88, 37);
            this.btnRestartService.TabIndex = 18;
            this.btnRestartService.Text = "Restart";
            this.btnRestartService.UseVisualStyleBackColor = true;
            this.btnRestartService.Click += new System.EventHandler(this.btnRestartService_Click);
            // 
            // btnReadEventLog
            // 
            this.btnReadEventLog.Location = new System.Drawing.Point(22, 285);
            this.btnReadEventLog.Name = "btnReadEventLog";
            this.btnReadEventLog.Size = new System.Drawing.Size(88, 37);
            this.btnReadEventLog.TabIndex = 19;
            this.btnReadEventLog.Text = "Read Log";
            this.btnReadEventLog.UseVisualStyleBackColor = true;
            this.btnReadEventLog.Click += new System.EventHandler(this.btnReadEventLog_Click);
            // 
            // btnClearEventLog
            // 
            this.btnClearEventLog.Location = new System.Drawing.Point(116, 285);
            this.btnClearEventLog.Name = "btnClearEventLog";
            this.btnClearEventLog.Size = new System.Drawing.Size(88, 37);
            this.btnClearEventLog.TabIndex = 20;
            this.btnClearEventLog.Text = "Clear Log";
            this.btnClearEventLog.UseVisualStyleBackColor = true;
            this.btnClearEventLog.Click += new System.EventHandler(this.btnClearEventLog_Click);
            // 
            // wInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 374);
            this.Controls.Add(this.btnClearEventLog);
            this.Controls.Add(this.btnReadEventLog);
            this.Controls.Add(this.btnRestartService);
            this.Controls.Add(this.btnStopService);
            this.Controls.Add(this.btnStartService);
            this.Controls.Add(this.txtProcessOutput);
            this.Controls.Add(this.txtServiceInstalledPath);
            this.Controls.Add(this.lblServiceInstalledPath);
            this.Controls.Add(this.txtServiceInstalledVersion);
            this.Controls.Add(this.lblServiceInstalledVersion);
            this.Controls.Add(this.txtServiceInstalled);
            this.Controls.Add(this.lblServiceInstalled);
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
        private System.Windows.Forms.TextBox txtServiceInstalled;
        private System.Windows.Forms.Label lblServiceInstalled;
        private System.Windows.Forms.TextBox txtServiceInstalledVersion;
        private System.Windows.Forms.Label lblServiceInstalledVersion;
        private System.Windows.Forms.TextBox txtServiceInstalledPath;
        private System.Windows.Forms.Label lblServiceInstalledPath;
        private System.Windows.Forms.TextBox txtProcessOutput;
        private System.Windows.Forms.Button btnStopService;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.Button btnRestartService;
        private System.Windows.Forms.Button btnReadEventLog;
        private System.Windows.Forms.Button btnClearEventLog;
    }
}

