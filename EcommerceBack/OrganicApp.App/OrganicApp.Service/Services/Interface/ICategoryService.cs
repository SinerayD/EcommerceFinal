using OrganicApp.Core.Entities;
using OrganicApp.Service.Utilities.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.Services.Interface
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        List<Category> GetCategories();
        Task CreateAsync(Category model);
        Task<Category> GetById(int id);
        Task<Category> GetByIdUpdate(int id);
        Task Update(Category dto);
        Task Remove(int id);
    }
}
