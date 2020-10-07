using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Badges
{
    public class SpicyBadges
    {
        public int BadgeId { get; set; }
        public ICollection<string> Doors { get; set; }
        public SpicyBadges(int badgeId, ICollection<string> doors)
        {
            BadgeId = badgeId;
            Doors = doors;
        }
        public SpicyBadges() { }
    }
}
