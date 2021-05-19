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
    }
}
