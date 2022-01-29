using FluentAssertions;
using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Rules;
using InsuranceAdvisor.Tests.Domain.Models.Factories;
using Xunit;

namespace InsuranceAdvisor.Tests.Domain.Rules
{
    public class ClientIsBetween30and40YearsOld_Rule_Test
    {
        [Theory]
        [InlineData(30)]
        [InlineData(35)]
        [InlineData(40)]
        [Trait("Success", "")]
        public void When_ClientIsBetween30and40YearsOld_Expect_EachInsuranceLineToDeduct1ScorePoint(int age)
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithAge(age);
            var rule = new ClientBetween30and40YearsOld();
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
