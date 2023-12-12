using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpulseCoreAPI.Bridge
{
    public class Member
    {
        public long MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }

    #region Employee
    public class Employee
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
    #endregion

    #region Student
    public class Student
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
    #endregion

    public class SP_DemoMultipleTableExcutionObj
    {
        public Employee Employee { get; set; }
        public Student Student { get; set; }
    }


}
