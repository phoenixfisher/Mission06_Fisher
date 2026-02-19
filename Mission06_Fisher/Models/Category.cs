namespace Mission06_Fisher.Models;

using System.ComponentModel.DataAnnotations;
public class Category
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    // Navigation
    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
