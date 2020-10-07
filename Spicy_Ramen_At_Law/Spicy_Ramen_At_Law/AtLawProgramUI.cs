using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Ramen_At_Law
{
    public class AtLawProgramUI
    {
        private readonly SpicyClaimsRepo _spicyClaimsRepo = new SpicyClaimsRepo();
        public void Run()
        {
            SpicyQueue();
            OpenMainMenu();
        }
        public void OpenMainMenu()
        {
            bool openMenu = true;
            while (openMenu)
            {
                Console.Clear();
                Console.WriteLine("Please make a selection from the following menu: \n" +
                    "1. View all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Close menu");
                var spicyOptions = Console.ReadLine();
                switch (spicyOptions)
                {
                    case "1":
                        {
                            DisplayAllClaims();
                            break;
                        }
                    case "2":
                        {
                            AssessNextClaim();
                            break;
                        }
                    case "3":
                        {
                            AddSpicyClaim();
                            break;
                        }
                    case "4":
                        {
                            openMenu = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please choose a valid option: \n" +
                                "Please press any key to return to the main menu:");
                            Console.ReadKey();
                            break;
                        }
                }
            }

        }

        public void DisplayAllClaims()
        {
            var spicyHeaders = String.Format("|{0,-8} {1,-10} {2,-38} {3,-15} {4,-15} {5,-11} {6,-10}|", "ClaimID", "Type", "Description", "Amount", "DateOfIncident", "DateOfClaim", "IsValid");
            Console.WriteLine(spicyHeaders);
            var claimList = _spicyClaimsRepo.DisplayAllClaims().ToList();
            foreach (SpicyClaims claim in claimList)
            {
                var spicyContent = String.Format("|{0,-8} {1,-10} {2,-38} {3,-15} {4,-15} {5,-11} {6,-10}|", claim.ClaimID, claim.TypeOfClaim, claim.Description, claim.ClaimAmount, claim.DateOfIncident.ToString("mm/dd/yyyy"), claim.DateOfClaim.ToString("mm/dd/yyyy"), claim.IsValid);
                Console.WriteLine(spicyContent);
            }
            Console.WriteLine("Press any key to return to the main menu:");
            Console.ReadKey();
        }
        public void AssessNextClaim()
        {
            var nextClaim = _spicyClaimsRepo.DisplayNextClaim();
            Console.WriteLine($"The following details are necessary to file the next claim:\n" +
                $"ClaimID: {nextClaim.ClaimID} \n" +
                $"Type: {nextClaim.TypeOfClaim} \n" +
                $"Description: {nextClaim.Description} \n" +
                $"Amount: ${nextClaim.ClaimAmount} \n" +
                $"Date Of Accident: {nextClaim.DateOfIncident} \n" +
                $"Date Of Claim: {nextClaim.DateOfClaim} \n" +
                $"Valid claim?: {nextClaim.IsValid} \n" +
                $"Do you want to deal with this claim now (y/n)?");
            var userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "y":
                    {
                        _spicyClaimsRepo.RemoveClaimFromQueue();
                        break;
                    }
                case "n":
                    {

                        break;
                    }
                default:
                    {
                        Console.WriteLine("Please enter y or n :\n" +
                            "Please press any key to continue:");
                        Console.ReadKey();
                        break;
                    }
            }
        }
        public void AddSpicyClaim()
        {
            var newClaim = new SpicyClaims();
            Console.WriteLine("Spicy Ramen Claims Division: \n" +
                "To begin filing a claim please fill out the following prompts:\n" +
                "Please enter the Claim ID:");
            newClaim.ClaimID = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a description for the claim:");
            newClaim.Description = Console.ReadLine();
            Console.WriteLine("Please select the type of claim you'd like to file from the following options:\n" +
                "1) Car \n" +
                "2) Home \n" +
                "3) Theft \n");
            var claimType = Int32.Parse(Console.ReadLine());
            newClaim.TypeOfClaim = (ClaimType)claimType;
            Console.WriteLine("Please enter the claim amount:");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the date in which the accident took place:\n" + 
                "Please enter the claim date in the following format - (year,month,day):");
            var dateOfIncident = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(dateOfIncident);
            Console.WriteLine("Please enter the date that the claim is being filed: \n" +
                "Please enter the claim date in the following format - (year,month,day):");
            var dateOfClaim = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(dateOfClaim);
            _spicyClaimsRepo.AddSpicyClaim(newClaim);
            Console.WriteLine("Please ensure that all of the information entered above is correct before continuing:\n" +
                "Your claim information will be filed and added to the queue:\n" +
                "Please press any key to continue:");
            Console.ReadKey();
        }
        public void SpicyQueue()
        {
            var claimEins = new SpicyClaims(77429, ClaimType.Home, "Ramen too spicy, caused house fire.", new DateTime(2006, 06, 06), new DateTime(2006, 06, 27), 300000.333m);
            var claimZwei = new SpicyClaims(666353, ClaimType.Theft, "No noodles, possible noodle theif.", new DateTime(2020, 01, 01), new DateTime(2020, 01, 21), 15);
            var claimDrei = new SpicyClaims(84343, ClaimType.Car, "Noodle theif stole my car!", new DateTime(2020, 02, 7), new DateTime(2020, 02, 14), 50000);
            var claimVier = new SpicyClaims(43278, ClaimType.Theft, "Ramen so delicious, it stole my heart.", new DateTime(2016, 06, 06), new DateTime(2016, 06, 09), 9999999.999m);
            _spicyClaimsRepo.AddSpicyClaim(claimEins);
            _spicyClaimsRepo.AddSpicyClaim(claimZwei);
            _spicyClaimsRepo.AddSpicyClaim(claimDrei);
            _spicyClaimsRepo.AddSpicyClaim(claimVier);
        }
    }
}
