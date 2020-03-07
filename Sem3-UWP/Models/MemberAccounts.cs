using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_UWP.Models
{
    public class MemberAccounts
    {
        
        public String email { get; set; }
        public String password { get; set; }
        public string token { get; set; }
        public string userId { get; set; }
        public string createdTimeMLS { get; set; }
        public string expiredTimeMLS { get; set; }
        public int status { get; set; }
        public string secretToken { get; set; }
        public string message { get; set; }

    
    }
}
