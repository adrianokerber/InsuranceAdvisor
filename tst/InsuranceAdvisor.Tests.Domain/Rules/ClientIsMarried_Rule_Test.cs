﻿using FluentAssertions;
using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Rules;
using InsuranceAdvisor.Tests.Domain.Models.Factories;
using Xunit;

namespace InsuranceAdvisor.Tests.Domain.Rules
{
    public class ClientIsMarried_Rule_Test
    {
        #region Success cases
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
        #endregion

        #region Error cases
        [Fact]
        [Trait("Error", "")]
        public void When_ClientIsSingle_Expect_ToSkipThisRule()
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithMartialStatus(MartialStatus.Single);
            var rule = new ClientIsMarried();
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
