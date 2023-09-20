using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using OrganicApp.Core.Entities;
using OrganicApp.Data.Contexts;
using OrganicApp.Data.UniteOfWork;
using OrganicApp.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.Services
{
    public class SocialService : ISocialService
    {
        private readonly IUow _uow;
        private readonly OrganicAppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SocialService(IUow uow, OrganicAppDbContext context, IWebHostEnvironment env)
        {
            _uow = uow;
            _context = context;
            _env = env;
        }
        public List<Social> GetSocials()
        {
            var list = _context.Socials.OrderBy(x => x.Id).ToList();

            return list;
        }

        public async Task<List<Social>> GetAllAsync()
        {
            var entities = await _context.Socials.OrderByDescending(x => x.Id).ToListAsync();

            return entities;
        }

        public async Task CreateAsync(Social model)
        {
            if (model != null)
            {

                await _uow.GetRepository<Social>().CreateAsync(model);

                await _uow.SaveChangesAsync();
            }
        }

        public async Task<List<Social>> GetByIdAsync(List<int> socialIds)
        {
            var entities = await _context.Socials
                                    .Where(x => socialIds.Contains(x.Id))
                                    .ToListAsync();
            return entities;
        }


        public async Task<Social> GetByIdUpdate(int id)
        {
            var entity = await _uow.GetRepository<Social>().FindAsync(id);

            return entity;
        }

        public async Task Update(Social model)
        {
            var DbEntity = await _uow.GetRepository<Social>().FindAsync(model.Id);

            if ((DbEntity != null) || (model != null))
            {

                _uow.GetRepository<Social>().Update(model, DbEntity);

                await _uow.SaveChangesAsync();
            }
        }

        public async Task Remove(int id)
        {
            var entity = await _uow.GetRepository<Social>().FindAsync(id);

            if (entity != null)
            {

                _uow.GetRepository<Social>().Remove(entity);

                await _uow.SaveChangesAsync();
            }
        }
    }
}
