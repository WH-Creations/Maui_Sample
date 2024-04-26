using System;
using System.ComponentModel.DataAnnotations;

namespace Maui_Api.DTO;

public class Inspection
{
    public Guid Id { get; set; }

    [Url]
    public string? ImageUrl { get; set; } // Validate URL if provided.

    [Required]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
    [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required]
    public DateTime Date { get; set; }

    [MaxLength(250, ErrorMessage = "Description cannot exceed 250 characters.")]
    public string? Description { get; set; }

    [Required]
    public InspectionStatus Status { get; set; }

    [Required]
    public Location Location { get; set; } = new Location();
}