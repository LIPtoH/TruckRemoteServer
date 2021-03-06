﻿namespace TruckRemoteServer
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpPort = new System.Windows.Forms.NumericUpDown();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelIp = new System.Windows.Forms.Label();
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonStartStopServer = new System.Windows.Forms.Button();
            this.contextMenuStripNotifyIconTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.StartStopServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMainMenu = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlMappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpPort)).BeginInit();
            this.menuStripMainMenu.SuspendLayout();
            this.contextMenuStripNotifyIconTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(136, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server status:";
            // 
            // numericUpPort
            // 
            this.numericUpPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpPort.Location = new System.Drawing.Point(139, 56);
            this.numericUpPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpPort.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpPort.Name = "numericUpPort";
            this.numericUpPort.Size = new System.Drawing.Size(68, 22);
            this.numericUpPort.TabIndex = 3;
            this.numericUpPort.Value = new decimal(new int[] {
            18250,
            0,
            0,
            0});
            this.numericUpPort.ValueChanged += new System.EventHandler(this.NumericUpPort_ValueChanged);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.ForeColor = System.Drawing.Color.Fuchsia;
            this.labelStatus.Location = new System.Drawing.Point(12, 121);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(60, 16);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "unknown";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(12, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Server IP:";
            // 
            // labelIp
            // 
            this.labelIp.AutoSize = true;
            this.labelIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelIp.Location = new System.Drawing.Point(12, 62);
            this.labelIp.Name = "labelIp";
            this.labelIp.Size = new System.Drawing.Size(80, 16);
            this.labelIp.TabIndex = 12;
            this.labelIp.Text = "192.168.0.16";
            // 
            // menuStripMainMenu
            // 
            this.menuStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem});
            this.menuStripMainMenu.Location = new System.Drawing.Point(0, 0);
            this.menuStripMainMenu.Name = "menuStripMainMenu";
            this.menuStripMainMenu.Size = new System.Drawing.Size(315, 24);
            this.menuStripMainMenu.TabIndex = 14;
            this.menuStripMainMenu.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.controlMappingToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // controlMappingToolStripMenuItem
            // 
            this.controlMappingToolStripMenuItem.Name = "controlMappingToolStripMenuItem";
            this.controlMappingToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.controlMappingToolStripMenuItem.Text = "Control mapping";
            this.controlMappingToolStripMenuItem.Click += new System.EventHandler(this.controlMappingToolStripMenuItem_Click);
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconTray.Icon")));
            this.notifyIconTray.Text = "Truck Remote Server";
            this.notifyIconTray.Visible = true;
            this.notifyIconTray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconTray_MouseClick);
            // 
            // buttonStartStopServer
            // 
            this.buttonStartStopServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonStartStopServer.Location = new System.Drawing.Point(12, 219);
            this.buttonStartStopServer.Name = "buttonStartStopServer";
            this.buttonStartStopServer.Size = new System.Drawing.Size(291, 33);
            this.buttonStartStopServer.TabIndex = 14;
            this.buttonStartStopServer.Text = "Stop";
            this.buttonStartStopServer.UseVisualStyleBackColor = true;
            // 
            // contextMenuStripNotifyIconTray
            // 
            this.contextMenuStripNotifyIconTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartStopServerToolStripMenuItem});
            this.contextMenuStripNotifyIconTray.Name = "contextMenuStripNotifyIconTray";
            this.contextMenuStripNotifyIconTray.Size = new System.Drawing.Size(181, 48);
            // 
            // StartStopServerToolStripMenuItem
            // 
            this.StartStopServerToolStripMenuItem.Name = "StartStopServerToolStripMenuItem";
            this.StartStopServerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.StartStopServerToolStripMenuItem.Text = "Stop Server";
            this.StartStopServerToolStripMenuItem.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 264);
            this.Controls.Add(this.buttonStartStopServer);
            this.Controls.Add(this.labelIp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.numericUpPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStripMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStripMainMenu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Truck Remote Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpPort)).EndInit();
            this.menuStripMainMenu.ResumeLayout(false);
            this.menuStripMainMenu.PerformLayout();
            this.contextMenuStripNotifyIconTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpPort;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelIp;
        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.Button buttonStartStopServer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotifyIconTray;
        private System.Windows.Forms.ToolStripMenuItem StartStopServerToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStripMainMenu;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlMappingToolStripMenuItem;
    }
}

