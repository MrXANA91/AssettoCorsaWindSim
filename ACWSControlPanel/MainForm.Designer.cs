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
            notifyContextMenu.SuspendLayout();
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "AssettoCorsaWindSim Control Panel";
            TopMost = true;
            WindowState = FormWindowState.Minimized;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            notifyContextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon notifyIcon;
        private ContextMenuStrip notifyContextMenu;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}