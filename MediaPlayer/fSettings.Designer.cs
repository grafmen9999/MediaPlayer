namespace MediaPlayer
{
    partial class fSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSettings));
            this.btnEnumFolders = new System.Windows.Forms.Button();
            this.lblInformationPlayList = new System.Windows.Forms.Label();
            this.cbAllDirectories = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbRepeatMusic = new System.Windows.Forms.CheckBox();
            this.cbRandomMusic = new System.Windows.Forms.CheckBox();
            this.cbSelectedPlayList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbVisibleVideo = new System.Windows.Forms.CheckBox();
            this.btnCustomUserSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEnumFolders
            // 
            this.btnEnumFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEnumFolders.Location = new System.Drawing.Point(10, 54);
            this.btnEnumFolders.Name = "btnEnumFolders";
            this.btnEnumFolders.Size = new System.Drawing.Size(185, 30);
            this.btnEnumFolders.TabIndex = 0;
            this.btnEnumFolders.Text = "Выбрать директорию";
            this.btnEnumFolders.UseVisualStyleBackColor = true;
            this.btnEnumFolders.Click += new System.EventHandler(this.btnEnumFolders_Click);
            // 
            // lblInformationPlayList
            // 
            this.lblInformationPlayList.AutoSize = true;
            this.lblInformationPlayList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInformationPlayList.Location = new System.Drawing.Point(12, 9);
            this.lblInformationPlayList.Name = "lblInformationPlayList";
            this.lblInformationPlayList.Size = new System.Drawing.Size(167, 20);
            this.lblInformationPlayList.TabIndex = 1;
            this.lblInformationPlayList.Text = "Выберите плей-лист";
            // 
            // cbAllDirectories
            // 
            this.cbAllDirectories.AutoSize = true;
            this.cbAllDirectories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAllDirectories.Location = new System.Drawing.Point(10, 91);
            this.cbAllDirectories.Name = "cbAllDirectories";
            this.cbAllDirectories.Size = new System.Drawing.Size(164, 24);
            this.cbAllDirectories.TabIndex = 2;
            this.cbAllDirectories.Text = "Вложенные папки";
            this.cbAllDirectories.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.Location = new System.Drawing.Point(156, 190);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 30);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Location = new System.Drawing.Point(242, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbRepeatMusic
            // 
            this.cbRepeatMusic.AutoSize = true;
            this.cbRepeatMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbRepeatMusic.Location = new System.Drawing.Point(10, 112);
            this.cbRepeatMusic.Name = "cbRepeatMusic";
            this.cbRepeatMusic.Size = new System.Drawing.Size(247, 24);
            this.cbRepeatMusic.TabIndex = 5;
            this.cbRepeatMusic.Text = "Повтор текущей композиции";
            this.cbRepeatMusic.UseVisualStyleBackColor = true;
            // 
            // cbRandomMusic
            // 
            this.cbRandomMusic.AutoSize = true;
            this.cbRandomMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbRandomMusic.Location = new System.Drawing.Point(10, 132);
            this.cbRandomMusic.Name = "cbRandomMusic";
            this.cbRandomMusic.Size = new System.Drawing.Size(206, 24);
            this.cbRandomMusic.TabIndex = 6;
            this.cbRandomMusic.Text = "Случайные композиции";
            this.cbRandomMusic.UseVisualStyleBackColor = true;
            // 
            // cbSelectedPlayList
            // 
            this.cbSelectedPlayList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbSelectedPlayList.FormattingEnabled = true;
            this.cbSelectedPlayList.Location = new System.Drawing.Point(201, 59);
            this.cbSelectedPlayList.Name = "cbSelectedPlayList";
            this.cbSelectedPlayList.Size = new System.Drawing.Size(124, 23);
            this.cbSelectedPlayList.Sorted = true;
            this.cbSelectedPlayList.TabIndex = 7;
            this.cbSelectedPlayList.Text = "Selected play list";
            this.cbSelectedPlayList.SelectedIndexChanged += new System.EventHandler(this.cbSelectedPlayList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(183, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Выберите плей-лист";
            // 
            // cbVisibleVideo
            // 
            this.cbVisibleVideo.AutoSize = true;
            this.cbVisibleVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbVisibleVideo.Location = new System.Drawing.Point(10, 152);
            this.cbVisibleVideo.Name = "cbVisibleVideo";
            this.cbVisibleVideo.Size = new System.Drawing.Size(174, 24);
            this.cbVisibleVideo.TabIndex = 9;
            this.cbVisibleVideo.Text = "Отображать видео";
            this.cbVisibleVideo.UseVisualStyleBackColor = true;
            // 
            // btnCustomUserSettings
            // 
            this.btnCustomUserSettings.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCustomUserSettings.Location = new System.Drawing.Point(10, 182);
            this.btnCustomUserSettings.Name = "btnCustomUserSettings";
            this.btnCustomUserSettings.Size = new System.Drawing.Size(87, 41);
            this.btnCustomUserSettings.TabIndex = 10;
            this.btnCustomUserSettings.Text = "Настройки пользователя";
            this.btnCustomUserSettings.UseVisualStyleBackColor = false;
            this.btnCustomUserSettings.Click += new System.EventHandler(this.btnCustomUserSettings_Click);
            // 
            // fSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 232);
            this.Controls.Add(this.btnCustomUserSettings);
            this.Controls.Add(this.cbVisibleVideo);
            this.Controls.Add(this.cbAllDirectories);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSelectedPlayList);
            this.Controls.Add(this.cbRandomMusic);
            this.Controls.Add(this.cbRepeatMusic);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblInformationPlayList);
            this.Controls.Add(this.btnEnumFolders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 270);
            this.MinimumSize = new System.Drawing.Size(350, 270);
            this.Name = "fSettings";
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fSettings_FormClosing);
            this.Load += new System.EventHandler(this.fSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnumFolders;
        private System.Windows.Forms.Label lblInformationPlayList;
        private System.Windows.Forms.CheckBox cbAllDirectories;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbRepeatMusic;
        private System.Windows.Forms.CheckBox cbRandomMusic;
        private System.Windows.Forms.ComboBox cbSelectedPlayList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbVisibleVideo;
        private System.Windows.Forms.Button btnCustomUserSettings;
    }
}