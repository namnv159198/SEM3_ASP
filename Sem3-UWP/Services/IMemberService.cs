using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sem3_UWP.Models;

namespace Sem3_UWP.Services
{
    interface IMemberService
    {
        Task<Member> Create(Member member);
        Task<List<Member>> GetList();
        Task<Member> GetDetail(string rollNumber);
        Task<Member> Update(Member member);
        Task<bool> Delete(string rollNumber);
    }
}
