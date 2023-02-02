using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3.Skola.Models
{
    public partial class StaffCourses
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public int CourseId { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
