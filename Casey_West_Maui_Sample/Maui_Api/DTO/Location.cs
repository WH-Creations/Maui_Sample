using System.ComponentModel.DataAnnotations;

namespace Maui_Api.DTO
{
    public class Location
    {
        public Guid Id { get; set; }

        [Required]
        public LocationType LocationType { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
