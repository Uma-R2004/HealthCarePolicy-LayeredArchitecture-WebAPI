using ApprovedPolicyInfoSkillsEval.Validators;
using Xunit;

namespace ApprovedPolicyInfoSkillsEval.Test
{
    public class UnitTest1
    {
        [Fact]
        public void IsValidPremium_ShouldReturnTrue_WhenPremiumIsGreaterThanZero()
        {
            // Arrange--  get 
            var validator = new PremiumValidator();
            int premium = 5000;

            // Act --- action
            bool result = validator.isValidPremium(premium);

            // Assert --response
            Assert.True(result);
        }

        [Fact]
        public void IsValidPremium_ShouldReturnFalse_WhenPremiumIsZero()
        {
            // Arrange
            var validator = new PremiumValidator();
            int premium = 0;

            // Act
            bool result = validator.isValidPremium(premium);

            // Assert
            Assert.False(result);
        }
    }
}
