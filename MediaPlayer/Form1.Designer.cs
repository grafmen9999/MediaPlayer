namespace MediaPlayer
{
    partial class fMediaPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMediaPlayer));
            this.WMP = new AxWMPLib.AxWindowsMediaPlayer();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tbVolume = new System.Windows.Forms.TrackBar();
            this.btnSettings = new System.Windows.Forms.Button();
            this.tbTimePassed = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbMusicList = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnControlsMusic = new System.Windows.Forms.Button();
            this.btnPreviousMusic = new System.Windows.Forms.Button();
            this.btnNextMusic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WMP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimePassed)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WMP
            // 
            this.WMP.AccessibleRole = System.Windows.Forms.AccessibleRole.Application;
            this.WMP.Enabled = true;
            this.WMP.Location = new System.Drawing.Point(465, 0);
            this.WMP.Margin = new System.Windows.Forms.Padding(0);
            this.WMP.Name = "WMP";
            this.WMP.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WMP.OcxState")));
            this.WMP.Size = new System.Drawing.Size(411, 313);
            this.WMP.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(166, 265);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(95, 25);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "Добавить";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tbVolume
            // 
            this.tbVolume.Location = new System.Drawing.Point(261, 268);
            this.tbVolume.Maximum = 100;
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(198, 45);
            this.tbVolume.TabIndex = 3;
            this.tbVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbVolume.Scroll += new System.EventHandler(this.tbVolume_Scroll);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(166, 288);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(95, 25);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Настройки";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // tbTimePassed
            // 
            this.tbTimePassed.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbTimePassed.Location = new System.Drawing.Point(0, 317);
            this.tbTimePassed.Maximum = 100;
            this.tbTimePassed.Name = "tbTimePassed";
            this.tbTimePassed.Size = new System.Drawing.Size(879, 45);
            this.tbTimePassed.TabIndex = 5;
            this.tbTimePassed.Scroll += new System.EventHandler(this.tbTimePassed_Scroll);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbMusicList
            // 
            this.lbMusicList.BackColor = System.Drawing.SystemColors.Menu;
            this.lbMusicList.ContextMenuStrip = this.contextMenuStrip1;
            this.lbMusicList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbMusicList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMusicList.FormattingEnabled = true;
            this.lbMusicList.ItemHeight = 16;
            this.lbMusicList.Items.AddRange(new object[] {
            "Выберите папку с медиа-файлами"});
            this.lbMusicList.Location = new System.Drawing.Point(0, 0);
            this.lbMusicList.Name = "lbMusicList";
            this.lbMusicList.Size = new System.Drawing.Size(459, 260);
            this.lbMusicList.TabIndex = 9;
            this.lbMusicList.SelectedIndexChanged += new System.EventHandler(this.lbMusicList_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnControlsMusic
            // 
            this.btnControlsMusic.BackgroundImage = global::MediaPlayer.Properties.Resources.imageButtonPlay3;
            this.btnControlsMusic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnControlsMusic.Location = new System.Drawing.Point(60, 273);
            this.btnControlsMusic.Name = "btnControlsMusic";
            this.btnControlsMusic.Size = new System.Drawing.Size(50, 40);
            this.btnControlsMusic.TabIndex = 8;
            this.btnControlsMusic.UseVisualStyleBackColor = true;
            this.btnControlsMusic.Click += new System.EventHandler(this.btnControlsMusic_Click);
            // 
            // btnPreviousMusic
            // 
            this.btnPreviousMusic.BackgroundImage = global::MediaPlayer.Properties.Resources.imageButtonPrevious3;
            this.btnPreviousMusic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPreviousMusic.Location = new System.Drawing.Point(9, 273);
            this.btnPreviousMusic.Name = "btnPreviousMusic";
            this.btnPreviousMusic.Size = new System.Drawing.Size(50, 40);
            this.btnPreviousMusic.TabIndex = 7;
            this.btnPreviousMusic.UseVisualStyleBackColor = true;
            this.btnPreviousMusic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.btnPreviousMusic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btnNextMusic
            // 
            this.btnNextMusic.BackgroundImage = global::MediaPlayer.Properties.Resources.imageButtonNext3;
            this.btnNextMusic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNextMusic.Location = new System.Drawing.Point(110, 273);
            this.btnNextMusic.Name = "btnNextMusic";
            this.btnNextMusic.Size = new System.Drawing.Size(50, 40);
            this.btnNextMusic.TabIndex = 6;
            this.btnNextMusic.UseVisualStyleBackColor = true;
            this.btnNextMusic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.btnNextMusic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // fMediaPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 362);
            this.Controls.Add(this.lbMusicList);
            this.Controls.Add(this.btnControlsMusic);
            this.Controls.Add(this.btnPreviousMusic);
            this.Controls.Add(this.btnNextMusic);
            this.Controls.Add(this.tbTimePassed);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.tbVolume);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.WMP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "fMediaPlayer";
            this.Text = "Медиа-плеер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMediaPlayer_FormClosing);
            this.Load += new System.EventHandler(this.fMediaPlayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WMP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimePassed)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer WMP;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TrackBar tbVolume;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.TrackBar tbTimePassed;
        private System.Windows.Forms.Button btnNextMusic;
        private System.Windows.Forms.Button btnPreviousMusic;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnControlsMusic;
        private System.Windows.Forms.ListBox lbMusicList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

