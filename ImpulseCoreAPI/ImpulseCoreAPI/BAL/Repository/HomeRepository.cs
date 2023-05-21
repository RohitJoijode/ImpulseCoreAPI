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
    public class HomeRepository : ImpulseCoreAPI.BAL.IRepository.IHome
    {

        private readonly DbEngine _DbEngine;


        public HomeRepository(DbEngine DbEngine)
        {
            _DbEngine = DbEngine;
        }


        List<Member> lisMembers = new List<Member>
        {
            new Member{MemberId=1, FirstName="Kirtesh", LastName="Shah", Address="Vadodara" },
            new Member{MemberId=2, FirstName="Nitya", LastName="Shah", Address="Vadodara" },
            new Member{MemberId=3, FirstName="Dilip", LastName="Shah", Address="Vadodara" },
            new Member{MemberId=4, FirstName="Atul", LastName="Shah", Address="Vadodara" },
            new Member{MemberId=5, FirstName="Swati", LastName="Shah", Address="Vadodara" },
            new Member{MemberId=6, FirstName="Rashmi", LastName="Shah", Address="Vadodara" },
        };
        public List<Member> GetAllMember()
        {
            List<Member> MembersList = new List<Member>();
            MembersList = _DbEngine.SqlQuery<Member>("GetMemberDb").ToList();
            return MembersList;
        }

        public Member GetMember(int id)
        {
            try
            {
                Member Member = new Member();
                SqlParameter[] parameters =   {
                                                new SqlParameter("@Id",id),
                                            };
                Member = _DbEngine.SqlQuery<Member>("GetMemberDbWithParameter @Id", parameters).FirstOrDefault();
                return Member;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Response SaveMembersDetails(Member MemberObj)
        {
            Response ResponseObj = new Response();
            ImpulseCoreAPI.DAL.MemberDb MemberDb = null;
            
                try
                {

                using (var transaction = _DbEngine.Database.BeginTransaction())
                {
                     MemberDb = _DbEngine.MemberDb.Where(x => x.MemberId == MemberObj.MemberId).FirstOrDefault();
                    if (MemberDb == null)
                    {
                        MemberDb = new DAL.MemberDb();
                        MemberDb.MemberId = 7;
                        MemberDb.FirstName = "Rohit";
                        MemberDb.LastName = "Joijode";
                        MemberDb.Address = "Jogeshwari";
                        _DbEngine.MemberDb.Add(MemberDb);
                        _DbEngine.SaveChanges();
                        transaction.Commit();
                        ResponseObj.IsSuccess = true;
                        ResponseObj.Message = "Data Save Succefully...";
                    }
                    else
                    {
                        MemberDb.FirstName = "Edit";
                        _DbEngine.Entry(MemberDb).State = EntityState.Modified;
                        _DbEngine.SaveChanges();
                        transaction.Commit();
                        ResponseObj.IsSuccess = true;
                        ResponseObj.Message = "Data Update Succefully...";
                    }
                }

                    

            




                }
                catch (Exception ex)
                {
                    throw ex;
                }
            return ResponseObj;

        }


//        JsonResponse Response = new JsonResponse();
//        DBAccessLayer.AddToCart ent2Save = null;
//        Impulse.BAL.Access.AcqCategory AcqCategoryObj = new Impulse.BAL.Access.AcqCategory();
//        bool isNew = false;
//            using (Impulse.DbEngine.DbEngine obj = new DbEngine.DbEngine())
//            {
//                using (var transaction = obj.Database.BeginTransaction())
//                {
//                    try
//                    {
//                            ent2Save = new DBAccessLayer.AddToCart();
//                            ent2Save.Id = AcqCategoryObj.GetAddToCartIncreamentId();
//                            ent2Save.AddToCartId = AcqCategoryObj.GetAddToCartIdIncreamentId(UserId);
//                            if(SubCategoryObject.WistListModel != null)
//                            {
//                                ent2Save.Quantity = SubCategoryObject.WistListModel.Quantity;
//                                ent2Save.Sub_Category_ColorWisePrice = SubCategoryObject.WistListModel.Sub_Category_ColorWisePrice;
//                                ent2Save.Sub_Category_Price = SubCategoryObject.WistListModel.Sub_Category_Price;
//                                ent2Save.Sub_Category_ColorId = SubCategoryObject.WistListModel.Sub_Category_ColorId;
//                                ent2Save.Sub_Category_SizeId = SubCategoryObject.WistListModel.Sub_Category_SizeId;
//                            }
//ent2Save.WistListUniqueId = WistListUniqueId;
//ent2Save.UserId = UserId;
//ent2Save.CategoryId = Categoryid;
//ent2Save.Sub_CategoryId = SubCategoryId;
//ent2Save.IsAddToCart = true;
//ent2Save.IsActive = true;
//ent2Save.CreatedBy = UserId;
//ent2Save.CreatedDate = DateTime.Now;
//isNew = true;
//if (isNew)
//{
//    obj.AddToCart.Add(ent2Save);
//    obj.SaveChanges();
//    transaction.Commit();
//    Response.IsSuccess = true;
//    Response.ResponseMessage = "Data Save Succefully...";
//}
//                    }
//                    catch (Exception ex)
//{
//    transaction.Rollback();
//    Response.IsSuccess = false;
//    Response.ResponseMessage = "Something went Wrong";
//    Impulse.BAL.Update.UpdCommon UpdCommonObj = new Impulse.BAL.Update.UpdCommon();
//    UpdCommonObj.Error_Log(0, "UpdCategory", "SaveToAddToCart", ex.Message.ToString(), 1);
//}
//                }
//            }





    }
}
