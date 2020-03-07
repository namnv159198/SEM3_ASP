using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_UWP.Models
{
    public class MemberInformation
    {
        public int Code { get; set; }
        public int status { get; set; }
        public String id { get; set; }
        public String firstName { get; set; }
        public string lastName { get; set; }
        public String password { get; set; }
        public String address { get; set; }
        public String phone { get; set; }
        public String avatar { get; set; }
        public int gender { get; set; }
        public String email { get; set; }
        public String birthday { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string salt { get; set; }

        public string returnGender(int gender)
        {
            string genderText = "";
            if (gender == 1)
            {
                genderText = "Male";
            }

            if (gender == 0)
            {
                genderText = "Female";
            }

            return genderText;
        }
    }
}
