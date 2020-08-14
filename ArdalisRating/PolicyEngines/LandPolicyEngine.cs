
using ArdalisRating.Abstractions;

namespace ArdalisRating {
    sealed class LandPolicyEngine : PolicyEngine 
    {
        public LandPolicyEngine(ILogger logger) :
            base(logger)
        { }

        public override decimal Rate(Policy policy) 
        {
            logger.Log("Rating LAND policy...");
            logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                logger.Log("Land policy must specify Bond Amount and Valuation.");
                return NO_RATE;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                logger.Log("Insufficient bond amount.");
                return NO_RATE;
            }
            return policy.BondAmount * 0.05m;
        }
    }
}