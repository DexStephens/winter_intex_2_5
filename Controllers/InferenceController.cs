using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult ScoreSex(SexData sexData)
        {
            return View();
        }
        [HttpPost]
        public IActionResult ScoreWrapping(WrappingData wrappingData)
        {
            var result = _inferenceSession.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", wrappingData.AsTensor())
            });
            Tensor<string> score = result.First().AsTensor<string>();
            var prediction = new WrappingPrediction { Wrapping = score.First() };
            result.Dispose();
            return Ok(prediction);
        }
    }
}