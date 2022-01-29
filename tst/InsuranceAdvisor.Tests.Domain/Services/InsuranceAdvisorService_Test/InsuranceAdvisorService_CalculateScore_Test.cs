using FluentAssertions;
using InsuranceAdvisor.Domain.Interfaces;
using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Rules.Chain;
using InsuranceAdvisor.Domain.Services;
using System.Collections.Generic;
using Xunit;

namespace InsuranceAdvisor.Tests.Domain.Services.InsuranceAdvisorService_Test
{
    public class InsuranceAdvisorService_CalculateScore_Test
    {
        private readonly IInsuranceAdvisorService _insuranceAdvisorService;

        public InsuranceAdvisorService_CalculateScore_Test()
        {
            var riskRuleChain = new RiskRuleChain();
            var riskScoreService = new RiskScoreService(riskRuleChain);
            _insuranceAdvisorService = new InsuranceAdvisorService(riskScoreService);
        }

        [Fact]
        [Trait("Success", "")]
        public void When_ClientHasAGeneralEconomicProfile_Expect_AllLinesOfInsuranceToBeClassifiedAsEconomic()
        {
            // Arrange
            var clientProfile = new ClientProfile(age: 29,
                                                  dependents: 0,
                                                  house: new HouseProfile(OwnershipStatus.Mortgaged),
                                                  income: 10_000,
                                                  martialStatus: MartialStatus.Married,
                                                  riskQuestions: new List<int> { 0, 0, 0 },
                                                  vehicle: new VehicleProfile(2013));
            var expectedInsuranceAdvice = new InsuranceAdvice(auto: InsuranceAdviceStatus.Economic,
                                                              disability: InsuranceAdviceStatus.Economic,
                                                              home: InsuranceAdviceStatus.Economic,
                                                              life: InsuranceAdviceStatus.Economic);

            // Act
            var insuranceAdvice = _insuranceAdvisorService.GenerateInsuranceAdvice(clientProfile);

            // Assert
            insuranceAdvice
                .Should().BeEquivalentTo(expectedInsuranceAdvice);
        }

        [Fact]
        [Trait("Success", "")]
        public void When_ClientHasNoIncome_Expect_DisabilityInsuranceLineToBeIneligible()
        {
            // Arrange
            var clientProfile = new ClientProfile(age: 29,
                                                  dependents: 0,
                                                  house: new HouseProfile(OwnershipStatus.Mortgaged),
                                                  income: 10_000,
                                                  martialStatus: MartialStatus.Married,
                                                  riskQuestions: new List<int> { 0, 0, 0 },
                                                  vehicle: null);
            var expectedInsuranceAdvice = new InsuranceAdvice(auto: InsuranceAdviceStatus.Ineligible,
                                                              disability: InsuranceAdviceStatus.Economic,
                                                              home: InsuranceAdviceStatus.Economic,
                                                              life: InsuranceAdviceStatus.Economic);

            // Act
            var insuranceAdvice = _insuranceAdvisorService.GenerateInsuranceAdvice(clientProfile);

            // Assert
            insuranceAdvice
                .Should().BeEquivalentTo(expectedInsuranceAdvice);
        }
    }
}
