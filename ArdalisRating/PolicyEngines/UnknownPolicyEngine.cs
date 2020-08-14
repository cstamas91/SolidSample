
using ArdalisRating.Abstractions;

namespace ArdalisRating
{
    sealed class UnknownPolicyEngine : PolicyEngine
    {
        public UnknownPolicyEngine(IRatingUpdater ratingUpdater, ILogger logger) :
            base(logger, ratingUpdater)
        { }

        public override void Rate(Policy policy)
        {
            logger.Log("Unknown policy type");
        }
    }
}
