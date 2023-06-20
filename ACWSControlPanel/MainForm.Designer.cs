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
            applicationToolStripMenuItem = new ToolStripMenuItem();
            backgroundToolStripMenuItem = new ToolStripMenuItem();
            closeApplicationToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            generalTabPage = new TabPage();
            acGroupBox = new GroupBox();
            rotationTextBox = new TextBox();
            speedTextBox = new TextBox();
            rotationLabel = new Label();
            speedLabel = new Label();
            acLabel = new Label();
            acPictureBox = new PictureBox();
            hardwareGroupBox = new GroupBox();
            BPowerProgressBar = new ProgressBar();
            APowerProgressBar = new ProgressBar();
            fanBPowerTextBox = new TextBox();
            fanBLabel = new Label();
            fanAPowerTextBox = new TextBox();
            fanALabel = new Label();
            usbLabel = new Label();
            usbPictureBox = new PictureBox();
            fan1AdvancedTabPage = new TabPage();
            fan2AdvancedTabPage = new TabPage();
            notifyContextMenu.SuspendLayout();
            menuStrip.SuspendLayout();
            tabControl1.SuspendLayout();
            generalTabPage.SuspendLayout();
            acGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)acPictureBox).BeginInit();
            hardwareGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usbPictureBox).BeginInit();
            SuspendLayout();
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = notifyContextMenu;
            resources.ApplyResources(notifyIcon, "notifyIcon");
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // notifyContextMenu
            // 
            notifyContextMenu.ImageScalingSize = new Size(20, 20);
            notifyContextMenu.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            notifyContextMenu.Name = "notifyContextMenu";
            resources.ApplyResources(notifyContextMenu, "notifyContextMenu");
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(exitToolStripMenuItem, "exitToolStripMenuItem");
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            resources.ApplyResources(statusStrip, "statusStrip");
            statusStrip.Name = "statusStrip";
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { applicationToolStripMenuItem, settingsToolStripMenuItem, helpToolStripMenuItem });
            resources.ApplyResources(menuStrip, "menuStrip");
            menuStrip.Name = "menuStrip";
            // 
            // applicationToolStripMenuItem
            // 
            applicationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backgroundToolStripMenuItem, closeApplicationToolStripMenuItem });
            applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            resources.ApplyResources(applicationToolStripMenuItem, "applicationToolStripMenuItem");
            // 
            // backgroundToolStripMenuItem
            // 
            backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            resources.ApplyResources(backgroundToolStripMenuItem, "backgroundToolStripMenuItem");
            backgroundToolStripMenuItem.Click += backgroundToolStripMenuItem_Click;
            // 
            // closeApplicationToolStripMenuItem
            // 
            closeApplicationToolStripMenuItem.Name = "closeApplicationToolStripMenuItem";
            resources.ApplyResources(closeApplicationToolStripMenuItem, "closeApplicationToolStripMenuItem");
            closeApplicationToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(aboutToolStripMenuItem, "aboutToolStripMenuItem");
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(generalTabPage);
            tabControl1.Controls.Add(fan1AdvancedTabPage);
            tabControl1.Controls.Add(fan2AdvancedTabPage);
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            // 
            // generalTabPage
            // 
            generalTabPage.Controls.Add(acGroupBox);
            generalTabPage.Controls.Add(hardwareGroupBox);
            resources.ApplyResources(generalTabPage, "generalTabPage");
            generalTabPage.Name = "generalTabPage";
            generalTabPage.UseVisualStyleBackColor = true;
            // 
            // acGroupBox
            // 
            acGroupBox.Controls.Add(rotationTextBox);
            acGroupBox.Controls.Add(speedTextBox);
            acGroupBox.Controls.Add(rotationLabel);
            acGroupBox.Controls.Add(speedLabel);
            acGroupBox.Controls.Add(acLabel);
            acGroupBox.Controls.Add(acPictureBox);
            resources.ApplyResources(acGroupBox, "acGroupBox");
            acGroupBox.Name = "acGroupBox";
            acGroupBox.TabStop = false;
            // 
            // rotationTextBox
            // 
            resources.ApplyResources(rotationTextBox, "rotationTextBox");
            rotationTextBox.Name = "rotationTextBox";
            rotationTextBox.ReadOnly = true;
            // 
            // speedTextBox
            // 
            resources.ApplyResources(speedTextBox, "speedTextBox");
            speedTextBox.Name = "speedTextBox";
            speedTextBox.ReadOnly = true;
            // 
            // rotationLabel
            // 
            resources.ApplyResources(rotationLabel, "rotationLabel");
            rotationLabel.Name = "rotationLabel";
            // 
            // speedLabel
            // 
            resources.ApplyResources(speedLabel, "speedLabel");
            speedLabel.Name = "speedLabel";
            // 
            // acLabel
            // 
            resources.ApplyResources(acLabel, "acLabel");
            acLabel.Name = "acLabel";
            // 
            // acPictureBox
            // 
            acPictureBox.Image = Resources.icons8_assetto_corsa_competizione_100_unknown;
            resources.ApplyResources(acPictureBox, "acPictureBox");
            acPictureBox.Name = "acPictureBox";
            acPictureBox.TabStop = false;
            // 
            // hardwareGroupBox
            // 
            hardwareGroupBox.Controls.Add(BPowerProgressBar);
            hardwareGroupBox.Controls.Add(APowerProgressBar);
            hardwareGroupBox.Controls.Add(fanBPowerTextBox);
            hardwareGroupBox.Controls.Add(fanBLabel);
            hardwareGroupBox.Controls.Add(fanAPowerTextBox);
            hardwareGroupBox.Controls.Add(fanALabel);
            hardwareGroupBox.Controls.Add(usbLabel);
            hardwareGroupBox.Controls.Add(usbPictureBox);
            resources.ApplyResources(hardwareGroupBox, "hardwareGroupBox");
            hardwareGroupBox.Name = "hardwareGroupBox";
            hardwareGroupBox.TabStop = false;
            // 
            // BPowerProgressBar
            // 
            resources.ApplyResources(BPowerProgressBar, "BPowerProgressBar");
            BPowerProgressBar.Maximum = 1000;
            BPowerProgressBar.Name = "BPowerProgressBar";
            BPowerProgressBar.Step = 1;
            // 
            // APowerProgressBar
            // 
            resources.ApplyResources(APowerProgressBar, "APowerProgressBar");
            APowerProgressBar.Maximum = 1000;
            APowerProgressBar.Name = "APowerProgressBar";
            APowerProgressBar.Step = 1;
            // 
            // fanBPowerTextBox
            // 
            resources.ApplyResources(fanBPowerTextBox, "fanBPowerTextBox");
            fanBPowerTextBox.Name = "fanBPowerTextBox";
            fanBPowerTextBox.ReadOnly = true;
            // 
            // fanBLabel
            // 
            resources.ApplyResources(fanBLabel, "fanBLabel");
            fanBLabel.Name = "fanBLabel";
            // 
            // fanAPowerTextBox
            // 
            resources.ApplyResources(fanAPowerTextBox, "fanAPowerTextBox");
            fanAPowerTextBox.Name = "fanAPowerTextBox";
            fanAPowerTextBox.ReadOnly = true;
            // 
            // fanALabel
            // 
            resources.ApplyResources(fanALabel, "fanALabel");
            fanALabel.Name = "fanALabel";
            // 
            // usbLabel
            // 
            resources.ApplyResources(usbLabel, "usbLabel");
            usbLabel.Name = "usbLabel";
            // 
            // usbPictureBox
            // 
            usbPictureBox.Image = Resources.icons8_usb_déconnectée_96;
            resources.ApplyResources(usbPictureBox, "usbPictureBox");
            usbPictureBox.Name = "usbPictureBox";
            usbPictureBox.TabStop = false;
            // 
            // fan1AdvancedTabPage
            // 
            resources.ApplyResources(fan1AdvancedTabPage, "fan1AdvancedTabPage");
            fan1AdvancedTabPage.Name = "fan1AdvancedTabPage";
            fan1AdvancedTabPage.UseVisualStyleBackColor = true;
            // 
            // fan2AdvancedTabPage
            // 
            resources.ApplyResources(fan2AdvancedTabPage, "fan2AdvancedTabPage");
            fan2AdvancedTabPage.Name = "fan2AdvancedTabPage";
            fan2AdvancedTabPage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            TopMost = true;
            WindowState = FormWindowState.Minimized;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            notifyContextMenu.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            tabControl1.ResumeLayout(false);
            generalTabPage.ResumeLayout(false);
            acGroupBox.ResumeLayout(false);
            acGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)acPictureBox).EndInit();
            hardwareGroupBox.ResumeLayout(false);
            hardwareGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)usbPictureBox).EndInit();
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
        private PictureBox usbPictureBox;
        private PictureBox acPictureBox;
        private Label usbLabel;
        private Label acLabel;
        private Label speedLabel;
        private TextBox rotationTextBox;
        private TextBox speedTextBox;
        private Label rotationLabel;
        private Label fanALabel;
        private TextBox fanAPowerTextBox;
        private TextBox fanBPowerTextBox;
        private Label fanBLabel;
        private ToolStripMenuItem applicationToolStripMenuItem;
        private ToolStripMenuItem backgroundToolStripMenuItem;
        private ToolStripMenuItem closeApplicationToolStripMenuItem;
        private ProgressBar BPowerProgressBar;
        private ProgressBar APowerProgressBar;
    }
}