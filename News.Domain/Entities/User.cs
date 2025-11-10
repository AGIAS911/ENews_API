using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anas_Abualsauod.News.Domain.Entities;

[Table("Users")]
public class User: BaseEntitey
{
    [Required]
    [MaxLength(100)]
    public required string UserName { get; set; }
    [Required]
    [MaxLength(100)]
    public required string FullName { get; set; }
    [Required]
    [MaxLength(100)]
    public required string Email { get; set; }
    [Required]
    [MaxLength(200)]
    public required string Password { get; set; }

    public List<Articale> Articales { get; set; } = new();
    [Required]
    public required string? ImagePath { get; set; }


    }
