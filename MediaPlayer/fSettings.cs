using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace MediaPlayer {
    public partial class fSettings : Form {
        //private string lastFolder = "";
        private fCustomUserSettings fCustomUser = new fCustomUserSettings();

        public fSettings() {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e) {
            //MediaPlayer.LastFolder = lastFolder;
            MediaPlayer.allDirectories = cbAllDirectories.Checked;
            MediaPlayer.repeatMusic = cbRepeatMusic.Checked;
            MediaPlayer.randomMusic = cbRandomMusic.Checked;
            MediaPlayer.visibleVideo = cbVisibleVideo.Checked;
            //MediaPlayer.ReadMusic();
            MediaPlayer.tmpCurPL = cbSelectedPlayList.Text;

            if (MediaPlayer.GetExistFile(MediaPlayer.currentPlayList) && MediaPlayer.GetExistRegistry(MediaPlayer.currentPlayList)) {
                MediaPlayer.SaveList();
            }

            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Set();
            MediaPlayer.tmpCurPL = cbSelectedPlayList.Text;
            this.Hide();
        }

        private void btnEnumFolders_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK) {
                string lastFolder = fbd.SelectedPath;
                MediaPlayer.ReadMusic(lastFolder);
            }
        }

        private void fSettings_Load(object sender, EventArgs e) {
            Set();
            SetTextOfInformation();
        }

        private void Set() {
            cbAllDirectories.Checked = MediaPlayer.allDirectories;
            cbRepeatMusic.Checked = MediaPlayer.repeatMusic;
            cbRandomMusic.Checked = MediaPlayer.randomMusic;
            cbVisibleVideo.Checked = MediaPlayer.visibleVideo;
            //lastFolder = MediaPlayer.LastFolder;
            cbSelectedPlayList.Text = (MediaPlayer.GetExistFile(MediaPlayer.currentPlayList) && MediaPlayer.GetExistRegistry(MediaPlayer.currentPlayList)) ? MediaPlayer.currentPlayList : "";

            try {
                cbSelectedPlayList.Items.Clear();
                cbSelectedPlayList.Items.AddRange(MediaPlayer.GetListing());
            }
            catch { }
        }

        private void SetTextOfInformation() {
            /*
            try {
                string[] list = Directory.GetFiles(lastFolder, "*.mp3", cbAllDirectories.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                lblInformationFolders.Text = "Выбранная папка: " + lastFolder.Split('\\').Last() + "\n" + "Количество композиций: " + list.Length.ToString();
            }
            catch { }
            */
            string[] list = null;

            try {
                using (StreamReader sr = new StreamReader("PlayList\\" + cbSelectedPlayList.Text + ".list")) {
                    list = sr.ReadToEnd().Split('\n');
                }

                lblInformationPlayList.Text = "Плей-лист: " + cbSelectedPlayList.Text + "\nКоличество композиций: " + list.Length.ToString();
            }
            catch { }
            
        }

        private void fSettings_FormClosing(object sender, FormClosingEventArgs e) {
            Set();
        }

        private void cbSelectedPlayList_SelectedIndexChanged(object sender, EventArgs e) { // а что я хотел то здесь сделать?
            //MediaPlayer.currentPlayList
            SetTextOfInformation(); // пусть будет так, буду рефрешить инфу
        }

        private void btnCustomUserSettings_Click(object sender, EventArgs e)
        {
            if (fCustomUser.ShowDialog() == DialogResult.OK)
            {
                MediaPlayer.SaveCustomSettings();
            }
        }
    }
}
