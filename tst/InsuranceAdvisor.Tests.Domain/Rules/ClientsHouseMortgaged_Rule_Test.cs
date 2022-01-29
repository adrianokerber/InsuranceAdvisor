using FluentAssertions;
using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Rules;
using InsuranceAdvisor.Tests.Domain.Models.Factories;
using Xunit;

namespace InsuranceAdvisor.Tests.Domain.Rules
{
    public class ClientsHouseMortgaged_Rule_Test
    {
        #region Success cases
        [Fact]
        [Trait("Success", "")]
        public void When_ClientsHouseIsMortgaged_Expect_DisabilityAndHomeToAdd1ToScore()
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithHouse(new HouseProfile(OwnershipStatus.Mortgaged));
            var rule = new ClientsHouseIsMortgaged();
            var insuranceLinesScore = new InsuranceLinesScore();

            // Act
            var ruleMatches = rule.MatchCondition(clientProfile);
            rule.ApplyScore(insuranceLinesScore);

            // Assert
            ruleMatches
                .Should().BeTrue();
            insuranceLinesScore.Disability.Score
                .Should().Be(1);
            insuranceLinesScore.Home.Score
                .Should().Be(1);
        }
        #endregion

        #region Error cases
        [Fact]
        [Trait("Error", "")]
        public void When_ClientsHouseIsNotMortgaged_Expect_ToSkipThisRule()
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithHouse(new HouseProfile(OwnershipStatus.None));
            var rule = new ClientsHouseIsMortgaged();
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
