using System.Collections.Generic;

namespace winter_intex_2_5.Models
{
    public class SummaryTableRowItem
    {
        public Burialmain Burialmain { get; set; }
        public List<Color> Colors { get; set; }
        public List<Textilefunction> Textilefunctions { get; set; }
        public List<Bodyanalysischart> Bodyanalysischarts { get; set; }
        public List<Structure> Structures { get; set; }

        public SummaryTableRowItem(Burialmain burialmain, List<Color> colors, List<Textilefunction> textilefunctions, List<Bodyanalysischart> bodyanalysischarts, List<Structure> structures)
        {
            Burialmain = burialmain;
            Colors = colors;
            Textilefunctions = textilefunctions;
            Bodyanalysischarts = bodyanalysischarts;
            Structures = structures;
        }
    }
}
