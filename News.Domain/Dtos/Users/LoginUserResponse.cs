namespace Anas_Abualsauod.News.Domain.Dtos.Users;

public class LoginUserResponse
{
    public int Id { get; set; }
    public string AccessToken { get; set; }
    public int Expiration { get; set; }
    public string UserName { get; set; }

  
}
