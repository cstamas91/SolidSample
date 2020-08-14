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
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        private PolicySerializer PolicySerializer { get; set; } = new PolicySerializer();
        private FilePolicySource PolicySource { get; set; } = new FilePolicySource();
        private PolicyEngineFactory Factory { get; set; } = new PolicyEngineFactory();
        public decimal Rating { get; set; }
        public void Rate()
        {
            Logger.Log("Starting rate.");
            Logger.Log("Loading policy.");

            // load policy - open file policy.json
            string policyJson = PolicySource.GetPolicyFromSource();

            var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);
            var policyEngine = Factory.Create(policy, this);
            policyEngine.Rate(policy);


            Logger.Log("Rating completed.");
        }
    }
}
