using _02_ClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_ClaimsRepository_Tests
{
    [TestClass]
    public class ClaimsRepositoryTests
    {
        
        private Claim _claim;
        private Claim _claim2;
        private ClaimsRepository _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepository();
            _claim = new Claim(2, ClaimType.Vehicle, "Crashed motorcycle after high speed chase.", 1400.63, new DateTime(2020,09,15), new DateTime(2020,10,15));
            _claim2 = new Claim(3, ClaimType.Theft, "Home invasion and robbery. Gaming consoles and computers stolen.", 3500, new DateTime(2020, 09, 15), new DateTime(2020, 10, 15));
            _repo.AddNewClaim(_claim);
            _repo.AddNewClaim(_claim2);
        }

        [TestMethod]
        public void AddNewClaim_ShouldReturnCorrectBool()
        {
            Claim claim2 = new Claim(4, ClaimType.Home, "House burned down. Victim of arson.", 234000, new DateTime(2020, 12, 24), new DateTime(2020, 12, 25));
            bool newClaimAdded = _repo.AddNewClaim(claim2);
            Assert.IsTrue(newClaimAdded);
        }

        [TestMethod]
        public void GetAllClaims_ShouldReturnCorrectCollection()
        {
            List<Claim> allInsuranceClaims = _repo.GetAllClaims();
            bool repoContainsClaims = allInsuranceClaims.Contains(_claim);
            Console.WriteLine(repoContainsClaims);
            Assert.IsTrue(repoContainsClaims);
        }

        [TestMethod]
        public void UpdateExistingClaim_ShouldUpdateClaimValues()
        {
            _repo.UpdateExistingClaim(3, new Claim(3, ClaimType.Theft, "Gaming consoles and computers stolen.", 3500, new DateTime(2020, 09, 15), new DateTime(2020, 10, 15)));
            Claim updatedClaim = _repo.GetClaimById(3);

            Assert.AreEqual("Gaming consoles and computers stolen.", updatedClaim.Description);
        }

        [TestMethod]
        public void DeleteClaim_ShouldReturnTrue()
        {
            bool claimDeleted = _repo.DeleteClaim(2);
            Assert.IsTrue(claimDeleted);
        }
    }
}
