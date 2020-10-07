using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Ramen_At_Law
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    public class SpicyClaims
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan validWindow = DateOfClaim - DateOfIncident;
                if (validWindow.Days < 30)
                {
                    return true;
                }
                return false;
            }
        }
        public SpicyClaims(int claimID, ClaimType typeOfClaim, string description, DateTime dateOfIncident, DateTime dateOfClaim, decimal claimAmount)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            ClaimAmount = claimAmount;
        }
        public SpicyClaims() { }
    }
}