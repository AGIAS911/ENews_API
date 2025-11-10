using Anas_Abualsauod.News.Domain.Dtos.Users;
using Anas_Abualsauod.News.Domain.Entities;
using Anas_Abualsauod.News.Domain.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using News.Infrastracture.EFDbContext;
using News.Infrastracture.Encrybtion;

namespace News.Service;

public class UserService : IUser

{
    private readonly NewsDbContext _dbContext;

    public UserService(NewsDbContext dbcontext)
    {
        _dbContext = dbcontext;
    }
    /// <summary>
    /// This method adds a new user to the database after validating the input request.
    /// </summary>
    /// <param name="request">set user object data - AddUserRequest type</param>
    public async Task Add(AddUserRequest request)
    {
        try
        {
            await Validation(request);
            var result = request.Adapt<User>();
            result.CreatedAt = DateTime.UtcNow;
            result.UpdatedAt = DateTime.UtcNow;
            result.Password = HashData.Hash(request.Password);
            try
            {

                var imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imag");
                Directory.CreateDirectory(imagesPath);

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(request.ProfileImage.FileName)}";
                var filePath = Path.Combine(imagesPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.ProfileImage.CopyToAsync(stream);
                }

                result.ImagePath = "/imag/" + fileName;

            }
            catch (Exception)
            {

                throw;
            }
            await _dbContext.Users.AddAsync(result);
            await _dbContext.SaveChangesAsync();

        }
        catch (Exception)
        {

            throw;
        }

    }
    /// <summary>
    /// This method deletes a user from the database based on the provided user ID.
    /// </summary>
    /// <param name="id"></param>
    public async Task Delete(int id)
    {
        try
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
                throw new ArgumentException("User not found");
            // _dbContext.Users.Remove(user);//physical delete
            user.IsDeleted = true;//logical delete
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

        }
        catch (Exception)
        {

            throw;
        }
    }

    /// <summary>
    /// This method retrieves all non-deleted users from the database.
    /// </summary>
    /// <returns></returns>
    public async Task<List<User>> GetAll()
    {
        var result = await _dbContext.Users.Where(q => !q.IsDeleted).ToListAsync();
        return result;
    }
    /// <summary>
    /// This method retrieves a user by their ID. (Not Implemented)
    /// </summary>
    /// <param name="id">set int value - id</param> 
    public async Task<User?> GetById(int id)
    {
        try
        {
            var userInfo = await _dbContext.Users
                .Where(x => x.Id == id && !x.IsDeleted)
                .FirstOrDefaultAsync();

            return userInfo;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<User?> Login(LoginUserRequest request)
    {
        var book = await _dbContext.Users
            .Where(q => q.UserName == request.UserName)
            .FirstOrDefaultAsync();
      
        if (book == null)
            throw new ArgumentException("Invalid UserName or Password");
        var isPasswordExsit = HashData.Verify(request.Password, book.Password);
        if (!isPasswordExsit)
            throw new ArgumentException("Invalid UserName or Password");
        return book;
    }

    /// <summary>
    /// This method updates an existing user's information without password in the database.
    /// </summary>
    public async Task Update(UpdateUserRequest request)
    {
        var userInfo = await _dbContext.Users.FindAsync(request.Id);
        if (userInfo == null || userInfo.IsDeleted)
            throw new ArgumentException("User not found");

        userInfo.FullName = request.FullName;
        userInfo.Email = request.Email;

        _dbContext.Users.Update(userInfo);
        await _dbContext.SaveChangesAsync();
    }
    /// <summary>
    /// This method updates an existing user's password in the database.
    /// </summary>
    public async Task UpdatePassword(UpdateUserRequest request)
    {
        var userInfo = await _dbContext.Users.FindAsync(request.Id);
        if (userInfo == null || userInfo.IsDeleted)
            throw new ArgumentException("User not found");
        userInfo.Password = request.Password;
        _dbContext.Users.Update(userInfo);
        await _dbContext.SaveChangesAsync();
    }
    /// <summary>
    /// This method validates request informations
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public async Task Validation(AddUserRequest request)
    {
        if (string.IsNullOrEmpty(request.FullName))
            throw new ArgumentNullException("FullName is required");

        if (string.IsNullOrEmpty(request.UserName))
            throw new ArgumentNullException("User Name is required");

        if (string.IsNullOrEmpty(request.Email))
            throw new ArgumentNullException("Email address is required");

        if (string.IsNullOrEmpty(request.Password))
            throw new ArgumentNullException("Password is required");

        var isEmailExist = await _dbContext.Users.AnyAsync(q => q.Email == request.Email);
        var isUserNameExist = await _dbContext.Users.AnyAsync(q => q.UserName == request.UserName);

        //if (isEmailExist)
        //    throw new ArgumentException("Email address already exists");
        //if (isUserNameExist)
        //    throw new ArgumentException("UserName already exists");

    }
}
