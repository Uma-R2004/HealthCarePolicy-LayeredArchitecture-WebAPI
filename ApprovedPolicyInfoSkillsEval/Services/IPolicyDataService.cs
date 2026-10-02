using ApprovedPolicyInfoSkillsEval.Models;

namespace ApprovedPolicyInfoSkillsEval.Services
{
    public interface IPolicyDataService
    {
        Policy? GetPolicy(int policyNumber);
    }
}
