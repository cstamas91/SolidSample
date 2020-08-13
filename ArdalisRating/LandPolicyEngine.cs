
namespace ArdalisRating {
    sealed class LandPolicyEngine : PolicyEngine {
        private readonly ConsoleLogger _logger;
        private readonly RatingEngine _engine;

        public LandPolicyEngine(RatingEngine engine, ConsoleLogger logger) {
            _engine = engine;
            _logger = logger;
        }

        public override void Rate(Policy policy) {
            _logger.Log("Rating LAND policy...");
            _logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                _logger.Log("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                _logger.Log("Insufficient bond amount.");
                return;
            }
            _engine.Rating = policy.BondAmount * 0.05m;
        }
    }
}