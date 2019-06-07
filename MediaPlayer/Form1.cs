using System;
using System.Linq;
using System.Windows.Input;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using Hooks;
// HOOKS CHECKED
namespace MediaPlayer {
    public partial class fMediaPlayer : Form, IMessageFilter {
        #region Variables
        private string[] FileExtension =
        {
            ".mp3",
            ".mp4",
            ".waw"  // здесь указываем расширения для проверки добавления новых файлов.
        };

        private fSettings fs = new fSettings();
        private DateTime DateTimeNow, DateTimeNever;
        private bool IsMousePressed, PressedButton;
        private bool FullScreenMode = false;
        private bool IsPlayingMusic = false, isProgramSelected = false, IsOpenedSettings = false;

        private const int DefaultSizeModeWithAudioX = 475;
        private const int DefaultSizeModeWithAudioY = 400;
        private const int DefaultSizeModeWithVideoX = (int)(DefaultSizeModeWithAudioX * 2.015);
        private const int DefaultSizeModeWithVideoY = DefaultSizeModeWithAudioY;

        private System.Drawing.Size DefaultSizeModeWithAudio = new System.Drawing.Size(DefaultSizeModeWithAudioX, DefaultSizeModeWithAudioY);
        private System.Drawing.Size DefaultSizeModeWithVideo = new System.Drawing.Size(DefaultSizeModeWithVideoX, DefaultSizeModeWithVideoY);

        private float SpeedShiftTmp;
        private float SpeedShift {
            get {
                return SpeedShiftTmp;
            }

            set {
                if (value < .0f) SpeedShiftTmp = 0.0f;
                else if (value > 3.0f) SpeedShiftTmp = 3.0f;
                else SpeedShiftTmp = value;
            }
        }
        #endregion
        #region Code
        public fMediaPlayer() {
            InitializeComponent();
            
            timer1.Start();

            AllowDrop = true;
            DragDrop += new DragEventHandler(Form1_DragDrop);
            DragEnter += new DragEventHandler(Form1_DragEnter);

            WMP.Size = DefaultSizeModeWithAudio;
            WMP.Height -= tbVolume.Height + 40;
            WMP.settings.autoStart = true;

            // Установка стилей для кнопок
            // SetStyle(MediaPlayer.styleImage);

            //HOOK SPACE Где-то не работает как нужно объект
            KeyboardHook.KeyboardUp += new KeyEventHandler(KeyboardHook_KeyboardClick);
            KeyboardHook.LocalHook = false;
            KeyboardHook.InstallHook();

            MouseHook.MouseUp += new MouseEventHandler(MouseHook_MouseClick);
            MouseHook.LocalHook = false;
            MouseHook.InstallHook();

            Application.AddMessageFilter(this);
            //loadHook();
            //lbMusicList.BackgroundImage = System.Drawing.Image.FromFile(@"D:\AirSendit\grafmen9999_5ae762e8-30ea-4f1b-a266-4faa64ce0f2b\anime-art\30306773747_5facb8627c_o.jpg");
        }

        private void SetStyle(int style)
        {
            if (style == 0)
            {
                SetImageForButton(btnControlsMusic, (IsPlayingMusic) ? Properties.Resources.imageButtonPause : Properties.Resources.imageButtonPlay);
                SetImageForButton(btnNextMusic, Properties.Resources.imageButtonNext);
                SetImageForButton(btnPreviousMusic, Properties.Resources.imageButtonPrevious);
            }
            else if (style == 1)
            {
                SetImageForButton(btnControlsMusic, (IsPlayingMusic) ? Properties.Resources.imageButtonPause1 : Properties.Resources.imageButtonPlay1);
                SetImageForButton(btnNextMusic, Properties.Resources.imageButtonNext1);
                SetImageForButton(btnPreviousMusic, Properties.Resources.imageButtonPrevious1);
            }
            else if (style == 2)
            {
                SetImageForButton(btnControlsMusic, (IsPlayingMusic) ? Properties.Resources.imageButtonPause3 : Properties.Resources.imageButtonPlay3);
                SetImageForButton(btnNextMusic, Properties.Resources.imageButtonNext3);
                SetImageForButton(btnPreviousMusic, Properties.Resources.imageButtonPrevious3);
            }
        }

        private void SetImageForButton(Button btn, System.Drawing.Bitmap image)
        {
            btn.BackgroundImage = image;
        }

        private void SetButtomStyle(Button btn, int style)
        {
            if (style == 0)
            {
                if (btn == btnNextMusic) SetImageForButton(btn, (IsMousePressed) ? Properties.Resources.imageButtonNextShift : Properties.Resources.imageButtonNext);
                else if (btn == btnPreviousMusic) SetImageForButton(btn, (IsMousePressed) ? Properties.Resources.imageButtonPreviousShift : Properties.Resources.imageButtonPrevious);
                else if (btn == btnControlsMusic) SetImageForButton(btn, (IsPlayingMusic) ? Properties.Resources.imageButtonPause : Properties.Resources.imageButtonPlay);
            }
            else if (style == 1)
            {
                if (btn == btnNextMusic) SetImageForButton(btn, (IsMousePressed) ? Properties.Resources.imageButtonNextShift1 : Properties.Resources.imageButtonNext1);
                else if (btn == btnPreviousMusic) SetImageForButton(btn, (IsMousePressed) ? Properties.Resources.imageButtonPreviousShift1 : Properties.Resources.imageButtonPrevious1);
                else if (btn == btnControlsMusic) SetImageForButton(btn, (IsPlayingMusic) ? Properties.Resources.imageButtonPause1 : Properties.Resources.imageButtonPlay1);
            }
            else if (style == 2)
            {
                if (btn == btnNextMusic) SetImageForButton(btn, (IsMousePressed) ? Properties.Resources.imageButtonNextShift3 : Properties.Resources.imageButtonNext3);
                else if (btn == btnPreviousMusic) SetImageForButton(btn, (IsMousePressed) ? Properties.Resources.imageButtonPreviousShift3 : Properties.Resources.imageButtonPrevious3);
                else if (btn == btnControlsMusic) SetImageForButton(btn, (IsPlayingMusic) ? Properties.Resources.imageButtonPause3 : Properties.Resources.imageButtonPlay3);
            }
        }

        private void FullScreen()
        {
            if (MediaPlayer.visibleVideo)
            {
                WMP.fullScreen = FullScreenMode;
            }
        }

        private void AddInPlayListWMP(string music)
        {
            WMPLib.IWMPMedia media = WMP.newMedia(music); // создаем новую медиа, и добавляем её в список
            WMP.currentPlaylist.appendItem(media);
        }

        private void RemoveInPlayListWMP(string music)
        {
            WMPLib.IWMPMedia media = GetWMPMediaInList(music);
            WMP.currentPlaylist.removeItem(media);
        }

        private WMPLib.IWMPMedia GetWMPMediaInList(string urlMusic)
        {
            WMPLib.IWMPMedia media = null;
            for (int i = 0; i < WMP.currentPlaylist.count; i++)
            {
                media = WMP.currentPlaylist.Item[i];
                if (media.sourceURL == urlMusic) break;
            }

            return media;
        }

        private void MakeMusicNext() {
            string url;
            try
            {
                url = WMP.currentMedia.sourceURL;
                //url = WMP.URL;
                if (MediaPlayer.randomMusic)
                {
                    int rnd = new Random().Next(MediaPlayer.list.IndexOf(url) + 1, MediaPlayer.list.Count);

                    if (MediaPlayer.currentMusic == MediaPlayer.list.Last())
                    {
                        rnd = new Random().Next(0, MediaPlayer.list.IndexOf(url));
                    }

                    MediaPlayer.currentMusic = MediaPlayer.list[rnd];
                }
                else
                    MediaPlayer.currentMusic = (!url.Any()) ? MediaPlayer.list[0] : ((url != MediaPlayer.list.Last()) ? MediaPlayer.list[MediaPlayer.list.IndexOf(url) + 1] : MediaPlayer.list[0]);

                //WMP.Ctlcontrols.next();
                //WMP.URL = MediaPlayer.currentMusic;
                //WMP.currentMedia = WMP.newMedia(MediaPlayer.currentMusic);
                //WMP.Ctlcontrols.currentItem = GetWMPMediaInList(MediaPlayer.currentMusic);
                WMP.Ctlcontrols.playItem(GetWMPMediaInList(MediaPlayer.currentMusic));
                //WMP.Ctlcontrols.play();
                SelectItem(GetMusicInList(MediaPlayer.currentMusic));
            }
            catch { }
        }

        private void MakeMusicPrevious() {
            string url;
            try
            {
                url = WMP.currentMedia.sourceURL;
                //url = WMP.URL;

                if (MediaPlayer.randomMusic)
                {
                    int rnd = new Random().Next(0, MediaPlayer.list.IndexOf(url));

                    if (MediaPlayer.currentMusic == MediaPlayer.list.First())
                    {
                        rnd = new Random().Next(1, MediaPlayer.list.Count);
                    }

                    MediaPlayer.currentMusic = MediaPlayer.list[rnd];
                }
                else
                {
                    MediaPlayer.currentMusic = (!url.Any()) ? MediaPlayer.list[0] : ((url != MediaPlayer.list.First())) ? MediaPlayer.list[MediaPlayer.list.IndexOf(url) - 1] : MediaPlayer.list.Last();
                }

                //WMP.Ctlcontrols.previous();
                //WMP.URL = MediaPlayer.currentMusic;
                //WMP.currentMedia = WMP.newMedia(MediaPlayer.currentMusic);
                //WMP.Ctlcontrols.currentItem = GetWMPMediaInList(MediaPlayer.currentMusic);
                //WMP.Ctlcontrols.play();
                WMP.Ctlcontrols.playItem(GetWMPMediaInList(MediaPlayer.currentMusic));
                SelectItem(GetMusicInList(MediaPlayer.currentMusic));
            }
            catch { }
        }

        private void MakeMusicRepeat() {
            WMP.URL = MediaPlayer.currentMusic;
            SelectItem(GetMusicInList(MediaPlayer.currentMusic));
        }

        private void btnOpenFile_Click(object sender, EventArgs e) { // "Открыть файл"
            string[] paths;

            FileDialog fd = new OpenFileDialog {
                SupportMultiDottedExtensions = true,
                Title = "Выберите медиа-файл",
                Filter = "Медиа-файлы|*.mp3|Видео-файлы|*.mp4|Все файлы|*.*",
                Multiselect = true
            };

            if (fd.ShowDialog() == DialogResult.OK) {
                paths = fd.FileNames;

                foreach (string s in paths) {
                    if (!MediaPlayer.list.Contains(s)) {
                        MediaPlayer.list.Add(s);
                    }
                }

                MediaPlayer.Sort();
                lbMusicList.Items.Clear();
                AddTextInListBox(lbMusicList);
                SelectItem(GetMusicInList(MediaPlayer.currentMusic));
                deleteToolStripMenuItem.Enabled = true;
                //WMP.currentPlaylist.clear();
                //LoadInPlayListWMP();
                LoadNewFileInPlayList();
            }
        }

        private void tbVolume_Scroll(object sender, EventArgs e) {
            MediaPlayer.Volume = tbVolume.Value;
            WMP.settings.volume = MediaPlayer.Volume;
        }

        private void NewPlayList() { 
            // Создание нового плэй-листа, избавить код от всякой хуйни, и оптимизировать чего-то
            /*
             * 1) Остановить музыку
             * 2) Сохранить информацию о старом плей-листе
             * 3) Установить новый плей-лист
             * 
            */
            WMP.Ctlcontrols.stop();
            //WMP.Ctlcontrols.currentItem = null;

            MediaPlayer.list.Clear();
            MediaPlayer.currentPlayList = MediaPlayer.tmpCurPL;
            MediaPlayer.currentPosition = 0.0;
            MediaPlayer.currentMusic = "";
            
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                if (fbd.ShowDialog() == DialogResult.OK) {
                    //MediaPlayer.LastFolder = fbd.SelectedPath;
                    MediaPlayer.ReadMusic(fbd.SelectedPath);
                    MediaPlayer.SaveList();
                    WMP.currentPlaylist.clear();
                    LoadInPlayListWMP();
                    PlayMusic();
                    lbMusicList.Items.Clear();
                    AddTextInListBox(lbMusicList);
                    SelectItem(GetMusicInList(MediaPlayer.currentMusic));
                }

            MediaPlayer.SaveListSettings();
            MediaPlayer.SaveSettings();
        }

        private void btnSettings_Click(object sender, EventArgs e) {
            OpenSettings();
        }

        private void tbTimePassed_Scroll(object sender, EventArgs e) {
            int tProc;
            double tElapsed, tDuration;

            if (WMP.currentPlaylist.count > 0) {
                tProc = tbTimePassed.Value;
                tDuration = WMP.currentMedia.duration;
                tElapsed = (tProc * tDuration) / 100;
                WMP.Ctlcontrols.currentPosition = tElapsed;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            double timeDuration, timeElapsed;
            try
            {
                if (WMP.Ctlcontrols.currentItem != null)
                {
                    if (IsMousePressed)
                    {
                        SpeedShift += .05f;
                        if (PressedButton)
                        {
                            // >>
                            if (SpeedShift >= 0.15)
                                SetButtomStyle(btnNextMusic, MediaPlayer.styleImage);
                            //btnNextMusic.BackgroundImage = Properties.Resources.imageButtonNextShift3;
                            WMP.Ctlcontrols.currentPosition += SpeedShift;
                        }
                        else
                        {
                            if (SpeedShift >= 0.15)
                                SetButtomStyle(btnPreviousMusic, MediaPlayer.styleImage);
                            //btnPreviousMusic.BackgroundImage = Properties.Resources.imageButtonPreviousShift3;

                            if (WMP.Ctlcontrols.currentPosition > SpeedShift)
                                WMP.Ctlcontrols.currentPosition -= SpeedShift;
                            else
                                WMP.Ctlcontrols.currentPosition = 0;
                        }
                    }

                    timeDuration = WMP.currentMedia.duration;
                    timeElapsed = WMP.Ctlcontrols.currentPosition;
                    tbTimePassed.Value = (int)(timeElapsed / timeDuration * 100.0);

                    if (/*WMP.currentMedia.name == GetMusicInList(MediaPlayer.currentMusic) && */timeDuration <= timeElapsed)
                    {
                        if (MediaPlayer.repeatMusic) MakeMusicRepeat();
                        else MakeMusicNext();
                    }
                }
            }
            catch {}

            if (FullScreenMode && !WMP.fullScreen) // снятие полноэкранного режима, если вдруг нас выкинуло из него, а мы ничего не жали для этого
            {
                FullScreenMode = false; 
            }
        }

        private void btnControlsMusic_Click(object sender, EventArgs e) {
            if (WMP.playState == WMPLib.WMPPlayState.wmppsPlaying) {
                PauseMusic();
            }
            else {
                PlayMusic();
            }
        }

        private void PlayMusic() {
            try
            {
                if (WMP.Ctlcontrols.currentItem.sourceURL.Any())
                {
                    WMP.Ctlcontrols.play();
                    MediaPlayer.currentMusic = WMP.Ctlcontrols.currentItem.sourceURL;
                }
                else if (!MediaPlayer.currentMusic.Any())
                {
                    MediaPlayer.currentMusic = (MediaPlayer.randomMusic) ? MediaPlayer.list[new Random().Next(0, MediaPlayer.list.Count)] : MediaPlayer.list[0];
                    WMP.Ctlcontrols.playItem(GetWMPMediaInList(MediaPlayer.currentMusic));
                }
                else
                {
                    WMP.Ctlcontrols.playItem(GetWMPMediaInList(MediaPlayer.currentMusic));
                    // WMP.Ctlcontrols.play();
                }
                
                SelectItem(GetMusicInList(MediaPlayer.currentMusic));

                //btnControlsMusic.BackgroundImage = Properties.Resources.imageButtonPause3;

                IsPlayingMusic = true;
                SetButtomStyle(btnControlsMusic, MediaPlayer.styleImage);
            }
            catch { }
        }

        private void PauseMusic() {
            WMP.Ctlcontrols.pause();
            //btnControlsMusic.BackgroundImage = Properties.Resources.imageButtonPlay3;

            IsPlayingMusic = false;
            SetButtomStyle(btnControlsMusic, MediaPlayer.styleImage);
        }

        private void fMediaPlayer_Load(object sender, EventArgs e) {
            try {
                MediaPlayer.LoadSettings();
                MediaPlayer.LoadCustomSettings();
                tbVolume.Value = MediaPlayer.Volume;
                WMP.settings.volume = MediaPlayer.Volume;

                if (MediaPlayer.GetExistFile(MediaPlayer.currentPlayList) && MediaPlayer.GetExistRegistry(MediaPlayer.currentPlayList)) {
                    MediaPlayer.LoadListSettings();
                    MediaPlayer.LoadList();
                    lbMusicList.Items.Clear();
                    AddTextInListBox(lbMusicList);
                    // Start music
                    WMP.currentPlaylist.clear();
                    LoadInPlayListWMP();

                    if (!MediaPlayer.currentMusic.Any())
                    {
                        MediaPlayer.currentMusic = (MediaPlayer.randomMusic) ? MediaPlayer.list[new Random().Next(0, MediaPlayer.list.Count)] : MediaPlayer.list[0];
                        WMP.Ctlcontrols.playItem(GetWMPMediaInList(MediaPlayer.currentMusic));
                    }
                    else
                    {
                        WMP.Ctlcontrols.playItem(GetWMPMediaInList(MediaPlayer.currentMusic));
                        // WMP.Ctlcontrols.play();
                    }
                    SelectItem(GetMusicInList(MediaPlayer.currentMusic));
                    //* ** * * ** * * ** * * ** * ** * ** * * ** * ** * * ** * ** * * ** * ** * * ** * * ** * ** * * ** * *
                    WMP.Ctlcontrols.playItem(GetWMPMediaInList(MediaPlayer.currentMusic));
                    WMP.Ctlcontrols.currentPosition = MediaPlayer.currentPosition;
                    PlayMusic();
                    deleteToolStripMenuItem.Enabled = true;
                }
                else {
                    OpenSettings();
                }

                if (MediaPlayer.visibleVideo)
                {
                    SetSizeMode(DefaultSizeModeWithVideo);
                    WMP.uiMode = "none";
                }
                else
                {
                    SetSizeMode(DefaultSizeModeWithAudio);
                    WMP.uiMode = "invisible";
                }
            }
            catch { }

            SetStyle(MediaPlayer.styleImage);

            //timer1.Start();
        }

        private void LoadInPlayListWMP()
        {
            foreach (string music in MediaPlayer.list)
            {
                AddInPlayListWMP(music);
            }
        }

        private void fMediaPlayer_FormClosing(object sender, FormClosingEventArgs e) {
            PauseMusic();
            MediaPlayer.SaveSettings();
            MediaPlayer.SaveCustomSettings();

            if (MediaPlayer.list.Any()) {
                MediaPlayer.currentPosition = WMP.Ctlcontrols.currentPosition;
                MediaPlayer.SaveListSettings();
                MediaPlayer.SaveList();
            }

            WMP.close();
            // HOOK SPACE
            KeyboardHook.UnInstallHook();
            MouseHook.UnInstallHook();
        }

        private void AddTextInListBox(ListBox listBox) {
            string[] array = MediaPlayer.list.ToArray();

            foreach(string s1 in array) {
                listBox.Items.Add(GetMusicInList(s1));
            }
        }

        private void lbMusicList_SelectedIndexChanged(object sender, EventArgs e) {
            string text = "";

            try {
                text = ((ListBox)sender).SelectedItem.ToString();

                foreach (string t1 in MediaPlayer.list)
                    MediaPlayer.currentMusic = (GetMusicInList(t1) == text) ? t1 : MediaPlayer.currentMusic;

                if (WMP.currentMedia.sourceURL != MediaPlayer.currentMusic) {
                    //WMP.currentMedia = WMP.newMedia(MediaPlayer.currentMusic);
                    //WMP.URL = MediaPlayer.currentMusic;
                    //WMP.Ctlcontrols.currentItem = GetWMPMediaInList(MediaPlayer.currentMusic);
                    if (!isProgramSelected)
                        WMP.Ctlcontrols.playItem(GetWMPMediaInList(MediaPlayer.currentMusic));

                    //btnControlsMusic.BackgroundImage = Properties.Resources.imageButtonPause3;

                    IsPlayingMusic = true;
                    SetButtomStyle(btnControlsMusic, MediaPlayer.styleImage);
                }
            }
            catch { }
         }

        private void btn_MouseDown(object sender, MouseEventArgs e) {
            DateTimeNever = DateTime.Now;
            WMP.Ctlcontrols.pause();
            IsMousePressed = true;
            SpeedShift = 0.00f;

            if ((Button)sender == btnNextMusic) {
                PressedButton = true;
            }
            else {
                PressedButton = false;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            //string nextMusic = ((WMP.URL != MediaPlayer.list.Last()) ? MediaPlayer.list[MediaPlayer.list.IndexOf(WMP.URL) + 1] : MediaPlayer.list[0]);
            if (MediaPlayer.list.Count == 0)
                return;

            string url = WMP.currentMedia.sourceURL;
            int indexOf = MediaPlayer.list.IndexOf(url);

            MediaPlayer.list.RemoveAt(GetIdMusicInList(lbMusicList.SelectedItem.ToString()));
            lbMusicList.Items.Remove(lbMusicList.SelectedItem.ToString());

            if (MediaPlayer.list.Count == 0) {
                PauseMusic();
                WMP.Ctlcontrols.stop();
                // WMP.Ctlcontrols.currentItem = null; // Эта фигня вызывает исключение, т.е ошибку, было что-то типа URL=""; обнуление url-a
                deleteToolStripMenuItem.Enabled = false;

                RemoveInPlayListWMP(url);
                return;
            }

            string nextMusic = (MediaPlayer.list.Count == indexOf) ? MediaPlayer.list[indexOf - 1] : MediaPlayer.list[indexOf];
            MediaPlayer.currentMusic = nextMusic;
            
            WMP.Ctlcontrols.playItem(GetWMPMediaInList(MediaPlayer.currentMusic));
            SelectItem(GetMusicInList(MediaPlayer.currentMusic));

            RemoveInPlayListWMP(url);
        }

        private void btn_MouseUp(object sender, MouseEventArgs e) {
            DateTimeNow = DateTime.Now;
            IsMousePressed = false;
            int second = Math.Abs(DateTimeNow.Second - DateTimeNever.Second);
            int millisecond = Math.Abs(DateTimeNever.Millisecond - DateTimeNow.Millisecond);
            double time = second + (millisecond / 1000.0);

            if (time <= 0.15)
                if (PressedButton) {
                    MakeMusicNext();
                }
                else {
                    MakeMusicPrevious();
                }

            if (PressedButton)
                SetButtomStyle(btnNextMusic, MediaPlayer.styleImage);
            //btnNextMusic.BackgroundImage = Properties.Resources.imageButtonNext3;
            else
                SetButtomStyle(btnPreviousMusic, MediaPlayer.styleImage);
            //btnPreviousMusic.BackgroundImage = Properties.Resources.imageButtonPrevious3;

            PlayMusic();
            SpeedShift = 0.00f;
        }

        private string GetMusicInList(string str) {
            try {
                string tmp = str.Split('\\').Last();
                return tmp.Substring(0, tmp.Length - 4);
            }
            catch { }

            return str;
        }

        private int GetIdMusicInList(string str) {
            int id = -1;
            string[] array = MediaPlayer.list.ToArray();

            for (int i = 0; i < array.Length; i++) {
                if (GetMusicInList(array[i]) == str) {
                    id = i;
                    break;
                }
            }

            return id;
        }
        
        private void OpenSettings() {
            IsOpenedSettings = true;
            Application.RemoveMessageFilter(this);

            this.Hide();

            if (fs.ShowDialog() == DialogResult.OK) {
                // сохраняем информацию о старом листе, если меняем его.
                //*************************************************************************************************************
                string tmp = MediaPlayer.currentPlayList;

                if (tmp != MediaPlayer.tmpCurPL) {
                    MediaPlayer.currentPosition = WMP.Ctlcontrols.currentPosition;
                    MediaPlayer.SaveListSettings();

                    if (MediaPlayer.GetExistRegistry(MediaPlayer.tmpCurPL) && MediaPlayer.GetExistFile(MediaPlayer.tmpCurPL)) {
                        MediaPlayer.currentPlayList = MediaPlayer.tmpCurPL;
                        MediaPlayer.LoadListSettings();
                        MediaPlayer.LoadList();
                    }
                    else {
                        WMP.currentPlaylist.clear();
                        NewPlayList();
                        this.Show();
                        IsOpenedSettings = false;
                        return;
                    }
                }

                //**************************************************************************************************************

                //PlayMusic();
                lbMusicList.Items.Clear();
                AddTextInListBox(lbMusicList);
                SelectItem(GetMusicInList(MediaPlayer.currentMusic));
                deleteToolStripMenuItem.Enabled = true;
                LoadNewFileInPlayList(); // добавим в плей-лист новые композиции, если таковые имеются

                if (tmp != MediaPlayer.tmpCurPL)
                {
                    // почистить плей-лист, и сразу же добавить в него обновленный
                    /*
                    WMP.Ctlcontrols.currentItem = GetWMPMediaInList(MediaPlayer.currentMusic);
                    PlayMusic();
                    WMP.Ctlcontrols.currentPosition = MediaPlayer.currentPosition;
                    */
                    WMP.Ctlcontrols.playItem(GetWMPMediaInList(MediaPlayer.currentMusic));
                    PlayMusic();
                    WMP.Ctlcontrols.currentPosition = MediaPlayer.currentPosition;
                }
            }

            this.Show();
            if (MediaPlayer.visibleVideo)
            {
                SetSizeMode(DefaultSizeModeWithVideo);
                WMP.uiMode = "none";
            }
            else
            {
                SetSizeMode(DefaultSizeModeWithAudio);
                WMP.uiMode = "invisible";
            }

            Application.AddMessageFilter(this);
            IsOpenedSettings = false;

            SetStyle(MediaPlayer.styleImage);
        }

        private void SelectItem(string item)
        {
            isProgramSelected = true;
            lbMusicList.SelectedItem = item;
            isProgramSelected = false;
        }

        private void SetSizeMode(System.Drawing.Size size)
        {
            MinimumSize = size;
            MaximumSize = size;
            // Size = size;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                //MessageBox.Show(file.Substring(file.Length - 5, file.Length-1));
                if (!MediaPlayer.list.Contains(file) && FileExtension.Contains(file.Substring(file.Length - 4))) MediaPlayer.list.Add(file);
            }

            MediaPlayer.Sort();
            lbMusicList.Items.Clear();
            AddTextInListBox(lbMusicList);

            //double curPos = WMP.Ctlcontrols.currentPosition;
            LoadNewFileInPlayList();

            //WMP.Ctlcontrols.playItem(GetWMPMediaInList(MediaPlayer.currentMusic));
            //WMP.Ctlcontrols.currentPosition = curPos;

            SelectItem(GetMusicInList(MediaPlayer.currentMusic));
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void LoadNewFileInPlayList()
        {
            string[] collectionURL = new string[WMP.currentPlaylist.count];

            for (int i = 0; i < WMP.currentPlaylist.count; i++)
                collectionURL[i] = WMP.currentPlaylist.Item[i].sourceURL;

            foreach(string url in MediaPlayer.list)
            {
                if (!collectionURL.Contains(url))
                {
                    AddInPlayListWMP(url);
                }
            }
        }
        #endregion

        #region IMessageFilter Members

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == Hooks.KeyboardHook.WM_KEYDOWN)
            {
                Keys keyCode = (Keys)(int)m.WParam & Keys.KeyCode;
                if (keyCode == MediaPlayer.keyFullScreen)
                {
                    try
                    {
                        if (MediaPlayer.visibleVideo && WMP.currentPlaylist.count > 0)
                            WMP.fullScreen = !WMP.fullScreen;
                        FullScreenMode = WMP.fullScreen;
                    }

                    catch { }
                }

                return true;
            }
            return false;
        }
        #endregion

        #region Hook Method
        private void MouseHook_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (FullScreenMode)
                {
                    if (IsPlayingMusic) PlayMusic();
                    else PauseMusic();
                }
            }
            
        }

        private void KeyboardHook_KeyboardClick(object sender, KeyEventArgs e)
        {
            if (!IsOpenedSettings) return;
            MessageBox.Show("DETECTED");

            if (e.KeyCode == MediaPlayer.keyPlayPause)
            {
                if (WMP.playState == WMPLib.WMPPlayState.wmppsPlaying) PauseMusic();
                else PlayMusic();
            }
            else if (e.KeyCode == MediaPlayer.keyNextMusic)
            {
                MakeMusicNext();
            }
            else if (e.KeyCode == MediaPlayer.keyPreviousMusic)
            {
                MakeMusicPrevious();
            }
            else if (e.KeyCode == MediaPlayer.keyNextShift)
            {
                double tElapsed, tDuration;

                if (WMP.currentPlaylist.count > 0)
                {
                    tDuration = WMP.currentMedia.duration;
                    tElapsed = WMP.Ctlcontrols.currentPosition;

                    if (tElapsed + MediaPlayer.defaultOffsetShift < tDuration) WMP.Ctlcontrols.currentPosition += MediaPlayer.defaultOffsetShift;
                    else WMP.Ctlcontrols.currentPosition += tDuration - tElapsed;
                }
            }
            else if (e.KeyCode == MediaPlayer.keyPreviousShift)
            {
                double tElapsed;

                if (WMP.currentPlaylist.count > 0)
                {
                    tElapsed = WMP.Ctlcontrols.currentPosition;

                    if (tElapsed - MediaPlayer.defaultOffsetShift >= 0.0) WMP.Ctlcontrols.currentPosition -= MediaPlayer.defaultOffsetShift;
                    else WMP.Ctlcontrols.currentPosition = 0.0;
                }
            }
            else if (e.KeyCode == MediaPlayer.keyVolumeUp)
            {
                if (MediaPlayer.Volume <= tbVolume.Maximum - MediaPlayer.defaultOffsetVolume) MediaPlayer.Volume += MediaPlayer.defaultOffsetVolume;
                else MediaPlayer.Volume += (tbVolume.Maximum - MediaPlayer.Volume);

                tbVolume.Value = MediaPlayer.Volume;
                WMP.settings.volume = MediaPlayer.Volume;
            }
            else if (e.KeyCode == MediaPlayer.keyVolumeDown)
            {
                if (MediaPlayer.Volume >= MediaPlayer.defaultOffsetVolume) MediaPlayer.Volume -= MediaPlayer.defaultOffsetVolume;
                else MediaPlayer.Volume -= MediaPlayer.Volume;

                tbVolume.Value = MediaPlayer.Volume;
                WMP.settings.volume = MediaPlayer.Volume;
            }
        }
        #endregion
        /*
        #region hook
        private Thread threadUpdate = null;
        private bool threadInitialized = false;
        private static int hHook = 0;
        private HookProc KeyboardLLProcedure;

        public void MouseHook_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (FullScreenMode)
                {
                    if (IsPlayingMusic) PlayMusic();
                    else PauseMusic();
                }
            }
        }

        public int KeyboardLLProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (!IsOpenedSettings)
            {
                if (nCode >= 0)
                {
                    KBDLLHOOKSTRUCT pKBDLLHOOKSTRUCT = new KBDLLHOOKSTRUCT();
                    pKBDLLHOOKSTRUCT = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, pKBDLLHOOKSTRUCT.GetType());
                    {
                        if (wParam == (IntPtr)WM_KEYUP)
                        {
                            Keys kCode = (Keys)pKBDLLHOOKSTRUCT.vkCode;

                            if (kCode == MediaPlayer.keyPlayPause)
                            {
                                if (WMP.playState == WMPLib.WMPPlayState.wmppsPlaying) PauseMusic();
                                else PlayMusic();
                            }
                            else if (kCode == MediaPlayer.keyNextMusic)
                            {
                                MakeMusicNext();
                            }
                            else if (kCode == MediaPlayer.keyPreviousMusic)
                            {
                                MakeMusicPrevious();
                            }
                            else if (kCode == MediaPlayer.keyNextShift)
                            {
                                double tElapsed, tDuration;

                                if (WMP.currentPlaylist.count > 0)
                                {
                                    tDuration = WMP.currentMedia.duration;
                                    tElapsed = WMP.Ctlcontrols.currentPosition;

                                    if (tElapsed + MediaPlayer.defaultOffsetShift < tDuration) WMP.Ctlcontrols.currentPosition += MediaPlayer.defaultOffsetShift;
                                    else WMP.Ctlcontrols.currentPosition += tDuration - tElapsed;
                                }
                            }
                            else if (kCode == MediaPlayer.keyPreviousShift)
                            {
                                double tElapsed;

                                if (WMP.currentPlaylist.count > 0)
                                {
                                    tElapsed = WMP.Ctlcontrols.currentPosition;

                                    if (tElapsed - MediaPlayer.defaultOffsetShift >= 0.0) WMP.Ctlcontrols.currentPosition -= MediaPlayer.defaultOffsetShift;
                                    else WMP.Ctlcontrols.currentPosition = 0.0;
                                }
                            }
                            else if (kCode == MediaPlayer.keyVolumeUp)
                            {
                                if (MediaPlayer.Volume <= tbVolume.Maximum - MediaPlayer.defaultOffsetVolume) MediaPlayer.Volume += MediaPlayer.defaultOffsetVolume;
                                else MediaPlayer.Volume += (tbVolume.Maximum - MediaPlayer.Volume);

                                tbVolume.Value = MediaPlayer.Volume;
                                WMP.settings.volume = MediaPlayer.Volume;
                            }
                            else if (kCode == MediaPlayer.keyVolumeDown)
                            {
                                if (MediaPlayer.Volume >= MediaPlayer.defaultOffsetVolume) MediaPlayer.Volume -= MediaPlayer.defaultOffsetVolume;
                                else MediaPlayer.Volume -= MediaPlayer.Volume;

                                tbVolume.Value = MediaPlayer.Volume;
                                WMP.settings.volume = MediaPlayer.Volume;
                            }
                        }
                    }
                }
            }

            return nCode < 0 ? CallNextHookEx(hHook, nCode, wParam, lParam) : 0;
        }

        private void loadHook()
        {
            threadUpdate = new Thread(new ThreadStart(UpdateThreadProc));
            threadUpdate.Start();

            if (hHook == 0)
            {
                KeyboardLLProcedure = new HookProc(KeyboardLLProc);
                hHook = SetWindowsHookEx((int)API.HookType.WH_KEYBOARD_LL, KeyboardLLProcedure, (IntPtr)0, 0);
            }
        }

        public void UpdateThreadProc()
        {
            while (!threadInitialized)
            {
                if (ActiveForm != null)
                    threadInitialized = true;
                Thread.Sleep(100);
            }
        }

        private void closeHook()
        {
            threadUpdate.Join();

            if (hHook != 0)
                UnhookWindowsHookEx(hHook);
        }
        #endregion
        
        
        #region HOOK_SETTINGS
        public const int WH_MIN = (-1);
        public const int WH_MSGFILTER = (-1);
        public const int WH_JOURNALRECORD = 0;
        public const int WH_JOURNALPLAYBACK = 1;
        public const int WH_KEYBOARD = 2;
        public const int WH_GETMESSAGE = 3;
        public const int WH_CALLWNDPROC = 4;
        public const int WH_CBT = 5;
        public const int WH_SYSMSGFILTER = 6;
        public const int WH_MOUSE = 7;
        public const int WH_HARDWARE = 8;
        public const int WH_DEBUG = 9;
        public const int WH_SHELL = 10;
        public const int WH_FOREGROUNDIDLE = 11;
        public const int WH_CALLWNDPROCRET = 12;
        public const int WH_KEYBOARD_LL = 13;
        public const int WH_MOUSE_LL = 14;
        public const int WH_MAX = 14;
        public const int WH_MINHOOK = WH_MIN;
        public const int WH_MAXHOOK = WH_MAX;
        
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct MSLLHOOKSTRUCT
        {
            public System.Drawing.Point pt;
            public int mouseData;
            public int flags;
            public int time;
            public uint dwExtraInfo;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct KBDLLHOOKSTRUCT
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public uint dwExtraInfo;
        }

        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x0101;

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        public delegate int SUBCLASSPROC(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr uIdSubclass, uint dwRefData);

        [DllImport("Comctl32.dll", SetLastError = true)]
        public static extern bool SetWindowSubclass(IntPtr hWnd, SUBCLASSPROC pfnSubclass, uint uIdSubclass, uint dwRefData);

        [DllImport("Comctl32.dll", SetLastError = true)]
        public static extern int DefSubclassProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);
        

        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_LBUTTONDBLCLK = 0x0203;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_RBUTTONUP = 0x0205;
        public const int WM_NCLBUTTONDBLCLK = 0x00A3;
        #endregion
        */
    }
}
