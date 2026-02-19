namespace Mission06_Fisher.Models;

using System.ComponentModel.DataAnnotations;
public class Director
{
    public int Id { get; set; }

    [Required, StringLength(200)]
    public string Name { get; set; } = string.Empty;

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
