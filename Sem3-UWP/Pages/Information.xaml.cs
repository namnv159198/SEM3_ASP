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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Sem3_UWP.Models;
using Sem3_UWP.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sem3_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Information : Page
    {
        private MemberInformationService _service = new MemberInformationService();
        private TokenSaveFileService _tokenSaveFileService = new TokenSaveFileService();
      
       
        public Information()
        {
            this.InitializeComponent();
            
                LoadMemberInformation();
        }

        private async void LoadMemberInformation()
        {
            
             MemberInformation MemberInfor = await this._service.GetMemberInformation();
             
                TxtFirstName.Text = MemberInfor.firstName;
                TxtLastName.Text = MemberInfor.lastName;
                TxtAddress.Text = MemberInfor.address;
                TxtGender.Text = " " +MemberInfor.returnGender(MemberInfor.gender) ;
                ImageControl.Source = new BitmapImage(new Uri(MemberInfor.avatar, UriKind.Absolute));
                TxtEmail.Text = MemberInfor.email;
                TxtUserID.Text = MemberInfor.id;
                TxtPhone.Text = MemberInfor.phone;
                TxtCreatAt.Text = MemberInfor.createdAt;
                TxtUpdateAt.Text = MemberInfor.updatedAt;
                TxtBirthday.Text = MemberInfor.birthday;
                TxtPassword.Text = MemberInfor.password;

        }
    }
}
