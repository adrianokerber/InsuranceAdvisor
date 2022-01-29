using FluentAssertions;
using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Rules;
using InsuranceAdvisor.Tests.Domain.Models.Factories;
using Xunit;

namespace InsuranceAdvisor.Tests.Domain.Rules
{
    public class ClientIsOver60YearsOld_Rule_Test
    {
        [Fact]
        [Trait("Success", "")]
        public void When_ClientIsOver60YearsOld_Expect_LifeAndDisabilityInsuranceLinesToBeIneligible()
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithAge(61);
            var rule = new ClientOver60YearsOld();
            var insuranceLinesScore = new InsuranceLinesScore();

            // Act
            var ruleMatches = rule.MatchCondition(clientProfile);
            rule.ApplyScore(insuranceLinesScore);

            // Assert
            ruleMatches
                .Should().BeTrue();
            insuranceLinesScore.Life.IsIneligible
                .Should().BeTrue();
            insuranceLinesScore.Disability.IsIneligible
                .Should().BeTrue();
        }
    }
}
