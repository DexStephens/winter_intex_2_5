using Newtonsoft.Json.Linq;
using winter_intex_2_5.Models;

namespace winter_intex_2_5.Services
{
    public class SexMinMax
    {
        public float SquareNorthSouthMax { get; set; }
        public float SquareNorthSouthMin { get; set; }
        public float SquareEastWestMax { get; set; }
        public float SquareEastWestMin { get; set; }
        public float BurialNumberMax { get; set; }
        public float BurialNumberMin { get; set; }
        public float DepthMax { get; set; }
        public float DepthMin { get; set; }
        public float LengthMax { get; set; }
        public float LengthMin { get; set; }
        public float SouthToFeetMax { get; set; }
        public float SouthToFeetMin { get; set; }
        public float SouthToHeadMax { get; set; }
        public float SouthToHeadMin { get; set; }
        public float WestToFeetMax { get; set; }
        public float WestToFeetMin { get; set; }
        public float WestToHeadMax { get; set; }
        public float WestToHeadMin { get; set; }
        public SexData StandardizeSex(SexData sexData)
        {
            sexData.SquareNorthSouth = (sexData.SquareNorthSouth - 130) / 60;
            sexData.SquareEastWest = (sexData.SquareEastWest - 0) / 40;
            sexData.BurialNumber = (sexData.BurialNumber - 1) / 58;
            sexData.Depth = (sexData.Depth - 0.1F) / 2.78F;
            sexData.Length = (sexData.Length - 0.5F) / 1.4F;
            sexData.SouthToFeet = (sexData.SouthToFeet - (-0.26F)) / 5.06F;
            sexData.SouthToHead = sexData.SouthToHead / 5.1F;
            sexData.WestToFeet = (sexData.WestToFeet - (-0.85F)) / 6.02F;
            sexData.WestToHead = (sexData.WestToHead - (-0.7F)) / 5.24F;
            return sexData;
        }
    }
}
