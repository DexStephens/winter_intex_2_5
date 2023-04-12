using System.Collections.Generic;

namespace winter_intex_2_5.Models
{
    public class SummaryTableFilter
    {
        public IEnumerable<string>? HairColors { get; set; }    
        public IEnumerable<string>? Structures { get; set; }
        public IEnumerable<string>? DeathAges { get; set; }
        public IEnumerable<string>? HeadDirections { get; set; }
        public IEnumerable<string>? TextileFunctions { get; set; }
        public IEnumerable<string> TextileColors { get; set; }
        public IEnumerable<string> BurialIDs { get; set; }
        public bool Male { get; set; }
        public bool Female { get; set; }
        public int? MinDepth { get; set; }
        public int? MaxDepth { get; set;}
        public int? MinStature { get; set; }
        public int? MaxStature { get;set; }
        public SummaryTableFilter() { }

        public SummaryTableFilter(IEnumerable<string>? hairColors, IEnumerable<string>? structures, IEnumerable<string>? deathAges, IEnumerable<string>? headDirections, IEnumerable<string>? textileFunctions, IEnumerable<string>? textileColors, IEnumerable<string> burialIDs, bool male, bool female, int? minDepth, int? maxDepth, int? minStature, int? maxStature)
        {
            HairColors = hairColors;
            Structures = structures;
            DeathAges = deathAges;
            HeadDirections = headDirections;
            TextileFunctions = textileFunctions;
            TextileColors = textileColors;
            BurialIDs = burialIDs;
            Male = male;
            Female = female;
            MinDepth = minDepth;
            MaxDepth = maxDepth;
            MinStature = minStature;
            MaxStature = maxStature;
        }
    }
}
