using OrganicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganicApp.Service.Services.Interface
{
    public interface ISettingService
    {
        List<Setting> GetSettings();
        Task<List<Setting>> GetAllAsync();
        Task CreateAsync(Setting model);
        Task<Setting> GetByIdAsync(int id);
        Task<Setting> GetByIdUpdateAsync(int id);
        Task UpdateAsync(Setting model);
        Task RemoveAsync(int id);
    }
}
