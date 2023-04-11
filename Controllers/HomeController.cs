using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using winter_intex_2_5.Data.Repositories;
using winter_intex_2_5.Models;
using winter_intex_2_5.Services;

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
        public IActionResult Summary()
        {
            List<SummaryTableRowItem> summaryTableRowItems = new SummaryTableService(_mummyRepository).OriginalLoadBurials();
            return View(summaryTableRowItems);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Burials()
        {
            return View();
        }

        public IActionResult Predictions()
        {
            return View();
        }

        public IActionResult Analysis()
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
