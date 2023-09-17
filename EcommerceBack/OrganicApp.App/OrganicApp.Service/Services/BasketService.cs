﻿using Microsoft.EntityFrameworkCore;
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
    public class BasketService : IBasketService
    {
        private readonly OrganicAppDbContext _context;
        private readonly IUow _uow;

        public BasketService(OrganicAppDbContext context, IUow uow)
        {
            _context = context;
            _uow = uow;
        }

        public async Task CreateAsync(int userId, Product dto)
        {
            var test = await _context.Baskets.Where(x => x.AppUserId == userId).Where(x => x.ProductName == dto.Name).FirstOrDefaultAsync();

            if (test == null)
            {
                var entity = new Basket();
                entity.ProductName = dto.Name;
                entity.Image = dto.Image;
                entity.Price = dto.Price;
                entity.AppUserId = userId;
                entity.Count++;

                await _uow.GetRepository<Basket>().CreateAsync(entity);
                await _uow.SaveChangesAsync();
            }
            else
            {
                var entity = await _uow.GetRepository<Basket>().FindAsync(test.Id);
                test.Price += test.Price;
                test.Count++;
                _uow.GetRepository<Basket>().Update(test, entity);
                await _uow.SaveChangesAsync();
            }

        }


        public async Task<List<Basket>> GetAllAsync(int userID)
        {
            return await _context.Baskets.Include(x => x.AppUser).Where(x => x.AppUserId == userID).ToListAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _uow.GetRepository<Basket>().FindAsync(id);
            _uow.GetRepository<Basket>().Remove(entity);
            await _uow.SaveChangesAsync();
        }
    }
}
