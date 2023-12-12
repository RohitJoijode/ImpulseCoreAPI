using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpulseCoreAPI.Bridge
{
    #region tbl_menu
    public class tbl_menu
    {
        public long Id { get; set; }
        public string MenuName { get; set; }
        public string Icon { get; set; }
        public long? UserId { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    #endregion

    #region GetSubMenu
    public class GetSubMenu
    {
        //public long Id { get; set; }
        public long? MenuId { get; set; }
        public string IconMenu { get; set; }
        public string SubMenuName { get; set; }
        public string url { get; set; }
        public long? UserId { get; set; }
        public bool? IsPermission { get; set; }
        public bool? IsEdit { get; set; }
        public bool? IsAdd { get; set; }
        public bool? IsExport { get; set; }
        public bool? IsAccess { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    #endregion

    #region getMenu
      public class getMenu

    {

        public long? Id { get; set; }

        public string MenuName { get; set; }

        public string Icon { get; set; }

        public bool? IsActive { get; set; }

        public long? UserId { get; set; }

        public long? Createdby { get; set; }

        public DateTime? createdOn { get; set; }

        public long? Updatedby { get; set; }

        public DateTime? updatedon { get; set; }
    }
    #endregion
}
