﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace winter_intex_2_5.Models
{
    public class SexData
    {
        public float AdultSubadult_C { get; set; }
        public string SubAdultDropdown { get; set; }
        public float Area_NW {get; set; } 
        public float Area_SE { get; set; } 
        public float Area_SW { get; set; } 
        public string AreaDropdown { get; set; }
        public float BurialNumber { get; set; }
        public float Depth { get; set; }   
        public float EastWest_W { get; set; }
        public string EastWestDropdown { get; set; }
        public float Length { get; set; }
        public float PreservationBones { get; set; }
        public float PreservationBonesodyOnly { get; set; }
        public float PreservationFair { get; set; }
        public float PreservationHeadlessSkeleton { get; set; }
        public float PreservationPoor { get; set; }
        public float PreservationScatteredBonesWithSkull { get; set; }
        public float PreservationSkeletalized { get; set; } 
        public float PreservationSkeletalizedkullOnly { get; set; }  
        public float PreservationWrapped { get; set; }
        public string PreservationDropdown { get; set; }
        public float SouthToFeet { get; set; } 
        public float SouthToHead { get; set; } 
        public float SquareEastWest { get; set; }  
        public float SquareNorthSouth { get; set; } 
        public float WestToFeet { get; set; }  
        public float WestToHead { get; set; } 
        public string WrappingDropdown { get; set; }
        public float Wrapping_H { get; set; }  
        public float Wrapping_W { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                AdultSubadult_C, Area_NW, Area_SE, Area_SW, BurialNumber, Depth, EastWest_W, 
                Length, PreservationBones, PreservationBonesodyOnly, PreservationFair, PreservationHeadlessSkeleton, 
                PreservationPoor, PreservationScatteredBonesWithSkull, PreservationSkeletalized, PreservationSkeletalizedkullOnly, 
                PreservationWrapped, SouthToFeet, SouthToHead, SquareEastWest, SquareNorthSouth, WestToFeet, WestToHead, Wrapping_H, 
                Wrapping_W
            };
            int[] dimensions = new int[] { 1, 25 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
