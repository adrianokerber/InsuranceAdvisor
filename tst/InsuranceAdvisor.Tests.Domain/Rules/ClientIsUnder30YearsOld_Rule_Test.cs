using FluentAssertions;
using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Rules;
using InsuranceAdvisor.Tests.Domain.Models.Factories;
using Xunit;

namespace InsuranceAdvisor.Tests.Domain.Rules
{
    public class ClientIsUnder30YearsOld_Rule_Test
    {
        [Fact]
        [Trait("Success", "")]
        public void When_ClientIsUnder30YearsOld_Expect_EachInsuranceLineToDeduct2ScorePoints()
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithAge(29);
            var rule = new ClientUnder30YearsOld();
            var insuranceLinesScore = new InsuranceLinesScore();

            // Act
            var ruleMatches = rule.MatchCondition(clientProfile);
            rule.ApplyScore(insuranceLinesScore);

            // Assert
            ruleMatches
                .Should().BeTrue();
            insuranceLinesScore.Life.Score
                .Should().Be(-2);
            insuranceLinesScore.Disability.Score
                .Should().Be(-2);
            insuranceLinesScore.Home.Score
                .Should().Be(-2);
            insuranceLinesScore.Auto.Score
                .Should().Be(-2);
        }
    }
}
