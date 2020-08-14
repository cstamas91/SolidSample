using ArdalisRating.Abstractions;
using System;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private readonly ILogger logger;
        private readonly IPolicySerializer policySerializer;
        private readonly IPolicySource policySource;
        private readonly PolicyEngineFactory policyEngineFactory;
        public decimal Rating { get; set; }

        public RatingEngine(
            ILogger logger, 
            IPolicySource policySource, 
            IPolicySerializer policySerializer,
            PolicyEngineFactory policyEngineFactory)
        {
            this.logger = logger;
            this.policySource = policySource;
            this.policySerializer = policySerializer;
            this.policyEngineFactory = policyEngineFactory;
        }

        public void Rate()
        {
            logger.Log("Starting rate.");
            logger.Log("Loading policy.");

            // load policy - open file policy.json
            string policyString = policySource.GetPolicyFromSource();
            var policy = policySerializer.GetPolicyFromJsonString(policyString);
            var policyEngine = policyEngineFactory.Create(policy);
            Rating = policyEngine.Rate(policy);


            logger.Log("Rating completed.");
        }
    }
}
