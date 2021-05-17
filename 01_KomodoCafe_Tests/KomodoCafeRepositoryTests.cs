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

        [TestMethod]
        public void GetItemByNumber_ShouldReturnCorrectItem()
        {
            KomodoCafeItem menuItem = new KomodoCafeItem(5, "Corndog", "Corn with dog meat", new List<string>() { "bread", "meat", "starch", "sugar"}, 5.95);
            KomodoCafeItem menuItem2 = new KomodoCafeItem(4, "Burger", "Cow meat with cheese", new List<string>() { "wild cow", "ketchup", "Fries", "relish" }, 7.95);

            KomodoCafeRepository repository = new KomodoCafeRepository();
            repository.AddNewMenuItem(menuItem);
            repository.AddNewMenuItem(menuItem2);

            KomodoCafeItem retrievedItem = repository.GetItemByNumber(4);
            Console.WriteLine($"Retrieved Item Name: {retrievedItem.MealName}\n" +
                $"Retrieved Item Ingredients: {retrievedItem.Ingredients[0]}");
            Assert.AreEqual("Burger", retrievedItem.MealName);


            KomodoCafeItem retrievedItem2 = repository.GetItemByNumber(5);
            Console.WriteLine($"Retrieved Item Name: {retrievedItem2.MealName}\n" +
                $"Retrieved Item Ingredients: {retrievedItem2.Ingredients[0]}");
            Assert.AreEqual("Corndog", retrievedItem2.MealName);
        }

        private KomodoCafeItem _menuItem;
        private KomodoCafeRepository _fullMenu;
        [TestInitialize]
        public void Arrange()
        {
            _fullMenu = new KomodoCafeRepository();
            _menuItem = new KomodoCafeItem(4, "Burger", "Cow meat with cheese", new List<string>() { "wild cow", "ketchup", "Fries", "relish" }, 7.95);
            _fullMenu.AddNewMenuItem(_menuItem);
        }

        [TestMethod]
        public void UpdateMenuItem_ShouldReturnTrue()
        {
            bool itemWasUpdated = _fullMenu.UpdateMenuItem(4, new KomodoCafeItem(4, "Burger", "Organic cow meat with cheese", new List<string>() { "wild cow", "ketchup", "Fries", "relish" }, 8.95));

            Console.WriteLine($"Updated Description: {_menuItem.Description}\n" +
                $"Updated Price: ${_menuItem.Price}");
            Assert.AreEqual("Organic cow meat with cheese", _menuItem.Description);
        }

    }
}
