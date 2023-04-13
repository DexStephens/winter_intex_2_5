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
        public decimal? MinDepth { get; set; }
        public decimal? MaxDepth { get; set;}
        public decimal? MinStature { get; set; }
        public decimal? MaxStature { get;set; }
        public SummaryTableFilter() { }

        public SummaryTableFilter(IEnumerable<string>? hairColors, IEnumerable<string>? structures, IEnumerable<string>? deathAges, IEnumerable<string>? headDirections, IEnumerable<string>? textileFunctions, IEnumerable<string>? textileColors, IEnumerable<string> burialIDs, bool male, bool female, decimal? minDepth, decimal? maxDepth, decimal? minStature, decimal? maxStature)
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
