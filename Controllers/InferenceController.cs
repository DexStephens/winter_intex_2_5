using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Linq;
using winter_intex_2_5.Models;
using winter_intex_2_5.Services;

namespace winter_intex_2_5.Controllers
{
    public class InferenceController : Controller
    {
        private InferenceSession _predictSexSession;
        private InferenceSession _predictWrappingSession;

        public InferenceController(InferenceSessions inferenceSessions)
        {
            _predictSexSession = inferenceSessions.PredictSexSession;
            _predictWrappingSession = inferenceSessions.WrappingSession;
        }

        public IActionResult Sex()
        {
            return View();
        }

        public IActionResult Wrapping()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ScoreSex(SexData sexData)
        {
            var result = _predictSexSession.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", sexData.AsTensor())
            });
            Tensor<string> score = result.First().AsTensor<string>();
            var prediction = new SexPrediction { Sex = Convert.ToInt32(score.First()) };
            result.Dispose();
            return Ok(prediction);
        }
        [HttpPost]
        public IActionResult ScoreWrapping(WrappingData wrappingData)
        {
            var result = _predictWrappingSession.Run(new List<NamedOnnxValue>
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