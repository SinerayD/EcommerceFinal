using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using OrganicApp.Core.Entities;
using OrganicApp.Data.Contexts;
using OrganicApp.Data.UniteOfWork;
using OrganicApp.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicApp.Service.Services
{
    public class SettingService : ISettingService
    {
        private readonly IUow _uow;
        private readonly OrganicAppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingService(IUow uow, OrganicAppDbContext context, IWebHostEnvironment env)
        {
            _uow = uow;
            _context = context;
            _env = env;
        }

        public List<Setting> GetSettings()
        {
            var list = _context.Settings.ToList();
            return list;
        }

        public async Task<List<Setting>> GetAllAsync()
        {
            var entities = await _context.Settings.OrderByDescending(x => x.Id).ToListAsync();
            return entities;
        }

        public async Task CreateAsync(Setting model)
        {
            if (model != null)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + model.file?.FileName;
                string path = Path.Combine(_env.WebRootPath, "AdminPanel/img/setting", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await model.file.CopyToAsync(stream);
                }
                model.Logo = fileName;

                await _uow.GetRepository<Setting>().CreateAsync(model);

                await _uow.SaveChangesAsync();
            }
        }

        public async Task<Setting> GetByIdAsync(int id)
        {
            var entity = await _uow.GetRepository<Setting>().FindAsync(id);

            return entity;
        }

        public async Task<Setting> GetByIdUpdateAsync(int id)
        {
            var entity = await _uow.GetRepository<Setting>().FindAsync(id);

            return entity;
        }

        public async Task UpdateAsync(Setting model)
        {
            var dbEntity = await _uow.GetRepository<Setting>().FindAsync(model.Id);

            if ((dbEntity != null) && (model != null))
            {
                string oldPath = Path.Combine(_env.WebRootPath, "AdminPanel/img/setting", dbEntity.Logo);
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
                string fileName = Guid.NewGuid().ToString() + "_" + model.file?.FileName;
                string newPath = Path.Combine(_env.WebRootPath, "AdminPanel/img/setting", fileName);
                using (FileStream stream = new FileStream(newPath, FileMode.Create))
                {
                    await model.file.CopyToAsync(stream);
                }
                model.Logo = fileName;

                _uow.GetRepository<Setting>().Update(model, dbEntity);

                await _uow.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _uow.GetRepository<Setting>().FindAsync(id);

            if (entity != null)
            {
                var path = Path.Combine(_env.WebRootPath, "AdminPanel/img/setting", entity.Logo);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                _uow.GetRepository<Setting>().Remove(entity);

                await _uow.SaveChangesAsync();
            }
        }
    }
}
