﻿using Maui_App.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_App.Converters
{
    internal class LocationTypeConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not LocationTypeEnum locationType)
            {
                return string.Empty;
            }

            return locationType switch
            {
                LocationTypeEnum.AED => "AED",
                LocationTypeEnum.FireExtinguisher => "Fire Extinguisher",
                LocationTypeEnum.FirstAidKit => "First Aid Kit",
                LocationTypeEnum.SmokeDetector => "Smoke Detector",
                LocationTypeEnum.Unknown => "Unknown",
                _ => string.Empty
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not string description)
            {
                return LocationTypeEnum.Unknown;
            }

            return description switch
            {
                "AED" => LocationTypeEnum.AED,
                "Fire Extinguisher" => LocationTypeEnum.FireExtinguisher,
                "First Aid Kit" => LocationTypeEnum.FirstAidKit,
                "Smoke Detector" => LocationTypeEnum.SmokeDetector,
                _ => LocationTypeEnum.Unknown,
            };
        }
    }
}
