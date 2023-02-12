using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Skola.Models;
using System.Linq;

namespace Labb3.Skola
{
    class CourseMethod
    {
        public static void PrintCourses()
        {
            ToftaGymnasiumDbContext context = new ToftaGymnasiumDbContext();

            var ListofCourses = from subj in context.Subject
                                where subj.SubjectId > 0
                                orderby subj.Subject1 ascending
                                select subj;
            Console.WriteLine("----All Courses----");
            foreach(var obj in ListofCourses)
            {
                Console.WriteLine("{0}", obj.Subject1);
            }



        }
    }
}
