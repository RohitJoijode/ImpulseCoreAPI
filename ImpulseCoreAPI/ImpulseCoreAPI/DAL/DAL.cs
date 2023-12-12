using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImpulseCoreAPI.DAL
{
    #region tbl_menu
    [Table("tbl_menu")]
    public class tbl_menu
    {
        public long Id { get; set; }
        public string MenuName { get; set; }
        public string Icon { get; set; }
        public bool? IsActive { get; set; }
        public long? UserId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    #endregion

    #region tbl_SubMenu
    [Table("tbl_SubMenu")]
    public class tbl_SubMenu
    {
        public long Id { get; set; }
        public long? MenuId { get; set; }
        public string IconMenu { get; set; }
        public string SubMenuName { get; set; }
        public bool? IsPermission { get; set; }
        public bool? IsEdit { get; set; }
        public bool? IsAdd { get; set; }
        public bool? IsExport { get; set; }
        public bool? IsAccess { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? UserId { get; set; } // Here Added by Rohit joijode Added on 1/12/2023
        public DateTime? UpdatedOn { get; set; }
    }
    #endregion

    #region tbl_Users
    [Table("tbl_Users")]
    public class tbl_Users
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Key, Column(Order = 1)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string PAN { get; set; }
        public long? TYPE { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    #endregion

}
