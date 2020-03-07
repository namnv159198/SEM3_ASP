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
using Sem3_UWP.Models;
using Sem3_UWP.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sem3_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        private SQLiteMemberService _service;
        public Register()
        {
            this.InitializeComponent();
            this._service = new SQLiteMemberService();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Member2 member2 = new Member2()
            {
                Name = TxtFirstName.Text,
                Username = TxtLastName.Text,
                Password = "123"
            };
            this._service.Create(member2);

        }
    }
}
