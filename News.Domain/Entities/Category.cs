using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anas_Abualsauod.News.Domain.Entities;

[Table("Categories")]
public class Category: BaseEntitey
{
    [Required]
    [MaxLength(60)]
    public required string Name { get; set; }
    [Required]
    [MaxLength(100)]
    public required string Description { get; set; }


}
