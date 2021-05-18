using _01_KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Console
{
    public class ProgramUI
    {
        private KomodoCafeRepository _repo = new KomodoCafeRepository();
        public void Run()
        {
            SeedMenuList();
            Menu();

        }

        public void SeedMenuList()
        {
            KomodoCafeItem menuItem = new KomodoCafeItem(1, "Corndog", "Corn with dog meat", new List<string>() { "bread", "meat", "starch", "sugar" }, 5.95);
            KomodoCafeItem menuItem2 = new KomodoCafeItem(2, "Burger", "Cow meat with cheese", new List<string>() { "wild cow", "ketchup", "Fries", "relish" }, 7.95);
            KomodoCafeItem menuItem3 = new KomodoCafeItem(3, "Pulled Pork Sandwich", "Pulled pork on artisan bun with bbq sauce", new List<string>() { "bread", "pork", "high fructose corn syrup" }, 8.99);
            KomodoCafeItem menuItem4 = new KomodoCafeItem(4, "Chicken Salad", "Mixed greens with grilled chicken", new List<string>() { "chicken", "iceberg lettuce", "tomatoes", "kale" }, 9.99);

            _repo.AddNewMenuItem(menuItem);
            _repo.AddNewMenuItem(menuItem2);
            _repo.AddNewMenuItem(menuItem3);
            _repo.AddNewMenuItem(menuItem4);
        }

        public void Menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Komodo Cafe Crud\n");
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Menu Item\n" +
                    "2. View All Menu Items\n" +
                    "3. Update existing Item\n" +
                    "4. Delete Item\n" +
                    "5. Exit App");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddItem();
                        break;
                    case "2":
                        // DisplayMenu();
                        break;
                    case "3":
                        // UpdateItem();
                        break;
                    case "4":
                        // DeleteItem();
                        break;
                    case "5":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Entry");
                        break;
                }
            }
        }


        public void AddItem()
        {
            Console.Clear();
            KomodoCafeItem newItem = new KomodoCafeItem();

            //Console.WriteLine("Enter the MealNumber\n" +
            //    "");
            //string mealNumberString = Console.ReadLine();
            //newItem.MealNumber = Convert.Double(mealNumberString); 

            Console.WriteLine("Enter Mealname:");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter Description:");
            newItem.Description = Console.ReadLine();

            List<string> newIngredientList = new List<string>();
            bool addMoreIngredients = true;
            while (addMoreIngredients)
            {
                
                Console.WriteLine("Enter Ingredient:\n" +
                    "Enter \"Done\" when finished");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "done")
                {
                    addMoreIngredients = false;
                }
                else
                {
                    newIngredientList.Add(userInput);
                    Console.WriteLine("Ingredient Added");
                }
                
            }

            Console.WriteLine("Enter Price:");
            newItem.Price = Convert.ToDouble(Console.ReadLine());

            bool wasAddedCorrectly = _repo.AddNewMenuItem(newItem);
            if (wasAddedCorrectly)
            {
                Console.WriteLine("New Menu Item Succesfully Added");
            }
            else
            {
                Console.WriteLine("Error adding menu item");
            }
        }

    }
}
