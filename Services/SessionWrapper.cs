using Microsoft.ML.OnnxRuntime;

namespace winter_intex_2_5.Services
{
    public class SessionWrapper : ISession
    {
        public InferenceSession Session { get; }

        public SessionWrapper(InferenceSession session)
        {
            Session = session;
        }
    }

}
