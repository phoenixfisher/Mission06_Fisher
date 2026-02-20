namespace Mission06_Fisher.Models;

using System.ComponentModel.DataAnnotations;public class Movie
{
    public int MovieId { get; set; }   // required for primary key

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    [Range(1888, 3000)]
    public int Year { get; set; }

    [Required]
    public bool Edited { get; set; }

    [Required]
    public bool CopiedToPlex { get; set; }

    [StringLength(25)]
    public string? Notes { get; set; }
}