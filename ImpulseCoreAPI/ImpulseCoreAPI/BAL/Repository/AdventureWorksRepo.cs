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
    public class AdventureWorksRepo : ImpulseCoreAPI.BAL.IRepository.IAdventureWorks
    {
        private readonly DbEngine _DbEngine;

        public AdventureWorksRepo(DbEngine DbEngine)
        {
            _DbEngine = DbEngine;
        }

        public List<DimAccountModal> GetDimAccount()
        {
            List<DimAccountModal> DimAccountList = new List<DimAccountModal>();
            try
            {
                DimAccountList = _DbEngine.SqlQuery<DimAccountModal>("GetDimAccount").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DimAccountList;
        }

    }
}
