using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Linq;
using System.Security.Policy;

namespace winter_intex_2_5.Models
{
    public class SexData
    {
        public float AdultSubadult_C { get; set; }
        public float AgeatDeath_C { get; set; }
        public float AgeatDeath_N { get; set; }
        public float Area_NW {get; set; } 
        public float Area_SE { get; set; } 
        public float Area_SW { get; set; } 
        public float BurialNumber { get; set; }
        public float Depth { get; set; }   
        public float EastWest_W { get; set; }
        public float Length { get; set; }
        public float Predictions { get; set; }
        public float PreservationBones { get; set; }
        public float PreservationBonesodyOnly { get; set; }
        public float PreservationFair { get; set; }
        public float PreservationHeadless { get; set; }
        public float Skeleton { get; set; }
        public float PreservationPoor { get; set; }
        public float PreservationScatteredBonesWithSkull { get; set; }
        public float PreservationSkeletalized { get; set; } 
        public float PreservationSkeletalizedkullOnly { get; set; }  
        public float PreservationWrapped { get; set; }
        public float SouthToFeet { get; set; } 
        public float SouthToHead { get; set; } 
        public float SquareEastWest { get; set; }  
        public float SquareNorthSouth { get; set; } 
        public float WestToFeet { get; set; }  
        public float WestToHead { get; set; } 
        public float Wrapping_H { get; set; }  
        public float Wrapping_W { get; set; }

        public Tensor<T> AsTensor<T>() where T : struct
        {
            object[] data = new object[]
            {
            MedianIncome, MedianHouseAge, AverageNumberOfRooms, AverageNumberOfBedrooms,
            Population, AverageOccupancy, City, State
            };
            int[] dimensions = new int[] { 1, 8 };
            var convertedData = data.Select(d => Convert.ChangeType(d, typeof(T))).ToArray();
            return new DenseTensor<T>(convertedData as T[], dimensions);
        }
    }
}
