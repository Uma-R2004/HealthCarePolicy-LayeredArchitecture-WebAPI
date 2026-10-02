namespace ApprovedPolicyInfoSkillsEval.Models
{
    public class Policy
    {
        public int PolicyNumber { get; set; }

        public string PolicyName { get; set; } = string.Empty;

        public string ApprovedInsuranceCoverages { get; set; } = string.Empty;

        public int AvailablePremium { get; set; }

        public DateTime RequestDate { get; set; }

        public string QuoteLetterUrl { get; set; } = string.Empty;
    }
}
