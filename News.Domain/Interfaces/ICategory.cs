using Anas_Abualsauod.News.Domain.Dtos.Category;
using Anas_Abualsauod.News.Domain.Dtos.Users;
using Anas_Abualsauod.News.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anas_Abualsauod.News.Domain.Interfaces;

public interface ICategory
{
    Task Add(AddCategoryRequest request);
    Task Update(UpdateCategoryRequest request);
    Task Delete(int id);
    Task<List<Category>> GetAll();
    Task<Category?> GetById(int id);
    Task Validation(AddCategoryRequest request);
}
