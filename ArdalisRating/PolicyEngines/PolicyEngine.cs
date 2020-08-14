
using ArdalisRating.Abstractions;

namespace ArdalisRating {
    abstract class PolicyEngine 
    {
        protected readonly ILogger logger;
        protected readonly IRatingUpdater ratingUpdater;

        public PolicyEngine(ILogger logger, IRatingUpdater ratingUpdater)
        {
            this.logger = logger;
            this.ratingUpdater = ratingUpdater;
        }

        public abstract void Rate(Policy policy);
    }
}