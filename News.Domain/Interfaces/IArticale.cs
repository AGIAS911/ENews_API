using Anas_Abualsauod.News.Domain.Dtos.Articale;
using Anas_Abualsauod.News.Domain.Dtos.Users;
using Anas_Abualsauod.News.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anas_Abualsauod.News.Domain.Interfaces;

public interface IArticale
{
    Task Add(AddArticaleRequest request);
    Task Update(UpdateArticaleRequest request);
    Task Delete(int id);
    Task<List<Articale>> GetAll();
    Task<Articale?> GetById(int id);
    Task Validation(AddArticaleRequest request);
}
