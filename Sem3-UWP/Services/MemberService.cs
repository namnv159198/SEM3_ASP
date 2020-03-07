using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Sem3_UWP.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Sem3_UWP.Services
{
    public class MemberService
    {
        private static String MemberRegisterUrl = "https://2-dot-backup-server-002.appspot.com/_api/v2/members";
        private static string CONTENT_TYPE = "application/json";

        public  async  Task<Member> RegisterMember(Member member)
        {
            var memberJson = JsonConvert.SerializeObject(member);

            HttpContent contentToSend = new StringContent(memberJson,Encoding.UTF8,CONTENT_TYPE);

            HttpClient httpClient = new HttpClient();

            var reponse = await httpClient.PostAsync(MemberRegisterUrl, contentToSend);

            var stringContent = await reponse.Content.ReadAsStringAsync();

            var returnStudent = JsonConvert.DeserializeObject<Member>(stringContent);
            
            return returnStudent;

        }
    }
}
