using ArdalisRating.Abstractions;
using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;

namespace ArdalisRating.Tests
{
    class FakePolicySource : IPolicySource
    {
        public string PolicyString { get; set; } = "";

        public string GetPolicyFromSource()
        {
            return PolicyString;
        }
    }

    public class RatingEngineRate
    {
        [Fact]
        public void ReturnsRatingOf10000For200000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 200000
            };
            string json = JsonConvert.SerializeObject(policy);
            var policySource = new FakePolicySource()
            {
                PolicyString = json
            };
            ILogger logger = new ConsoleLogger();
            var factory = new PolicyEngineFactory(logger);
            var engine = new RatingEngine(logger, policySource, new PolicySerializer(), factory);
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(10000, result);
        }

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            string json = JsonConvert.SerializeObject(policy);
            var policySource = new FakePolicySource
            {
                PolicyString = json
            };
            ILogger logger = new ConsoleLogger();
            var factory = new PolicyEngineFactory(logger);
            var engine = new RatingEngine(logger, policySource, new PolicySerializer(), factory);
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(0, result);
        }
    }
}
