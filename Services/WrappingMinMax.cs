using System.IO;
using System.Security.Policy;
using winter_intex_2_5.Models;

namespace winter_intex_2_5.Services
{
    public class WrappingMinMax
    {
        public float SquareNorthSouthMax { get; set; }
        public float SquareNorthSouthMin { get; set; } = 130;
        public float SquareEastWestMax { get; set; }
        public float SquareEastWestMin { get; set; }
        public float BurialNumberMax { get; set; }
        public float BurialNumberMin { get; set; }
        public float DepthMax { get; set; }
        public float DepthMin { get; set; }
        public float LengthMax { get; set;  }
        public float LengthMin { get; set; }
        public float SouthToFeetMax { get; set; }
        public float SouthToFeetMin { get; set; }
        public float SouthToHeadMax { get; set; }
        public float SouthToHeadMin { get; set; }
        public float WestToFeetMax { get; set; }
        public float WestToFeetMin { get; set; }
        public float WestToHeadMax { get; set; }
        public float WestToHeadMin { get; set; }
        public float FemurLengthMax { get; set; }
        public float FemurLengthMin { get; set; }
        public WrappingData StandardizeWrapping(WrappingData wrappingData)
        {
            wrappingData.SquareNorthSouth = (wrappingData.SquareNorthSouth - 130) / 60;
            wrappingData.SquareEastWest = (wrappingData.SquareEastWest - 0) / 40;
            wrappingData.BurialNumber = (wrappingData.BurialNumber - 1) / 58;
            wrappingData.Depth = (wrappingData.Depth - 0.1F) / 2.78F;
            wrappingData.Length = (wrappingData.Length - 0.5F) / 1.4F;
            wrappingData.SouthToFeet = (wrappingData.SouthToFeet - (-0.26F)) / 5.06F;
            wrappingData.SouthToHead = wrappingData.SouthToHead / 5.1F;
            wrappingData.WestToFeet = (wrappingData.WestToFeet - (-0.85F)) / 6.02F;
            wrappingData.WestToHead = (wrappingData.WestToHead - (-0.7F)) / 5.24F;
            wrappingData.FemurLength = (wrappingData.FemurLength - 16.1F) / 33.3F;
            return wrappingData;
        }
    }
}
