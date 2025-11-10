using Anas_Abualsauod.News.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using News.Infrastracture.Encrybtion;

namespace News.Infrastracture.Configurations;

public class UserConfigurationsDb
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        SeedData(modelBuilder);
    }
    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(p => p.UserName).IsUnique();


        modelBuilder.Entity<User>().HasData(
            new User
            {
                Email = "Admain@gmail.com",
                FullName = "Admain",
                Id = -1,
                //Password = HashData.Hash("00000"),
                Password = "00000",
                ImagePath = "default.png",
                UserName = "ADMAIN",
                IsDeleted = false




            }
                    );
        }
    }