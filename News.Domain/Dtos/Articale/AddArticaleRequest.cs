using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anas_Abualsauod.News.Domain.Dtos.Articale;

public class AddArticaleRequest
{
    public required string Title { get; set; }
    public required string Content { get; set; }
    [Required]

    public required int CategoryId { get; set; }
    [Required]
    
    public required int AuthorId { get; set; }

}
