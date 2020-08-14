using ArdalisRating.Abstractions;
using System;

namespace ArdalisRating {
    public sealed class PolicyEngineFactory
    {
        private readonly ILogger logger;

        public PolicyEngineFactory(ILogger logger)
        {
            this.logger = logger;
        }

        public PolicyEngine Create(Policy policy) 
        {
            try
            {
                return (PolicyEngine)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyEngine"),
                    new object[] { logger });
            }
            catch
            {
                return new UnknownPolicyEngine(logger);
            }
        }
    }
}