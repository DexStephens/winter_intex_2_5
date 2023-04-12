using System.Collections.Generic;

namespace winter_intex_2_5.Models
{
    public class SummaryTableFilter
    {
        public List<string>? HairColors { get; set; }    
        public List<string>? Structures { get; set; }
        public List<string>? DeathAges { get; set; }
        public List<string>? HeadDirections { get; set; }
        public List<string>? TextileFunctions { get; set; }
        public List<string> TextileColors { get; set; }
        public IEnumerable<string> BurialIDs { get; set; }
        public bool Male { get; set; }
        public bool Female { get; set; }
        public int? MinDepth { get; set; }
        public int? MaxDepth { get; set;}
        public int? MinStature { get; set; }
        public int? MaxStature { get;set; }
        public SummaryTableFilter() { }

        public SummaryTableFilter(List<string>? hairColors, List<string>? structures, List<string>? deathAges, List<string>? headDirections, List<string>? textileFunctions, List<string>? textileColors, IEnumerable<string> burialIDs, bool male, bool female, int? minDepth, int? maxDepth, int? minStature, int? maxStature)
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
