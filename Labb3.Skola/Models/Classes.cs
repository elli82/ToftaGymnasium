using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3.Skola.Models
{
    public partial class Classes
    {
        public Classes()
        {
            Students = new HashSet<Students>();
        }

        public int ClassId { get; set; }
        public string Class { get; set; }
        public string Program { get; set; }

        public virtual ICollection<Students> Students { get; set; }
    }
}
