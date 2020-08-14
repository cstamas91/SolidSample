
using ArdalisRating.Abstractions;

namespace ArdalisRating
{
    sealed class UnknownPolicyEngine : PolicyEngine
    {
        public UnknownPolicyEngine(ILogger logger) :
            base(logger)
        { }

        public override decimal Rate(Policy policy)
        {
            logger.Log("Unknown policy type");
            return NO_RATE;
        }
    }
}
