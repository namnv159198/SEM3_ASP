using System;
using System.Collections.Generic;
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
using Sem3_UWP.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sem3_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Main : Page
    {
        private LoginService _serviceLogin = new LoginService();
        private TokenSaveFileService _serviceSaveFileService = new TokenSaveFileService();
        public Main()
        {
            this.InitializeComponent();
          
            ContentView.Navigate(typeof(LoginSuccesPage));
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (splitView.IsPaneOpen)
            {
                splitView.IsPaneOpen = false;
            }

        }
        private void Button_Menu(object sender, RoutedEventArgs e)
        {

            if (splitView.IsPaneOpen)
            {
                splitView.IsPaneOpen = false;
            }
            else
            {
                splitView.IsPaneOpen = true;
            }

        }


        private void Button_Home(object sender, RoutedEventArgs e)
        {
            ContentView.Navigate(typeof(Pages.LoginSuccesPage));
        }
        private void Button_Profile(object sender, RoutedEventArgs e)
        {
            ContentView.Navigate(typeof(Pages.Information));
        }
        private void Button_Add_Music(object sender, RoutedEventArgs e)
        {
            ContentView.Navigate(typeof(Pages.CreateSong));
        }
        private void Button_Music(object sender, RoutedEventArgs e)
        {
            ContentView.Navigate(typeof(Pages.ListSong));
        }
        private void Button_Your_Music(object sender, RoutedEventArgs e)
        {
            ContentView.Navigate(typeof(Pages.MySongPage));
        }
    }

    
}
