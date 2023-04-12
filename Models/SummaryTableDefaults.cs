using System.Collections.Generic;

namespace winter_intex_2_5.Models
{
    public class SummaryTableDefaults
    {
        public List<string> HairColors { get; set; }    
        public IEnumerable<string> Structures { get; set; }
        public List<string> DeathAges { get; set; }
        public List<string> HeadDirections { get; set; }
        public List<string> TextileFunctions { get; set; }
        public List<string> TextileColors { get; set; }
        public IEnumerable<string> BurialIDs { get; set; }

        public SummaryTableDefaults(List<string> hairColors, IEnumerable<string> structures, List<string> deathAges, List<string> headDirections, List<string> textileFunctions, List<string> textileColors, IEnumerable<string> burialIDs)
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
