using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImpulseCoreAPI.DAL
{
    [Table("MemberDb")]
    public class MemberDb
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Column(Order = 1)]
        public long MemberId {get;set;}
        public string FirstName{get;set;}
        public string LastName {get;set;}
        public string Address { get; set; }
    }
}
