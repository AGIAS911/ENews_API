using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anas_Abualsauod.News.Domain.Dtos.Category;

public class AddCategoryRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string CategoryId { get; set; }
}
