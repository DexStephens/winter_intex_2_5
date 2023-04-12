using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace winter_intex_2_5.Models
{
    public class WrappingData
    {
        public float SouthToHead { get; set; }
        public float Length { get; set; }
        public float SouthToFeet { get; set; }
        public float HeadDirection_W { get; set; }
        public float SquareEastWest { get; set; }
        public float WestToHead { get; set; }
        public float WestToFeet { get; set; }
        public float Depth { get; set; }
        public float FemurHeadDiameter { get; set; }
        public float FemurLength { get; set; }
        public float ClusterBool { get; set; }
        public float SquareNorthSouth { get; set; }
        public float BurialNumber { get; set; }
        public float ToothEruption_Bool { get; set; }
        public float EastWest_W { get; set; }
        public float Area_NW { get; set; }
        public float Area_SE { get; set; }
        public float Area_SW { get; set; }
        public float HeadDirection_E { get; set; }
        public float AdultSubadult_A { get; set; }
        public float AdultSubadult_C { get; set; }
        public float SupraorbitalRidges_Unknown { get; set; }
        public float SupraorbitalRidges_Heavy { get; set; }
        public float SupraorbitalRidges_Light { get; set; }
        public float SupraorbitalRidges_Medium { get; set; }
        public float OrbitEdge_Unknown { get; set; }
        public float OrbitEdge_Blunt { get; set; }
        public float OrbitEdge_Medium { get; set; }
        public float OrbitEdge_Sharp { get; set; }
        public float Gonion_Flat { get; set; }
        public float Gonion_Medium { get; set; }
        public float Gonion_Pointed { get; set; }
        public float ZygomaticCrest_Longer { get; set; }
        public float ZygomaticCrest_Medium { get; set; }
        public float ZygomaticCrest_Shorter { get; set; }
        public float ToothAttrition_I { get; set; }
        public float ToothAttrition_II { get; set; }
        public float ToothAttrition_III { get; set; }
        public float ToothAttrition_IV { get; set; }
        public float ToothAttrition_NoTeeth { get; set; }
        public float ToothAttrition_V { get; set; }
        public float ToothEruptionAgeEstimate_17_25Years { get; set; }
        public float ToothEruptionAgeEstimate_25_35Years { get; set; }
        public float ToothEruptionAgeEstimate_35_Years { get; set; }
        public float ToothEruptionAgeEstimate_4_8Years { get; set; }
        public float ToothEruptionAgeEstimate_8_16Years { get; set; }
        public float ToothEruptionAgeEstimate_None { get; set; }
        public float ToothEruptionAgeEstimate_Other { get; set; }
        public float SciaticNotch_Medium { get; set; }
        public float SciaticNotch_Narrow { get; set; }
        public float SciaticNotch_Wide { get; set; }
        public float HairColorGroup_Black { get; set; }
        public float HairColorGroup_Blond { get; set; }
        public float HairColorGroup_Brown { get; set; }
        public float HairColorGroup_None { get; set; }
        public float HairColorGroup_Red { get; set; }
        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                AdultSubadult_A,AdultSubadult_C,Area_NW, Area_SE, Area_SW,BurialNumber, ClusterBool, Depth, EastWest_W, FemurHeadDiameter, FemurLength,
                Gonion_Flat, Gonion_Medium, Gonion_Pointed, HairColorGroup_Black, HairColorGroup_Blond, HairColorGroup_Brown, HairColorGroup_None, HairColorGroup_Red,
                HeadDirection_E, HeadDirection_W, Length, OrbitEdge_Blunt, OrbitEdge_Medium, OrbitEdge_Sharp, OrbitEdge_Unknown, SciaticNotch_Medium, SciaticNotch_Narrow, SciaticNotch_Wide,
                SouthToFeet, SouthToHead, SquareEastWest, SquareNorthSouth, SupraorbitalRidges_Heavy, SupraorbitalRidges_Light, SupraorbitalRidges_Medium, SupraorbitalRidges_Unknown,
                ToothAttrition_I, ToothAttrition_II, ToothAttrition_III,ToothAttrition_IV, ToothAttrition_NoTeeth, ToothAttrition_V, ToothEruption_Bool,
                ToothEruptionAgeEstimate_17_25Years, ToothEruptionAgeEstimate_25_35Years, ToothEruptionAgeEstimate_35_Years, ToothEruptionAgeEstimate_4_8Years, ToothEruptionAgeEstimate_8_16Years,
                ToothEruptionAgeEstimate_None, ToothEruptionAgeEstimate_Other, WestToFeet, WestToHead, ZygomaticCrest_Longer, ZygomaticCrest_Medium, ZygomaticCrest_Shorter
            };
            int[] dimensions = new int[] { 1, 56 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
