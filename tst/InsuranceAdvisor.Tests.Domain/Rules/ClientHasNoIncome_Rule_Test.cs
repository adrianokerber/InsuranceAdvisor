using FluentAssertions;
using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Rules;
using InsuranceAdvisor.Tests.Domain.Models.Factories;
using Xunit;

namespace InsuranceAdvisor.Tests.Domain.Rules
{
    public class ClientHasNoIncome_Rule_Test
    {
        #region Success cases
        [Fact]
        [Trait("Success", "")]
        public void When_ClientHasNoIncome_Expect_DisabilityInsuranceLineToBeIneligible()
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithIncome(0);
            var rule = new ClientHasNoIncome();
            var insuranceLinesScore = new InsuranceLinesScore();

            // Act
            var ruleMatches = rule.MatchCondition(clientProfile);
            rule.ApplyScore(insuranceLinesScore);

            // Assert
            ruleMatches
                .Should().BeTrue();
            insuranceLinesScore.Disability.IsIneligible
                .Should().BeTrue();

        }
        #endregion

        #region Error cases
        [Fact]
        [Trait("Error", "")]
        public void When_ClientHasIncome_Expect_ToSkipThisRule()
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithIncome(1);
            var rule = new ClientHasNoIncome();
            var insuranceLinesScore = new InsuranceLinesScore();

            // Act
            var ruleMatches = rule.MatchCondition(clientProfile);
            rule.ApplyScore(insuranceLinesScore);

            // Assert
            ruleMatches
                .Should().BeFalse();

        }
        #endregion
    }
}
