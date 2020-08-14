
using ArdalisRating.Abstractions;

namespace ArdalisRating 
{
    sealed class AutoPolicyEngine : PolicyEngine 
    {
        public AutoPolicyEngine(ILogger logger) :
            base(logger)
        { }

        public override decimal Rate(Policy policy) 
        {
            logger.Log("Rating AUTO policy...");
            logger.Log("Validating policy.");
            if (string.IsNullOrEmpty(policy.Make))
            {
                logger.Log("Auto policy must specify Make");
                return 0m;
            }

            if (policy.Make != "BMW")
                return 0m;

            if (policy.Deductible < 500)
            {
                return 1000m;
            }

            return 900m;
        }
    }
}