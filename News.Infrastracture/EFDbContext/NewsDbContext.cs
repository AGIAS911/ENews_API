using Anas_Abualsauod.News.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using News.Infrastracture.Configurations;

namespace News.Infrastracture.EFDbContext;

public class NewsDbContext : DbContext
{
    public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NewsDbContext).Assembly);
        base.OnModelCreating(modelBuilder);


        UserConfigurationsDb.Configure(modelBuilder);

        CategoryConfigurationsDb.Configure(modelBuilder);
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Articale> Articles { get; set; }
}
