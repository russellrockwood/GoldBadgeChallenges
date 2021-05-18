using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsRepository
{
    class ClaimsRepository
    {
        private readonly List<Claim> _claimsDirectory = new List<Claim>();

        public bool AddNewClaim(Claim newClaim)
        {
            int startingCount = _claimsDirectory.Count;
            _claimsDirectory.Add(newClaim);
            return startingCount < _claimsDirectory.Count ? true : false;
        }

        public List<Claim> GetAllClaims()
        {
            return _claimsDirectory;
        }
        public Claim GetClaimById(int claimId)
        {
            foreach (Claim item in _claimsDirectory)
            {
                if (item.ClaimID == claimId)
                {
                    return item;
                }
            }
            return null;
        }

        public bool UpdateExistingClaim(int claimId, Claim newClaim)
        {
            Claim oldClaim = GetClaimById(claimId);

            if (oldClaim != null)
            {
                oldClaim.ClaimID = newClaim.ClaimID;
                oldClaim.ClaimType = newClaim.ClaimType;
                oldClaim.ClaimAmount = newClaim.ClaimAmount;
                oldClaim.DateOfClaim = newClaim.DateOfClaim;
                oldClaim.DateOfIncident = newClaim.DateOfIncident;
                oldClaim.Description = newClaim.Description;
                return true;
            }
            return false;
        }

        public bool DeleteClaim(int claimId)
        {
            Claim claimToDelete = GetClaimById(claimId);

            if (claimToDelete != null)
            {
                _claimsDirectory.Remove(claimToDelete);
                return true;
            }
            return false;
        }
    }
}
