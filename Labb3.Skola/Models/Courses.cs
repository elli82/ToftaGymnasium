using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3.Skola.Models
{
    public partial class Courses
    {
        public Courses()
        {
            StaffCourses = new HashSet<StaffCourses>();
            StudentsCourses = new HashSet<StudentsCourses>();
        }

        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int Grade { get; set; }
        public int StaffId { get; set; }
        public DateTime Date { get; set; }
        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<StaffCourses> StaffCourses { get; set; }
        public virtual ICollection<StudentsCourses> StudentsCourses { get; set; }
    }
}
