using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spicy_Ramen;

namespace Spicy_Repo_Tests
{
    [TestClass]
    public class RamenRepoTests
    {
        private MenuItems _item;
        private MenuItemsRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            string[] spicyRamenIngredients = { "Miso Paste", "Sambal Oelek", "Nori Seaweed" };
            _item = new MenuItems(01, "Spicy Ramen", "Cayde-6's personal favorite, with the perfect balance of savory\n and spicy. Giving your light level that extra kick it needs!", 450, spicyRamenIngredients);
            _repo = new MenuItemsRepo();
            _repo.CreateMenuItem(_item);
        }

        [TestMethod]
        public void AddItem_ShouldGetTrue()
        {
            string[] spicyRamenIngredients = { "Miso Paste", "Sambal Oelek", "Nori Seaweed" };
            MenuItems food = new MenuItems(01, "Spicy Ramen", "Cayde-6's personal favorite, with the perfect balance of savory\n and spicy. Giving your light level that extra kick it needs!", 450, spicyRamenIngredients);
            MenuItemsRepo repository = new MenuItemsRepo();
            bool addResult = repository.CreateMenuItem(food);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void DeleteItem_ShouldGetTrue()
        {
            MenuItems item = _item;
            bool deleteResult = _repo.DeleteMenuItem(item);
            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void GetItems_ShouldReturnTrue()
        {
            List<MenuItems> menuItems = _repo.ShowAllMenuItems();
            bool listHasItems = menuItems.Contains(_item);
            Assert.IsTrue(listHasItems);
        }
    }
}