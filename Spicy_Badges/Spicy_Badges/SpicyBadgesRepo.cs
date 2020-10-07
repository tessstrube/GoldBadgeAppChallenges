using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Badges
{
    public class SpicyBadgesRepo
    {
        private readonly Dictionary<int, List<string>> _spicyBadgeList = new Dictionary<int, List<string>>();
        public void AddSpicyBadge(int key, List<string> value)
        {
            try
            {
                _spicyBadgeList.Add(key, value);
            }
            catch
            {
                Console.WriteLine("Badge already currently exists within the system - Please enter a badge # that doesn't already exist:");
            }
        }
        public Dictionary<int, List<string>> DisplaySpicyBadges()
        {
            return _spicyBadgeList;
        }
        public SpicyBadges ShowOneSpicyBadge(int badgeId)
        {
            SpicyBadges badge = new SpicyBadges(badgeId, _spicyBadgeList[badgeId]);
            return badge;

        }
        public void DeleteDoorsSpicyBadge(int badgeId)
        {
            _spicyBadgeList[badgeId].Clear();
        }
        public void RemoveDoorSpicyBadge(int badgeId, string roomNumber)
        {
            _spicyBadgeList[badgeId].Remove(roomNumber);
        }
    }
}
