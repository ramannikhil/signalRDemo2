using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly EmployeeDBContext _context;
        //private readonly IEmployeeRepository _repository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //public HomeController(ILogger<HomeController> logger, IEmployeeRepository repository, EmployeeDBContext context)
        //{
        //    _logger = logger;
        //    _repository = repository;
        //    _context = context;
        //}


        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult GetEmployees()
        //{
        //    return Ok(_repository.GetAllEmployees());
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
