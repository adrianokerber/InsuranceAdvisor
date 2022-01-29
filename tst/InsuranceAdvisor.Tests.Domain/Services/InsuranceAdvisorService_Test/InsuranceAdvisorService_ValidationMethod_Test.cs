using FluentAssertions;
using InsuranceAdvisor.Domain.Interfaces;
using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Services;
using InsuranceAdvisor.Tests.Domain.Models.Factories;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace InsuranceAdvisor.Tests.Domain.Services.InsuranceAdvisorService_Test
{
    public class InsuranceAdvisorService_ValidationMethod_Test
    {
        private readonly IInsuranceAdvisorService _insuranceAdvisorService;

        public InsuranceAdvisorService_ValidationMethod_Test()
        {
            var mockRiskScoreService = new Mock<IRiskScoreService>();
            _insuranceAdvisorService = new InsuranceAdvisorService(mockRiskScoreService.Object);
        }

        #region Success cases
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(19)]
        [InlineData(29)]
        [InlineData(208083)]
        [Trait("Success", "")]
        public void When_ClientHasValidAge_Expect_ValidResult(int givenAge)
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithAge(givenAge);

            // Act
            var validationResult = _insuranceAdvisorService.ValidateClientProfile(clientProfile);

            // Assert
            validationResult.IsValid
                .Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(1000)]
        [Trait("Success", "")]
        public void When_ClientHasValidDependents_Expect_ValidResult(int givenDependents)
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithDependents(givenDependents);

            // Act
            var validationResult = _insuranceAdvisorService.ValidateClientProfile(clientProfile);

            // Assert
            validationResult.IsValid
                .Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(899899)]
        [InlineData(200_000)]
        [Trait("Success", "")]
        public void When_ClientHasValidIncome_Expect_ValidResult(int givenIncome)
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithIncome(givenIncome);

            // Act
            var validationResult = _insuranceAdvisorService.ValidateClientProfile(clientProfile);

            // Assert
            validationResult.IsValid
                .Should().BeTrue();
        }

        [Theory]
        [InlineData(MartialStatus.Single)]
        [InlineData(MartialStatus.Married)]
        [Trait("Success", "")]
        public void When_ClientHasValidMartialStatus_Expect_ValidResult(MartialStatus givenMartialStatus)
        {
            // Arrange
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithMartialStatus(givenMartialStatus);

            // Act
            var validationResult = _insuranceAdvisorService.ValidateClientProfile(clientProfile);

            // Assert
            validationResult.IsValid
                .Should().BeTrue();
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(1, 1, 1)]
        [Trait("Success", "")]
        public void When_ClientHasAllThreeRiskQuestionsAnsweredWithValuesFrom0To1_Expect_ValidResult(int givenRiskQuestion1, int givenRiskQuestion2, int givenRiskQuestion3)
        {
            // Arrange
            var givenRiskQuestions = new List<int> { givenRiskQuestion1, givenRiskQuestion2, givenRiskQuestion3 };
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithRiskQuestions(givenRiskQuestions);

            // Act
            var validationResult = _insuranceAdvisorService.ValidateClientProfile(clientProfile);

            // Assert
            validationResult.IsValid
                .Should().BeTrue();
        }

        [Theory]
        [InlineData(OwnershipStatus.Owned)]
        [InlineData(OwnershipStatus.Mortgaged)]
        [Trait("Success", "")]
        public void When_ClientHasHouseWithProperOwnershipStatus_Expect_ValidResult(OwnershipStatus givenOwnershipStatus)
        {
            // Arrange
            var givenHouseProfile = new HouseProfile(givenOwnershipStatus);
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithHouse(givenHouseProfile);

            // Act
            var validationResult = _insuranceAdvisorService.ValidateClientProfile(clientProfile);

            // Assert
            validationResult.IsValid
                .Should().BeTrue();
        }
        #endregion

        #region Error cases
        [Fact]
        [Trait("Error", "")]
        public void When_ClientHasInvalidAge_Expect_ErrorMessageAboutInvalidAge()
        {
            // Arrange
            int givenAge = -1;
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithAge(givenAge);

            // Act
            var validationResult = _insuranceAdvisorService.ValidateClientProfile(clientProfile);

            // Assert
            validationResult.IsValid
                .Should().BeFalse();
            validationResult.Messages
                .Should().ContainSingle("Age must be equal or greater than zero");
        }

        [Fact]
        [Trait("Error", "")]
        public void When_ClientHasInvalidDependents_Expect_ErrorMessageAboutInvalidDependents()
        {
            // Arrange
            int givenDependents = -1;
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithDependents(givenDependents);

            // Act
            var validationResult = _insuranceAdvisorService.ValidateClientProfile(clientProfile);

            // Assert
            validationResult.IsValid
                .Should().BeFalse();
            validationResult.Messages
                .Should().ContainSingle("Dependents must be equal or greater than zero");
        }

        [Fact]
        [Trait("Error", "")]
        public void When_ClientHasInvalidIncome_Expect_ErrorMessageAboutInvalidIncome()
        {
            // Arrange
            int givenIncome = -1;
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithIncome(givenIncome);

            // Act
            var validationResult = _insuranceAdvisorService.ValidateClientProfile(clientProfile);

            // Assert
            validationResult.IsValid
                .Should().BeFalse();
            validationResult.Messages
                .Should().ContainSingle("Income must be equal or greater than zero");
        }

        [Fact]
        [Trait("Error", "")]
        public void When_ClientHasInvalidMartialStatus_Expect_ErrorMessageAboutInvalidMartialStatus()
        {
            // Arrange
            var givenMartialStatus = MartialStatus.None;
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithMartialStatus(givenMartialStatus);

            // Act
            var validationResult = _insuranceAdvisorService.ValidateClientProfile(clientProfile);

            // Assert
            validationResult.IsValid
                .Should().BeFalse();
            validationResult.Messages
                .Should().ContainSingle("Martial status unrecognized, use 'single' or 'married' as possible martial status");
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [Trait("Error", "")]
        public void When_ClientHasOnlyOneInvalidRiskQuestion_Expect_ErrorMessageAboutInvalidRiskQuestions(int givenRiskQuestion)
        {
            // Arrange
            var givenRiskQuestions = new List<int> { givenRiskQuestion };
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithRiskQuestions(givenRiskQuestions);

            // Act
            var validationResult = _insuranceAdvisorService.ValidateClientProfile(clientProfile);

            // Assert
            validationResult.IsValid
                .Should().BeFalse();
            validationResult.Messages
                .Should().ContainSingle("Risk questions not informed properly, please inform three values as zeros and ones");
        }

        [Theory]
        [InlineData(-1, -2)]
        [InlineData(0, 2)]
        [InlineData(1, 2)]
        [InlineData(0, -1)]
        [InlineData(-5, 5)]
        [Trait("Error", "")]
        public void When_ClientHasTwoRiskQuestionsWithAtLeastOneInvalid_Expect_ErrorMessageAboutInvalidRiskQuestions(int givenRiskQuestion1, int givenRiskQuestion2)
        {
            // Arrange
            var givenRiskQuestions = new List<int> { givenRiskQuestion1, givenRiskQuestion2 };
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithRiskQuestions(givenRiskQuestions);

            // Act
            var validationResult = _insuranceAdvisorService.ValidateClientProfile(clientProfile);

            // Assert
            validationResult.IsValid
                .Should().BeFalse();
            validationResult.Messages
                .Should().ContainSingle("Risk questions not informed properly, please inform three values as zeros and ones");
        }

        [Theory]
        [InlineData(-1, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 0, -1)]
        [Trait("Error", "")]
        public void When_ClientHasThreeRiskQuestionsWithAtLeastOneInvalid_Expect_ErrorMessageAboutInvalidRiskQuestions(int givenRiskQuestion1, int givenRiskQuestion2, int givenRiskQuestion3)
        {
            // Arrange
            var givenRiskQuestions = new List<int> { givenRiskQuestion1, givenRiskQuestion2, givenRiskQuestion3 };
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithRiskQuestions(givenRiskQuestions);

            // Act
            var validationResult = _insuranceAdvisorService.ValidateClientProfile(clientProfile);

            // Assert
            validationResult.IsValid
                .Should().BeFalse();
            validationResult.Messages
                .Should().ContainSingle("Risk questions not informed properly, please inform three values as zeros and ones");
        }

        [Theory]
        [InlineData(OwnershipStatus.None)]
        [Trait("Error", "")]
        public void When_ClientHaveHouseButWithoutProperOwnershipStatus_Expect_ErrorMessageAboutInvalidOwnershipStatus(OwnershipStatus givenOwnershipStatus)
        {
            // Arrange
            var givenHouseProfile = new HouseProfile(givenOwnershipStatus);
            var clientProfile = ClientProfileTestFactory.CreateValidClientProfileWithHouse(givenHouseProfile);

            // Act
            var validationResult = _insuranceAdvisorService.ValidateClientProfile(clientProfile);

            // Assert
            validationResult.IsValid
                .Should().BeFalse();
            validationResult.Messages
                .Should().ContainSingle("House ownership status must be 'owned' or 'mortgaged'");
        }
        #endregion
    }
}