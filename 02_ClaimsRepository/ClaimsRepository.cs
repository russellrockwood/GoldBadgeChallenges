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
    }
}
