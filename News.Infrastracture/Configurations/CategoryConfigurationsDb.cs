using Anas_Abualsauod.News.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace News.Infrastracture.Configurations;

public class CategoryConfigurationsDb
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        

        SeedData(modelBuilder);

    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = -1,
                Name = "Technology",
                Description = "About Technology",
                CreatedAt = new DateTime(2025, 1, 1),
                UpdatedAt = new DateTime(2025, 1, 1),
                IsDeleted = false
            },
            new Category
            {
                Id = -2,
                Name = "Health",
                Description = "About Health",
                CreatedAt = new DateTime(2025, 1, 1),
                UpdatedAt = new DateTime(2025, 1, 1),
                IsDeleted = false
            },
            new Category
            {
                Id = -3,
                Name = "Sports",
                Description = "About Sports",
                CreatedAt = new DateTime(2025, 1, 1),
                UpdatedAt = new DateTime(2025, 1, 1),
                IsDeleted = false
            },
            new Category
            {
                Id = -4,
                Name = "Business",
                Description = "About Business",
                CreatedAt = new DateTime(2025, 1, 1),
                UpdatedAt = new DateTime(2025, 1, 1),
                IsDeleted = false
            },
            new Category
            {
                Id = -5,
                Name = "Entertainment",
                Description = "About Entertainment",
                CreatedAt = new DateTime(2025, 1, 1),
                UpdatedAt = new DateTime(2025, 1, 1),
                IsDeleted = false
            }
        );
    }

}
