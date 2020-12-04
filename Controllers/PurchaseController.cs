using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Suppliers.Data;
using Suppliers.Models;
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
        private readonly MyDbContext _context;

        public PurchasesController(MyDbContext context)
        {
            _context = context;
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

            var puarchase = await _context.Purchase.FindAsync(id);

            if (puarchase == null)
            {
                return NotFound();
            }

            return Ok(puarchase);
        }

        // PUT: api/Puarchases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuarchase([FromForm] int id, [FromForm] Purchase puarchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != puarchase.id)
            {
                return BadRequest();
            }

            _context.Entry(puarchase).State = EntityState.Modified;

            try
            {
                int num = await _context.SaveChangesAsync();
                if (num > 0)
                {
                    return Ok(new { code = true, msg = "success" });
                }
                else
                {
                    return Ok(new { code = false, msg = "failure" });
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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

            _context.Purchase.Add(purchase);
            await _context.SaveChangesAsync();
            var num = await _context.SaveChangesAsync();
            if (num > 0)
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

            var purchase = await _context.Purchase.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            _context.Purchase.Remove(purchase);
            await _context.SaveChangesAsync();

            return Ok(purchase);
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchase.Any(e => e.id == id);
        }
    }
}
