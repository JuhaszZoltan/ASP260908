using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP260908.Models;

[Table(name: "Movies")]
public class Movie
{
    public int Id { get; set; }
    [Required(ErrorMessage = "a 'title' mező kitöltése kötlező!")]
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    [DisplayName("Release Date")]
    public DateTime ReleaseDate { get; set; }
    [Required]
    public string? Genre { get; set; }
    
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
}
