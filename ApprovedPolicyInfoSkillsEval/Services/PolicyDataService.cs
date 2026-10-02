using ApprovedPolicyInfoSkillsEval.Models;

namespace ApprovedPolicyInfoSkillsEval.Services
{
    public class PolicyDataService : IPolicyDataService
    {
        private readonly IConfiguration _configuration;
        public PolicyDataService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Mock database.
        private readonly List<Policy> _policies = new()
        {
            new Policy
            {
                PolicyNumber = 34343538,
                PolicyName = "Blue Waters Inc.",
                AvailablePremium = 8000
            },
            new Policy
            {
                PolicyNumber = 58343582,
                PolicyName = "Silver Rock LLC",
                AvailablePremium = 150000
            }
        };

      

        public Policy? GetPolicy(int policyNumber)
        {
            // Find the policy in the mock data store.
            var policy = _policies.FirstOrDefault(p => p.PolicyNumber == policyNumber);

            if (policy == null)
            {
                return null;
            }

            // Fill computed/generated properties.
            policy.ApprovedInsuranceCoverages = GetApprovedInsuranceCoverages(policy.AvailablePremium);
            policy.RequestDate = DateTime.Today;

            var baseUrl = _configuration["QuoteLetterSettings:BaseUrl"] ?? "dev.quoteLetter.com";
            policy.QuoteLetterUrl = $"{baseUrl}/{policy.PolicyNumber}";

            return policy;
        }

        private string GetApprovedInsuranceCoverages(int availablePremium)
        {
            string[] coverageNames = { "Auto", "Rental", "Pet" };
            int[] coverageCosts = { 8000, 5000, 2000 };

            var approvedCoverages = new List<string>();

            // Greedy calculation based on the given order.
            for (int i = 0; i < coverageNames.Length; i++)
            {
                if (availablePremium >= coverageCosts[i])
                {
                    approvedCoverages.Add(coverageNames[i]);
                    availablePremium -= coverageCosts[i];
                }
            }

            if (approvedCoverages.Count == 0)
            {
                return "No Insurance Coverages Available";
            }

            return string.Join(", ", approvedCoverages);
        }
    }
}
