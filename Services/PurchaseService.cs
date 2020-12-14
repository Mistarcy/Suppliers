using Microsoft.EntityFrameworkCore;
using Suppliers.Data;
using Suppliers.Models;
using Suppliers.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suppliers.Services
{
    public class PurchaseService : IPurchase
    {
        private readonly MyDbContext _dbContext;

        public PurchaseService(MyDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<bool> Add(Purchase purchase)
        {
            _dbContext.Purchase.Add(purchase);
            var res = await _dbContext.SaveChangesAsync();
            return res > 0 ? true : false;
        }

        public async Task<int> Delete(int id)
        {
            var purchase = await _dbContext.Purchase.FindAsync(id);
             _dbContext.Purchase.Remove(purchase);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _dbContext.Purchase.AnyAsync(e => e.id == id);
        }

        public async Task<Purchase> Find(int id)
        {
            return await _dbContext.Purchase.FindAsync(id);
        }

        public async Task<int> Update(Purchase purchase)
        {
            _dbContext.Entry(purchase).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }

       
    }
}