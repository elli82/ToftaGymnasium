using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Labb3.Skola.Models;


namespace Labb3.Skola
{
    class StudentMethod
    {
        public static void ListAllStudents()
        {
            ToftaGymnasiumDbContext context = new ToftaGymnasiumDbContext();
            try
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
                        Console.WriteLine("----All Students----");
                        foreach (var item in listofstudents)

                        {
                            Console.WriteLine("{0}, {1}, StudentId:{2}", item.LastName, item.FirstName, item.StudentId);
                        }
                    }
                    if (c == 2)
                    {
                        var listofstudents = from stud in context.Students
                                             where stud.StudentId > 0
                                             orderby stud.LastName descending
                                             select stud;
                        Console.WriteLine("----All Students----");
                        foreach (var item in listofstudents)

                        {
                            Console.WriteLine("{0}, {1}, StudentId:{2}", item.LastName, item.FirstName, item.StudentId);
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
                        Console.WriteLine("----All Students----");
                        foreach (var item in listofstudents)

                        {
                            Console.WriteLine("{0} {1}, StudentId:{2}", item.FirstName, item.LastName, item.StudentId);
                        }
                    }
                    if (c == 2)
                    {
                        var listofstudents = from stud in context.Students
                                             where stud.StudentId > 0
                                             orderby stud.FirstName descending
                                             select stud;
                        Console.WriteLine("----All Students----");
                        foreach (var item in listofstudents)

                        {
                            Console.WriteLine("{0} {1}, StudentId:{2}", item.FirstName, item.LastName, item.StudentId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
            public static void SingleStudentInfo() 
        {
            ToftaGymnasiumDbContext context = new ToftaGymnasiumDbContext();
            try
            {
                Console.WriteLine("For info of Student, enter StudentId");
                int choice = int.Parse(Console.ReadLine());

                var StSingle = from s in context.Students
                               join cl in context.Classes
                               on s.ClassId equals cl.ClassId
                               where s.StudentId == choice
                               select new
                               {
                                   Id = s.StudentId,
                                   FirstName = s.FirstName,
                                   LastName = s.LastName,
                                   PersonalNumber = s.PersonalNr,
                                   Class = cl.Class,
                                   Prog = cl.Program
                               };
                foreach (var item in StSingle)
                {
                    Console.WriteLine("Student with Id nr {0}: {1} {2}", item.Id, item.FirstName, item.LastName);
                    Console.WriteLine("Personalnumber: {0}", item.PersonalNumber);
                    Console.WriteLine(" Program: {0}, Class: {1}", item.Prog, item.Class);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
