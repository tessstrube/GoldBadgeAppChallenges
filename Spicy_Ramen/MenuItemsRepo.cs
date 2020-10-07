using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Ramen
{
    public class MenuItemsRepo
    {
        private readonly List<MenuItems> _menuItems = new List<MenuItems>();

        public List<MenuItems> ShowAllMenuItems()
        {
            return _menuItems;
        }

        public bool CreateMenuItem(MenuItems item)
        {
            int startCount = _menuItems.Count;
            _menuItems.Add(item);
            bool wasAdded = (_menuItems.Count > startCount);
            return wasAdded;
        }
        public bool DeleteMenuItem(MenuItems item)
        {
            bool deleteResult = _menuItems.Remove(item);
            return deleteResult;
        }
    }
}
