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

    }
}
