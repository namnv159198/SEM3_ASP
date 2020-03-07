using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Sem3_UWP.Models;
using Sem3_UWP.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sem3_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListSong : Page
    {
        private Song currentSong;
        private GetListSongService _getListSongService = new GetListSongService();
        private TokenSaveFileService _tokenSaveFileService = new TokenSaveFileService();
        private bool _isPlaying = false;
        private bool _SongNext= true;
        private bool _SongPrevious = false;
        
        public ListSong()
        {
            this.InitializeComponent();
        }



        private async void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)

        {
            Songs.ItemsSource = await _getListSongService.LoadSong();
        }

        private void Songs_OnItemClick(object sender, ItemClickEventArgs e)
        {
            PlaySong(e.ClickedItem as Song);
        }

        private void Next_OnClick(object sender, RoutedEventArgs e)
        {
            SongToward(_SongNext);
        }
        private void Previous_OnClick(object sender, RoutedEventArgs e)
        {
            SongToward(_SongPrevious);
        }

        private void PlayButton_Clicked(object sender, RoutedEventArgs e)
        {
            playButton();
        }
        private void Shuffle_OnClick(object sender, RoutedEventArgs e)
        {
            
        }




        public  void PlaySong(Song s)
        {
            MyPlayer.Source = MediaSource.CreateFromUri(new Uri(s.link));
            MyPlayer.MediaPlayer.Play();
            PlayButton.Icon = new SymbolIcon(Symbol.Pause);
            _isPlaying = true;
            StatusText.Text = "Now Playing: " + s.name;
        }

      
        public  void SongToward(Boolean check)
        {
            var currentIndex = Songs.SelectedIndex;
            if (check == true)
            {
                currentIndex++;
                if (currentIndex >= Songs.Items.Count)
                {
                    currentIndex = 0;
                }
                currentSong = Songs.Items[currentIndex] as Song;
                Songs.SelectedIndex = currentIndex;
                PlaySong(currentSong);
            }

            if (check == false)
            {
                currentIndex--;
                if (currentIndex < 0)
                {
                    currentIndex = Songs.Items.Count - 1;
                }
                currentSong = Songs.Items[currentIndex] as Song;
                Songs.SelectedIndex = currentIndex;
                PlaySong(currentSong);
            }
        }

        public void playButton()
        {
            if (Songs.ItemsSource == null) return;
            if (currentSong == null)
            {
                currentSong = _getListSongService.LoadSongs().FirstOrDefault();
                PlaySong(currentSong);
                Songs.SelectedIndex = 0;
            }

            if (_isPlaying)
            {
                MyPlayer.MediaPlayer.Pause();
                PlayButton.Icon = new SymbolIcon(Symbol.Play);

                StatusText.Text = "Paused";
                _isPlaying = false;
            }
            else
            {
                MyPlayer.MediaPlayer.Play();
                PlayButton.Icon = new SymbolIcon(Symbol.Pause);

                StatusText.Text = "Now Playing: " + currentSong.name;
                _isPlaying = true;
            }
        }
    }
}
