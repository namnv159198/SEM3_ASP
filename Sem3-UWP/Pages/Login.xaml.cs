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
    public sealed partial class Login : Page
    {
       private LoginService _serviceLogin = new LoginService();
       private TokenSaveFileService _serviceSaveFileService = new TokenSaveFileService();
     
       public static string TokenFile = "TokenFile.txt";

       public Login()
        {
            this.InitializeComponent();
          
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            var email = TxtEmail.Text;
            var password = PasswordBox.Password;
            var checkPages = await this._serviceSaveFileService.ReadTokenFormFile();
            if (email == null)
            {
                notifyTextEmail.Text = "Email is Required !";
            }
            MemberAccounts login = await this._serviceLogin.LoginAccounts(email, password);
            if ( login.status == 1)
            {
                _serviceSaveFileService.SaveTokenToFile(Login.TokenFile, login.token);
                this.Frame.Navigate(typeof(Pages.Main));
            }
            else
            {
                TxtEmail.Text = "";
                PasswordBox.Password = "";
                StatusLoginFalies.Text = "Invalid Information";
            }
           
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            TxtEmail.Text = "";
            PasswordBox.Password = "";
        }

        private async void LoadFrame()
        {
            var checkToken = await this._serviceSaveFileService.GetToken();
            if (checkToken != null)
            {
                this.Frame.Navigate(typeof(Pages.Main));
            }
            else
            {
                this.Frame.Navigate(typeof(Pages.Login));
            }
        }

      
        private void Sigin_In_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.RegisterPages));
        }
    }
}
