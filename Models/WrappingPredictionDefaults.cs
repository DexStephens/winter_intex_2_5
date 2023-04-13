using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace winter_intex_2_5.Models
{
    public class WrappingPredictionDefaults
    {
        public List<SelectListItem> EastWestItems = new List<SelectListItem>()
        {
            new SelectListItem { Value = "E", Text = "East", Selected = true },
            new SelectListItem { Value = "W", Text = "West" }
        };
        public List<SelectListItem> HairColorItems = new List<SelectListItem>()
        {
            new SelectListItem { Value = "none", Text = "none", Selected = true },
            new SelectListItem { Value = "blond", Text = "blond" },
            new SelectListItem { Value = "red", Text = "red" },
            new SelectListItem { Value = "brown", Text = "brown" },
            new SelectListItem { Value = "black", Text = "black" }
        };
        public List<SelectListItem> SciaticNotchItems = new List<SelectListItem>()
        {
            new SelectListItem { Value = "", Text = "", Selected = true },
            new SelectListItem { Value = "narrow", Text = "narrow" },
            new SelectListItem { Value = "medium", Text = "medium" },
            new SelectListItem { Value = "wide", Text = "wide" }
        };
        public List<SelectListItem> ToothEruptionAgeItems = new List<SelectListItem>()
        {
            new SelectListItem { Value = "none", Text = "none", Selected = true },
            new SelectListItem { Value = "0_4", Text = "0-4 years" },
            new SelectListItem { Value = "4_8", Text = "4-8 years" },
            new SelectListItem { Value = "8_16", Text = "8-16 years" },
            new SelectListItem { Value = "17_25", Text = "17-25 years" },
            new SelectListItem { Value = "25_35", Text = "25-35 years" },
            new SelectListItem { Value = "35_", Text = "35+ years" },
            new SelectListItem { Value = "other", Text = "other" }
        };
        public List<SelectListItem> ToothAttritionItems = new List<SelectListItem>()
        {
            new SelectListItem { Value = "", Text = "", Selected = true },
            new SelectListItem { Value = "noTeeth", Text = "No Teeth"},
            new SelectListItem { Value = "1", Text = "I" },
            new SelectListItem { Value = "2", Text = "II" },
            new SelectListItem { Value = "3", Text = "III" },
            new SelectListItem { Value = "4", Text = "IV" },
            new SelectListItem { Value = "5", Text = "V" }
        };
       public List<SelectListItem> ZygomaticItems = new List<SelectListItem>()
        {
            new SelectListItem { Value = "", Text = "", Selected = true},
            new SelectListItem { Value = "shorter", Text = "shorter"},
            new SelectListItem { Value = "medium", Text = "medium" },
            new SelectListItem { Value = "longer", Text = "longer" }
        };
        public List<SelectListItem> GonionItems = new List<SelectListItem>()
        {
            new SelectListItem { Value = "", Text = "", Selected = true },
            new SelectListItem { Value = "flat", Text = "flat" },
            new SelectListItem { Value = "pointed", Text = "pointed" },
            new SelectListItem { Value = "medium", Text = "medium" }
        };
        public List<SelectListItem> OrbitEdgeItems = new List<SelectListItem>()
        {
            new SelectListItem { Value = "", Text = "", Selected = true },
            new SelectListItem { Value = "sharp", Text = "sharp"},
            new SelectListItem { Value = "blunt", Text = "blunt" },
            new SelectListItem { Value = "medium", Text = "medium" },
            new SelectListItem { Value = "unknown", Text = "unknown" }
        };
        public List<SelectListItem> SupraOrbitalItems = new List<SelectListItem>()
        {
            new SelectListItem { Value = "", Text = "", Selected = true },
            new SelectListItem { Value = "heavy", Text = "heavy"},
            new SelectListItem { Value = "light", Text = "light" },
            new SelectListItem { Value = "medium", Text = "medium" },
            new SelectListItem { Value = "unknown", Text = "unknown" }
        };
        public List<SelectListItem> AreaItems = new List<SelectListItem>
        {
            new SelectListItem { Value = "SE", Text = "SE", Selected = true },
            new SelectListItem { Value = "SW", Text = "SW" },
            new SelectListItem { Value = "NE", Text = "NE" },
            new SelectListItem { Value = "NW", Text = "NW" }
        };
        public List<SelectListItem> HeadDirectionItems = new List<SelectListItem>
        {
            new SelectListItem { Value = "E", Text = "East", Selected = true },
            new SelectListItem { Value = "W", Text = "West" }
        };
        public List<SelectListItem> SubAdultItems = new List<SelectListItem>
        {
            new SelectListItem { Value = "A", Text = "Adult", Selected = true },
            new SelectListItem { Value = "C", Text = "Child" }
        };
    }
}
