using System.Collections.Generic;

namespace winter_intex_2_5.Models
{
    public class SummaryTableDefaults
    {
        public IEnumerable<string> HairColors { get; set; }
        public Dictionary<string, string> RecordedHairColors { get; set; } = new Dictionary<string, string>()
        {
            { "B", "Brown/Dark Brown/Lt Brown" },
            { "K", "Black"},
            { "A", "Brown-Red" },
            { "R", "Red/Red-BL" },
            { "D", "Blond" },
            { "U", "Unknown" }
        };
        public IEnumerable<string> Structures { get; set; }
        public IEnumerable<string> DeathAges { get; set; }
        public Dictionary<string, string> RecordedDeathAges { get; set; } = new Dictionary<string, string>()
        {
            { "A", "Adult - years 15+"},
            { "C", "Child - years 3-15" },
            { "I", "Infant - years 1-3" },
            { "N", "Newborn - year 0-1" },
            { "U", "Unknown" }
        };
        public IEnumerable<string> HeadDirections { get; set; }
        public Dictionary<string, string> RecordedHeadDirections { get; set; } = new Dictionary<string, string>()
        {
            { "E", "Head East"},
            { "W", "Head West" },
            { "I", "Indeterminate" }
        };
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
