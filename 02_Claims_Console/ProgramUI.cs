using _02_ClaimsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console
{
    public class ProgramUI
    {
        private ClaimsRepository _repo = new ClaimsRepository();
        private Queue<Claim> _repoQueue = new Queue<Claim>();

        public void Run()
        {
            SeedClaimsList();
            Menu();
        }

        public void SeedClaimsList() 
        {
            Claim claim1 = new Claim(4, ClaimType.Home, "House burned down.", 234000, new DateTime(2020, 12, 24), new DateTime(2020, 12, 25));
            Claim claim2 = new Claim(2, ClaimType.Vehicle, "Crashed motorcycle.", 1400.63, new DateTime(2020, 09, 15), new DateTime(2020, 10, 15));
            Claim claim3 = new Claim(3, ClaimType.Theft, "Home invasion/robbery.", 3500, new DateTime(2020, 09, 15), new DateTime(2020, 10, 15));

            _repoQueue.Enqueue(claim1);
            _repoQueue.Enqueue(claim2);
            _repoQueue.Enqueue(claim3);

            _repo.AddNewClaim(claim1);
            _repo.AddNewClaim(claim2);
            _repo.AddNewClaim(claim3);
        }

        public void Menu()
        {
            Console.WriteLine("~Komodo Insurance~");
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Choose a menu item:\n" +
                    "1. See all claims\n" +
                    "2. Handle next claim\n" +
                    "3. Enter new claim\n" +
                    "4. Remove Claim From Directory\n" +
                    "5. Exit console");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;

                    case "2":
                        HandleNextClaim();
                        break;

                    case "3":
                        // EnterNewClaim();
                        break;

                    case "4":
                        // RemoveClaim();
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
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

        public void SeeAllClaims()
        {
            Console.Clear();
            List<Claim> claimsDirectory = _repo.GetAllClaims();
            //Console.WriteLine(("-|- Name: " + myList[i].GetName()).PadRight(20, ' ') +
            //      ("| Surname: " + myList[i].GetName()) + "|".PadRight(20, ' ');

            Console.WriteLine(("ClaimId").PadRight(25) + ("Type").PadRight(25) + ("Description").PadRight(25) + ("Amount").PadRight(25) + ("DateOfAccident").PadRight(25) + ("DateOfClaim").PadRight(25) + ("IsValid").PadRight(25));
            foreach (Claim item in claimsDirectory)
            {
                Console.WriteLine(($"{item.ClaimID}").PadRight(25) + ($"{item.TypeOfClaim}").PadRight(25) + ($"{item.Description}").PadRight(25) + ($"{item.ClaimAmount}").PadRight(25) + ($"{item.DateOfIncident.ToString("d")}").PadRight(25) + ($"{item.DateOfClaim.ToString("d")}").PadRight(25) + ($"{item.IsValid}").PadRight(25));
            }

        }

        public void HandleNextClaim()
        {
            Console.Clear();
            
            Claim nextClaim = _repoQueue.Peek();
            Console.WriteLine($"Claim ID: {nextClaim.ClaimID}\n\n" +
                $"Type: {nextClaim.TypeOfClaim}\n\n" +
                $"Description: {nextClaim.Description}\n\n" +
                $"Claim Amount: ${nextClaim.ClaimAmount}\n\n" +
                $"Date of incident: {nextClaim.DateOfIncident}\n\n" +
                $"Date of claim: {nextClaim.DateOfClaim}\n\n" +
                $"IsValid: {nextClaim.IsValid}\n\n");

            Console.WriteLine("Would you like to deal with this claim now (y/n)");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "y")
            {
                nextClaim = _repoQueue.Dequeue();
                _repo.DeleteClaim(nextClaim.ClaimID);
                Console.WriteLine("Claim Removed From Queue");
            }
            else
            {
                Console.WriteLine("Returning to main menu...");
            }
        }

    }
}
