using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Ramen_At_Law
{
    public class SpicyClaimsRepo
    {
        private Queue<SpicyClaims> _queueOfSpicyClaims = new Queue<SpicyClaims>();

        public Queue<SpicyClaims> DisplayAllClaims()
        {
            return _queueOfSpicyClaims;
        }

        public void AddSpicyClaim(SpicyClaims claim)
        {
            _queueOfSpicyClaims.Enqueue(claim);
        }

        public SpicyClaims DisplayNextClaim()
        {
            return _queueOfSpicyClaims.Peek();
        }

        public void RemoveClaimFromQueue()
        {
            _queueOfSpicyClaims.Dequeue();
        }
    }
}