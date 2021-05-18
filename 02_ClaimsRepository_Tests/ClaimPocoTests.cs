using _02_ClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_ClaimsRepository_Tests
{
    [TestClass]
    public class ClaimPocoTests
    {
        [TestMethod]
        
        public void IsClaimValidShouldReturnCorrectBool()
        {
            Claim claim1 = new Claim(2, ClaimType.Vehicle, "Crashed motorcycle after high speed chase.", 1400.63, new DateTime(2020, 09, 15), new DateTime(2020, 09, 16));

            Claim claim2 = new Claim(3, ClaimType.Theft, "Home invasion and robbery. Gaming consoles and computers stolen.", 3500, new DateTime(2020, 09, 15), new DateTime(2021, 10, 15));

            Assert.IsTrue(claim1.IsValid);
            Assert.IsFalse(claim2.IsValid);
        }
    }
}
