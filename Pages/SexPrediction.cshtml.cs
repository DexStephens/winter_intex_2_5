using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.ML.OnnxRuntime.Tensors;
using Microsoft.ML.OnnxRuntime;
using System.Collections.Generic;
using System;
using winter_intex_2_5.Models;
using winter_intex_2_5.Services;
using System.Linq;

namespace winter_intex_2_5.Pages
{
    public class SexPredictionModel : PageModel
    {
        public SexData SexData { get; set; }
        public SexPrediction SexPrediction { get; set; }
        public SexPredictionDefaults SexPredictionDefaults {get; set; }
        private InferenceSession _sexSession;
        public SexPredictionModel(InferenceSessions inferenceSessions)
        {
            SexPredictionDefaults = new SexPredictionDefaults();
            SexData = new SexData();
            _sexSession = inferenceSessions.SexSession;
        }
        public void OnGet()
        {
        }
        public void OnPost(SexData sexData)
        {
            SexData = new PredictionService().PopulateSexData(sexData);
            //do the prediction stuff here
            var result = _sexSession.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", sexData.AsTensor())
            });
            Tensor<Int64> score = result.First().AsTensor<Int64>();
            SexPrediction = new SexPrediction { Sex = score.First() };
            result.Dispose();
        }
    }
}
