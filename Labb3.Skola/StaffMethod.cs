using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Skola.Models;
using System.Linq;

namespace Labb3.Skola
{
    class StaffMethod
    {
        
        public static void AddtoStaff()
        {
            ToftaGymnasiumDbContext context = new ToftaGymnasiumDbContext();

            try
            {
                Console.WriteLine("Add a member of the Staff:");
                Console.WriteLine("First Name:");
                string fname = Console.ReadLine();
                Console.WriteLine("Last Name:");
                string lname = Console.ReadLine();
                Console.WriteLine("Role:");
                string rol = Console.ReadLine();
                Console.WriteLine("Date of Employment: (yy-mm-dd) ");
                DateTime date = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Salary:");
                int salr = int.Parse(Console.ReadLine());

                Staff p1 = new Staff()
                {
                    FirstName = fname,
                    LastName = lname,
                    Role = rol,
                    DateofEmployment = date,
                    Salary = salr
                };
                context.Staff.Add(p1);
                context.SaveChanges();
                Console.WriteLine("Staff was added");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MembersofStaff()
        {
            ToftaGymnasiumDbContext context = new ToftaGymnasiumDbContext();

            try
            {
                Console.WriteLine("Enter Department:");
                string department = Console.ReadLine();

                var numberofStaff = (from member in context.Staff
                                     where member.Role == department
                                     select member).Count();
                Console.WriteLine("There are currently {0} people working in the {1} department", numberofStaff, department);

                var StaffinDepartments = from member in context.Staff
                                         where member.Role == department
                                         select member;

                foreach (var item in StaffinDepartments)
                {
                    Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
