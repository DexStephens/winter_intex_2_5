using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime;
using System.Collections.Generic;
using winter_intex_2_5.Models;

namespace winter_intex_2_5.Controllers
{
    public class InferenceController : Controller
    {
        private InferenceSession _inferenceSession;

        public InferenceController(InferenceSession inferenceSession)
        {
            _inferenceSession = inferenceSession;
        }

        [HttpPost]
        public IActionResult Score(SexData sexData)
        {
            return View();
        }
    }
}