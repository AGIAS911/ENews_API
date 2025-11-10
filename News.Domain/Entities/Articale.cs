using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anas_Abualsauod.News.Domain.Entities;
[Table("Articales")]
public class Articale: BaseEntitey
{
    [Required]
    [MaxLength(60)]
    public required string Title { get; set; }
    [Required]
    [MaxLength(500)]
    public required string Content { get; set; }
    [Required]
    [MaxLength(60)]
    public required int CategoryId { get; set; }
    [Required]
   
    public required Category Category { get; set; }
    [Required]
    [MaxLength(60)]
    public required int AuthorId { get; set; }
    [Required]
    public required User Author { get; set; }


}
