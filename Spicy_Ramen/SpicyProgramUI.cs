using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Ramen
{
    public class SpicyProgramUI
    {
        private readonly MenuItemsRepo _menuItemsRepo = new MenuItemsRepo();
        public void Run()
        {
            RamenData();
            OpenMenu();
        }
        public void OpenMenu()
        {
            bool keepMenuOpen = true;
            while (keepMenuOpen)
            {

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Enter the number for the action you'd like to preform: \n\n" +
                "1: Show all menu items.\n" +
                "2: Add new menu item\n" +
                "3: Delete an item from the menu \n" +
                "4: Exit Ramen Menu\n\n");
                var spicyInput = Console.ReadLine();
                switch (spicyInput)
                {
                    case "1":

                        Console.Clear();
                        ShowAllMenuItems();
                        break;

                    case "2":

                        Console.Clear();
                        CreateMenuItem();
                        break;

                    case "3":

                        Console.Clear();
                        DeleteMenuItem();
                        break;


                    case "4":

                        Console.Clear();
                        keepMenuOpen = false;
                        break;

                    default:

                        Console.Clear();
                        Console.WriteLine("Invalid entry.\n Please enter a valid option:\n Or press any key to continue:\n");
                        Console.ReadKey();
                        break;

                }

            }
        }

        public void ShowAllMenuItems()
        {
            List<MenuItems> allItems = _menuItemsRepo.ShowAllMenuItems();


            foreach (MenuItems item in allItems)
            {
                string listOfIngredients = string.Join(",", item.Ingredients);
                Console.WriteLine($"Number; {item.FoodNumber}, Name: {item.FoodName}, Price: { item.Price}, Description: {item.Description}, Ingredients: {listOfIngredients}\n ");

            }


        }

        public void CreateMenuItem()
        {
            MenuItems addItem = new MenuItems();
            Console.Clear();
            Console.WriteLine($"Please enter the new menu item's number:\n");
            addItem.FoodNumber = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the name of the new ramen:\n");
            addItem.FoodName = Console.ReadLine();

            Console.WriteLine($"Please describe how the ramen tastes:\n");
            addItem.Description = Console.ReadLine();

            Console.WriteLine($"Please set the price to charge customers for the new ramen:\n");
            addItem.Price = Int32.Parse(Console.ReadLine());


            Console.WriteLine($"Please enter the three main ingredients of the new ramen:\n Enter ingredients as such, (ingredient,ingredient,ingredient):\n");
            string ingredientsList = Console.ReadLine();
            addItem.Ingredients = ingredientsList.Split(',');

            _menuItemsRepo.CreateMenuItem(addItem);
            Console.WriteLine($"{addItem.FoodName} has been added:");
            Console.WriteLine("Please press any key to continue:");
            Console.ReadKey();

        }


        public void DeleteMenuItem()
        {
            List<MenuItems> menuItems = _menuItemsRepo.ShowAllMenuItems();

            if (menuItems.Count == 0)
            {
                Console.WriteLine("Invalid input: Unable to remove entries:");
                Console.WriteLine("Please press any key to continue:");
                Console.ReadKey();
            }

            else
            {
                int count = 0;

                foreach (MenuItems item in menuItems)
                {
                    count++;
                    Console.WriteLine($"{count}) {item.FoodName}");
                }
                int targetID = int.Parse(Console.ReadLine());
                int actualID = targetID - 1;

                if (actualID >= 0 && actualID < menuItems.Count)
                {
                    MenuItems desiredItem = menuItems[actualID];
                    if (_menuItemsRepo.DeleteMenuItem(desiredItem))
                    {
                        Console.WriteLine($"{desiredItem.FoodName} has been removed:");
                        Console.WriteLine("Please press any key to continue:");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Error 404: Please enter a valid input:");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input:");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        public void RamenData()
        {
            string[] spicyRamenIngredients = { "Miso Paste", "Sambal Oelek", "Nori Seaweed" };
            MenuItems item1 = new MenuItems(01, "Spicy Ramen", "Cayde-6's personal favorite, with the perfect balance of savory\n and spicy. Giving your light level that extra kick it needs!", 450, spicyRamenIngredients);
            string[] shoyuRamenIngredients = { "Chashu Pork", "Ajitsuke Tamago", "Togarashi" };
            MenuItems item2 = new MenuItems(02, "Shoyu Ramen", "Tokyo meets the tower with this masterpiece of a ramen. Made\n with a legendary soy sauce-based broth that'll leave you wanting another bowl.", 350, shoyuRamenIngredients);
            string[] shioRamenIngredients = { "Chicken Broth", "Narutomaki", "Menma" };
            MenuItems item3 = new MenuItems(03, "Shio Ramen", "Winner, winner, chicken broth dinner. This ramen is literally\n ancient, but it's flavors will make you feel more alive than ever!", 300, shioRamenIngredients);
            string[] misoRamenIngredients = { "Miso Tare", "Sesame Seed Oil", "Ikayaki" };
            MenuItems item4 = new MenuItems(04, "Miso Ramen", "Eyes up guardian! This hearty ramen will give you the perfect\n boost to get you through those dark and damp Hive misions.", 250, misoRamenIngredients);
            string[] tonkotsuRamenIngredients = { "Boiled Tonkotsu", "Enoki Mushrooms", "Kakuni" };
            MenuItems item5 = new MenuItems(05, "Tonkotsu Ramen", "Don't let this ramen's cloudy broth deceive you, because\n it's going to leave your taste buds bursting with light!", 200, tonkotsuRamenIngredients);

            _menuItemsRepo.CreateMenuItem(item1);
            _menuItemsRepo.CreateMenuItem(item2);
            _menuItemsRepo.CreateMenuItem(item3);
            _menuItemsRepo.CreateMenuItem(item4);
            _menuItemsRepo.CreateMenuItem(item5);


        }

    }
}
