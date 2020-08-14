
using ArdalisRating.Abstractions;

namespace ArdalisRating 
{
    sealed class AutoPolicyEngine : PolicyEngine 
    {
        public AutoPolicyEngine(IRatingUpdater ratingUpdater, ILogger logger) :
            base(logger, ratingUpdater)
        { }

        public override void Rate(Policy policy) 
        {
            logger.Log("Rating AUTO policy...");
            logger.Log("Validating policy.");
            if (string.IsNullOrEmpty(policy.Make))
            {
                logger.Log("Auto policy must specify Make");
                return;
            }

            if (policy.Make != "BMW")
                return;

            if (policy.Deductible < 500)
            {
                ratingUpdater.UpdateRating(1000m);
                return;
            }

            ratingUpdater.UpdateRating(900m);
        }
    }
}