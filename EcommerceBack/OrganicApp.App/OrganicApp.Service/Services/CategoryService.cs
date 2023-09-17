using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using OrganicApp.Core.Entities;
using OrganicApp.Data.Contexts;
using OrganicApp.Data.UniteOfWork;
using OrganicApp.Service.Services.Interface;
using OrganicApp.Service.Utilities.Paginations;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUow _uow;
        private readonly OrganicAppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CategoryService(IUow uow, OrganicAppDbContext context, IWebHostEnvironment env)
        {
            _uow = uow;
            _context = context;
            _env = env;
        }
        public List<Category> GetCategories()
        {
            var list = _context.Categories?.OrderBy(x => x.Id).ToList();

            return list;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var entities = await _context.Categories.Include(x => x.Products).OrderByDescending(x => x.Id).ToListAsync();

            return entities;
        }

        public async Task CreateAsync(Category model)
        {
            if (model != null)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + model.Photo?.FileName;
                string path = Path.Combine(_env.WebRootPath, "AdminPanel/img/category", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await model.Photo.CopyToAsync(stream);
                }
                model.Image = fileName;

                await _uow.GetRepository<Category>().CreateAsync(model);

                await _uow.SaveChangesAsync();
            }
        }

        public async Task<Category> GetById(int id)
        {
            var entity = await _uow.GetRepository<Category>().FindAsync(id);

            return entity;
        }

        public async Task<Category> GetByIdUpdate(int id)
        {
            var entity = await _uow.GetRepository<Category>().FindAsync(id);

            return entity;
        }

        public async Task Update(Category model)
        {
            var DbEntity = await _uow.GetRepository<Category>().FindAsync(model.Id);

            if ((DbEntity != null) || (model != null))
            {
                string oldPath = Path.Combine(_env.WebRootPath, "AdminPanel/img/category", DbEntity.Image);
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
                string fileName = Guid.NewGuid().ToString() + "_" + model.Photo?.FileName;
                string newPath = Path.Combine(_env.WebRootPath, "AdminPanel/img/category", fileName);
                using (FileStream stream = new FileStream(newPath, FileMode.Create))
                {
                    await model.Photo.CopyToAsync(stream);
                }
                model.Image = fileName;

                _uow.GetRepository<Category>().Update(model, DbEntity);

                await _uow.SaveChangesAsync();
            }
        }

        public async Task Remove(int id)
        {
            var entity = await _uow.GetRepository<Category>().FindAsync(id);

            if (entity != null)
            {
                var path = Path.Combine(_env.WebRootPath, "AdminPanel/img/category", entity.Image);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                _uow.GetRepository<Category>().Remove(entity);

                await _uow.SaveChangesAsync();
            }
        }
    }
}
