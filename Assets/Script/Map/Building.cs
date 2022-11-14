using System.Collections.Generic;

namespace Assets.Script.Map
{
    public class Building
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Location> Locations { get; set; }
    }
}
