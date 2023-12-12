using ImpulseCoreAPI.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpulseCoreAPI
{
    public class DbEngine : DbContext
    {
        public DbEngine(DbContextOptions<DbEngine> dbContextOptions)
       : base(dbContextOptions)
        {
        }
        public DbSet<MemberDb> MemberDb { get; set; }
        public DbSet<DimAccount> DimAccount { get; set; }
        public DbSet<tbl_Users> Users { get; set; }
        public DbSet<tbl_menu> tbl_menu { get; set; }
        public DbSet<tbl_SubMenu> tbl_SubMenu { get; set; }
        public DbSet<FilePathString> FilePathString { get; set; }
    }
}
