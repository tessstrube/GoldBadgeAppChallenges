using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Ramen
{
    public class MenuItems
    {
        public int FoodNumber { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string[] Ingredients { get; set; }

        public MenuItems(int number, string name, string yum, int price, string[] ingredients)
        {
            FoodNumber = number;
            FoodName = name;
            Description = yum;
            Price = price;
            Ingredients = ingredients;
        }
        public MenuItems() { }
    }
}
