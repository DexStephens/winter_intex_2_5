using System.Collections.Generic;

namespace winter_intex_2_5.Models
{
    public class SummaryTableDefaults
    {
        public IEnumerable<string> HairColors { get; set; }    
        public IEnumerable<string> Structures { get; set; }
        public IEnumerable<string> DeathAges { get; set; }
        public IEnumerable<string> HeadDirections { get; set; }
        public IEnumerable<string> TextileFunctions { get; set; }
        public IEnumerable<string> TextileColors { get; set; }
        public IEnumerable<string> BurialIDs { get; set; }

        public SummaryTableDefaults(IEnumerable<string> hairColors, IEnumerable<string> structures, IEnumerable<string> deathAges, IEnumerable<string> headDirections, IEnumerable<string> textileFunctions, IEnumerable<string> textileColors, IEnumerable<string> burialIDs)
        {
            HairColors = hairColors;
            Structures = structures;
            DeathAges = deathAges;
            HeadDirections = headDirections;
            TextileFunctions = textileFunctions;
            TextileColors = textileColors;
            BurialIDs = burialIDs;
        }
    }
}
