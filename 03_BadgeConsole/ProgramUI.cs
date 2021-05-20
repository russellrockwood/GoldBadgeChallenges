
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
            Badge employee2 = new Badge(1235, new List<Doors> { Doors.A2, Doors.B2, Doors.A3, Doors.A4});
            Badge employee3 = new Badge(1236, new List<Doors> {Doors.A1, Doors.A2, Doors.A3, Doors.B3, Doors.B4, Doors.EscapeTunnel });
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
                        AddBadge();
                        break;

                    case "2":
                        //EditBadge();
                        break;

                    case "3":
                        ListBadges();
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
                Console.Clear();
            }
        }

        public void AddBadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();
            List<Doors> newBadgeAccessList = new List<Doors>();

            Console.WriteLine("Enter new badge number:");
            newBadge.BadgeNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter door number to grant access or type \"done\" when finished");
            bool addingDoorAccess = true;
            while (addingDoorAccess)
            {
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "done")
                {
                    addingDoorAccess = false;
                }
                else
                {
                    Doors door = (Doors)Enum.Parse(typeof(Doors), userInput);
                    newBadgeAccessList.Add(door);
                    Console.WriteLine("Door access successfully added. Enter another door or type \"done\"");
                }
                //Animal animal = (Animal)Enum.Parse(typeof(Animal), str)
            }
            newBadge.DoorAccess = newBadgeAccessList;
            bool newBadgeAdded =_repo.AddNewBadge(newBadge);
            if (newBadgeAdded)
            {
                Console.WriteLine("New Badge Successfully Added :)");
            }
            else
            {
                Console.WriteLine("Error Adding New Badge");
            }
        }

        public void ListBadges()
        {
            Console.Clear();
            Dictionary<int, List<Doors>> badgeDirectory = _repo.GetFullDirectory();

            Console.WriteLine(("Badge #").PadRight(20) + ("DoorAccess") + "\n");
            foreach (var item in badgeDirectory)
            {
                Console.WriteLine(($"{item.Key}").PadRight(20) + string.Join(" ", item.Value));
                Console.WriteLine("\n");
            }
        }
    }
}
