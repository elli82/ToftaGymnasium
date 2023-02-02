using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3.Skola.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Courses = new HashSet<Courses>();
        }

        public int SubjectId { get; set; }
        public string Subject1 { get; set; }

        public virtual ICollection<Courses> Courses { get; set; }
    }
}
