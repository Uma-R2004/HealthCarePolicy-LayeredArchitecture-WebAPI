using ApprovedPolicyInfoSkillsEval.Services;
using ApprovedPolicyInfoSkillsEval.Validators;
using Microsoft.AspNetCore.Mvc;

//If     is not working
// use --- https://localhost:49700/api/Policy/ApprovedPolicyInfo/34343538
// or Use -- https://localhost:49700/swagger

namespace ApprovedPolicyInfoSkillsEval.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyDataService _policyDataService;

        public PolicyController(IPolicyDataService policyDataService)
        {
            _policyDataService = policyDataService;
        }

        // POST: api/Policy/ApprovedPolicyInfo/34343538
        [HttpPost("ApprovedPolicyInfo/{policyNumber}")]
        public IActionResult ApprovedPolicyInfo(int policyNumber)
        {
            // Validate the incoming policy number.
            if (!PolicyValidator.IsValidPolicyNumber(policyNumber))
            {
                return BadRequest("Invalid policy number.");
            }

            // Get the policy from the service.
            var policy = _policyDataService.GetPolicy(policyNumber);

            // If not found in the mock database, return bad request.
            if (policy == null)
            {
                return BadRequest("Policy not found.");
            }

            return Ok(policy);
        }
    }
}
