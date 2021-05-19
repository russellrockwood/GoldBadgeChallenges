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

        [TestMethod]
        public void GetFullDirectory_ShouldReturnCorrectCollection()
        {
            Dictionary<int, List<Doors>> badgeDirectory = _repo.GetFullDirectory();
            bool directoryHasBadgeNumber = badgeDirectory.ContainsKey(_badge.BadgeNumber);
            bool directoryHasAccessList = badgeDirectory.ContainsValue(_badge.DoorAccess);

            Assert.IsTrue(directoryHasBadgeNumber);
            Assert.IsTrue(directoryHasAccessList);
        }

        [TestMethod]
        public void ViewAccessById_ShouldReturnCorrectList()
        {
            List<Doors> doorAccess = _repo.ViewAccessByID(1234);
            bool hasCorrectDoor = doorAccess.Contains(Doors.EscapeTunnel);
            bool hasCorrectDoor2 = doorAccess.Contains(Doors.A1);
            bool hasCorrectDoor3 = doorAccess.Contains(Doors.B1);

            Assert.IsTrue(hasCorrectDoor);
            Assert.IsTrue(hasCorrectDoor2);
            Assert.IsTrue(hasCorrectDoor3);
        }

        [TestMethod]
        public void AddDoorAccess_ShouldReturnCorrectBool()
        {
            _repo.AddDoorAccess(1234, Doors.A2);
            _repo.AddDoorAccess(1234, Doors.B2);

            List<Doors> newDoorAccess = _repo.ViewAccessByID(1234);
            bool hasCorrectDoor = newDoorAccess.Contains(Doors.B2);
            bool hasCorrectDoor2 = newDoorAccess.Contains(Doors.A2);

            Assert.IsTrue(hasCorrectDoor);
            Assert.IsTrue(hasCorrectDoor2);
        }
    }
}
