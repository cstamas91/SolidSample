
namespace ArdalisRating
{
    sealed class UnknownPolicyEngine : PolicyEngine
    {
        private readonly RatingEngine engine;
        private readonly ConsoleLogger logger;

        public UnknownPolicyEngine(RatingEngine engine, ConsoleLogger logger)
        {
            this.engine = engine;
            this.logger = logger;
        }

        public override void Rate(Policy policy)
        {
            logger.Log("Unknown policy type");
        }
    }
}
