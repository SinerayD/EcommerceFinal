using OrganicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.Services.Interface
{
    public interface ISubscribeService
    {
        Task CreateAsync(Subscribe entity);
        Task<List<Subscribe>> GetAllAsync();
        Task RemoveAsync(int id);
    }
}
