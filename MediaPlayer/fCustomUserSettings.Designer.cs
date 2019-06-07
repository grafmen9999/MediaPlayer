namespace MediaPlayer
{
    partial class fCustomUserSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCustomUserSettings));
            this.udChangeStyle = new System.Windows.Forms.DomainUpDown();
            this.tbFullScreenMode = new System.Windows.Forms.TextBox();
            this.tbPlayPause = new System.Windows.Forms.TextBox();
            this.tbPreviousMusic = new System.Windows.Forms.TextBox();
            this.tbNextMusic = new System.Windows.Forms.TextBox();
            this.tbShiftPrevious = new System.Windows.Forms.TextBox();
            this.tbShiftNext = new System.Windows.Forms.TextBox();
            this.tbVolumeUp = new System.Windows.Forms.TextBox();
            this.tbVolumeDown = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbOffsetVolume = new System.Windows.Forms.TextBox();
            this.tbOffsetShift = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // udChangeStyle
            // 
            this.udChangeStyle.InterceptArrowKeys = false;
            this.udChangeStyle.Items.Add("Стиль 1");
            this.udChangeStyle.Items.Add("Стиль 2");
            this.udChangeStyle.Items.Add("Стиль 3");
            this.udChangeStyle.Location = new System.Drawing.Point(16, 260);
            this.udChangeStyle.Name = "udChangeStyle";
            this.udChangeStyle.ReadOnly = true;
            this.udChangeStyle.Size = new System.Drawing.Size(68, 20);
            this.udChangeStyle.Sorted = true;
            this.udChangeStyle.TabIndex = 0;
            this.udChangeStyle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.udChangeStyle.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.udChangeStyle.Wrap = true;
            // 
            // tbFullScreenMode
            // 
            this.tbFullScreenMode.Location = new System.Drawing.Point(12, 31);
            this.tbFullScreenMode.Name = "tbFullScreenMode";
            this.tbFullScreenMode.Size = new System.Drawing.Size(193, 20);
            this.tbFullScreenMode.TabIndex = 1;
            this.tbFullScreenMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbFullScreenMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPress_TextBox);
            this.tbFullScreenMode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_TextBox);
            // 
            // tbPlayPause
            // 
            this.tbPlayPause.Location = new System.Drawing.Point(16, 77);
            this.tbPlayPause.Name = "tbPlayPause";
            this.tbPlayPause.Size = new System.Drawing.Size(189, 20);
            this.tbPlayPause.TabIndex = 2;
            this.tbPlayPause.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPlayPause.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPress_TextBox);
            this.tbPlayPause.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_TextBox);
            // 
            // tbPreviousMusic
            // 
            this.tbPreviousMusic.Location = new System.Drawing.Point(16, 123);
            this.tbPreviousMusic.Name = "tbPreviousMusic";
            this.tbPreviousMusic.Size = new System.Drawing.Size(189, 20);
            this.tbPreviousMusic.TabIndex = 3;
            this.tbPreviousMusic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPreviousMusic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPress_TextBox);
            this.tbPreviousMusic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_TextBox);
            // 
            // tbNextMusic
            // 
            this.tbNextMusic.Location = new System.Drawing.Point(16, 169);
            this.tbNextMusic.Name = "tbNextMusic";
            this.tbNextMusic.Size = new System.Drawing.Size(189, 20);
            this.tbNextMusic.TabIndex = 4;
            this.tbNextMusic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNextMusic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPress_TextBox);
            this.tbNextMusic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_TextBox);
            // 
            // tbShiftPrevious
            // 
            this.tbShiftPrevious.Location = new System.Drawing.Point(215, 169);
            this.tbShiftPrevious.Name = "tbShiftPrevious";
            this.tbShiftPrevious.Size = new System.Drawing.Size(193, 20);
            this.tbShiftPrevious.TabIndex = 8;
            this.tbShiftPrevious.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbShiftPrevious.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPress_TextBox);
            this.tbShiftPrevious.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_TextBox);
            // 
            // tbShiftNext
            // 
            this.tbShiftNext.Location = new System.Drawing.Point(215, 123);
            this.tbShiftNext.Name = "tbShiftNext";
            this.tbShiftNext.Size = new System.Drawing.Size(193, 20);
            this.tbShiftNext.TabIndex = 7;
            this.tbShiftNext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbShiftNext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPress_TextBox);
            this.tbShiftNext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_TextBox);
            // 
            // tbVolumeUp
            // 
            this.tbVolumeUp.Location = new System.Drawing.Point(215, 77);
            this.tbVolumeUp.Name = "tbVolumeUp";
            this.tbVolumeUp.Size = new System.Drawing.Size(193, 20);
            this.tbVolumeUp.TabIndex = 6;
            this.tbVolumeUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbVolumeUp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPress_TextBox);
            this.tbVolumeUp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_TextBox);
            // 
            // tbVolumeDown
            // 
            this.tbVolumeDown.Location = new System.Drawing.Point(215, 31);
            this.tbVolumeDown.Name = "tbVolumeDown";
            this.tbVolumeDown.Size = new System.Drawing.Size(193, 20);
            this.tbVolumeDown.TabIndex = 5;
            this.tbVolumeDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbVolumeDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPress_TextBox);
            this.tbVolumeDown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_TextBox);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Полный экран";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Плей / Пауза";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Предыдущая песня";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Следующая песня";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(211, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Перемотка назад";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(211, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Перемотка вперед";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(211, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Повысить громкость";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(211, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Понизить громкость";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(57, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(251, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Смещение при изменении звука";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(57, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(206, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Смещение при перемотке";
            // 
            // tbOffsetVolume
            // 
            this.tbOffsetVolume.Location = new System.Drawing.Point(16, 204);
            this.tbOffsetVolume.Name = "tbOffsetVolume";
            this.tbOffsetVolume.Size = new System.Drawing.Size(39, 20);
            this.tbOffsetVolume.TabIndex = 21;
            this.tbOffsetVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOffsetShift
            // 
            this.tbOffsetShift.Location = new System.Drawing.Point(16, 230);
            this.tbOffsetShift.Name = "tbOffsetShift";
            this.tbOffsetShift.Size = new System.Drawing.Size(39, 20);
            this.tbOffsetShift.TabIndex = 22;
            this.tbOffsetShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(266, 277);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(347, 277);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fCustomUserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 312);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbOffsetShift);
            this.Controls.Add(this.tbOffsetVolume);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbShiftPrevious);
            this.Controls.Add(this.tbShiftNext);
            this.Controls.Add(this.tbVolumeUp);
            this.Controls.Add(this.tbVolumeDown);
            this.Controls.Add(this.tbNextMusic);
            this.Controls.Add(this.tbPreviousMusic);
            this.Controls.Add(this.tbPlayPause);
            this.Controls.Add(this.tbFullScreenMode);
            this.Controls.Add(this.udChangeStyle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(450, 350);
            this.Name = "fCustomUserSettings";
            this.Text = "Персональные настройки пользователя";
            this.Load += new System.EventHandler(this.fCustomUserSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DomainUpDown udChangeStyle;
        private System.Windows.Forms.TextBox tbFullScreenMode;
        private System.Windows.Forms.TextBox tbPlayPause;
        private System.Windows.Forms.TextBox tbPreviousMusic;
        private System.Windows.Forms.TextBox tbNextMusic;
        private System.Windows.Forms.TextBox tbShiftPrevious;
        private System.Windows.Forms.TextBox tbShiftNext;
        private System.Windows.Forms.TextBox tbVolumeUp;
        private System.Windows.Forms.TextBox tbVolumeDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbOffsetVolume;
        private System.Windows.Forms.TextBox tbOffsetShift;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}