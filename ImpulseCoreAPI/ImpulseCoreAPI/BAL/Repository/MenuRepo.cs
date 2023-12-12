using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using ImpulseCoreAPI.Bridge;

namespace ImpulseCoreAPI.BAL.Repository
{
    public class MenuRepo : ImpulseCoreAPI.BAL.IRepository.IMenuRepo
    {

        private readonly DbEngine _DbEngine;

        public MenuRepo(DbEngine DbEngine)
        {
            _DbEngine = DbEngine;
        }

        public List<getMenu> GetMenuByUserId(UserLogInRequest UserLogInRequest)
        {
            List<getMenu> getMenuList = new List<getMenu>();
            try
            {
                SqlParameter[] parameters =   {
                                                new SqlParameter("@userId",UserLogInRequest.UserId),
                                            };
                getMenuList = _DbEngine.SqlQuery<getMenu>("SP_GetMenuByUserId @userId",parameters).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return getMenuList;
        }

        public List<GetSubMenu> GetSubMenuByUserIdAndMenuId(UserLogInRequest UserLogInRequest)
        {
            List<GetSubMenu> getSubMenuList = new List<GetSubMenu>();
            try
            {
                SqlParameter[] parameters =   {
                                                new SqlParameter("@userId",UserLogInRequest.UserId),
                                                new SqlParameter("@MenuId",UserLogInRequest.MenuId),
                                            };
                getSubMenuList = _DbEngine.SqlQuery<GetSubMenu>("SP_GetSubMenuByUserIdAndMuenuId @userId,@MenuId",parameters).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return getSubMenuList;
        }
    }
}
