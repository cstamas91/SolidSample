using ArdalisRating.Utils;
using System;

namespace ArdalisRating
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ardalis Insurance Rating System Starting...");
            var logger = new FileLogger();
            var policySource = new FilePolicySource();
            var policySerializer = new PolicySerializer();
            var engineFactory = new PolicyEngineFactory(logger);
            var engine = new RatingEngine(
                logger,
                policySource,
                policySerializer,
                engineFactory);

            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }
        }
    }
}
