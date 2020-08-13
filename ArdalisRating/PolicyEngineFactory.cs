using System;

namespace ArdalisRating {
    sealed class PolicyEngineFactory {
        public PolicyEngine Create(Policy policy, RatingEngine engine) {
            switch (policy.Type) {
                case PolicyType.Auto:
                    return new AutoPolicyEngine(engine, engine.Logger);
                case PolicyType.Land:
                    return new LandPolicyEngine(engine, engine.Logger);
                case PolicyType.Life:
                    return new LifePolicyEngine(engine, engine.Logger);
                case PolicyType.Flood:
                    return new FloodPolicyEngine(engine, engine.Logger);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}