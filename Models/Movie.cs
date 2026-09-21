using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP260908.Models;

[Table(name: "Movies")]
public class Movie
{
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    [Required]
    public string? Genre { get; set; }
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
}
