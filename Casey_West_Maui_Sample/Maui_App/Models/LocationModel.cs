using System.ComponentModel.DataAnnotations;

namespace Maui_App.Models
{
    public class LocationModel
    {
        public Guid Id { get; set; }

        [Required]
        public LocationTypeEnum LocationType { get; set; }

        public string Name { get; set; } = default!;
    }
}
