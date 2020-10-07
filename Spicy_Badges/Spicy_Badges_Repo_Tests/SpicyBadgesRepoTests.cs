using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spicy_Badges;

namespace Spicy_Badges_Repo_Tests
{
    [TestClass]
    public class SpicyBadgesRepoTests
    {
        private SpicyBadgesRepo _spicyBadgesRepo;
        [TestInitialize]
        public void Arrange()
        {
            _spicyBadgesRepo = new SpicyBadgesRepo();
        }
        [TestMethod]
        public void AddSpicyBadgeTest()
        {
            var key = 3461;
            var value = new List<string> { "S1", "S2", "S3" };

            _spicyBadgesRepo.AddSpicyBadge(key, value);
            int expected = 1;
            int actual = _spicyBadgesRepo.DisplaySpicyBadges().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveDoorSpicyBadgeTest()
        {
            var key = 3461;
            var value = new List<string> { "S1", "S2", "S3" };

            _spicyBadgesRepo.AddSpicyBadge(key, value);
            _spicyBadgesRepo.RemoveDoorSpicyBadge(3461, "S2");
            var badgeList = _spicyBadgesRepo.DisplaySpicyBadges();
            int expected = 2;
            int actual = value.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteDoorsSpicyBadgeTest()
        {
            var key = 3461;
            var value = new List<string> { "S1", "S2", "S3" };

            _spicyBadgesRepo.AddSpicyBadge(key, value);
            _spicyBadgesRepo.DeleteDoorsSpicyBadge(key);
            var expected = 0;
            var actual = value.Count;
            Assert.AreEqual(expected, actual);

        }
    }
}
