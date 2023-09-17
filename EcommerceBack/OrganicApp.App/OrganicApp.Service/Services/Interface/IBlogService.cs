using OrganicApp.Core.Entities;
using OrganicApp.Service.Utilities.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.Services.Interface
{
    public interface IBlogService
    {
        Task<Paginate<Blog>> AllFilterAsync(string search, string sortOrder, int page, int take);
        Task<Paginate<Blog>> AllHomeFilterAsync(string search, int page, int take);
        Task<List<Blog>> AllAsync();
        List<Blog> GetAll();
        Task<Blog> GetByUpdateIdAsync(int id);
        Task<Blog> GetByIdAsync(int id);
        Task CreateAsync(Blog model);
        Task UpdateAsync(Blog model);
        Task RemoveAsync(int id);
    }
}
