using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP260908.Models;

[Table(name: "Movies")]
public class Movie
{
    public int Id { get; set; }

    [Required(ErrorMessage = "a 'title' mező kitöltése kötlező!")]
    [StringLength(60, MinimumLength = 3)]
    public string? Title { get; set; }

    [DataType(DataType.Date)]
    [DisplayName("Release Date")]
    public DateTime ReleaseDate { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    [StringLength(30)]
    public string? Genre { get; set; }

    
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    [Range(500, 8000)]
    public decimal Price { get; set; }

    [StringLength(5)]
    [AllowedValues("G", "PG", "PG-13", "R", "NC-17")]
    [Required]
    public string? Rating { get; set; }
}
