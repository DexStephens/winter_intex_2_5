﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace winter_intex_2_5.Models
{
    public class SexPredictionDefaults
    {
        public List<SelectListItem> WrappingItems = new List<SelectListItem>
        {
            new SelectListItem { Value = "B", Text = "bones", Selected = true },
            new SelectListItem { Value = "H", Text = "half wrapped" },
            new SelectListItem { Value = "W", Text = "whole wrapped" }
        };
        public List<SelectListItem> PreservationItems = new List<SelectListItem>
        {
            new SelectListItem { Value = "poor", Text = "poor", Selected = true },
            new SelectListItem { Value = "wrapped", Text = "wrapped" },
            new SelectListItem { Value = "c", Text = "Child" }
        };
        public List<SelectListItem> EastWestItems = new List<SelectListItem>
        {
            new SelectListItem { Value = "E", Text = "East", Selected = true },
            new SelectListItem { Value = "W", Text = "West" }
        };
        public List<SelectListItem> AreaItems = new List<SelectListItem>
        {
            new SelectListItem { Value = "SE", Text = "SE", Selected = true },
            new SelectListItem { Value = "SW", Text = "SW" },
            new SelectListItem { Value = "NE", Text = "NE" },
            new SelectListItem { Value = "NW", Text = "NW" }
        };
        public List<SelectListItem> SubAdultItems = new List<SelectListItem>
        {
            new SelectListItem { Value = "A", Text = "Adult", Selected = true },
            new SelectListItem { Value = "C", Text = "Child" }
        };

    }
}