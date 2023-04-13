using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using winter_intex_2_5.Data.Repositories;
using winter_intex_2_5.Models;

namespace winter_intex_2_5.Controllers
{
    [Authorize(Roles ="administrator,researcher")]
    public class RecordsController : Controller
    {
        private IMummyRepository _mummyRepository;

        public RecordsController(IMummyRepository mummyRepository)
        {
            _mummyRepository = mummyRepository;
        }
        public IActionResult Index(long burialId = 0)
        {
            var burialMain = new Burialmain();
            if(burialId != 0)
            {
                ViewBag.Editing = true;
                burialMain = _mummyRepository.Burialmains.Single(x => x.Id == burialId);
            }
            
            return View(burialMain);
        }
    }
}
