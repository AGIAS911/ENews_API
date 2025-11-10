using Anas_Abualsauod.News.Domain.Dtos.Category;
using Anas_Abualsauod.News.Domain.Entities;
using Anas_Abualsauod.News.Domain.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using News.Infrastracture.EFDbContext;

namespace News.Service;

public class CategoryService : ICategory
{
    private readonly NewsDbContext _dbContext;

    public CategoryService(NewsDbContext dbcontext)
    {
        _dbContext = dbcontext;
    }
    public async Task Add(AddCategoryRequest request)
    {
        var result = request.Adapt<Category>();
        result.CreatedAt = DateTime.UtcNow;
        result.UpdatedAt = DateTime.UtcNow;
        await _dbContext.Categories.AddAsync(result);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {

        var category = await _dbContext.Categories.FindAsync(id);
        if (category == null)
            throw new ArgumentException("Category not found");
         _dbContext.Categories.Remove(category);//physical delete
        //category.IsDeleted = true;//logical delete
       // _dbContext.Categories.Update(category);
        await _dbContext.SaveChangesAsync();

    }

    public async Task<List<Category>> GetAll()
    {
        
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task<Category?> GetById(int id)
    {
        var category =  await _dbContext.Categories.FindAsync(id);
        return category;
    }

    public async Task Update(UpdateCategoryRequest request)
    {
        
        var category = await _dbContext.Categories.FindAsync(request.Id);
        if (category == null)
            throw new ArgumentException("Category not found");
        category.Name = request.Name;
        category.Description = request.Description;
        
      
        await _dbContext.SaveChangesAsync();

    }

    public Task Validation(AddCategoryRequest request)
    {
        throw new NotImplementedException();//later
    }
}
