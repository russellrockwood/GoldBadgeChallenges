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
        
        // handle removing claims from queue in removeclaim method
        // check for duplicate id numbers.
        
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
                    "5. Update Existing Claim\n" +
                    "6. Exit console\n");
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
                        EnterNewClaim();
                        break;

                    case "4":
                        RemoveClaim();
                        break;

                    case "5":
                        UpdateClaim();
                        break;

                    case "6":
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

        public void EnterNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            Console.WriteLine("Select new claim type:\n" +
                "1. Vehicle\n" +
                "2. Home\n" +
                "3 Theft\n");
            newClaim.TypeOfClaim = (ClaimType)Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter a claim description:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter claim dollar amount:");
            newClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine());

            //TimeSpan testTime = (DateTime.Parse("1990/09/08")) - (DateTime.Parse("1990/09/07"));
            Console.WriteLine("Enter date of incident: yyyy/mm/dd");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter date of claim: yyyy/mm/dd");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter new claim ID:");
            int idInput = Convert.ToInt32(Console.ReadLine());
            if (_repo.GetClaimById(idInput) == null)
            {
                newClaim.ClaimID = idInput;
                bool addedCorrectly = _repo.AddNewClaim(newClaim);
                if (addedCorrectly)
                {
                    _repoQueue.Enqueue(newClaim);
                    Console.WriteLine("New claim succesfully added.");
                }
                else
                {
                    Console.WriteLine("Error adding new claim.");
                }
            }
            else
            {
                //bool duplicateClaim = true;
                //while (duplicateClaim)
                //{
                //}
                Console.WriteLine("A Claim with that ID already exists.");
            }

            //bool duplicateClaimId = _repo.GetClaimById(idInput);
            //while (duplicateClaimId == false)
            //{
            //    Console.WriteLine("A Claim with that ID already exists. Please enter a new claim ID");
            //}



            //bool idIsNotDuplicate = _repo.CheckForDuplicateClaimId(idInput);
        }

        public void RemoveClaim() 
        {
            Console.Clear();
            Console.WriteLine("Enter Id of claim you would like to remove:");
            bool claimDeleted = _repo.DeleteClaim(Convert.ToInt32(Console.ReadLine()));
            if (claimDeleted)
            {
                Console.WriteLine("Claim succesfully deleted");
            }
            else
            {
                Console.WriteLine("Error deleting claim");
            }
        }

        public void UpdateClaim()
        {
            Console.Clear();
            Console.WriteLine("Enter Id of claim to update:");
            Claim oldClaim = _repo.GetClaimById(Convert.ToInt32(Console.ReadLine()));

            if (oldClaim != null)
            {
                Claim newClaim = new Claim();

                Console.WriteLine("Select new claim type:\n" +
                    "1. Vehicle\n" +
                    "2. Home\n" +
                    "3 Theft\n");
                newClaim.TypeOfClaim = (ClaimType)Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter a claim description:");
                newClaim.Description = Console.ReadLine();

                Console.WriteLine("Enter claim dollar amount:");
                newClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine());

                
                Console.WriteLine("Enter date of incident: yyyy/mm/dd");
                newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter date of claim: yyyy/mm/dd");
                newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

                _repo.UpdateExistingClaim(oldClaim.ClaimID, newClaim);

                Console.WriteLine("Claim Succesfully Updated");
            }
            else
            {
                Console.WriteLine("Could not locate claim to update");
            }
        }
    }
}
