using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sem3_UWP.Models;
using Sem3_UWP.Pages;

namespace Sem3_UWP.Services
{
    public class LoginService
    {
        private static String LOGIN_URL_API = "https://2-dot-backup-server-002.appspot.com/_api/v2/members/authentication";
        private static String CONENT_TYPE = "application/json";
        private  TokenSaveFileService _tokenSaveFileService = new TokenSaveFileService();
        public async Task<MemberAccounts> LoginAccounts (string email , string password)
        {
            JObject loginAccount = new JObject();

            loginAccount["email"] = email;
            loginAccount["password"] = password;

            var accountJson = JsonConvert.SerializeObject(loginAccount);

            HttpContent loginContent = new StringContent(accountJson,Encoding.UTF8,CONENT_TYPE);

            HttpClient httpClient = new HttpClient();

            var reponse = await (httpClient.PostAsync(LOGIN_URL_API, loginContent));

            var stringContent = await reponse.Content.ReadAsStringAsync();

            var accountContent = JsonConvert.DeserializeObject<MemberAccounts>(stringContent);
      
            return accountContent;
        }

        

       
    }
}
