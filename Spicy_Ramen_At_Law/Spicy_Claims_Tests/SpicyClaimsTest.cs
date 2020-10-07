using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spicy_Ramen_At_Law;
using System.Collections.Generic;

namespace Spicy_Claims_Tests
{
    [TestClass]
    public class SpicyClaimsTest
    {
        private SpicyClaimsRepo _SpicyClaimRepo;
        private SpicyClaims _spicyClaimItem;
        [TestInitialize]
        public void Arrange()
        {
            _SpicyClaimRepo = new SpicyClaimsRepo();
            _spicyClaimItem = new SpicyClaims(77429, ClaimType.Home, "Spicy ramen was too spicy, caused massive house fire.", new DateTime(2006, 06, 06), new DateTime(2006, 06, 27), 300000.333m);
        }
        [TestMethod]
        public void TestAddMethod()
        {
            _SpicyClaimRepo.AddSpicyClaim(_spicyClaimItem);
            var expected = 1;
            var actual = _SpicyClaimRepo.DisplayAllClaims().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDequeueMethod()
        {
            var testEins = new SpicyClaims(77429, ClaimType.Home, "Spicy ramen was too spicy, caused massive house fire.", new DateTime(2006, 06, 06), new DateTime(2006, 06, 27), 300000.333m);
            var testZwei = new SpicyClaims(666353, ClaimType.Theft, "All broth no noodles, possible noodle theif.", new DateTime(2020, 01, 01), new DateTime(2020, 01, 21), 15);
            var testDrei = new SpicyClaims(84343, ClaimType.Car, "Noodle theif stole my car!", new DateTime(2020, 02, 13), new DateTime(2020, 02, 14), 50000);
            var testVier = new SpicyClaims(43278, ClaimType.Theft, "Spicy ramen so delicious, it stole my heart.", new DateTime(2016, 06, 06), new DateTime(2016, 06, 09), 9999999.999m);
            _SpicyClaimRepo.AddSpicyClaim(_spicyClaimItem);
            _SpicyClaimRepo.AddSpicyClaim(testEins);
            _SpicyClaimRepo.AddSpicyClaim(testZwei);
            _SpicyClaimRepo.AddSpicyClaim(testDrei);
            _SpicyClaimRepo.AddSpicyClaim(testVier);
            _SpicyClaimRepo.RemoveClaimFromQueue();
            var expected = 3;
            var actual = _SpicyClaimRepo.DisplayAllClaims().Count;
            Assert.AreEqual(expected, actual);
        }
    }
}