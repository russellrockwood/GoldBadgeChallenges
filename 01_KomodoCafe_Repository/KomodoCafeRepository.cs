using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Repository
{
    public class KomodoCafeRepository
    {
        private readonly List<KomodoCafeItem> _menuItems = new List<KomodoCafeItem>();

        public bool AddNewMenuItem(KomodoCafeItem newItem)
        {
            int menuItemCount = _menuItems.Count;

            _menuItems.Add(newItem);

            return (menuItemCount < _menuItems.Count) ? true : false;

        }

        public List<KomodoCafeItem> GetAllMenuItems()
        {
            return _menuItems;
        }

        public KomodoCafeItem GetItemByNumber(int mealNumber)
        {
            foreach (var menuItem in _menuItems)
            {
                if (menuItem.MealNumber == mealNumber)
                {
                    return menuItem;
                }
            }

            return null;
        }

        public bool UpdateMenuItem(int itemNumber, KomodoCafeItem newItemValues)
        {
            KomodoCafeItem oldItem = GetItemByNumber(itemNumber);
            if (oldItem != null)
            {
                oldItem.MealNumber = newItemValues.MealNumber;
                oldItem.MealName = newItemValues.MealName;
                oldItem.Description = newItemValues.Description;
                oldItem.Ingredients = newItemValues.Ingredients;
                oldItem.Price = newItemValues.Price;

                return true;
            }

            return false;
        }
    }
}

/*Your Task:
Create a MenuItem Class with properties, constructors, and fields.
Create a MenuRepository Class that has methods needed.
Create a Test Class for your repository methods. (You don't need to test your constructors or objects, just your methods)
Create a Program file that allows the cafe manager to add, update, and delete, and see all items in the menu list. */
