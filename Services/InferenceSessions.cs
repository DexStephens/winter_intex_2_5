using Microsoft.ML.OnnxRuntime;

namespace winter_intex_2_5.Services
{
    public class InferenceSessions
    {
        public InferenceSession SexSession { get; set; }
        public InferenceSession WrappingSession { get; set; }

        public InferenceSessions(InferenceSession sexSession, InferenceSession wrappingSession)
        {
            SexSession = sexSession;
            WrappingSession = wrappingSession;
        }
    }

}
