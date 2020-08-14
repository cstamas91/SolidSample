
using ArdalisRating.Abstractions;

namespace ArdalisRating {
    sealed class LandPolicyEngine : PolicyEngine 
    {
        public LandPolicyEngine(IRatingUpdater ratingUpdater, ILogger logger) :
            base(logger, ratingUpdater)
        { }

        public override void Rate(Policy policy) 
        {
            logger.Log("Rating LAND policy...");
            logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                logger.Log("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                logger.Log("Insufficient bond amount.");
                return;
            }
            ratingUpdater.UpdateRating(policy.BondAmount * 0.05m);
        }
    }
}