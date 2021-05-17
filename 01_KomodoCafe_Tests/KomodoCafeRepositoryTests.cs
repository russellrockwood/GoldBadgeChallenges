using _01_KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_KomodoCafe_Tests
{
    [TestClass]
    public class KomodoCafeRepositoryTests
    {

        //AAA

        //Arrange 
        //Act
        //Assert
        [TestMethod]
        public void AddNewMenuItem_ShouldReturnCorrectBool()
        {
            KomodoCafe menu = new KomodoCafe();
            KomodoCafeRepository repository = new KomodoCafeRepository();

            bool itemAdded = repository.AddNewMenuItem(menu);
            Console.WriteLine($"Was item added?: {itemAdded}");
            Assert.IsTrue(itemAdded);
        }

    }
}
