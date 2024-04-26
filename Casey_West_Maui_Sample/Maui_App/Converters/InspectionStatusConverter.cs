using Maui_App.Models;
using System.Globalization;

namespace Maui_App.Converters
{
    public class InspectionStatusConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not InspectionStatusEnum status)
            {
                return string.Empty;
            }

            return status switch
            {
                InspectionStatusEnum.InProgress => "In Progress",
                InspectionStatusEnum.Complete => "Complete",
                InspectionStatusEnum.Cancelled => "Cancelled",
                InspectionStatusEnum.Unknown => "Unknown",
                _ => string.Empty
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not string description)
            {
                return InspectionStatusEnum.Unknown;
            }

            return description switch
            {
                "In Progress" => InspectionStatusEnum.InProgress,
                "Complete" => InspectionStatusEnum.Complete,
                "Cancelled" => InspectionStatusEnum.Cancelled,
                _ => InspectionStatusEnum.Unknown,
            };
        }
    }
}
