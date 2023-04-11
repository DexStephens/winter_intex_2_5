using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using winter_intex_2_5.Data.Repositories;
using winter_intex_2_5.Models;

namespace winter_intex_2_5.Controllers
{
    public class HomeController : Controller
    {
        private IMummyRepository _mummyRepository;

        public HomeController(IMummyRepository mummyRepository)
        {
            _mummyRepository = mummyRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Researcher")]
        public IActionResult Summary()
        {
            var burials = _mummyRepository.Burialmains.ToList();
            return View(burials);
        }

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
