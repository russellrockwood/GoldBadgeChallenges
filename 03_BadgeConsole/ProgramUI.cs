
using _03_BadgeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeConsole
{
    public class ProgramUI
    {
        //private Dictionary<int, List<Doors>> _repo = new Dictionary<int, List<Doors>>();
        BadgeRepository _repo = new BadgeRepository();
        public void Run()
        {
            SeedBadgeDictionary();
            Menu();
        }

        public void SeedBadgeDictionary()
        {
            Badge employee1 = new Badge(1234, new List<Doors> { Doors.A1, Doors.B1, Doors.EscapeTunnel });
            Badge employee2 = new Badge(1235, new List<Doors> { Doors.A1, Doors.B1, Doors.EscapeTunnel });
            Badge employee3 = new Badge(1236, new List<Doors> { Doors.A1, Doors.B1, Doors.EscapeTunnel });
            _repo.AddNewBadge(employee1);
            _repo.AddNewBadge(employee2);
            _repo.AddNewBadge(employee3);
        }
        public void Menu()
        {
            Console.WriteLine("~ Badge Management Console ~\n\n");
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("What would you like to do?\n" +
                    "1. Add A Badge\n" +
                    "2. Edit A Badge\n" +
                    "3. List All Badges\n" +
                    "4. Remove Badge From Directory\n" +
                    "5. Exit Console\n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //AddBadge();
                        break;

                    case "2":
                       //EditBadge();
                        break;

                    case "3":
                        //SeeAllBadges();
                        break;

                    case "4":
                        //RemoveBadge();
                        break;

                    case "5":
                        Console.Clear();
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
    }
}
