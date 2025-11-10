using Anas_Abualsauod.News.Domain.Dtos.Articale;
using Anas_Abualsauod.News.Domain.Entities;
using Anas_Abualsauod.News.Domain.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using News.Infrastracture.EFDbContext;

namespace News.Service;

public class ArticaleService : IArticale
{
    private readonly NewsDbContext _dbContext;

    public ArticaleService(NewsDbContext dbcontext)
    {
        _dbContext = dbcontext;
    }
    public async Task Add(AddArticaleRequest request)
    {
        //await Validation(request);
        var articale=request.Adapt<Articale>();
        articale.CreatedAt = DateTime.UtcNow;
        articale.UpdatedAt = DateTime.UtcNow;
        await _dbContext.Articles.AddAsync(articale);
        await _dbContext.SaveChangesAsync();



    }

    public async Task Delete(int id)
    {
        var articale = await _dbContext.Articles.FindAsync(id);
        if (articale == null)
            throw new ArgumentException("Articale not found");
         _dbContext.Articles.Remove(articale);//physical delete
      //  articale.IsDeleted = true;//logical delete
        _dbContext.Articles.Update(articale);
        await _dbContext.SaveChangesAsync();


    }

    public async Task<List<Articale>> GetAll()
    {
         var resulr=await _dbContext.Articles.ToListAsync();
        return resulr;

    }

    public async Task<Articale?> GetById(int id)
    {
        var result = await _dbContext.Articles.FindAsync(id);
        return result;

    }

    public async Task Update(UpdateArticaleRequest request)
    {
       
        var articale = await _dbContext.Articles.FindAsync(request.Id);
        if (articale == null)
            throw new ArgumentException("Articale not found");
        articale.Title = request.Title;
        articale.Content = request.Content;
        articale.CategoryId = request.CategoryId;
        articale.UpdatedAt = DateTime.UtcNow;
        _dbContext.Articles.Update(articale);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Validation(AddArticaleRequest request)
    {
        //if (string.IsNullOrEmpty(request.Title))
        //    throw new ArgumentException("Title is required");
        //if (string.IsNullOrEmpty(request.Content))
        //    throw new ArgumentException("Content is required");
        //if (request. <= 0)
        //    throw new ArgumentException("CategoryId must be greater than zero");
        //var category = await _dbContext.Categories.FindAsync(request.CategoryId);
        //if (category == null)
        //    throw new ArgumentException("Category not found");
        await Task.CompletedTask;
       

    }
}
