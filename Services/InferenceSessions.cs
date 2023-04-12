using Microsoft.ML.OnnxRuntime;

namespace winter_intex_2_5.Services
{
    public class InferenceSessions
    {
        public InferenceSession PredictSexSession { get; set; }
        public InferenceSession WrappingSession { get; set; }

        public InferenceSessions(InferenceSession predictSexSession, InferenceSession wrappingSession)
        {
            PredictSexSession = predictSexSession;
            WrappingSession = wrappingSession;
        }
    }

}
