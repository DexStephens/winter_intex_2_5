using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.Collections.Generic;
using System.Linq;
using winter_intex_2_5.Models;
using winter_intex_2_5.Services;

namespace winter_intex_2_5.Pages
{
    public class WrappingPredictionModel : PageModel
    {
        public WrappingPrediction WrappingPrediction { get; set; }
        public WrappingData WrappingData { get; set; }
        public WrappingPredictionDefaults WrappingPredictionDefaults { get; set; }
        private InferenceSession _wrappingSession;
        public WrappingPredictionModel(InferenceSessions inferenceSessions)
        {
            _wrappingSession = inferenceSessions.WrappingSession;
            WrappingData = new WrappingData();
            WrappingPredictionDefaults = new WrappingPredictionDefaults();
        }
        public void OnGet()
        {
        }
        public void OnPost(WrappingData wrappingData)
        {
            WrappingData = new PredictionService().PopulateWrappingData(wrappingData);
            //do predictions here
            WrappingData = new WrappingMinMax().StandardizeWrapping(wrappingData);
            var result = _wrappingSession.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", wrappingData.AsTensor())
            });
            Tensor<string> score = result.First().AsTensor<string>();
            WrappingPrediction = new WrappingPrediction { Wrapping = score.First() };
            result.Dispose();
        }
    }
}
