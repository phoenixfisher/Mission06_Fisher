namespace Mission06_Fisher.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum Rating
{
    G,
    PG,
    PG13,
    R
}

public class Movie
{
    public int Id { get; set; }

    [Required]
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    // Year could be a string to allow ranges like "2001-2002"
    [Required]
    [StringLength(20)]
    public string Year { get; set; } = string.Empty;

    [Required]
    public int DirectorId { get; set; }
    public Director Director { get; set; } = null!;

    [Required]
    public Rating Rating { get; set; }

    [Required]
    public bool Edited { get; set; }

    [StringLength(100)]
    public string? LentTo { get; set; }

    [StringLength(25)]
    public string? Notes { get; set; }

    public DateTime DateAdded { get; set; } = DateTime.UtcNow;
}
