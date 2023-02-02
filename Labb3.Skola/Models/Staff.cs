using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3.Skola.Models
{
    public partial class Staff
    {
        public Staff()
        {
            StaffCourses = new HashSet<StaffCourses>();
        }

        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public DateTime DateofEmployment { get; set; }
        public int Salary { get; set; }

        public virtual ICollection<StaffCourses> StaffCourses { get; set; }
    }
}
