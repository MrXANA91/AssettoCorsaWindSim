namespace ACWSControlPanel
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            notifyIcon = new NotifyIcon(components);
            notifyContextMenu = new ContextMenuStrip(components);
            exitToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            menuStrip = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            generalTabPage = new TabPage();
            acGroupBox = new GroupBox();
            hardwareGroupBox = new GroupBox();
            pictureBox1 = new PictureBox();
            fan1AdvancedTabPage = new TabPage();
            fan2AdvancedTabPage = new TabPage();
            notifyContextMenu.SuspendLayout();
            menuStrip.SuspendLayout();
            tabControl1.SuspendLayout();
            generalTabPage.SuspendLayout();
            hardwareGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = notifyContextMenu;
            notifyIcon.Text = "notifyIcon";
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // notifyContextMenu
            // 
            notifyContextMenu.ImageScalingSize = new Size(20, 20);
            notifyContextMenu.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            notifyContextMenu.Name = "notifyContextMenu";
            notifyContextMenu.Size = new Size(103, 28);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(102, 24);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Location = new Point(0, 428);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 22);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip";
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 28);
            menuStrip.TabIndex = 2;
            menuStrip.Text = "menuStrip";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(76, 24);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(224, 26);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(generalTabPage);
            tabControl1.Controls.Add(fan1AdvancedTabPage);
            tabControl1.Controls.Add(fan2AdvancedTabPage);
            tabControl1.Location = new Point(12, 31);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 394);
            tabControl1.TabIndex = 3;
            // 
            // generalTabPage
            // 
            generalTabPage.Controls.Add(acGroupBox);
            generalTabPage.Controls.Add(hardwareGroupBox);
            generalTabPage.Location = new Point(4, 29);
            generalTabPage.Name = "generalTabPage";
            generalTabPage.Padding = new Padding(3);
            generalTabPage.Size = new Size(768, 361);
            generalTabPage.TabIndex = 0;
            generalTabPage.Text = "General";
            generalTabPage.UseVisualStyleBackColor = true;
            // 
            // acGroupBox
            // 
            acGroupBox.Location = new Point(387, 6);
            acGroupBox.Name = "acGroupBox";
            acGroupBox.Size = new Size(375, 349);
            acGroupBox.TabIndex = 1;
            acGroupBox.TabStop = false;
            acGroupBox.Text = "Assetto Corsa";
            // 
            // hardwareGroupBox
            // 
            hardwareGroupBox.Controls.Add(pictureBox1);
            hardwareGroupBox.Location = new Point(6, 6);
            hardwareGroupBox.Name = "hardwareGroupBox";
            hardwareGroupBox.Size = new Size(375, 349);
            hardwareGroupBox.TabIndex = 0;
            hardwareGroupBox.TabStop = false;
            hardwareGroupBox.Text = "Hardware";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resources.icons8_usb_déconnectée_96;
            pictureBox1.Location = new Point(6, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(96, 96);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // fan1AdvancedTabPage
            // 
            fan1AdvancedTabPage.Location = new Point(4, 29);
            fan1AdvancedTabPage.Name = "fan1AdvancedTabPage";
            fan1AdvancedTabPage.Padding = new Padding(3);
            fan1AdvancedTabPage.Size = new Size(768, 361);
            fan1AdvancedTabPage.TabIndex = 1;
            fan1AdvancedTabPage.Text = "Fan A (Advanced)";
            fan1AdvancedTabPage.UseVisualStyleBackColor = true;
            // 
            // fan2AdvancedTabPage
            // 
            fan2AdvancedTabPage.Location = new Point(4, 29);
            fan2AdvancedTabPage.Name = "fan2AdvancedTabPage";
            fan2AdvancedTabPage.Size = new Size(768, 361);
            fan2AdvancedTabPage.TabIndex = 2;
            fan2AdvancedTabPage.Text = "Fan B (Advanced)";
            fan2AdvancedTabPage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "AssettoCorsaWindSim Control Panel";
            TopMost = true;
            WindowState = FormWindowState.Minimized;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            notifyContextMenu.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            tabControl1.ResumeLayout(false);
            generalTabPage.ResumeLayout(false);
            hardwareGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon notifyIcon;
        private ContextMenuStrip notifyContextMenu;
        private ToolStripMenuItem exitToolStripMenuItem;
        private StatusStrip statusStrip;
        private MenuStrip menuStrip;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage generalTabPage;
        private TabPage fan1AdvancedTabPage;
        private TabPage fan2AdvancedTabPage;
        private GroupBox acGroupBox;
        private GroupBox hardwareGroupBox;
        private PictureBox pictureBox1;
    }
}