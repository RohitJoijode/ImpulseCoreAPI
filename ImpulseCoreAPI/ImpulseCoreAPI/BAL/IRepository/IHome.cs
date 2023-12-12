using ImpulseCoreAPI.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpulseCoreAPI.BAL.IRepository
{
    public interface IHome  
    {
        List<getMenu> GetAllMember();
        List<getMenu> GetMember(int id);
        Response SaveMembersDetails(Member MemberObj);
        List<Employee> SP_DemoMultipleTableExcution();
    }
}
