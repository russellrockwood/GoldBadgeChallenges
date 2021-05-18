using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsRepository
{
    public enum ClaimType { Car, Home, Theft}
    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public int ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid 
        {
            get 
            {
                double claimTimeSpan = (DateOfClaim - DateOfIncident).TotalDays;
                if (claimTimeSpan > 30)
                {
                    return false;
                }
                return true;
            } 
        }
    }
}

//The Claim has the following properties:
//ClaimID
//ClaimType
//Description
//ClaimAmount
//DateOfIncident
//DateOfClaim
//IsValid

//Komodo allows an insurance claim to be made up to 30 days after an incident took place. If the claim is not in the proper time limit, it is not valid.

//A ClaimType could be the following:
//Car
//Home
//Theft
