namespace Dnn.BulkUserDelete.Console
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.btnPingAnon = new System.Windows.Forms.Button();
            this.txtLogOutput = new System.Windows.Forms.TextBox();
            this.txtPortalAlias = new System.Windows.Forms.TextBox();
            this.lblPortalAlias = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnPingHost = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsersDeleted = new System.Windows.Forms.TextBox();
            this.chkTestMode = new System.Windows.Forms.CheckBox();
            this.lblBatchLength = new System.Windows.Forms.Label();
            this.tckSpeed = new System.Windows.Forms.TrackBar();
            this.btnDeleteBatches = new System.Windows.Forms.Button();
            this.updBatchSize = new System.Windows.Forms.NumericUpDown();
            this.lblNumberToProcess = new System.Windows.Forms.Label();
            this.btnHardDeleteNextUser = new System.Windows.Forms.Button();
            this.btnCheckSoftDeletedUsers = new System.Windows.Forms.Button();
            this.timBatchTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemainingUsers = new System.Windows.Forms.TextBox();
            this.txtTimeToComplete = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkFastDelete = new System.Windows.Forms.CheckBox();
            this.ttpFastDelete = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tckSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updBatchSize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPingAnon
            // 
            this.btnPingAnon.Enabled = false;
            this.btnPingAnon.Location = new System.Drawing.Point(16, 59);
            this.btnPingAnon.Name = "btnPingAnon";
            this.btnPingAnon.Size = new System.Drawing.Size(141, 23);
            this.btnPingAnon.TabIndex = 0;
            this.btnPingAnon.Text = "Ping Anon";
            this.btnPingAnon.UseVisualStyleBackColor = true;
            this.btnPingAnon.Click += new System.EventHandler(this.btnPingAnon_Click);
            // 
            // txtLogOutput
            // 
            this.txtLogOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogOutput.Location = new System.Drawing.Point(163, 59);
            this.txtLogOutput.Multiline = true;
            this.txtLogOutput.Name = "txtLogOutput";
            this.txtLogOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogOutput.Size = new System.Drawing.Size(394, 361);
            this.txtLogOutput.TabIndex = 1;
            // 
            // txtPortalAlias
            // 
            this.txtPortalAlias.Location = new System.Drawing.Point(12, 32);
            this.txtPortalAlias.Name = "txtPortalAlias";
            this.txtPortalAlias.Size = new System.Drawing.Size(273, 20);
            this.txtPortalAlias.TabIndex = 2;
            this.txtPortalAlias.TextChanged += new System.EventHandler(this.txtPortalAlias_TextChanged);
            // 
            // lblPortalAlias
            // 
            this.lblPortalAlias.AutoSize = true;
            this.lblPortalAlias.Location = new System.Drawing.Point(13, 13);
            this.lblPortalAlias.Name = "lblPortalAlias";
            this.lblPortalAlias.Size = new System.Drawing.Size(50, 13);
            this.lblPortalAlias.TabIndex = 3;
            this.lblPortalAlias.Text = "Site Alias";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(296, 13);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(58, 13);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "Username:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(299, 32);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(408, 32);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(149, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(405, 13);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password:";
            // 
            // btnPingHost
            // 
            this.btnPingHost.Enabled = false;
            this.btnPingHost.Location = new System.Drawing.Point(16, 88);
            this.btnPingHost.Name = "btnPingHost";
            this.btnPingHost.Size = new System.Drawing.Size(141, 23);
            this.btnPingHost.TabIndex = 8;
            this.btnPingHost.Text = "Ping Host";
            this.btnPingHost.UseVisualStyleBackColor = true;
            this.btnPingHost.Click += new System.EventHandler(this.btnPingHost_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkFastDelete);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTimeToComplete);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRemainingUsers);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUsersDeleted);
            this.groupBox1.Controls.Add(this.chkTestMode);
            this.groupBox1.Controls.Add(this.lblBatchLength);
            this.groupBox1.Controls.Add(this.tckSpeed);
            this.groupBox1.Controls.Add(this.btnDeleteBatches);
            this.groupBox1.Controls.Add(this.updBatchSize);
            this.groupBox1.Controls.Add(this.lblNumberToProcess);
            this.groupBox1.Controls.Add(this.btnHardDeleteNextUser);
            this.groupBox1.Location = new System.Drawing.Point(5, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 274);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delete Actions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Users Deleted:";
            // 
            // txtUsersDeleted
            // 
            this.txtUsersDeleted.Location = new System.Drawing.Point(79, 201);
            this.txtUsersDeleted.Name = "txtUsersDeleted";
            this.txtUsersDeleted.Size = new System.Drawing.Size(62, 20);
            this.txtUsersDeleted.TabIndex = 19;
            // 
            // chkTestMode
            // 
            this.chkTestMode.AutoSize = true;
            this.chkTestMode.Checked = true;
            this.chkTestMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTestMode.Location = new System.Drawing.Point(7, 46);
            this.chkTestMode.Name = "chkTestMode";
            this.chkTestMode.Size = new System.Drawing.Size(123, 17);
            this.chkTestMode.TabIndex = 18;
            this.chkTestMode.Text = "Test Mode (rollback)";
            this.chkTestMode.UseVisualStyleBackColor = true;
            // 
            // lblBatchLength
            // 
            this.lblBatchLength.AutoSize = true;
            this.lblBatchLength.Location = new System.Drawing.Point(10, 185);
            this.lblBatchLength.Name = "lblBatchLength";
            this.lblBatchLength.Size = new System.Drawing.Size(136, 13);
            this.lblBatchLength.TabIndex = 17;
            this.lblBatchLength.Text = "Seconds Between Batches";
            // 
            // tckSpeed
            // 
            this.tckSpeed.Location = new System.Drawing.Point(5, 150);
            this.tckSpeed.Maximum = 31;
            this.tckSpeed.Minimum = 1;
            this.tckSpeed.Name = "tckSpeed";
            this.tckSpeed.Size = new System.Drawing.Size(139, 45);
            this.tckSpeed.TabIndex = 16;
            this.tckSpeed.TickFrequency = 5;
            this.tckSpeed.Value = 6;
            this.tckSpeed.Scroll += new System.EventHandler(this.tckSpeed_Scroll);
            // 
            // btnDeleteBatches
            // 
            this.btnDeleteBatches.Enabled = false;
            this.btnDeleteBatches.Location = new System.Drawing.Point(2, 121);
            this.btnDeleteBatches.Name = "btnDeleteBatches";
            this.btnDeleteBatches.Size = new System.Drawing.Size(141, 23);
            this.btnDeleteBatches.TabIndex = 15;
            this.btnDeleteBatches.Text = "Start Deleting Batches";
            this.btnDeleteBatches.UseVisualStyleBackColor = true;
            this.btnDeleteBatches.Click += new System.EventHandler(this.btnDeleteBatches_Click);
            // 
            // updBatchSize
            // 
            this.updBatchSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updBatchSize.Location = new System.Drawing.Point(98, 20);
            this.updBatchSize.Name = "updBatchSize";
            this.updBatchSize.Size = new System.Drawing.Size(43, 20);
            this.updBatchSize.TabIndex = 14;
            this.updBatchSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblNumberToProcess
            // 
            this.lblNumberToProcess.AutoSize = true;
            this.lblNumberToProcess.Location = new System.Drawing.Point(3, 22);
            this.lblNumberToProcess.Name = "lblNumberToProcess";
            this.lblNumberToProcess.Size = new System.Drawing.Size(100, 13);
            this.lblNumberToProcess.TabIndex = 13;
            this.lblNumberToProcess.Text = "Number to Process:";
            // 
            // btnHardDeleteNextUser
            // 
            this.btnHardDeleteNextUser.Enabled = false;
            this.btnHardDeleteNextUser.Location = new System.Drawing.Point(2, 90);
            this.btnHardDeleteNextUser.Name = "btnHardDeleteNextUser";
            this.btnHardDeleteNextUser.Size = new System.Drawing.Size(141, 23);
            this.btnHardDeleteNextUser.TabIndex = 12;
            this.btnHardDeleteNextUser.Text = "Hard Delete 1 Batch";
            this.btnHardDeleteNextUser.UseVisualStyleBackColor = true;
            this.btnHardDeleteNextUser.Click += new System.EventHandler(this.btnHardDeleteNextUser_Click_1);
            // 
            // btnCheckSoftDeletedUsers
            // 
            this.btnCheckSoftDeletedUsers.Enabled = false;
            this.btnCheckSoftDeletedUsers.Location = new System.Drawing.Point(16, 117);
            this.btnCheckSoftDeletedUsers.Name = "btnCheckSoftDeletedUsers";
            this.btnCheckSoftDeletedUsers.Size = new System.Drawing.Size(141, 23);
            this.btnCheckSoftDeletedUsers.TabIndex = 11;
            this.btnCheckSoftDeletedUsers.Text = "Check Soft Deleted Users";
            this.btnCheckSoftDeletedUsers.UseVisualStyleBackColor = true;
            this.btnCheckSoftDeletedUsers.Click += new System.EventHandler(this.btnCheckSoftDeletedUsers_Click_1);
            // 
            // timBatchTimer
            // 
            this.timBatchTimer.Interval = 1000;
            this.timBatchTimer.Tick += new System.EventHandler(this.timBatchTimer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Remaining:";
            // 
            // txtRemainingUsers
            // 
            this.txtRemainingUsers.Location = new System.Drawing.Point(79, 225);
            this.txtRemainingUsers.Name = "txtRemainingUsers";
            this.txtRemainingUsers.Size = new System.Drawing.Size(62, 20);
            this.txtRemainingUsers.TabIndex = 21;
            // 
            // txtTimeToComplete
            // 
            this.txtTimeToComplete.Location = new System.Drawing.Point(79, 246);
            this.txtTimeToComplete.Name = "txtTimeToComplete";
            this.txtTimeToComplete.Size = new System.Drawing.Size(62, 20);
            this.txtTimeToComplete.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Est. Complete:";
            // 
            // chkFastDelete
            // 
            this.chkFastDelete.AutoSize = true;
            this.chkFastDelete.Checked = true;
            this.chkFastDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFastDelete.Location = new System.Drawing.Point(6, 67);
            this.chkFastDelete.Name = "chkFastDelete";
            this.chkFastDelete.Size = new System.Drawing.Size(102, 17);
            this.chkFastDelete.TabIndex = 26;
            this.chkFastDelete.Text = "Use Fast Delete";
            this.ttpFastDelete.SetToolTip(this.chkFastDelete, "Fast Delete uses direct path and datbase access to delete a folder.  Use this mod" +
        "e for faster execution and when Folder Providers are not being used (User Folder" +
        "s are stored on local storage of site)");
            this.chkFastDelete.UseVisualStyleBackColor = true;
            this.chkFastDelete.CheckedChanged += new System.EventHandler(this.chkFastDelete_CheckedChanged);
            // 
            // ttpFastDelete
            // 
            this.ttpFastDelete.ToolTipTitle = "Help";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 432);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPingHost);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnCheckSoftDeletedUsers);
            this.Controls.Add(this.lblPortalAlias);
            this.Controls.Add(this.txtPortalAlias);
            this.Controls.Add(this.txtLogOutput);
            this.Controls.Add(this.btnPingAnon);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Dnn Bulk User Delete";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tckSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updBatchSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPingAnon;
        private System.Windows.Forms.TextBox txtLogOutput;
        private System.Windows.Forms.TextBox txtPortalAlias;
        private System.Windows.Forms.Label lblPortalAlias;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnPingHost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBatchLength;
        private System.Windows.Forms.TrackBar tckSpeed;
        private System.Windows.Forms.Button btnDeleteBatches;
        private System.Windows.Forms.NumericUpDown updBatchSize;
        private System.Windows.Forms.Label lblNumberToProcess;
        private System.Windows.Forms.Button btnHardDeleteNextUser;
        private System.Windows.Forms.Button btnCheckSoftDeletedUsers;
        private System.Windows.Forms.Timer timBatchTimer;
        private System.Windows.Forms.CheckBox chkTestMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsersDeleted;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimeToComplete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemainingUsers;
        private System.Windows.Forms.CheckBox chkFastDelete;
        private System.Windows.Forms.ToolTip ttpFastDelete;
    }
}

