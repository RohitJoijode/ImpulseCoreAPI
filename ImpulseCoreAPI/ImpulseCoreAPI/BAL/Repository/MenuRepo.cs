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

        public List<GetUsers> GetUsersList(UserLogInRequest UserLogInRequest)
        {
            List<GetUsers> GetUsersList = new List<GetUsers>();
            try
            {
                SqlParameter[] parameters =   {
                                                new SqlParameter("@userId",UserLogInRequest.UserId),
                                            };
                GetUsersList = _DbEngine.SqlQuery<GetUsers>("GetUsersList @userId",parameters).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return GetUsersList;
        }

        public GetUsers GetUserEditData(UserRequest UserRequest)
        {
            GetUsers GetUsers = new GetUsers();
            try
            {
                SqlParameter[] parameters =   {
                                                new SqlParameter("@Id",UserRequest.Id == null ? "" : UserRequest.Id),
                                                new SqlParameter("@UserId",UserRequest.UserId == "" ? "0" : UserRequest.UserId),
                                            };
                GetUsers = _DbEngine.SqlQuery<GetUsers>("SP_GetUserEditData @Id,@UserId", parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return GetUsers;
        }


        public List<GetUsers> getdemoUserList(UserRequest UserRequest)
        {
            List<GetUsers> GetUsersList = new List<GetUsers>();
            try
            {
                SqlParameter[] parameters =   {
                                                new SqlParameter("@Start",UserRequest.Start == null ? "" : UserRequest.Start),
                                                new SqlParameter("@Take",UserRequest.Take == null ? "" : UserRequest.Take),
                                                new SqlParameter("@orderBy",UserRequest.orderBy == null ? "" : UserRequest.orderBy),
                                                new SqlParameter("@search",UserRequest.search == null ? "" : UserRequest.search),
                                            };
                GetUsersList = _DbEngine.SqlQuery<GetUsers>("dbo.getdemoUserList1 @Start,@Take,@orderBy,@search", parameters).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return GetUsersList;
        }



        public List<dbresponse> SaveupdateUserList(UserRequest UserRequest)
        {
            List<dbresponse> response = new List<dbresponse>();
            try
            {
                SqlParameter[] parameters =   {
                    
                                                new SqlParameter("@Name",UserRequest.Name == null ? "" : UserRequest.Name),
                                                new SqlParameter("@Address1",UserRequest.Address1 == null ? "" : UserRequest.Address1),
                                                new SqlParameter("@Address2",UserRequest.Address2 == null ? "" : UserRequest.Address2),
                                                new SqlParameter("@Address3",UserRequest.Address3 == null ? "" : UserRequest.Address3),
                                                new SqlParameter("@EmailId",UserRequest.EmailId == null ? "" : UserRequest.EmailId),
                                                new SqlParameter("@Password",UserRequest.Password == null ? "" : UserRequest.Password),
                                                new SqlParameter("@MobileNo",UserRequest.MobileNo == null ? "" : UserRequest.MobileNo),
                                                new SqlParameter("@PAN",UserRequest.PAN == null ? "" : UserRequest.PAN),
                                                new SqlParameter("@TYPE",UserRequest.TYPE == null ? "" : UserRequest.TYPE),
                                                new SqlParameter("@IsActive",UserRequest.IsActive),
                                                new SqlParameter("@CreatedBy",UserRequest.UserId == null ? "" : UserRequest.UserId),
                                                new SqlParameter("@CreatedOn",UserRequest.CreatedOn == null ? "" : UserRequest.CreatedOn),
                                                new SqlParameter("@Mode",UserRequest.Id == "0" ? "Save" : "edit"),
                                                new SqlParameter("@UserId",UserRequest.Id == "" ? "0" : UserRequest.Id),
                                            };

                response = _DbEngine.SqlQuery<dbresponse>("SP_SaveupdateUserList @Name,@Address1,@Address2,@Address3,@EmailId,@Password,@MobileNo,@PAN,@TYPE,@IsActive,@CreatedBy,@CreatedOn,@Mode,@UserId", parameters).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        
    }
}
