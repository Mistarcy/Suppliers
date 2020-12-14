using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Suppliers.Data;
using Suppliers.Models;
using Suppliers.Services;
using Suppliers.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suppliers.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchase _purchaseService;

        //private readonly MyDbContext _context;

        public PurchasesController(IPurchase purchaseService)
        {
            this._purchaseService = purchaseService;
        }

        // GET: api/Purchases
        [HttpGet]
        //public IEnumerable<Purchase> GetPuarchase()
        //{
        //    return _context.Purchase;
        //}

        // GET: api/Puarchases/5
        [HttpGet]
        public async Task<IActionResult> GetPuarchase([FromQuery] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var puarchase = await _context.Purchase.FindAsync(id);
            var puarchase = await _purchaseService.Find(id);
            if (puarchase == null)
            {
                return NotFound();
            }

            return Ok(puarchase);
        }

        // PUT: api/Puarchases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuarchase([FromForm] int id, [FromForm] Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchase.id)
            {
                return BadRequest();
            }



            int num = await _purchaseService.Update(purchase);
            if (num > 0)
            {
                return Ok(new { code = true, msg = "success" });
            }
            else
            {
                return Ok(new { code = false, msg = "failure" });
            }
        }

        // POST: api/Purchases
        [HttpPost]
        public async Task<IActionResult> PostPurchase([FromForm] Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            //_context.Purchase.Add(purchase);
            //await _context.SaveChangesAsync();
            //var num = await _context.SaveChangesAsync();
            var res = await _purchaseService.Add(purchase);

            if (res)
            {
                return Ok(new { code = true, msg = "success" });
            }
            else
            {
                return Ok(new { code = false, msg = "failure" });
            }
        }

        // DELETE: api/Purchases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase([FromForm] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var purchase = await _purchaseService.Delete(id);
            return Ok(purchase);
        }

        private async Task<IActionResult> PurchaseExists(int id)
        {
            var res = await _purchaseService.Exists(id);
            return Ok(res);
        }

    }
}
