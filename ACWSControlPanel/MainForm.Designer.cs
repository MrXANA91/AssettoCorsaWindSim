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
            fileToolStripMenuItem = new ToolStripMenuItem();
            backgroundToolStripMenuItem = new ToolStripMenuItem();
            closeApplicationToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
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
            fanACompFuncComboBox = new ComboBox();
            fanAAngleLabel = new Label();
            fanAAngleTrackBar = new TrackBar();
            label2 = new Label();
            label4 = new Label();
            label3 = new Label();
            fanAGammaNum = new NumericUpDown();
            label1 = new Label();
            fanAMaxSpeedNum = new NumericUpDown();
            fan2AdvancedTabPage = new TabPage();
            fanBCompFuncComboBox = new ComboBox();
            fanBAngleLabel = new Label();
            fanBAngleTrackBar = new TrackBar();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            fanBGammaNum = new NumericUpDown();
            label9 = new Label();
            fanBMaxSpeedNum = new NumericUpDown();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            notifyContextMenu.SuspendLayout();
            menuStrip.SuspendLayout();
            tabControl1.SuspendLayout();
            generalTabPage.SuspendLayout();
            acGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)acPictureBox).BeginInit();
            hardwareGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usbPictureBox).BeginInit();
            fan1AdvancedTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fanAAngleTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fanAGammaNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fanAMaxSpeedNum).BeginInit();
            fan2AdvancedTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fanBAngleTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fanBGammaNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fanBMaxSpeedNum).BeginInit();
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
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, optionsToolStripMenuItem, helpToolStripMenuItem });
            resources.ApplyResources(menuStrip, "menuStrip");
            menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backgroundToolStripMenuItem, closeApplicationToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(fileToolStripMenuItem, "fileToolStripMenuItem");
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
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            resources.ApplyResources(optionsToolStripMenuItem, "optionsToolStripMenuItem");
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
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
            fan1AdvancedTabPage.Controls.Add(fanACompFuncComboBox);
            fan1AdvancedTabPage.Controls.Add(fanAAngleLabel);
            fan1AdvancedTabPage.Controls.Add(fanAAngleTrackBar);
            fan1AdvancedTabPage.Controls.Add(label2);
            fan1AdvancedTabPage.Controls.Add(label4);
            fan1AdvancedTabPage.Controls.Add(label3);
            fan1AdvancedTabPage.Controls.Add(fanAGammaNum);
            fan1AdvancedTabPage.Controls.Add(label1);
            fan1AdvancedTabPage.Controls.Add(fanAMaxSpeedNum);
            resources.ApplyResources(fan1AdvancedTabPage, "fan1AdvancedTabPage");
            fan1AdvancedTabPage.Name = "fan1AdvancedTabPage";
            fan1AdvancedTabPage.UseVisualStyleBackColor = true;
            // 
            // fanACompFuncComboBox
            // 
            fanACompFuncComboBox.FormattingEnabled = true;
            resources.ApplyResources(fanACompFuncComboBox, "fanACompFuncComboBox");
            fanACompFuncComboBox.Name = "fanACompFuncComboBox";
            fanACompFuncComboBox.SelectedIndexChanged += fanACompFuncComboBox_SelectedIndexChanged;
            // 
            // fanAAngleLabel
            // 
            resources.ApplyResources(fanAAngleLabel, "fanAAngleLabel");
            fanAAngleLabel.Name = "fanAAngleLabel";
            // 
            // fanAAngleTrackBar
            // 
            resources.ApplyResources(fanAAngleTrackBar, "fanAAngleTrackBar");
            fanAAngleTrackBar.Maximum = 900;
            fanAAngleTrackBar.Minimum = -900;
            fanAAngleTrackBar.Name = "fanAAngleTrackBar";
            fanAAngleTrackBar.ValueChanged += fanAAngleTrackBar_ValueChanged;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // fanAGammaNum
            // 
            fanAGammaNum.DecimalPlaces = 3;
            fanAGammaNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            resources.ApplyResources(fanAGammaNum, "fanAGammaNum");
            fanAGammaNum.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            fanAGammaNum.Name = "fanAGammaNum";
            fanAGammaNum.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            fanAGammaNum.ValueChanged += fanAGammaNum_ValueChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // fanAMaxSpeedNum
            // 
            resources.ApplyResources(fanAMaxSpeedNum, "fanAMaxSpeedNum");
            fanAMaxSpeedNum.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            fanAMaxSpeedNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            fanAMaxSpeedNum.Name = "fanAMaxSpeedNum";
            fanAMaxSpeedNum.Value = new decimal(new int[] { 250, 0, 0, 0 });
            fanAMaxSpeedNum.ValueChanged += fanAMaxSpeedNum_ValueChanged;
            // 
            // fan2AdvancedTabPage
            // 
            fan2AdvancedTabPage.Controls.Add(fanBCompFuncComboBox);
            fan2AdvancedTabPage.Controls.Add(fanBAngleLabel);
            fan2AdvancedTabPage.Controls.Add(fanBAngleTrackBar);
            fan2AdvancedTabPage.Controls.Add(label6);
            fan2AdvancedTabPage.Controls.Add(label7);
            fan2AdvancedTabPage.Controls.Add(label8);
            fan2AdvancedTabPage.Controls.Add(fanBGammaNum);
            fan2AdvancedTabPage.Controls.Add(label9);
            fan2AdvancedTabPage.Controls.Add(fanBMaxSpeedNum);
            resources.ApplyResources(fan2AdvancedTabPage, "fan2AdvancedTabPage");
            fan2AdvancedTabPage.Name = "fan2AdvancedTabPage";
            fan2AdvancedTabPage.UseVisualStyleBackColor = true;
            // 
            // fanBCompFuncComboBox
            // 
            fanBCompFuncComboBox.FormattingEnabled = true;
            resources.ApplyResources(fanBCompFuncComboBox, "fanBCompFuncComboBox");
            fanBCompFuncComboBox.Name = "fanBCompFuncComboBox";
            fanBCompFuncComboBox.SelectedIndexChanged += fanBCompFuncComboBox_SelectedIndexChanged;
            // 
            // fanBAngleLabel
            // 
            resources.ApplyResources(fanBAngleLabel, "fanBAngleLabel");
            fanBAngleLabel.Name = "fanBAngleLabel";
            // 
            // fanBAngleTrackBar
            // 
            resources.ApplyResources(fanBAngleTrackBar, "fanBAngleTrackBar");
            fanBAngleTrackBar.Maximum = 900;
            fanBAngleTrackBar.Minimum = -900;
            fanBAngleTrackBar.Name = "fanBAngleTrackBar";
            fanBAngleTrackBar.ValueChanged += fanBAngleTrackBar_ValueChanged;
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // fanBGammaNum
            // 
            fanBGammaNum.DecimalPlaces = 3;
            fanBGammaNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            resources.ApplyResources(fanBGammaNum, "fanBGammaNum");
            fanBGammaNum.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            fanBGammaNum.Name = "fanBGammaNum";
            fanBGammaNum.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            fanBGammaNum.ValueChanged += fanBGammaNum_ValueChanged;
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            // 
            // fanBMaxSpeedNum
            // 
            resources.ApplyResources(fanBMaxSpeedNum, "fanBMaxSpeedNum");
            fanBMaxSpeedNum.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            fanBMaxSpeedNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            fanBMaxSpeedNum.Name = "fanBMaxSpeedNum";
            fanBMaxSpeedNum.Value = new decimal(new int[] { 250, 0, 0, 0 });
            fanBMaxSpeedNum.ValueChanged += fanBMaxSpeedNum_ValueChanged;
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
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
            fan1AdvancedTabPage.ResumeLayout(false);
            fan1AdvancedTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fanAAngleTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)fanAGammaNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)fanAMaxSpeedNum).EndInit();
            fan2AdvancedTabPage.ResumeLayout(false);
            fan2AdvancedTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fanBAngleTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)fanBGammaNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)fanBMaxSpeedNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon notifyIcon;
        private ContextMenuStrip notifyContextMenu;
        private ToolStripMenuItem exitToolStripMenuItem;
        private StatusStrip statusStrip;
        private MenuStrip menuStrip;
        private ToolStripMenuItem optionsToolStripMenuItem;
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
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem backgroundToolStripMenuItem;
        private ToolStripMenuItem closeApplicationToolStripMenuItem;
        private ProgressBar BPowerProgressBar;
        private ProgressBar APowerProgressBar;
        private TrackBar fanAAngleTrackBar;
        private Label label2;
        private Label label1;
        private NumericUpDown fanAMaxSpeedNum;
        private Label fanAAngleLabel;
        private Label label3;
        private NumericUpDown fanAGammaNum;
        private ComboBox fanACompFuncComboBox;
        private Label label4;
        private ComboBox fanBCompFuncComboBox;
        private Label fanBAngleLabel;
        private TrackBar fanBAngleTrackBar;
        private Label label6;
        private Label label7;
        private Label label8;
        private NumericUpDown fanBGammaNum;
        private Label label9;
        private NumericUpDown fanBMaxSpeedNum;
        private ToolStripMenuItem settingsToolStripMenuItem;
    }
}