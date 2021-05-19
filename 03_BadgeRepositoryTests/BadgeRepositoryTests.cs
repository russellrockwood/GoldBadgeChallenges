using _03_BadgeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_BadgeRepositoryTests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        private Badge _badge;
        private BadgeRepository _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepository();
            _badge = new Badge(1234, new List<Doors> { Doors.A1, Doors.B1, Doors.EscapeTunnel});
            _repo.AddNewBadge(_badge);
        }
        [TestMethod]
        public void AddNewBadge_ShouldReturnCorrectBool()
        {
            Badge testBadge = new Badge(2345, new List<Doors> { Doors.A1, Doors.B1, Doors.A2 });
            bool wasAdded = _repo.AddNewBadge(testBadge);
            Assert.IsTrue(wasAdded);
        }
    }
}
