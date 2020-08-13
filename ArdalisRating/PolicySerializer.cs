using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating {
    public sealed class PolicySerializer {
        public Policy GetPolicyFromJsonString(string policyJson) {
            return JsonConvert.DeserializeObject<Policy>(
                policyJson,
                new StringEnumConverter());
        }
    }
}