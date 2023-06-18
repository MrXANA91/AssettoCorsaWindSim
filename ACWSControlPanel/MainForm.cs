using System.Drawing;
using System.Windows.Forms;
using assettocorsasharedmemory;
using AssettoCorsaWindSim;

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

        const int ICON_VANILLA = 0;
        const int ICON_ERROR = 1;
        const int ICON_PAUSE = 2;
        const int ICON_PLAY = 3;
        const int ICON_READY = 4;
        const int ICON_WAITING_UNKNOWN = 5;

        private AssettoCorsaWindSimController acws;

        private Boolean allowClose = false;

        public MainForm()
        {
            InitializeComponent();

            acws = new AssettoCorsaWindSimController();

            UpdateNotifyIcon(DEVICE_NOT_CONNECTED, false);
            UpdateNotifyIconImage();
            UpdateHardwareImage(false);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.Hide();
            acws.AssettoCorsaConnectionChanged += Acws_AssettoCorsaConnectionChanged;
            acws.HardwareConnectionChanged += Acws_HardwareConnectionChanged;
            acws.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            acws.AssettoCorsaDataReceived -= Acws_AssettoCorsaDataReceived;
            acws.HardwareDataSent -= Acws_HardwareDataSent;

            if (e.CloseReason == CloseReason.UserClosing && !allowClose)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }

            acws.AssettoCorsaConnectionChanged -= Acws_AssettoCorsaConnectionChanged;
            acws.HardwareConnectionChanged -= Acws_HardwareConnectionChanged;

            notifyIcon.Visible = false;

            acws.Stop();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            acws.AssettoCorsaDataReceived += Acws_AssettoCorsaDataReceived;
            acws.HardwareDataSent += Acws_HardwareDataSent;

            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO : prompt a messagebox if the device is connected
            allowClose = true;
            this.Close();
        }

        private void Acws_AssettoCorsaConnectionChanged(object sender, GameStatusEventArgs e)
        {
            UpdateAssettoCorsa(e.GameStatus);

            if (acws.IsHardwareConnected)
            {
                switch (e.GameStatus)
                {
                    default:
                    case AC_STATUS.AC_OFF:
                        UpdateNotifyIcon(GAME_NOT_DETECTED);
                        break;
                    case AC_STATUS.AC_REPLAY:
                    case AC_STATUS.AC_PAUSE:
                        UpdateNotifyIcon(GAME_NOT_RUNNING);
                        break;
                    case AC_STATUS.AC_LIVE:
                        UpdateNotifyIcon(GAME_RUNNING);
                        break;
                }
            }
        }

        private void Acws_AssettoCorsaDataReceived(object sender, AssettoCorsaDataEventArgs e)
        {
            speedTextBox.Text = e.Speed.ToString("0.0") + " km/h";
            rotationTextBox.Text = e.LocalAngularVelocity.ToString("0.000") + " °";
        }

        private void Acws_HardwareConnectionChanged(object sender, HardwareConnectionEventArgs e)
        {
            UpdateHardwareImage(e.Connected);

            if (!acws.IsHardwareConnected)
            {
                UpdateNotifyIcon(DEVICE_NOT_CONNECTED, true); // TODO : replace 'true' by the notification parameter
            } else
            {
                switch (acws.gameStatus)
                {
                    default:
                    case AC_STATUS.AC_OFF:
                        UpdateNotifyIcon(GAME_NOT_DETECTED);
                        break;
                    case AC_STATUS.AC_REPLAY:
                    case AC_STATUS.AC_PAUSE:
                        UpdateNotifyIcon(GAME_NOT_RUNNING);
                        break;
                    case AC_STATUS.AC_LIVE:
                        UpdateNotifyIcon(GAME_RUNNING);
                        break;
                }
            }
        }

        private void Acws_HardwareDataSent(object sender, HardwareDataEventArgs e)
        {
            fanAPowerTextBox.Text = ((float)e.FanAPower / 255f).ToString("0.0") + " %";
            fanBPowerTextBox.Text = ((float)e.FanBPower / 255f).ToString("0.0") + " %";
        }

        private void UpdateNotifyIcon(int state, bool showBalloon = false)
        {
            switch (state)
            {
                default:
                case DEVICE_NOT_CONNECTED:
                    notifyIcon.Text = APP_NAME_PREFIX + S_DEVICE_NOT_CONNECTED;
                    UpdateNotifyIconImage(ICON_ERROR);
                    if (showBalloon) notifyIcon.ShowBalloonTip(3000, ACWS_STATUSCHANGED_TITLE, S_DEVICE_NOT_CONNECTED, ToolTipIcon.Warning);
                    break;
                case GAME_NOT_DETECTED:
                    notifyIcon.Text = APP_NAME_PREFIX + S_GAME_NOT_DETECTED;
                    UpdateNotifyIconImage(ICON_WAITING_UNKNOWN);
                    break;
                case GAME_NOT_RUNNING:
                    notifyIcon.Text = APP_NAME_PREFIX + S_GAME_NOT_RUNNING;
                    UpdateNotifyIconImage(ICON_READY);
                    break;
                case GAME_RUNNING:
                    notifyIcon.Text = APP_NAME_PREFIX + S_GAME_RUNNING;
                    UpdateNotifyIconImage(ICON_PLAY);
                    break;
            }
        }

        private void UpdateNotifyIconImage(int icon = ICON_VANILLA)
        {
            switch (icon)
            {
                default:
                case ICON_VANILLA:
                    // TODO : bug here, why?
                    //notifyIcon.Icon = Resources.Dall_e_icon_2;
                    break;
                case ICON_ERROR:
                    notifyIcon.Icon = Resources.Dall_e_icon_2_error;
                    break;
                case ICON_PAUSE:
                    notifyIcon.Icon = Resources.Dall_e_icon_2_pause;
                    break;
                case ICON_PLAY:
                    notifyIcon.Icon = Resources.Dall_e_icon_2_play;
                    break;
                case ICON_READY:
                    notifyIcon.Icon = Resources.Dall_e_icon_2_ready;
                    break;
                case ICON_WAITING_UNKNOWN:
                    notifyIcon.Icon = Resources.Dall_e_icon_2_waiting;
                    break;
            }
        }

        private void UpdateHardwareImage(bool connected)
        {
            usbPictureBox.Image = connected ? Resources.icons8_connexion_usb_96 : Resources.icons8_usb_déconnectée_96;
        }

        private void UpdateAssettoCorsa(AC_STATUS status)
        {
            int icon;
            switch (status)
            {
                default:
                    icon = ICON_VANILLA;
                    break;
                case AC_STATUS.AC_OFF:
                    icon = ICON_WAITING_UNKNOWN;
                    break;
                case AC_STATUS.AC_REPLAY:
                    icon = ICON_READY;
                    break;
                case AC_STATUS.AC_LIVE:
                    icon = ICON_PLAY;
                    break;
                case AC_STATUS.AC_PAUSE:
                    icon = ICON_PAUSE;
                    break;
            }
            UpdateAssettoCorsaImage(icon);
        }

        private void UpdateAssettoCorsaImage(int icon)
        {
            switch (icon)
            {
                default:
                case ICON_VANILLA:
                    acPictureBox.Image = Resources.icons8_assetto_corsa_competizione_100;
                    break;
                case ICON_ERROR:
                    acPictureBox.Image = Resources.icons8_assetto_corsa_competizione_100_error;
                    break;
                case ICON_PAUSE:
                    acPictureBox.Image = Resources.icons8_assetto_corsa_competizione_100_pause;
                    break;
                case ICON_PLAY:
                    acPictureBox.Image = Resources.icons8_assetto_corsa_competizione_100_play;
                    break;
                case ICON_READY:
                    acPictureBox.Image = Resources.icons8_assetto_corsa_competizione_100_ready;
                    break;
                case ICON_WAITING_UNKNOWN:
                    acPictureBox.Image = Resources.icons8_assetto_corsa_competizione_100_unknown;
                    break;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox
            {
                TopMost = true
            };
            about.Show();
        }
    }
}