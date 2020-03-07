using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class CreateSong : Page
    {
        private CreatSongService _creatSongService = new CreatSongService();
        public CreateSong()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.ListSong));
        }

        private async void Submit_Create_Song(object sender, RoutedEventArgs e)
        {

            var song = new Song()
            {
                name = TxtSongName.Text,
                singer = TxtSongSinger.Text,
                author = TxtSongAuthor.Text,
                thumbnail = TxtSongThumbnail.Text,
                link = TxtSongLink.Text,
                //description = TxtSongDescription.Text
            };

            Song Song = await this._creatSongService.PostSong(song);

            if (Song.status == 400)
            {

                Debug.WriteLine("Status : " + Song.status);
                Debug.WriteLine("Create Failes ");
                StatusCreateSongFailes.Text = "Create Failes";
            }

            if (Song.status == 1)
            {
                resetValue();
                StatusCreateSongSuccess.Text = "Create Success . Your Song :" + Song.name;

            }

        }

        

        private void resetValue()
        {
            this.TxtSongName.Text = "";
            this.TxtSongAuthor.Text = "";
            this.TxtSongSinger.Text = "";
            this.TxtSongLink.Text = "";
            this.TxtSongThumbnail.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            resetValue();
        }
    }
}
