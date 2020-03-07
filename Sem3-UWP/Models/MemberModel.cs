using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace Sem3_UWP.Models
{
   public class MemberModel
    {
        public bool Save(Member2 member)
        {
            var sqlConnection = SQLiteHelper.CreateInstance().SQLiteConnection;
            var sqlCommandString = "insert into Members (Name, Username, Password) values (?,?,?)";
            using (var stt = sqlConnection.Prepare(sqlCommandString))
            {
                stt.Bind(1, member.Name);
                stt.Bind(2, member.Username);
                stt.Bind(3, member.Password);
                var result = stt.Step();
                return result == SQLiteResult.OK;
            }
        }
        public bool Save2(Contact2 contacts)
        {
            var sqlConnection = SQLiteHelper.CreateInstance().SQLiteConnection;
            var sqlCommandString = "insert into Contacts (Name, Username) values (?,?)";
            using (var stt = sqlConnection.Prepare(sqlCommandString))
            {
                stt.Bind(1, contacts.Name);
                stt.Bind(2, contacts.Phone);
                var result = stt.Step();
                return result == SQLiteResult.OK;
            }
        }

        public List<Member> GetList()
        {
            return new List<Member>();
        }

        public Member GetDetail(int id)
        {
            return new Member();
        }

        public Member Update(Member member)
        {
            return new Member();
        }

        public bool Delete(int id)
        {
            return false;
        }
    }
}
