using FluentAssertions;
using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Rules;
using InsuranceAdvisor.Tests.Domain.Models.Factories;
using Xunit;

namespace InsuranceAdvisor.Tests.Domain.Rules
{
    public class ClientHasNoHouse_Rule_Test
    {
        [Fact]
        [Trait("Success", "")]
        public void When_ClientHasNoHouse_Expect_HomeInsuranceLineToBeIneligible()
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithHouse(null);
            var rule = new ClientHasNoHouse();
            var insuranceLinesScore = new InsuranceLinesScore();

            // Act
            var ruleMatches = rule.MatchCondition(clientProfile);
            rule.ApplyScore(insuranceLinesScore);

            // Assert
            ruleMatches
                .Should().BeTrue();
            insuranceLinesScore.Home.IsIneligible
                .Should().BeTrue();
        }
    }
}
