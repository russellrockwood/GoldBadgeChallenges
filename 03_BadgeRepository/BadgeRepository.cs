using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeRepository
{
    public class BadgeRepository
    {
        Dictionary<int, List<Doors>> _accessDirectory = new Dictionary<int, List<Doors>>();
        public bool AddNewBadge(Badge newBadge)
        {
            int startingCount = _accessDirectory.Count();
            _accessDirectory.Add(newBadge.BadgeNumber, newBadge.DoorAccess);

            if (startingCount < _accessDirectory.Count())
            {
                return true;
            }
            return false;
        }
        public Dictionary<int, List<Doors>> GetFullDirectory()
        {
            return _accessDirectory;
        }
        public List<Doors> GetAccessByID(int badgeNumber)
        {
            if (_accessDirectory.ContainsKey(badgeNumber))
            {
                return _accessDirectory[badgeNumber];
            }
            return null;
        }
        public bool AddDoorAccess(int badgeNumber, Doors newDoor)
        {
            List<Doors> checkBadgeExists = GetAccessByID(badgeNumber);
            if (checkBadgeExists != null)
            {
                _accessDirectory[badgeNumber].Add(newDoor);  
                return true;
            }
            return false;
        }
        public bool RemoveDoorAccess(int badgeNumber, Doors doorToRemove)
        {
            List<Doors> checkBadgeExists = GetAccessByID(badgeNumber);

            if (checkBadgeExists != null)
            {
                _accessDirectory[badgeNumber].Remove(doorToRemove);
                return true;
            }
            return false;
        }
        public bool DeleteBadge(int badgeNumber)
        {
            List<Doors> checkBadgeExists = GetAccessByID(badgeNumber);

            if (checkBadgeExists != null)
            {
                _accessDirectory.Remove(badgeNumber);
                return true;
            }
            return false;
        }
    }
}
