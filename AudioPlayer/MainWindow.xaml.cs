using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AudioPlayer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // изменить Position трэка при изменении значения слайдера мышкой 
        // рандомайзер

        public MainWindow()
        {
            InitializeComponent();
            PlayerManager.SetPlayerElements(mediaElement, labelFileInfo);
            sliderVolume.Value = 0.5f;
        }
        private void rButtonNext_Click(object sender, RoutedEventArgs e)
        {
            PlayerManager.ShiftIndx(true);
            PlayerManager.NewTrack();

            var path = Path.Combine(Environment.CurrentDirectory, "UI", "play.png");
            var uri = new Uri(path);
            rButtonPlayPause.LargeImageSource = new BitmapImage(uri);
        }
        private void rButtonPrev_Click(object sender, RoutedEventArgs e)
        {
            PlayerManager.ShiftIndx(false);
            PlayerManager.NewTrack();

            var path = Path.Combine(Environment.CurrentDirectory, "UI", "play.png");
            var uri = new Uri(path);
            rButtonPlayPause.LargeImageSource = new BitmapImage(uri);
        }
        private void rButtonPlayPause_Click(object sender, RoutedEventArgs e)
        {
            PlayerManager.PlayPause();

            var path = PlayerManager.Play
                ? Path.Combine(Environment.CurrentDirectory, "UI", "pause.png")
                : Path.Combine(Environment.CurrentDirectory, "UI", "play.png");

            var uri = new Uri(path);
            rButtonPlayPause.LargeImageSource = new BitmapImage(uri);
        }
        private void rButtonFolder_Click(object sender, RoutedEventArgs e)
        {
            string[] files = null;
            CommonOpenFileDialog dialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true
            };
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
                files = Directory.GetFiles(dialog.FileName);

            PlayerManager.NewTrackList(files);
            PlayerManager.NewTrack();
        }
        private void rButtonMixType_Click(object sender, RoutedEventArgs e)
        {
            PlayerManager.NewMixType();

            string path = "";

            switch (PlayerManager.MixType)
            {
                case PlayerManager._MixType.overkill:
                    path = Path.Combine(Environment.CurrentDirectory, "UI", "overkill.png");
                    break;
                case PlayerManager._MixType.loop:
                    path = Path.Combine(Environment.CurrentDirectory, "UI", "loop.png");
                    break;
                case PlayerManager._MixType.random:
                    path = Path.Combine(Environment.CurrentDirectory, "UI", "random.png");
                    break;
            }
            var uri = new Uri(path);
            rButtonMixType.LargeImageSource = new BitmapImage(uri);
        }

        private void mediaElement_LayoutUpdated(object sender, EventArgs e)
        {
            if (mediaElement.Source == null)
                return;

            labelTimeStart.Content = mediaElement.Position.ToString().Substring(0, 8);
            sliderTrackLine.Value = mediaElement.Position.TotalSeconds;
            labelTimeEnd.Content = TimeSpan.FromSeconds(sliderTrackLine.Maximum - mediaElement.Position.TotalSeconds).ToString().Substring(0, 8);
        }

        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (mediaElement.Source == null)
                return;
            sliderTrackLine.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalSeconds;
        }

        private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement.Volume = sliderVolume.Value;
        }
    }
}