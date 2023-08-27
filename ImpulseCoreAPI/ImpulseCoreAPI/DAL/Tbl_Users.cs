using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImpulseCoreAPI.DAL
{
    #region Tbl_USERS
    [Table("Tbl_USERS")]
    public class Tbl_USERS
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Column(Order = 1)]
        public long Id { get; set; }
        public long? UserId { get; set; }
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
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
    }
    #endregion
}
