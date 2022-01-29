﻿using FluentAssertions;
using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Rules;
using InsuranceAdvisor.Tests.Domain.Models.Factories;
using Xunit;

namespace InsuranceAdvisor.Tests.Domain.Rules
{
    public class ClientHasDependents_Rule_Test
    {
        [Fact]
        [Trait("Success", "")]
        public void When_ClientHasDependents_Expect_LifeAndDisabilityToAdd1ToScore()
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithDependents(1);
            var rule = new ClientHasDependents();
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
                .Should().Be(1);
        }
    }
}
