using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using winter_intex_2_5.Data.Repositories;
using winter_intex_2_5.Models;

namespace winter_intex_2_5.Controllers
{
    [Authorize(Roles ="administrator,researcher")]
    public class RecordsController : Controller
    {
        private IMummyRepository _mummyRepository;
        private MummyContext _mummyContext;

        public RecordsController(IMummyRepository mummyRepository, MummyContext mummyContext)
        {
            _mummyRepository = mummyRepository;
            _mummyContext = mummyContext;
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

        public IActionResult DeleteConfirmation()
        {
            long burialId = Convert.ToInt64(Request.Form["burialId"]);
            var burialMain = _mummyRepository.Burialmains.Single(x => x.Id == burialId);
            return View(burialMain);
        }

        [HttpPost]
        public IActionResult Delete()
        {
            long burialId = Convert.ToInt64(Request.Form["burialId"]);
            var burialMain = _mummyRepository.Burialmains.Single(x => x.Id == burialId);
            _mummyContext.Remove(burialMain);
            _mummyContext.SaveChanges();
            return RedirectToAction("Success", new { newRecord = false });
        }

        [HttpPost]
        public IActionResult CreateUpdate(Burialmain burialmain)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if (burialmain.Id != 0)
                    {
                        //edit record
                        _mummyContext.Update(burialmain);
                    }
                    else
                    {
                        //add record
                        _mummyContext.Add(burialmain);
                    }
                    _mummyContext.SaveChanges();
                    return RedirectToAction("Success", new {newRecord = true});
                }
                catch
                {
                    return View("Index", burialmain);
                }
                
            }
            return View("Index", burialmain);
        }

        public IActionResult Success(bool newRecord)
        {
            return View(newRecord);
        }

    }
}
