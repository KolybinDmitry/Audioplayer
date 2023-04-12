using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace AudioPlayer
{
    public static class PlayerManager
    {
        public enum _MixType
        {
            overkill,
            loop,
            random
        }
        public enum _WarningType
        {
            endList,
            emptyList
        }
        const string defaultFileName = "None audio track";
        public static List<string> MusicFiles { get; private set; } = new List<string>();
        public static bool Play { get; private set; }
        public static int Indx { get; private set; }
        public static _MixType MixType { get; private set; }

        private static MediaElement mediaElement;
        private static Label labelFileInfo;
        private static RandomList randomList = new RandomList(0);

        public static void SetPlayerElements(MediaElement _mediaElement, Label _labelFileInfo)
        {
            mediaElement = _mediaElement ?? throw new ArgumentNullException(nameof(_mediaElement));
            labelFileInfo = _labelFileInfo ?? throw new ArgumentNullException(nameof(_labelFileInfo));
        }

        private static void Warning(_WarningType warningType)
        {
            switch (warningType)
            {
                case _WarningType.emptyList:
                    MessageBox.Show(
                        "Аудиофайлы не найдены",
                        "Warning!",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                        );
                    break;
                case _WarningType.endList:
                    MessageBox.Show(
                        "Файлы кончились. Выберете новые",
                        "Warning!",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                        );
                    break;
            }
        }

        public static void NewTrackList(string[] files)
        {
            mediaElement.Source = null;
            // Нужно ли иначе фильтровать файлы?
            Regex regex = new Regex(@"(\w)*(.mp3|.wav|.flac|.aac)$");
            MusicFiles = files != null
                ? files.Where(it => regex.IsMatch(it)).ToList()
                : new List<string>();

            randomList = new RandomList(MusicFiles.Count);

            if (MusicFiles.Count == 0)
            {
                Warning(_WarningType.emptyList);
                return;
            }
            Indx = 0;
        }

        public static void NewTrack()
        {
            if (MusicFiles.Count == 0)
            {
                Warning(_WarningType.emptyList);
                return;
            }

            if (Indx >= 0 && Indx < MusicFiles.Count)
            {
                mediaElement.Source = new Uri(MusicFiles[Indx]);
                mediaElement.LoadedBehavior = MediaState.Pause;
            }
            else
            {
                Warning(_WarningType.endList);
                return;
            }

            string fileName = mediaElement.Source != null
                ? mediaElement.Source.ToString()
                : defaultFileName;
            labelFileInfo.Content = fileName.Substring(fileName.LastIndexOf("/") + 1);
        }

        public static void ShiftIndx(bool div)
        {
            switch (MixType)
            {
                case _MixType.overkill:
                    if (Indx == MusicFiles.Count - 1 && div || Indx == 0 && !div)
                    {
                        Warning(_WarningType.endList);
                        mediaElement.Source = null;
                    }
                    Indx = div ? ++Indx : --Indx;
                    break;
                case _MixType.loop:
                    Indx = div
                    ? (++Indx) % MusicFiles.Count
                    : (MusicFiles.Count + --Indx) % MusicFiles.Count;
                    break;
                case _MixType.random:
                    Indx = randomList.Indxs[randomList.GetNewIndx(div)];
                    break;
            }
        }

        public static void PlayPause()
        {
            if (MusicFiles.Count == 0)
            {
                Warning(_WarningType.emptyList);
                return;
            }
            Play = !Play;
            mediaElement.LoadedBehavior = Play
                ? MediaState.Play
                : MediaState.Pause;
        }

        public static void NewMixType()
        {
            MixType = (_MixType)(((int)MixType + 1) % 3);
        }
    }

    class RandomList
    {
        public List<int> Indxs { get; private set; } = new List<int>();
        private int ptr = 0;
        private List<int> values = new List<int>();
        public RandomList(int count)
        {
            for (int i = 0; i < count; ++i)
                values.Add(i);
            for (int i = 0; i < count; ++i)
            {
                int _value = values[new Random().Next(0, values.Count)];
                Indxs.Add(_value);
                values.Remove(_value);
            }
        }

        public int GetNewIndx(bool div)
        {
            return div
                ? (++ptr) % Indxs.Count
                : (Indxs.Count + --ptr) % Indxs.Count;
        }
    }
}