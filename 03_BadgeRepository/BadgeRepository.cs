﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeRepository
{
    public class BadgeRepository
    {
        Dictionary<int, List<Doors>> _accessDirectory = new Dictionary<int, List<Doors>>();

        public bool AddNewBadge(int newBadgeNumber, List<Doors> doorAccessList)
        {
            int startingCount = _accessDirectory.Count();

            Badge newBadge = new Badge();
            newBadge.BadgeNumber = newBadgeNumber;
            newBadge.DoorAccess = doorAccessList;
            _accessDirectory.Add(newBadgeNumber, doorAccessList);

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

        public List<Doors> ViewAccessByID(int badgeNumber)
        {
            if (_accessDirectory.ContainsKey(badgeNumber))
            {
                return _accessDirectory[badgeNumber];
            }
            return null;
        }

        public bool AddDoorAccess(int badgeNumber, List<Doors> newDoorList)
        {
            List<Doors> checkBadgeExists = ViewAccessByID(badgeNumber);
            if (checkBadgeExists != null)
            {
                List<Doors> oldDoorAccess = _accessDirectory[badgeNumber];
                IEnumerable<Doors> newDoorAccess = oldDoorAccess.Union(newDoorList);
                _accessDirectory[badgeNumber] = (List<Doors>)newDoorAccess;
                return true;
            }
            return false;
        }

    }
}
