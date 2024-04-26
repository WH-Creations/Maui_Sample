using System.ComponentModel.DataAnnotations;

namespace Maui_App.Models
{
    internal class InspectionModel
    {
        public Guid Id { get; set; }
        public string? ImageUrl { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        [Required]
        public InspectionStatusEnum Status { get; set; }

        [Required]
        public LocationModel Location { get; set; } = new LocationModel();
    }
}
