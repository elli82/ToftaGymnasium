using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3.Skola.Models
{
    public partial class Students
    {
        public Students()
        {
            StudentsCourses = new HashSet<StudentsCourses>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNr { get; set; }
        public int ClassId { get; set; }

        public virtual Classes Class { get; set; }
        public virtual ICollection<StudentsCourses> StudentsCourses { get; set; }
    }
}
