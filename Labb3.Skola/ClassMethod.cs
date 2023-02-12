using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Skola.Models;
using System.Linq;


namespace Labb3.Skola
{
    class ClassMethod
    {
        public static void ClassLists()
        {
            ToftaGymnasiumDbContext context = new ToftaGymnasiumDbContext();

            var listofclasses = from cla in context.Classes
                                where cla.ClassId > 0
                                select cla;

            Console.WriteLine("----All Classes----");

            foreach (var item in listofclasses)
            {
                Console.WriteLine("{0}, {1}", item.Class, item.Program);
            }
            try
            {
                Console.WriteLine("For a list of all Students in a certain Class, enter name of the class:");
                Console.WriteLine("Otherwise, press Enter for return to main menu.");
                string selection = Console.ReadLine();

                var studinclass = from s in context.Students
                                  join cl in context.Classes
                                  on s.ClassId equals cl.ClassId
                                  where cl.Class == selection
                                  select new
                                  {
                                      FirstName = s.FirstName,
                                      LastName = s.LastName
                                  };
                Console.WriteLine("----Students in class {0}----", selection);
                foreach (var obj in studinclass)
                {
                    Console.WriteLine("{0} {1}", obj.FirstName, obj.LastName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
