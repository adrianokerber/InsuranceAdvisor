﻿using FluentAssertions;
using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Rules;
using InsuranceAdvisor.Tests.Domain.Models.Factories;
using Xunit;

namespace InsuranceAdvisor.Tests.Domain.Rules
{
    public class ClientHasNoVehicle_Rule_Test
    {
        [Fact]
        [Trait("Success", "")]
        public void When_ClientHasNoVehicle_Expect_AutoInsuranceLineToBeIneligible()
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithVehicle(null);
            var rule = new ClientHasNoVehicle();
            var insuranceLinesScore = new InsuranceLinesScore();

            // Act
            var ruleMatches = rule.MatchCondition(clientProfile);
            rule.ApplyScore(insuranceLinesScore);

            // Assert
            ruleMatches
                .Should().BeTrue();
            insuranceLinesScore.Auto.IsIneligible
                .Should().BeTrue();

        }
    }
}
