using winter_intex_2_5.Models;

namespace winter_intex_2_5.Services
{
    public class PredictionService
    {
        public SexData PopulateSexData(SexData sexData)
        {
            switch (sexData.WrappingDropdown)
            {
                case "H":
                    sexData.Wrapping_H = 1;
                    sexData.Wrapping_W = 0;
                    break;
                case "W":
                    sexData.Wrapping_H = 0;
                    sexData.Wrapping_W = 1;
                    break;
                default:
                    sexData.Wrapping_H = 0;
                    sexData.Wrapping_W = 0;
                    break;
            }
            switch (sexData.PreservationDropdown)
            {
                case "poor":
                    sexData.PreservationBones = 0;
                    sexData.PreservationBonesodyOnly = 0;
                    sexData.PreservationFair= 0;
                    sexData.PreservationHeadlessSkeleton = 0;
                    sexData.PreservationPoor = 1;
                    sexData.PreservationScatteredBonesWithSkull = 0;
                    sexData.PreservationSkeletalized = 0;
                    sexData.PreservationSkeletalizedkullOnly= 0;
                    sexData.PreservationWrapped = 0;
                    break;
                case "wrapped":
                    sexData.PreservationBones = 0;
                    sexData.PreservationBonesodyOnly = 0;
                    sexData.PreservationFair = 0;
                    sexData.PreservationHeadlessSkeleton = 0;
                    sexData.PreservationPoor = 0;
                    sexData.PreservationScatteredBonesWithSkull = 0;
                    sexData.PreservationSkeletalized = 0;
                    sexData.PreservationSkeletalizedkullOnly = 0;
                    sexData.PreservationWrapped = 1;
                    break;
                case "bones":
                    sexData.PreservationBones = 1;
                    sexData.PreservationBonesodyOnly = 0;
                    sexData.PreservationFair = 0;
                    sexData.PreservationHeadlessSkeleton = 0;
                    sexData.PreservationPoor = 0;
                    sexData.PreservationScatteredBonesWithSkull = 0;
                    sexData.PreservationSkeletalized = 0;
                    sexData.PreservationSkeletalizedkullOnly = 0;
                    sexData.PreservationWrapped = 0;
                    break;
                case "bonesbody":
                    sexData.PreservationBones = 0;
                    sexData.PreservationBonesodyOnly = 1;
                    sexData.PreservationFair = 0;
                    sexData.PreservationHeadlessSkeleton = 0;
                    sexData.PreservationPoor = 0;
                    sexData.PreservationScatteredBonesWithSkull = 0;
                    sexData.PreservationSkeletalized = 0;
                    sexData.PreservationSkeletalizedkullOnly = 0;
                    sexData.PreservationWrapped = 0;
                    break;
                case "fair":
                    sexData.PreservationBones = 0;
                    sexData.PreservationBonesodyOnly = 0;
                    sexData.PreservationFair = 1;
                    sexData.PreservationHeadlessSkeleton = 0;
                    sexData.PreservationPoor = 0;
                    sexData.PreservationScatteredBonesWithSkull = 0;
                    sexData.PreservationSkeletalized = 0;
                    sexData.PreservationSkeletalizedkullOnly = 0;
                    sexData.PreservationWrapped = 0;
                    break;
                case "scatteredbones":
                    sexData.PreservationBones = 0;
                    sexData.PreservationBonesodyOnly = 0;
                    sexData.PreservationFair = 0;
                    sexData.PreservationHeadlessSkeleton = 0;
                    sexData.PreservationPoor = 0;
                    sexData.PreservationScatteredBonesWithSkull = 1;
                    sexData.PreservationSkeletalized = 0;
                    sexData.PreservationSkeletalizedkullOnly = 0;
                    sexData.PreservationWrapped = 0;
                    break;
                case "skeletalized":
                    sexData.PreservationBones = 0;
                    sexData.PreservationBonesodyOnly = 0;
                    sexData.PreservationFair = 0;
                    sexData.PreservationHeadlessSkeleton = 0;
                    sexData.PreservationPoor = 0;
                    sexData.PreservationScatteredBonesWithSkull = 0;
                    sexData.PreservationSkeletalized = 1;
                    sexData.PreservationSkeletalizedkullOnly = 0;
                    sexData.PreservationWrapped = 0;
                    break;
                case "skullonly":
                    sexData.PreservationBones = 0;
                    sexData.PreservationBonesodyOnly = 0;
                    sexData.PreservationFair = 0;
                    sexData.PreservationHeadlessSkeleton = 0;
                    sexData.PreservationPoor = 0;
                    sexData.PreservationScatteredBonesWithSkull = 0;
                    sexData.PreservationSkeletalized = 0;
                    sexData.PreservationSkeletalizedkullOnly = 1;
                    sexData.PreservationWrapped = 0;
                    break;
                case "":
                    sexData.PreservationBones = 0;
                    sexData.PreservationBonesodyOnly = 0;
                    sexData.PreservationFair = 0;
                    sexData.PreservationHeadlessSkeleton = 0;
                    sexData.PreservationPoor = 0;
                    sexData.PreservationScatteredBonesWithSkull = 0;
                    sexData.PreservationSkeletalized = 0;
                    sexData.PreservationSkeletalizedkullOnly = 0;
                    sexData.PreservationWrapped = 0;
                    break;
                default :
                    sexData.PreservationBones = 0;
                    sexData.PreservationBonesodyOnly = 0;
                    sexData.PreservationFair = 0;
                    sexData.PreservationHeadlessSkeleton = 0;
                    sexData.PreservationPoor = 0;
                    sexData.PreservationScatteredBonesWithSkull = 0;
                    sexData.PreservationSkeletalized = 0;
                    sexData.PreservationSkeletalizedkullOnly = 0;
                    sexData.PreservationWrapped = 0;
                    break;
            }

            switch (sexData.EastWestDropdown)
            {
                case "E":
                    sexData.EastWest_W = 0;
                    break;
                default:
                    sexData.EastWest_W = 1;
                    break;
            }
            switch (sexData.AreaDropdown)
            {
                case "SE":
                    sexData.Area_NW = 0;
                    sexData.Area_SE = 1;
                    sexData.Area_SW = 0;
                    break;
                case "SW":
                    sexData.Area_NW = 0;
                    sexData.Area_SE = 0;
                    sexData.Area_SW = 1;
                    break;
                case "NW":
                    sexData.Area_NW = 1;
                    sexData.Area_SE = 0;
                    sexData.Area_SW = 0;
                    break;
                default:
                    sexData.Area_NW = 0;
                    sexData.Area_SE = 0;
                    sexData.Area_SW = 0;
                    break;
            }
            switch (sexData.SubAdultDropdown)
            {
                case "C":
                    sexData.AdultSubadult_C = 1;
                    break;
                default:
                    sexData.AdultSubadult_C = 0;
                    break;
            }
            return sexData;
        }
        public WrappingData PopulateWrappingData(WrappingData wrappingData)
        {
            switch (wrappingData.SubAdultDropdown)
            {
                case "C":
                    wrappingData.AdultSubadult_C = 1;
                    break;
                default:
                    wrappingData.AdultSubadult_C = 0;
                    break;
            }
            switch (wrappingData.EastWestDropdown)
            {
                case "W":
                    wrappingData.EastWest_W = 1;
                    break;
                default:
                    wrappingData.EastWest_W = 0;
                    break;
            }
            switch (wrappingData.HairColorDropdown)
            {
                case "none":
                    wrappingData.HairColorGroup_None = 1;
                    wrappingData.HairColorGroup_Black = 0;
                    wrappingData.HairColorGroup_Blond = 0;
                    wrappingData.HairColorGroup_Brown = 0;
                    wrappingData.HairColorGroup_Red = 0;
                    break;
                case "black":
                    wrappingData.HairColorGroup_None = 0;
                    wrappingData.HairColorGroup_Black = 1;
                    wrappingData.HairColorGroup_Blond = 0;
                    wrappingData.HairColorGroup_Brown = 0;
                    wrappingData.HairColorGroup_Red = 0;
                    break;
                case "blond":
                    wrappingData.HairColorGroup_None = 0;
                    wrappingData.HairColorGroup_Black = 0;
                    wrappingData.HairColorGroup_Blond = 1;
                    wrappingData.HairColorGroup_Brown = 0;
                    wrappingData.HairColorGroup_Red = 0;
                    break;
                case "brown":
                    wrappingData.HairColorGroup_None = 0;
                    wrappingData.HairColorGroup_Black = 0;
                    wrappingData.HairColorGroup_Blond = 0;
                    wrappingData.HairColorGroup_Brown = 1;
                    wrappingData.HairColorGroup_Red = 0;
                    break;
                case "red":
                    wrappingData.HairColorGroup_None = 0;
                    wrappingData.HairColorGroup_Black = 0;
                    wrappingData.HairColorGroup_Blond = 0;
                    wrappingData.HairColorGroup_Brown = 0;
                    wrappingData.HairColorGroup_Red = 1;
                    break;
                default:
                    wrappingData.HairColorGroup_None = 0;
                    wrappingData.HairColorGroup_Black = 0;
                    wrappingData.HairColorGroup_Blond = 0;
                    wrappingData.HairColorGroup_Brown = 0;
                    wrappingData.HairColorGroup_Red = 0;
                    break;
            }
            switch (wrappingData.SciaticNotchDropdown)
            {
                case "narrow":
                    wrappingData.SciaticNotch_Narrow = 1;
                    wrappingData.SciaticNotch_Medium = 0;
                    wrappingData.SciaticNotch_Wide = 0;
                    break;
                case "medium":
                    wrappingData.SciaticNotch_Narrow = 0;
                    wrappingData.SciaticNotch_Medium = 1;
                    wrappingData.SciaticNotch_Wide = 0;
                    break;
                case "wide":
                    wrappingData.SciaticNotch_Narrow = 0;
                    wrappingData.SciaticNotch_Medium = 0;
                    wrappingData.SciaticNotch_Wide = 1;
                    break;
                default:
                    wrappingData.SciaticNotch_Narrow = 0;
                    wrappingData.SciaticNotch_Medium = 0;
                    wrappingData.SciaticNotch_Wide = 0;
                    break;
            }
            switch (wrappingData.ToothEruptionAgeDropdown)
            {
                case "none":
                    wrappingData.ToothEruptionAgeEstimate_None = 1;
                    wrappingData.ToothEruptionAgeEstimate_4_8Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_8_16Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_17_25Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_25_35Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_35_Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_Other = 0;
                    break;
                case "4_8":
                    wrappingData.ToothEruptionAgeEstimate_None = 0;
                    wrappingData.ToothEruptionAgeEstimate_4_8Years = 1;
                    wrappingData.ToothEruptionAgeEstimate_8_16Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_17_25Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_25_35Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_35_Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_Other = 0;
                    break;
                case "8_16":
                    wrappingData.ToothEruptionAgeEstimate_None = 0;
                    wrappingData.ToothEruptionAgeEstimate_4_8Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_8_16Years = 1;
                    wrappingData.ToothEruptionAgeEstimate_17_25Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_25_35Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_35_Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_Other = 0;
                    break;
                case "17_25":
                    wrappingData.ToothEruptionAgeEstimate_None = 0;
                    wrappingData.ToothEruptionAgeEstimate_4_8Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_8_16Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_17_25Years = 1;
                    wrappingData.ToothEruptionAgeEstimate_25_35Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_35_Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_Other = 0;
                    break;
                case "25_35":
                    wrappingData.ToothEruptionAgeEstimate_None = 0;
                    wrappingData.ToothEruptionAgeEstimate_4_8Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_8_16Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_17_25Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_25_35Years = 1;
                    wrappingData.ToothEruptionAgeEstimate_35_Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_Other = 0;
                    break;
                case "35_":
                    wrappingData.ToothEruptionAgeEstimate_None = 0;
                    wrappingData.ToothEruptionAgeEstimate_4_8Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_8_16Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_17_25Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_25_35Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_35_Years = 1;
                    wrappingData.ToothEruptionAgeEstimate_Other = 0;
                    break;
                case "other":
                    wrappingData.ToothEruptionAgeEstimate_None = 0;
                    wrappingData.ToothEruptionAgeEstimate_4_8Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_8_16Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_17_25Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_25_35Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_35_Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_Other = 1;
                    break;
                default:
                    wrappingData.ToothEruptionAgeEstimate_None = 0;
                    wrappingData.ToothEruptionAgeEstimate_4_8Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_8_16Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_17_25Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_25_35Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_35_Years = 0;
                    wrappingData.ToothEruptionAgeEstimate_Other = 0;
                    break;
            }
            switch (wrappingData.ToothAttritionDropdown)
            {
                case "noTeeth":
                    wrappingData.ToothAttrition_NoTeeth = 1;
                    wrappingData.ToothAttrition_I = 0;
                    wrappingData.ToothAttrition_II = 0;
                    wrappingData.ToothAttrition_III = 0;
                    wrappingData.ToothAttrition_IV = 0;
                    wrappingData.ToothAttrition_V = 0;
                    break;
                case "1":
                    wrappingData.ToothAttrition_NoTeeth = 0;
                    wrappingData.ToothAttrition_I = 1;
                    wrappingData.ToothAttrition_II = 0;
                    wrappingData.ToothAttrition_III = 0;
                    wrappingData.ToothAttrition_IV = 0;
                    wrappingData.ToothAttrition_V = 0;
                    break;
                case "2":
                    wrappingData.ToothAttrition_NoTeeth = 0;
                    wrappingData.ToothAttrition_I = 0;
                    wrappingData.ToothAttrition_II = 1;
                    wrappingData.ToothAttrition_III = 0;
                    wrappingData.ToothAttrition_IV = 0;
                    wrappingData.ToothAttrition_V = 0;
                    break;
                case "3":
                    wrappingData.ToothAttrition_NoTeeth = 0;
                    wrappingData.ToothAttrition_I = 0;
                    wrappingData.ToothAttrition_II = 0;
                    wrappingData.ToothAttrition_III = 1;
                    wrappingData.ToothAttrition_IV = 0;
                    wrappingData.ToothAttrition_V = 0;
                    break;
                case "4":
                    wrappingData.ToothAttrition_NoTeeth = 0;
                    wrappingData.ToothAttrition_I = 0;
                    wrappingData.ToothAttrition_II = 0;
                    wrappingData.ToothAttrition_III = 0;
                    wrappingData.ToothAttrition_IV = 1;
                    wrappingData.ToothAttrition_V = 0;
                    break;
                case "5":
                    wrappingData.ToothAttrition_NoTeeth = 0;
                    wrappingData.ToothAttrition_I = 0;
                    wrappingData.ToothAttrition_II = 0;
                    wrappingData.ToothAttrition_III = 0;
                    wrappingData.ToothAttrition_IV = 0;
                    wrappingData.ToothAttrition_V = 1;
                    break;
                default:
                    wrappingData.ToothAttrition_NoTeeth = 0;
                    wrappingData.ToothAttrition_I = 0;
                    wrappingData.ToothAttrition_II = 0;
                    wrappingData.ToothAttrition_III = 0;
                    wrappingData.ToothAttrition_IV = 0;
                    wrappingData.ToothAttrition_V = 0;
                    break;
            }
            switch (wrappingData.ZygomaticDropdown)
            {
                case "shorter":
                    wrappingData.ZygomaticCrest_Shorter = 1;
                    wrappingData.ZygomaticCrest_Medium = 0;
                    wrappingData.ZygomaticCrest_Longer = 0;
                    break;
                case "medium":
                    wrappingData.ZygomaticCrest_Shorter = 0;
                    wrappingData.ZygomaticCrest_Medium = 1;
                    wrappingData.ZygomaticCrest_Longer = 0;
                    break;
                case "longer":
                    wrappingData.ZygomaticCrest_Shorter = 0;
                    wrappingData.ZygomaticCrest_Medium = 0;
                    wrappingData.ZygomaticCrest_Longer = 1;
                    break;
                default:
                    wrappingData.ZygomaticCrest_Shorter = 0;
                    wrappingData.ZygomaticCrest_Medium = 0;
                    wrappingData.ZygomaticCrest_Longer = 0;
                    break;
            }
            switch (wrappingData.GonionDropdown)
            {
                case "flat":
                    wrappingData.Gonion_Flat = 1;
                    wrappingData.Gonion_Pointed = 0;
                    wrappingData.Gonion_Medium = 0;
                    break;
                case "pointed":
                    wrappingData.Gonion_Flat = 0;
                    wrappingData.Gonion_Pointed = 1;
                    wrappingData.Gonion_Medium = 0;
                    break;
                case "medium":
                    wrappingData.Gonion_Flat = 0;
                    wrappingData.Gonion_Pointed = 0;
                    wrappingData.Gonion_Medium = 1;
                    break;
                default:
                    wrappingData.Gonion_Flat = 0;
                    wrappingData.Gonion_Pointed = 0;
                    wrappingData.Gonion_Medium = 0;
                    break;
            }
            switch (wrappingData.OrbitEdgeItems)
            {
                case "sharp":
                    wrappingData.OrbitEdge_Sharp = 1;
                    wrappingData.OrbitEdge_Blunt = 0;
                    wrappingData.OrbitEdge_Medium = 0;
                    wrappingData.OrbitEdge_Unknown = 0;
                    break;
                case "blunt":
                    wrappingData.OrbitEdge_Sharp = 0;
                    wrappingData.OrbitEdge_Blunt = 1;
                    wrappingData.OrbitEdge_Medium = 0;
                    wrappingData.OrbitEdge_Unknown = 0;
                    break;
                case "medium":
                    wrappingData.OrbitEdge_Sharp = 0;
                    wrappingData.OrbitEdge_Blunt = 0;
                    wrappingData.OrbitEdge_Medium = 1;
                    wrappingData.OrbitEdge_Unknown = 0;
                    break;
                case "unknown":
                    wrappingData.OrbitEdge_Sharp = 0;
                    wrappingData.OrbitEdge_Blunt = 0;
                    wrappingData.OrbitEdge_Medium = 0;
                    wrappingData.OrbitEdge_Unknown = 1;
                    break;
                default:
                    wrappingData.OrbitEdge_Sharp = 0;
                    wrappingData.OrbitEdge_Blunt = 0;
                    wrappingData.OrbitEdge_Medium = 0;
                    wrappingData.OrbitEdge_Unknown = 0;
                    break;
            }
            switch (wrappingData.SupraOrbitalDropdown)
            {
                case "heavy":
                    wrappingData.SupraorbitalRidges_Heavy = 1;
                    wrappingData.SupraorbitalRidges_Light = 0;
                    wrappingData.SupraorbitalRidges_Medium = 0;
                    wrappingData.SupraorbitalRidges_Unknown = 0;
                    break;
                case "light":
                    wrappingData.SupraorbitalRidges_Heavy = 0;
                    wrappingData.SupraorbitalRidges_Light = 1;
                    wrappingData.SupraorbitalRidges_Medium = 0;
                    wrappingData.SupraorbitalRidges_Unknown = 0;
                    break;
                case "medium":
                    wrappingData.SupraorbitalRidges_Heavy = 0;
                    wrappingData.SupraorbitalRidges_Light = 0;
                    wrappingData.SupraorbitalRidges_Medium = 1;
                    wrappingData.SupraorbitalRidges_Unknown = 0;
                    break;
                case "unknown":
                    wrappingData.SupraorbitalRidges_Heavy = 0;
                    wrappingData.SupraorbitalRidges_Light = 0;
                    wrappingData.SupraorbitalRidges_Medium = 0;
                    wrappingData.SupraorbitalRidges_Unknown = 1;
                    break;
                default:
                    wrappingData.SupraorbitalRidges_Heavy = 0;
                    wrappingData.SupraorbitalRidges_Light = 0;
                    wrappingData.SupraorbitalRidges_Medium = 0;
                    wrappingData.SupraorbitalRidges_Unknown = 0;
                    break;
            }
            switch (wrappingData.AreaDropdown)
            {
                case "SE":
                    wrappingData.Area_NW = 0;
                    wrappingData.Area_SE = 1;
                    wrappingData.Area_SW = 0;
                    break;
                case "SW":
                    wrappingData.Area_NW = 0;
                    wrappingData.Area_SE = 0;
                    wrappingData.Area_SW = 1;
                    break;
                case "NW":
                    wrappingData.Area_NW = 1;
                    wrappingData.Area_SE = 0;
                    wrappingData.Area_SW = 0;
                    break;
                default:
                    wrappingData.Area_NW = 0;
                    wrappingData.Area_SE = 0;
                    wrappingData.Area_SW = 0;
                    break;
            }
            switch (wrappingData.HeadDirectionDropdown)
            {
                case "W":
                    wrappingData.HeadDirection_E = 0;
                    wrappingData.HeadDirection_W = 1;
                    break;
                case "E":
                    wrappingData.HeadDirection_E = 1;
                    wrappingData.HeadDirection_W = 0;
                    break;
                default:
                    wrappingData.HeadDirection_E = 0;
                    wrappingData.HeadDirection_W = 0;
                    break;
            }
            switch (wrappingData.SubAdultDropdown)
            {
                case "C":
                    wrappingData.AdultSubadult_C = 1;
                    wrappingData.AdultSubadult_A = 0;
                    break;
                case "A":
                    wrappingData.AdultSubadult_C = 1;
                    wrappingData.AdultSubadult_A = 0;
                    break;
                default:
                    wrappingData.AdultSubadult_C = 0;
                    wrappingData.AdultSubadult_A = 0;
                    break;
            }
            return wrappingData;
        }
    }
}
