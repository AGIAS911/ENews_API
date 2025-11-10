using Anas_Abualsauod.News.Domain.Dtos.Users;
using Anas_Abualsauod.News.Domain.Entities;

namespace Anas_Abualsauod.News.Domain.Interfaces;

public interface IUser
{
    Task Add(AddUserRequest request);
    Task Update(UpdateUserRequest request);
    Task Delete(int id);
    Task<List<User>> GetAll();
    Task<User?> GetById(int id);
    Task Validation(AddUserRequest request);
    Task UpdatePassword(UpdateUserRequest request);
    Task<User?> Login(LoginUserRequest request);

}
