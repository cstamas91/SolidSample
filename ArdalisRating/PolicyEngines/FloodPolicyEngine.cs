
using ArdalisRating.Abstractions;

namespace ArdalisRating {
    sealed class FloodPolicyEngine : PolicyEngine 
    {
        public FloodPolicyEngine(IRatingUpdater ratingUpdater, ILogger logger) :
            base(logger, ratingUpdater)
        { }

        public override void Rate(Policy policy) 
        {
            logger.Log("Rating FLOOD policy...");
            logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0){
                logger.Log("Flood policy must specify bond amount and valuation");
                return;
            }

            if (policy.ElevationAboveSeaLevelFeet <= 0){
                logger.Log("Flood policy is not available for elevations at or below sea level");
                return;
            }

            decimal multiple = 1.0m;
            if (policy.ElevationAboveSeaLevelFeet < 100) {
                multiple = 2.0m;
            } else if (policy.ElevationAboveSeaLevelFeet < 500) {
                multiple = 1.5m;
            } else if (policy.ElevationAboveSeaLevelFeet < 1000) {
                multiple = 1.1m;
            }

            ratingUpdater.UpdateRating(policy.BondAmount * 0.05m * multiple);
        }
    }
}