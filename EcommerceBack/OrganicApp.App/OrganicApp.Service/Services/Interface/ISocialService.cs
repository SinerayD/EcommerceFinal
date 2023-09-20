using OrganicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.Services.Interface
{
    public interface ISocialService
    {
        List<Social> GetSocials();
        Task<List<Social>> GetAllAsync();
        Task CreateAsync(Social model);
        Task<List<Social>> GetByIdAsync(List<int> socialIds);
        Task<Social> GetByIdUpdate(int id);
        Task Update(Social model);
        Task Remove(int id);
    }
}
