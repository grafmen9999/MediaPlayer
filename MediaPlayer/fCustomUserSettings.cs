using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class fCustomUserSettings : Form
    {
        public fCustomUserSettings()
        {
            InitializeComponent();
        }

        private void fCustomUserSettings_Load(object sender, EventArgs e)
        {
            Set();
        }

        private void SetConfingKeysToScreen()
        {
            tbFullScreenMode.Text   = MediaPlayer.keyFullScreen.ToString();
            tbNextMusic.Text        = MediaPlayer.keyNextMusic.ToString();
            tbPlayPause.Text        = MediaPlayer.keyPlayPause.ToString();
            tbPreviousMusic.Text    = MediaPlayer.keyPreviousMusic.ToString();
            tbShiftNext.Text        = MediaPlayer.keyNextShift.ToString();
            tbShiftPrevious.Text    = MediaPlayer.keyPreviousShift.ToString();
            tbVolumeDown.Text       = MediaPlayer.keyVolumeDown.ToString();
            tbVolumeUp.Text         = MediaPlayer.keyVolumeUp.ToString();
        }

        private void Set()
        {
            udChangeStyle.SelectedIndex = MediaPlayer.styleImage;
            SetConfingKeysToScreen();
            tbOffsetShift.Text = MediaPlayer.defaultOffsetShift.ToString();
            tbOffsetVolume.Text = MediaPlayer.defaultOffsetVolume.ToString();
        }

        private void SaveData() // Записываем поля в переменные
        {
            KeysConverter converter = new KeysConverter();
            MediaPlayer.keyFullScreen       = (Keys)converter.ConvertFromString(tbFullScreenMode.Text);
            MediaPlayer.keyNextMusic        = (Keys)converter.ConvertFromString(tbNextMusic.Text);
            MediaPlayer.keyPlayPause        = (Keys)converter.ConvertFromString(tbPlayPause.Text);
            MediaPlayer.keyPreviousMusic    = (Keys)converter.ConvertFromString(tbPreviousMusic.Text);
            MediaPlayer.keyNextShift        = (Keys)converter.ConvertFromString(tbShiftNext.Text);
            MediaPlayer.keyPreviousShift    = (Keys)converter.ConvertFromString(tbShiftPrevious.Text);
            MediaPlayer.keyVolumeDown       = (Keys)converter.ConvertFromString(tbVolumeDown.Text);
            MediaPlayer.keyVolumeUp         = (Keys)converter.ConvertFromString(tbVolumeUp.Text);
            MediaPlayer.defaultOffsetShift  = Convert.ToInt32(tbOffsetShift.Text);
            MediaPlayer.defaultOffsetVolume = Convert.ToInt32(tbOffsetVolume.Text);
            MediaPlayer.styleImage          = udChangeStyle.SelectedIndex;
        }

        private void KeyPress_TextBox(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void KeyPress_TextBox(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            Keys keyCode = e.KeyCode;

            ((TextBox)sender).Text = keyCode.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            Set();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Set();
        }
    }
}
