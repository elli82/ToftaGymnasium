using Labb3.Skola.Models;
using System;
using System.Linq;


namespace Labb3.Skola
{
    class Program
    {
        static void Main(string[] args)
        {
            ToftaGymnasiumDbContext context = new ToftaGymnasiumDbContext();
            bool isrunning = true;

            Console.WriteLine("Tofta Gymnasium Administration Tool");
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("Students[1]");
                Console.WriteLine("Classes[2]");
                Console.WriteLine("Staff[3]");
                Console.WriteLine("Quit [4]");

                int select = int.Parse(Console.ReadLine());

                switch (select)
                {
                    case 1:
                        {
                            Console.WriteLine("For a list of all Students, by Lastnames, press 1:");
                            Console.WriteLine("For a list of all Students, by Firstnames, press 2:");
                            int choice = int.Parse(Console.ReadLine());

                            if (choice == 1)
                            {
                                Console.WriteLine("Ascending, press 1:");
                                Console.WriteLine("Descending, press 2");
                                int c = int.Parse(Console.ReadLine());
                                if (c == 1)
                                {
                                    var listofstudents = from stud in context.Students
                                                         where stud.StudentId > 0
                                                         orderby stud.LastName ascending
                                                         select stud;
                                    Console.WriteLine("----Students----");
                                    foreach (var item in listofstudents)

                                    {
                                        Console.WriteLine("{0}, {1}", item.LastName, item.FirstName);
                                    }
                                }
                                if (c == 2)
                                {
                                    var listofstudents = from stud in context.Students
                                                         where stud.StudentId > 0
                                                         orderby stud.LastName descending
                                                         select stud;
                                    Console.WriteLine("----Students----");
                                    foreach (var item in listofstudents)

                                    {
                                        Console.WriteLine("{0}, {1}", item.LastName, item.FirstName);
                                    }

                                }

                            }
                            if (choice == 2)
                            {
                                Console.WriteLine("Ascending, press 1:");
                                Console.WriteLine("Desscending, press 2");
                                int c = int.Parse(Console.ReadLine());
                                if (c == 1)
                                {
                                    var listofstudents = from stud in context.Students
                                                         where stud.StudentId > 0
                                                         orderby stud.FirstName ascending
                                                         select stud;
                                    Console.WriteLine("----Students----");
                                    foreach (var item in listofstudents)

                                    {
                                        Console.WriteLine("{0}, {1}", item.FirstName, item.LastName);
                                    }
                                }
                                if (c == 2)
                                {
                                    var listofstudents = from stud in context.Students
                                                         where stud.StudentId > 0
                                                         orderby stud.FirstName descending
                                                         select stud;
                                    Console.WriteLine("----Students----");
                                    foreach (var item in listofstudents)

                                    {
                                        Console.WriteLine("{0}, {1}", item.FirstName, item.LastName);
                                    }
                                }

                            }
                            break;
                        }
                    case 2:
                        var listofclasses = from cla in context.Classes
                                            where cla.ClassId > 0
                                            select cla;

                        Console.WriteLine("----All Classes----");

                        foreach (var item in listofclasses)
                        {
                            Console.WriteLine("{0}, {1}", item.Class, item.Program);
                        }
                        Console.WriteLine("For a list of all Students in a certain Class, enter name of the class:");
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

                        foreach (var obj in studinclass)
                        {
                            Console.WriteLine("{0} {1}", obj.FirstName, obj.LastName);
                        }

                        break;
                    case 3:
                        {
                            Console.WriteLine("Add a member of the Staff:");
                            Console.WriteLine("First Name:");
                            string fname = Console.ReadLine();
                            Console.WriteLine("Last Name:");
                            string lname = Console.ReadLine();
                            Console.WriteLine("Role:");
                            string rol = Console.ReadLine();
                            Console.WriteLine("Salary:");
                            int salr = int.Parse(Console.ReadLine());

                            Staff p1 = new Staff()
                            {
                                FirstName = fname,
                                LastName = lname,
                                Role = rol,
                                DateofEmployment = DateTime.Today,
                                Salary = salr
                            };
                            context.Staff.Add(p1);
                            context.SaveChanges();
                            Console.WriteLine("Staff was added");
                            break;
                        }
                    case 4:
                        isrunning = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Klicka Enter för att återgå till menyn.");
                        break;
                }
            } while (isrunning);
        }
    }
}
