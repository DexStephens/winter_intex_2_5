namespace winter_intex_2_5.Services
{
    public class InferenceSessions
    {
        public SessionWrapper PredictSexSession { get; set; }
        public SessionWrapper WrappingSession { get; set; }

        public InferenceSessions(SessionWrapper predictSexSession, SessionWrapper wrappingSession)
        {
            PredictSexSession = predictSexSession;
            WrappingSession = wrappingSession;
        }
    }

}
