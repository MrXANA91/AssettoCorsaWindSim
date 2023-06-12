using System.Windows.Forms;

namespace ACWSControlPanel
{
    public partial class MainForm : Form
    {
        const string APP_NAME_PREFIX = "AssettoCorsaWindSim - ";
        const string ACWS_STATUSCHANGED_TITLE = "ACWS - Status changed";
        const int DEVICE_NOT_CONNECTED = 0;
        const string S_DEVICE_NOT_CONNECTED = "Device not connected";
        const int GAME_NOT_DETECTED = 1;
        const string S_GAME_NOT_DETECTED = "Device connected but game not detected";
        const int GAME_NOT_RUNNING = 2;
        const string S_GAME_NOT_RUNNING = "Device connected and game detected";
        const int GAME_RUNNING = 3;
        const string S_GAME_RUNNING = "Device connected and game running";

        private Boolean allowClose = false;

        public MainForm()
        {
            InitializeComponent();

            UpdateNotifyIcon(DEVICE_NOT_CONNECTED, false);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !allowClose)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }

            notifyIcon.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO : prompt a messagebox if the device is connected
            allowClose = true;
            this.Close();
        }

        private void UpdateNotifyIcon(int state, bool showBalloon)
        {
            switch (state)
            {
                default:
                case DEVICE_NOT_CONNECTED:
                    notifyIcon.Text = APP_NAME_PREFIX + S_DEVICE_NOT_CONNECTED;
                    notifyIcon.Icon = Resources.Dall_e_icon_2_error;
                    if (showBalloon) notifyIcon.ShowBalloonTip(3000, ACWS_STATUSCHANGED_TITLE, S_DEVICE_NOT_CONNECTED, ToolTipIcon.Warning);
                    break;
                case GAME_NOT_DETECTED:
                    notifyIcon.Text = APP_NAME_PREFIX + S_GAME_NOT_DETECTED;
                    notifyIcon.Icon = Resources.Dall_e_icon_2_waiting;
                    break;
                case GAME_NOT_RUNNING:
                    notifyIcon.Text = APP_NAME_PREFIX + S_GAME_NOT_RUNNING;
                    notifyIcon.Icon = Resources.Dall_e_icon_2_ready;
                    break;
                case GAME_RUNNING:
                    notifyIcon.Text = APP_NAME_PREFIX + S_GAME_RUNNING;
                    notifyIcon.Icon = Resources.Dall_e_icon_2_play;
                    break;
            }
        }
    }
}