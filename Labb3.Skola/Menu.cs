using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Skola.Models;
using System.Linq;

namespace Labb3.Skola
{
    class Menu
    {

        public static void RunMainMenu()
        {
                Console.WriteLine("Tofta Gymnasium Administration Tool");
                Console.WriteLine();
                Console.WriteLine("-----------Menu:------------");
                Console.WriteLine();
                Console.WriteLine("--------Students------------");               
                Console.WriteLine("All Students-------------[1]");
                Console.WriteLine("Info of single Student---[2]");
                Console.WriteLine();
                Console.WriteLine("Classes------------------[3]");
                Console.WriteLine();
                Console.WriteLine("Courses------------------[4]");
                Console.WriteLine();
                Console.WriteLine("---------Staff--------------");
                Console.WriteLine("Info of Departments------[5]");
                Console.WriteLine("Add member of the Staff--[6]");
                Console.WriteLine();
                Console.WriteLine("Exit---------------------[7]");

            try
            {
                int select = int.Parse(Console.ReadLine());


                switch (select)
                {
                    case 1:
                        StudentMethod.ListAllStudents();
                        Console.WriteLine("Press enter for return to main menu.");
                        break;
                    case 2:
                        StudentMethod.SingleStudentInfo();
                        Console.WriteLine("Press enter for return to main menu.");
                        break;
                    case 3:
                        ClassMethod.ClassLists();
                        Console.WriteLine("Press enter for return to main menu.");
                        break;
                    case 4:
                        CourseMethod.PrintCourses();
                        Console.WriteLine("Press enter for return to main menu.");
                        break;
                    case 5:
                        StaffMethod.MembersofStaff();
                        Console.WriteLine("Press enter for return to main menu.");
                        break;
                    case 6:
                        StaffMethod.AddtoStaff();
                        Console.WriteLine("Press enter for return to main menu.");
                        break;
                    case 7:
                        Console.WriteLine("Thank you for using Tofta Gymnasium Administration Tool.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press enter for main menu.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            Console.Clear();
            
            
        }
    }
}
