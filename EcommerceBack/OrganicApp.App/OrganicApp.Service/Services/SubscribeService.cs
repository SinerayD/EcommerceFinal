using OrganicApp.Core.Entities;
using OrganicApp.Data.UniteOfWork;
using OrganicApp.Service.Services.Interface;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.Services
{
    public class SubscribeService : ISubscribeService
    {
        private readonly IUow _uow;
        public SubscribeService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<List<Subscribe>> GetAllAsync()
        {
            var list = await _uow.GetRepository<Subscribe>().AllAsync();

            return list;
        }

        public async Task CreateAsync(Subscribe entity)
        {
            if (entity != null)
            {
                await _uow.GetRepository<Subscribe>().CreateAsync(entity);

                await _uow.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _uow.GetRepository<Subscribe>().FindAsync(id);

            if (entity != null)
            {
                _uow.GetRepository<Subscribe>().Remove(entity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
