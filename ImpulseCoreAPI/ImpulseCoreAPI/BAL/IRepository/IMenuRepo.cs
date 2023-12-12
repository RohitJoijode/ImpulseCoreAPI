using System;
using System.Collections.Generic;
using ImpulseCoreAPI.Bridge;
using System.Linq;
using System.Threading.Tasks;

namespace ImpulseCoreAPI.BAL.IRepository
{
    public interface IMenuRepo
    {
        List<getMenu> GetMenuByUserId(UserLogInRequest UserLogInRequest);
        List<GetSubMenu> GetSubMenuByUserIdAndMenuId(UserLogInRequest UserLogInRequest);
    }
}
