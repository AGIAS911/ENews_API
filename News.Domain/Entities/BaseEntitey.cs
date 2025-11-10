using System.ComponentModel.DataAnnotations;

namespace Anas_Abualsauod.News.Domain.Entities;

public class BaseEntitey
{
    [Key]
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; } 

    public DateTime UpdatedAt { get; set; }   

    public bool IsDeleted { get; set; } = false;

}
