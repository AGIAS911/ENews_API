using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anas_Abualsauod.News.Domain.Dtos.Users;

public class UserInfo
{
    public required string UserName { get; set; }
    public required string FullName { get; set; }

    public required string Email { get; set; }


}
