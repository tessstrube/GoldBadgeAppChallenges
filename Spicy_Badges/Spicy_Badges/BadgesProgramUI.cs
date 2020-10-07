using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Badges
{
    public class BadgesProgramUI
    {
        private readonly SpicyBadgesRepo _spicyBadgeRepo = new SpicyBadgesRepo();

        public void Run()
        {
            SpicyBadgeData();
            OpenMenu();
        }

        public void OpenMenu()
        {
            bool menuOperator = true;
            while (menuOperator)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Spicy Security - Please select a task from the menu: \n" +
                    "1. Add a badge:\n" +
                    "2. Edit a badge:\n" +
                    "3. Display all badges:\n" +
                    "4. Close the main menu:");
                var userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "1":
                        {
                            AddSpicyBadge();
                            break;
                        }
                    case "2":
                        {
                            EditSpicyBadge();
                            break;
                        }
                    case "3":
                        {
                            DisplaySpicyBadges();
                            break;
                        }
                    case "4":
                        {
                            menuOperator = false;
                            break;
                        }
                    default:
                        {
                            menuOperator = false;
                            break;
                        }
                }
            }

        }

        public void EditSpicyBadge()
        {
            Console.WriteLine("Please enter the badgeID for the badge you want to edit:");
            var userBadgeInput = int.Parse(Console.ReadLine());
            var onebadge = _spicyBadgeRepo.ShowOneSpicyBadge(userBadgeInput);
            Console.WriteLine("The Selected badge currently has access to the following doors:");
            foreach (string value in onebadge.Doors)
            {
                Console.WriteLine($"{value}");
            }
            var extraDoorMenu = true;
            while (extraDoorMenu)
            {
                Console.Clear();
                Console.WriteLine($"Badge: {onebadge} currently has access to the following doors:");
                foreach (string door in onebadge.Doors)
                {
                    Console.Write($"{door} - ");
                }
                Console.WriteLine("Please select a task from the menu:\n" +
                    "1) Add new door access:\n" +
                    "2) Remove door access:\n" +
                    "3) Clear all door access from badge:\n" +
                    "4) Finish editing badge:\n" +
                    "Please enter 1, 2, or 3 to select an option from the menu above:");
                var userReponse = Console.ReadLine();
                switch (userReponse)
                {
                    case "1":
                        {
                            Console.WriteLine("Please enter the door you want to add to this badge:");
                            var newDoor = Console.ReadLine();
                            onebadge.Doors.Add(newDoor);
                            Console.WriteLine($"Badge {onebadge.BadgeId} has been granted access to door {newDoor}:\n" +
                                $"Please press any key to continue:");
                            Console.ReadKey();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Please enter the door you want to remove from this badge:");
                            var removedDoor = Console.ReadLine();
                            _spicyBadgeRepo.RemoveDoorSpicyBadge(onebadge.BadgeId, removedDoor);
                            Console.WriteLine($"Door ({removedDoor}) has been removed from the badge #{onebadge.BadgeId}:\n" +
                                $"Please press any key to continue:");
                            Console.ReadKey();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Warning! - You are about to remove all door access from this badge:\n" +
                                "This action cannot be reversed. Regranting door access will have to be preformed manually:\n" +
                                "Please press y to continue - Or please press n to return:");
                            var userInput = Console.ReadLine().ToLower();
                            switch (userInput)
                            {
                                case "y":
                                    {
                                        _spicyBadgeRepo.DeleteDoorsSpicyBadge(onebadge.BadgeId);
                                        Console.WriteLine("All granted door access has been removed from this badge:\n" +
                                            "Please press any key to continue:");
                                        Console.ReadKey();
                                        break;
                                    }
                                case "n":
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Please enter y or n to choose an option from the menu:\n" +
                                            "Please press any key to return to the menu:");
                                        Console.ReadKey();
                                        break;
                                    }
                            }

                            break;
                        }
                    case "4":
                        {
                            extraDoorMenu = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Error 404 - Invalid response:\n" +
                                "Please enter 1, 2, or 3 to select an option from the menu:\n" +
                                "Please press any key to continue:");
                            Console.ReadKey();
                            break;
                        }
                }

            }
        }
        public void DisplaySpicyBadges()
        {
            var listOfBadges = _spicyBadgeRepo.DisplaySpicyBadges();
            foreach (KeyValuePair<int, List<string>> kvp in listOfBadges)
            {
                Console.WriteLine("________________________________");
                Console.WriteLine($"Badge: {kvp.Key}\n" +
                    $"Door Access List:");
                foreach (string value in kvp.Value)
                {
                    Console.WriteLine($"{value}");
                }
            }
            Console.WriteLine("Please press any key to return to the main menu:");
            Console.ReadKey();
        }
        public void AddSpicyBadge()
        {
            Console.WriteLine("Please enter the Spicy Badge ID:");
            var badgeID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the first door to grant this badge access to:");
            var doorList = new List<string>();
            doorList.Add(Console.ReadLine());
            bool addingDoors = true;
            while (addingDoors)
            {
                Console.WriteLine("Would you like to grant this badge access to another door?:\n" +
                    "Please enter y or n :");
                var userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "y":
                        {
                            Console.WriteLine("Please enter the desired door number:");
                            var doorNumber = (Console.ReadLine());
                            doorList.Add(doorNumber);
                            break;
                        }
                    case "n":
                        {
                            _spicyBadgeRepo.AddSpicyBadge(badgeID, doorList);
                            addingDoors = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter y or n :\n" +
                                "Or please press any key to return to the menu:");
                            Console.ReadKey();
                            break;
                        }
                }

            }
        }
        public void SpicyBadgeData()
        {
            _spicyBadgeRepo.AddSpicyBadge(3461, new List<string> { "S1", "S2", "S3" });
            _spicyBadgeRepo.AddSpicyBadge(9934, new List<string> { "S4", "S5", "S6" });
            _spicyBadgeRepo.AddSpicyBadge(3734, new List<string> { "S7", "S8", "S9" });
            _spicyBadgeRepo.AddSpicyBadge(8437, new List<string> { "S10", "S11", "S12" });
            _spicyBadgeRepo.AddSpicyBadge(3863, new List<string> { "S13", "S14", "S15" });
            _spicyBadgeRepo.AddSpicyBadge(73247, new List<string> { "S16", "S17", "S18" });
        }
    }
}