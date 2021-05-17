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
    }
}
