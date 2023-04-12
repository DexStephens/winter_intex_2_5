using Microsoft.ML.OnnxRuntime;

namespace winter_intex_2_5.Services
{
    public class ISession
    {
        InferenceSession Session { get; }
    }
}
