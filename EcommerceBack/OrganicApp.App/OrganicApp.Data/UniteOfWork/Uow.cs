using OrganicApp.Core.Entities;
using OrganicApp.Data.Contexts;
using OrganicApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Data.UniteOfWork
{
    public class Uow : IUow
    {
        private readonly OrganicAppDbContext _context;

        public Uow(OrganicAppDbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
