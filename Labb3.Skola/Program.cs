using Labb3.Skola.Models;
using System;
using System.Linq;


namespace Labb3.Skola
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool isrunning = true;
            
            do
            {
                Menu.RunMainMenu();
                
            } while (isrunning);            
        }
    }
}

