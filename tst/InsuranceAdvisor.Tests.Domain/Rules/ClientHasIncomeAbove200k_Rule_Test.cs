using FluentAssertions;
using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Rules;
using InsuranceAdvisor.Tests.Domain.Models.Factories;
using Xunit;

namespace InsuranceAdvisor.Tests.Domain.Rules
{
    public class ClientHasIncomeAbove200k_Rule_Test
    {
        [Fact]
        [Trait("Success", "")]
        public void When_ClientHasIncomeAbove200k_Expect_AllLinesOfInsuranceToHave1DeductedFromScore()
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithIncome(200_001);
            var rule = new ClientHasIncomeAbove200Thousand();
            var insuranceLinesScore = new InsuranceLinesScore();

            // Act
            var ruleMatches = rule.MatchCondition(clientProfile);
            rule.ApplyScore(insuranceLinesScore);

            // Assert
            ruleMatches
                .Should().BeTrue();
            insuranceLinesScore.Life.Score
                .Should().Be(-1);
            insuranceLinesScore.Disability.Score
                .Should().Be(-1);
            insuranceLinesScore.Home.Score
                .Should().Be(-1);
            insuranceLinesScore.Auto.Score
                .Should().Be(-1);
        }
    }
}
