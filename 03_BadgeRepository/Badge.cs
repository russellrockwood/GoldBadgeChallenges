using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeRepository
{
    public enum Doors { A1, A2, A3, A4, B1, B2, B3, B4, ESCAPETUNNEL}
    public class Badge
    {
        public int BadgeNumber { get; set; }
        public List<Doors> DoorAccess { get; set; }
        public Badge() { }

        public Badge(int badgeNumber, List<Doors> doorAccess)
        {
            BadgeNumber = badgeNumber;
            DoorAccess = doorAccess;
        }
    }
}
