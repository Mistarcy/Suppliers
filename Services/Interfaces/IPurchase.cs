using Suppliers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suppliers.Services.Interfaces
{
    public interface IPurchase
    {
        Task<bool> Add(Purchase purchase);

        Task<Purchase> Find(int id);

        Task<int> Update(Purchase purchase);

        Task<int> Delete(int id);

        Task<bool> Exists(int id);
    }
}
