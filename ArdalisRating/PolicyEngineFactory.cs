using System;

namespace ArdalisRating {
    sealed class PolicyEngineFactory
    {
        public PolicyEngine Create(Policy policy, RatingEngine engine) 
        {
            try
            {
                return (PolicyEngine)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyEngine"),
                    new object[] { engine, engine.Logger });
            }
            catch
            {
                return new UnknownPolicyEngine(engine, engine.Logger);
            }
        }
    }
}