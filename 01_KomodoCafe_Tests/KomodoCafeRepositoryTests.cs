using _01_KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            KomodoCafeItem menuItem = new KomodoCafeItem();
            KomodoCafeRepository repository = new KomodoCafeRepository();

            bool itemAdded = repository.AddNewMenuItem(menuItem);
            Console.WriteLine($"Was item added?: {itemAdded}");
            Assert.IsTrue(itemAdded);
        }

        [TestMethod]
        public void GetAllMenuItems_ShouldReturnCollection()
        {
            KomodoCafeItem menuItem = new KomodoCafeItem();
            KomodoCafeRepository repository = new KomodoCafeRepository();
            repository.AddNewMenuItem(menuItem);

            List<KomodoCafeItem> fullMenu = repository.GetAllMenuItems();
            bool menuContainsItems = fullMenu.Contains(menuItem);

            Assert.IsTrue(menuContainsItems);
        }

    }
}
