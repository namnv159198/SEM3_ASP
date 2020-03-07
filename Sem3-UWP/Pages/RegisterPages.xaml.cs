using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage;
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
    public sealed partial class RegisterPages : Page
    {
        private StorageFile photo;
        private MemberService _service = new MemberService();
        public int _optionChooseGender = 0;
        private TokenSaveFileService _tokenSaveFileService = new TokenSaveFileService();
        public RegisterPages()
        {
            this.InitializeComponent();
            
             
        }

        private async void Create_Member(object sender, RoutedEventArgs e)
        {
            var member = new Member()
            {
                firstName = TxtFirstName.Text,
                lastName = TxtLastName.Text,
                password = TxtPassword.Password,
                address = TxtAddress.Text,
                phone = TxtPhone.Text,
                avatar = TxtAvatar.Text,
                gender = Convert.ToInt32(_optionChooseGender),
                email = TxtEmail.Text,
                birthday = TxtBirthday.Text
            };
            var errors = member.CheckValue();
            if (errors.Count > 0)
            {
               
            }

            Member Member = await this._service.RegisterMember(member);

            if (Member.status == 400)
            {
                
                Debug.WriteLine("Status : " +Member.status);
                Debug.WriteLine("Create Failes ");
                StatusCreateFailes.Text = "Create Failes";
            }

            if (Member.status == 1)
            {
                this.TxtFirstName.Text = "";
                this.TxtLastName.Text = "";
                this.TxtAddress.Text = "";
                this.TxtBirthday.Text = "";
                this.TxtPhone.Text = "";
                this.TxtAvatar.Text = "";
                this.TxtPassword.Password = "";
                this.TxtEmail.Text = ""; ;
                StatusCreateSuccess.Text = "Create Success . Your User ID :" + Member.id;

            }
               

        }

        private void Reset_Register(object sender, RoutedEventArgs e)
        {
            this.TxtFirstName.Text = "";
            this.TxtLastName.Text = "";
            this.TxtAddress.Text = "";
            this.TxtBirthday.Text = "";
            this.TxtPhone.Text = "";
            this.TxtAvatar.Text = "";
            this.TxtPassword.Password = "";
            this.TxtEmail.Text = "";
        }

        private void Login_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.Login));
        }
        private void Choose_Gender(object sender, RoutedEventArgs e)
        {
            if (!(sender is RadioButton optionChooseGender)) return;
            switch (optionChooseGender.Tag)
            {
                case 0:
                    _optionChooseGender = 0;
                    break;
                case 1:
                    _optionChooseGender = 1;
                    break;
            }

        }
        public async void HttpUploadFile(string url, string paramName, string contentType)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";

            Stream rs = await wr.GetRequestStreamAsync();
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string header = string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n", paramName, "path_file", contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            // write file.
            Stream fileStream = await this.photo.OpenStreamForReadAsync();
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);

            WebResponse wresp = null;
            try
            {
                wresp = await wr.GetResponseAsync();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                //Debug.WriteLine(string.Format("File uploaded, server response is: @{0}@", reader2.ReadToEnd()));
                //string imgUrl = reader2.ReadToEnd();
                //Uri u = new Uri(reader2.ReadToEnd(), UriKind.Absolute);
                //Debug.WriteLine(u.AbsoluteUri);
                //ImageUrl.Text = u.AbsoluteUri;
                //MyAvatar.Source = new BitmapImage(u);
                //Debug.WriteLine(reader2.ReadToEnd());
                string imageUrl = reader2.ReadToEnd();
                Debug.WriteLine(imageUrl);
                ImageControl.Source = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
                TxtAvatar.Text = imageUrl;
                this._tokenSaveFileService.SaveCameraFileToFile(imageUrl);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error uploading file", ex.StackTrace);
                Debug.WriteLine("Error uploading file", ex.InnerException);
                if (wresp != null)
                {
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
        }
        private async void Click_My_Cam(object sender, RoutedEventArgs e)
        {
            // get upload url
            HttpClient client = new HttpClient();
            var uploadUrl = client.GetAsync("https://2-dot-backup-server-003.appspot.com/get-upload-token").Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("Upload url: " + uploadUrl);

            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

            this.photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (this.photo == null)
            {
                // User cancelled photo capture
                return;
            }

            HttpUploadFile(uploadUrl, "myFile", "image/png");

        }
    }
}
