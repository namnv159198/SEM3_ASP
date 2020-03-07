using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sem3_UWP.Models;
using Sem3_UWP.Pages;

namespace Sem3_UWP.Services
{
   public  class MemberInformationService
   {
       private static string MEMBER_INFORMATION_URL =
           "https://2-dot-backup-server-002.appspot.com/_api/v2/members/information";


       private TokenSaveFileService _tokenSaveFileService = new TokenSaveFileService();

        public async Task<MemberInformation> GetMemberInformation()
       {
           var token = await  this._tokenSaveFileService.ReadTokenFormFile(Login.TokenFile);
           HttpClient httpClient = new HttpClient();
           httpClient.DefaultRequestHeaders.Add("Authorization","Basic " + token);
           var reponse = await httpClient.GetAsync(MEMBER_INFORMATION_URL);
           if (reponse.StatusCode == HttpStatusCode.Created)
           {
               var stringContent = await reponse.Content.ReadAsStringAsync();
               
               var returnInfor = JsonConvert.DeserializeObject<MemberInformation>(stringContent);

               return returnInfor;
           }
           return null;
       }

        
        
   }
   
}
