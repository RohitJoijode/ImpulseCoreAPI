using ImpulseCoreAPI.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpulseCoreAPI.BAL.IRepository
{
    public interface IHome  
    {
        List<Member> GetAllMember();
        Member GetMember(int id);
        Response SaveMembersDetails(Member MemberObj);
    }
}
