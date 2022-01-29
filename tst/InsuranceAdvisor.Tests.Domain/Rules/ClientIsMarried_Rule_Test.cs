using FluentAssertions;
using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Rules;
using InsuranceAdvisor.Tests.Domain.Models.Factories;
using Xunit;

namespace InsuranceAdvisor.Tests.Domain.Rules
{
    public class ClientIsMarried_Rule_Test
    {
        [Fact]
        [Trait("Success", "")]
        public void When_ClientIsMarried_Expect_LifeInsuranceToAdd1AndDisabilityInsuranceToDeduct1FromScore()
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithMartialStatus(MartialStatus.Married);
            var rule = new ClientIsMarried();
            var insuranceLinesScore = new InsuranceLinesScore();

            // Act
            var ruleMatches = rule.MatchCondition(clientProfile);
            rule.ApplyScore(insuranceLinesScore);

            // Assert
            ruleMatches
                .Should().BeTrue();
            insuranceLinesScore.Life.Score
                .Should().Be(1);
            insuranceLinesScore.Disability.Score
                .Should().Be(-1);
        }
    }
}
