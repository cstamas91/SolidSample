using System.IO;
using ArdalisRating.Abstractions;

namespace ArdalisRating 
{
    public class FilePolicySource : IPolicySource
    {
        public string GetPolicyFromSource()
        {
            return File.ReadAllText("policy.json");
        }
    }
}