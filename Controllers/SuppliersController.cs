//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Suppliers.Data;

//namespace Suppliers.Controllers
//{
//    [Route("api/[controller]")]
//    public class SuppliersController : Controller
//    {
//        private MyDbContext _dbcontext;
//        public SuppliersController(MyDbContext dbContext)
//        {
//            _dbcontext = dbContext;
//        }
//        // GET api/supplier
//        [HttpGet]
//        public IActionResult Get()
//        {
//            var arc = _dbcontext.Supplierdata.FirstOrDefault();
//            return Json(arc);
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }
//        public IActionResult Purchase(string employmentID, int stock = 1)
//        {
//            ViewData["EmploymentID"] = "name" + employmentID;
//            ViewData["Stock"] = stock;
//            return View();
//        }
//    }
//}
