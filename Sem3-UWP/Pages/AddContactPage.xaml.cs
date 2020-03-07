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
using Contact = Windows.ApplicationModel.Contacts.Contact;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sem3_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddContactPage : Page
    {
        private SQLiteMemberService _service;
        public AddContactPage()
        {
            this.InitializeComponent();
            this._service = new SQLiteMemberService();
        }
        private void Add_Contact_Click(object sender, RoutedEventArgs e)
        {
            Contact2 contact = new Contact2()
            {
                Name = TxtName.Text,
                Phone = TxtPhone.Text,
            };
            this._service.Create2(contact);
            StatusAdd.Text = "Add Success";
        }
    }
}
