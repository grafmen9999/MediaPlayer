using System;
using System.Collections.Generic;
using Microsoft.Win32;
using System.IO;
using System.Linq;

namespace MediaPlayer {
    static class MediaPlayer {
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
        private static int tmpVolume = 50;

        public static bool repeatMusic = false;
        public static bool allDirectories = false;
        public static bool randomMusic = false;
        public static bool visibleVideo = false;
        public static string currentMusic = "";
        public static string currentPlayList = "", tmpCurPL = "";
        // static public string LastFolder = "";
        public static List<string> list = new List<string>();
        public static int Volume {
            get
            {
                return tmpVolume;
            }
            set
            {
                if (value < 0) tmpVolume = 0;
                else if (value > 100) tmpVolume = 100;
                else tmpVolume = value;
            }
        }
        public static double currentPosition = 0.0;
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
        public static int styleImage = 0; // 0, 1, 2 - возможные стили на текущий момент
        // ключи для переключения
        public static System.Windows.Forms.Keys keyFullScreen     = System.Windows.Forms.Keys.F8; // полноэкранный режим
        public static System.Windows.Forms.Keys keyPlayPause      = System.Windows.Forms.Keys.MediaPlayPause; // Пуск-Пауза
        public static System.Windows.Forms.Keys keyNextMusic      = System.Windows.Forms.Keys.MediaNextTrack; // Следующая музыка
        public static System.Windows.Forms.Keys keyPreviousMusic  = System.Windows.Forms.Keys.MediaPreviousTrack; // Предыдущая музыка
        public static System.Windows.Forms.Keys keyVolumeUp       = System.Windows.Forms.Keys.Right; // Добавить громкость
        public static System.Windows.Forms.Keys keyVolumeDown     = System.Windows.Forms.Keys.Left; // Убавить громкость
        public static System.Windows.Forms.Keys keyNextShift      = System.Windows.Forms.Keys.Up; // перемотка вперед
        public static System.Windows.Forms.Keys keyPreviousShift  = System.Windows.Forms.Keys.Down; //Перемотка назад
        // значения для перемотки и громкости
        public static int defaultOffsetVolume = 5; // Изменения громкости за одно нажатие
        public static double defaultOffsetShift = 5.0; // изменения перемотки (она же скорость перемотки) за одно нажатие
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        private const string SubKey = "SoftWare\\cGraf_Men\\MediaPlayer";

        public static void LoadSettings() {
            RegistryKey rk = null;

            try {
                rk = Registry.CurrentUser.OpenSubKey(SubKey);
                if (rk == null) return;
                currentPlayList = rk.GetValue("currentPlayList").ToString();
                repeatMusic = Convert.ToBoolean(rk.GetValue("RepeatMusic", false));
                visibleVideo = Convert.ToBoolean(rk.GetValue("VisibleVideo", false));
                Volume = Convert.ToInt32(rk.GetValue("Volume"));
                // LastFolder = rk.GetValue("LastFolder").ToString();
                allDirectories = Convert.ToBoolean(rk.GetValue("AllDirectories", false));
                randomMusic = Convert.ToBoolean(rk.GetValue("RandomMusic", false));
            }
            finally {
                if (rk != null) rk.Close();
            }
        }

        public static void SaveSettings() {
            RegistryKey rk = null;

            try {
                rk = Registry.CurrentUser.CreateSubKey(SubKey);
                if (rk == null) return;
                rk.SetValue("currentPlayList", currentPlayList);
                rk.SetValue("AllDirectories", allDirectories);
                rk.SetValue("RandomMusic", randomMusic);
                rk.SetValue("VisibleVideo", visibleVideo);
                // rk.SetValue("LastFolder", LastFolder);
                rk.SetValue("Volume", Volume);
                rk.SetValue("RepeatMusic", repeatMusic);
            }
            finally {
                if (rk != null) rk.Close();
            }
        }

        public static void LoadCustomSettings()
        {
            RegistryKey rk = null;

            try
            {
                rk = Registry.CurrentUser.OpenSubKey(SubKey + "\\CustomUserSettings");
                if (rk == null) return;
                System.Windows.Forms.KeysConverter converter = new System.Windows.Forms.KeysConverter();
                keyFullScreen = (System.Windows.Forms.Keys)converter.ConvertFromString(rk.GetValue("KeyFullScreen").ToString());
                keyNextMusic = (System.Windows.Forms.Keys)converter.ConvertFromString(rk.GetValue("KeyNextMusic").ToString());
                keyPlayPause = (System.Windows.Forms.Keys)converter.ConvertFromString(rk.GetValue("KeyPlayPause").ToString());
                keyPreviousMusic = (System.Windows.Forms.Keys)converter.ConvertFromString(rk.GetValue("KeyPreviousMusic").ToString());
                keyNextShift = (System.Windows.Forms.Keys)converter.ConvertFromString(rk.GetValue("KeyNextShift").ToString());
                keyPreviousShift = (System.Windows.Forms.Keys)converter.ConvertFromString(rk.GetValue("KeyPreviousShift").ToString());
                keyVolumeDown = (System.Windows.Forms.Keys)converter.ConvertFromString(rk.GetValue("KeyVolumeDown").ToString());
                keyVolumeUp = (System.Windows.Forms.Keys)converter.ConvertFromString(rk.GetValue("KeyVolumeUp").ToString());
                defaultOffsetShift = Convert.ToDouble(rk.GetValue("OffsetShift"));
                defaultOffsetVolume = Convert.ToInt32(rk.GetValue("OffsetVolume"));
                styleImage = Convert.ToInt32(rk.GetValue("StyleImage"));
            }
            finally
            {
                if (rk != null) rk.Close();
            }
        }

        public static void SaveCustomSettings()
        {
            RegistryKey rk = null;

            try
            {
                rk = Registry.CurrentUser.CreateSubKey(SubKey + "\\CustomUserSettings");
                if (rk == null) return;
                rk.SetValue("KeyFullScreen", keyFullScreen);
                rk.SetValue("KeyNextMusic", keyNextMusic);
                rk.SetValue("KeyPreviousMusic", keyPreviousMusic);
                rk.SetValue("KeyNextShift", keyNextShift);
                rk.SetValue("KeyPreviousShift", keyPreviousShift);
                rk.SetValue("KeyPlayPause", keyPlayPause);
                rk.SetValue("KeyVolumeDown", keyVolumeDown);
                rk.SetValue("KeyVolumeUp", keyVolumeUp);
                rk.SetValue("OffsetShift", defaultOffsetShift);
                rk.SetValue("OffsetVolume", defaultOffsetVolume );
                rk.SetValue("StyleImage", styleImage);
            }
            finally
            {
                if (rk != null) rk.Close();
            }
        }

        public static void LoadListSettings() {
            RegistryKey rk = null;

            try {
                rk = Registry.CurrentUser.OpenSubKey(SubKey + "\\" + currentPlayList);
                if (rk == null) return;
                currentMusic = rk.GetValue("CurrentMusic").ToString();
                currentPosition = Convert.ToDouble(rk.GetValue("CurrentPosition"));
            }
            finally {
                if (rk != null) rk.Close();
            }
        }

        public static void SaveListSettings() {
            RegistryKey rk = null;

            try {
                rk = Registry.CurrentUser.CreateSubKey(SubKey + "\\" + currentPlayList);
                if (rk == null) return;
                rk.SetValue("CurrentMusic", currentMusic);
                rk.SetValue("CurrentPosition", currentPosition);
            }
            finally {
                if (rk != null) rk.Close();
            }
        }
        /*
        static public void ReadMusic() {
            string[] tmpMusic = list.ToArray();

            try {
                // list.Clear();
                string[] listMusic = Directory.GetFiles(LastFolder, "*.mp3", allDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

                foreach (string s1 in listMusic)
                    if (!list.Contains(s1)) list.Add(s1);

                //list.AddRange(listMusic);
                Sort();
            }
            catch {
                list.Clear();
                list.AddRange(tmpMusic);
                Sort();
            }
        }
        */
        public static void ReadMusic(string folder) {
            string[] tmpMusic = list.ToArray();

            try {
                // list.Clear();
                string[] listMusic = Directory.GetFiles(folder, "*.mp*", allDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

                foreach (string s1 in listMusic)
                    if (!list.Contains(s1)) list.Add(s1);

                //list.AddRange(listMusic);
                Sort();
            }
            catch {
                list.Clear();
                list.AddRange(tmpMusic);
                Sort();
            }
        }

        public static void SaveList() {
            try {
                if (!Directory.Exists("PlayList"))
                    Directory.CreateDirectory("PlayList");
                
                using (StreamWriter sw = new StreamWriter("PlayList\\" + currentPlayList + ".list")) {
                    foreach (string s1 in list.ToArray()) {
                        if (File.Exists(s1)) {
                            sw.WriteLine(s1);
                        }
                    }
                }
            }
            catch { }
        }

        public static void LoadList() {
            try {
                //string[] musicList = File.ReadAllLines("PlayList\\" + currentPlayList + ".list");
                list.Clear();
                string musicList;

                using (StreamReader sr = new StreamReader("PlayList\\" + currentPlayList + ".list")) {
                    while((musicList = sr.ReadLine()) != null) {
                        if (File.Exists(musicList)) { 
                            list.Add(musicList);
                        }
                    }
                }
                /*
                using (FileStream streamReader = File.OpenRead("C:\\ProgranFiles\\cGraf_Men\\PlayList\\" + currentPlayList + ".list"))
                {
                    // if (streamReader == null) return;
                    byte[] array = new byte[streamReader.Length];
                    streamReader.Read(array, 0, array.Length);
                    string textFromFile = System.Text.Encoding.Default.GetString(array);
                    list.Clear();
                    string[] listArray = textFromFile.Split('\n');
                    list.AddRange(listArray);
                }
                */
            }
            catch { }
        }

        public static bool GetExistRegistry(string key) {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(SubKey)) {
                string[] list = rk.GetSubKeyNames();
                return list.Contains(key);
            }
        }

        public static bool GetExistFile(string key) {
            return File.Exists("PlayList\\" + key + ".list");
        }

        public static void Sort() {
            string[] listMusic = list.ToArray();
            list.Clear();
            string tmp, tmp1, tmp2;

            for (int i = 0; i < listMusic.Length; i++) {
                for (int j = 0; j < listMusic.Length - 1; j++) {
                    tmp1 = listMusic[j].ToLower().Split('\\').Last();
                    tmp2 = listMusic[j + 1].ToLower().Split('\\').Last();

                    if (NeedToReOrder(tmp1.Substring(0, tmp1.Length - 4), tmp2.Substring(0, tmp2.Length - 4))) {
                        tmp = listMusic[j];
                        listMusic[j] = listMusic[j + 1];
                        listMusic[j + 1] = tmp;
                    }
                }
            }

            list.AddRange(listMusic);
        }

        private static bool NeedToReOrder(string s1, string s2) {
            for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++) {
                if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
                if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
            }

            return false;
        }

        public static string[] GetListing() {
            RegistryKey rk = null;
            List<string> strList = new List<string>();
            string[] str;

            try {
                rk = Registry.CurrentUser.OpenSubKey(SubKey);
                if (rk == null) return null;
                str = rk.GetSubKeyNames();
                strList.AddRange(str);

                foreach(string s in strList.ToArray()) {
                    if (!GetExistFile(s)) {
                        strList.Remove(s);
                    }
                }

                str = strList.ToArray();

                return str;
            }
            catch {
                return null;
            }
            finally {
                if (rk != null) rk.Close();
            }
        }
    }
}
