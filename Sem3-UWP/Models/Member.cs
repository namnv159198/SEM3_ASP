using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_UWP.Models
{
    public class Member
    {
        public int  Code { get; set; }
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

       
        public Dictionary<String, String> CheckValue()
        {
            var errors = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(this.firstName))
            {
                errors.Add("TxtFirstName", "First name is required!");
            }
            if (string.IsNullOrEmpty(this.lastName))
            {
                errors.Add("TxtLastName", "Last name is required!");
            }
            if (string.IsNullOrEmpty(this.password))
            {
                errors.Add("TxtPassword", " Password is required!");
            }
            if (this.password.Length < 6)
            {
                errors.Add("TxtPassword", "Pasaword is  min 6 characters");
            }

            if (string.IsNullOrEmpty(this.address))
            {
                errors.Add("TxtAddres", "Address is required!");
            }

            if (string.IsNullOrEmpty(this.phone))
            {
                errors.Add("TxtPhone", "Phone number is required!");
            }
            if (string.IsNullOrEmpty(this.email))
            {
                errors.Add("TxtEmail", "Email is required!");
            }

            if (IsEmailValid(this.email) == false)
            {
                errors.Add("TxtEmail", "Email : a@xyz.com");
            }
            if (string.IsNullOrEmpty(this.avatar))
            {
                errors.Add("TxtAvatar", "Avatar is required!");
            }
            if (string.IsNullOrEmpty(this.birthday))
            {
                errors.Add("TxtBirthday", "Birthday is required!");
            }

            if (CheckBirthday(this.birthday) == false)
            {
                errors.Add("TxtBirthday", "Birthday is [yyyy-MM-dddd] !");
            }
            return errors;
        }
        public bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsValidDate(string value, string[] dateFormats)
        {
            DateTime tempDate;
            bool validDate = DateTime.TryParseExact(value, dateFormats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out tempDate);
            if (validDate)
                return true;
            else
                return false;
        }

        public static bool CheckBirthday(string date)
        {
            var dateFormats = new[] {"yyyy-MM-dddd" };
            if (IsValidDate(date,dateFormats))
            {
                return true;
            }

            return false;
        }
    }
}
