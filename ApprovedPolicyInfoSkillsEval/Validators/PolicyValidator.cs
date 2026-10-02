namespace ApprovedPolicyInfoSkillsEval.Validators
{
    public class PolicyValidator
    {
        public static bool IsValidPolicyNumber(int policyNumber)
        {
            string policyNumberText = policyNumber.ToString();

            // Must be exactly 8 digits.
            if (policyNumberText.Length != 8)
            {
                return false;
            }

            // The 6th digit must be 5.
            if (policyNumberText[5] != '5')
            {
                return false;
            }

            return true;
        }
    }
}
