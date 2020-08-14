
using ArdalisRating.Abstractions;

namespace ArdalisRating {
    public abstract class PolicyEngine 
    {
        protected readonly ILogger logger;
        protected const decimal NO_RATE = 0m;

        public PolicyEngine(ILogger logger)
        {
            this.logger = logger;
        }

        public abstract decimal Rate(Policy policy);
    }
}