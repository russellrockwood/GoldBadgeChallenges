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

        public void Run()
        {
            SeedClaimsList();
            Menu();
        }

        public void SeedClaimsList() 
        {
            Claim claim1 = new Claim(4, ClaimType.Home, "House burned down. Victim of arson.", 234000, new DateTime(2020, 12, 24), new DateTime(2020, 12, 25));
            _repo = new ClaimsRepository();
            Claim claim2 = new Claim(2, ClaimType.Vehicle, "Crashed motorcycle after high speed chase.", 1400.63, new DateTime(2020, 09, 15), new DateTime(2020, 10, 15));
            Claim claim3 = new Claim(3, ClaimType.Theft, "Home invasion and robbery. Gaming consoles and computers stolen.", 3500, new DateTime(2020, 09, 15), new DateTime(2020, 10, 15));
            _repo.AddNewClaim(claim1);
            _repo.AddNewClaim(claim2);
            _repo.AddNewClaim(claim3);
        }

        public void Menu()
        {
            Console.WriteLine("~Komodo Insurance~");
            Console.ReadLine();
        }

    }
}
