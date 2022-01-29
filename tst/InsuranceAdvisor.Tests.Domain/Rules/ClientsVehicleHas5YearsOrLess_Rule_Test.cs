using FluentAssertions;
using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Rules;
using InsuranceAdvisor.Tests.Domain.Models.Factories;
using System;
using Xunit;

namespace InsuranceAdvisor.Tests.Domain.Rules
{
    public class ClientsVehicleHas5YearsOrLess_Rule_Test
    {
        #region Success cases
        [Fact]
        [Trait("Success", "")]
        public void When_ClientsVehicleHas5YearsOrLess_Expect_Add1ToLifeAndDeduct1FromAuto()
        {
            // Arrange
            var vehicleManufacture = DateTime.UtcNow.Year - 4;
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithVehicle(new VehicleProfile(vehicleManufacture));
            var rule = new ClientsVehicleHasLessThan5Years();
            var insuranceLinesScore = new InsuranceLinesScore();

            // Act
            var ruleMatches = rule.MatchCondition(clientProfile);
            rule.ApplyScore(insuranceLinesScore);

            // Assert
            ruleMatches
                .Should().BeTrue();
            insuranceLinesScore.Life.Score
                .Should().Be(1);
            insuranceLinesScore.Auto.Score
                .Should().Be(-1);
        }
        #endregion

        #region Error cases
        [Fact]
        [Trait("Error", "")]
        public void When_ClientsVehicleHasMoreThan5Years_Expect_ToSkipThisRule()
        {
            // Arrange
            var vehicleManufacture = DateTime.UtcNow.Year - 6;
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithVehicle(new VehicleProfile(vehicleManufacture));
            var rule = new ClientsVehicleHasLessThan5Years();
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
