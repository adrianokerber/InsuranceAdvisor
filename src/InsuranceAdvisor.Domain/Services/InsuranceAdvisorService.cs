using InsuranceAdvisor.Domain.Interfaces;
using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Bases;

namespace InsuranceAdvisor.Domain.Services
{
    public class InsuranceAdvisorService : IInsuranceAdvisorService
    {
        private const string _equalOrGreaterThanConditionMessage = "must be equal or greater than zero";
        private readonly IRiskScoreService _riskScoreService;

        public InsuranceAdvisorService(IRiskScoreService riskScoreService)
        {
            _riskScoreService = riskScoreService;
        }

        public BaseResult ValidateClientProfile(ClientProfile clientProfile)
        {
            if (clientProfile == null)
                return new BaseResult("Please inform client profile");

            var errorMessages = new List<string>();
            if (clientProfile.Age < 0)
                errorMessages.Add($"Age {_equalOrGreaterThanConditionMessage}");
            if (clientProfile.Dependents < 0)
                errorMessages.Add($"Dependents {_equalOrGreaterThanConditionMessage}");
            if (clientProfile.Income < 0)
                errorMessages.Add($"Income {_equalOrGreaterThanConditionMessage}");
            if (clientProfile.MartialStatus != MartialStatus.Single && clientProfile.MartialStatus != MartialStatus.Married)
                errorMessages.Add("Martial status unrecognized, use 'single' or 'married' as possible martial status");
            if (clientProfile.RiskQuestions.Count != 3 || clientProfile.RiskQuestions.Any(x => x < 0 || x > 1))
                errorMessages.Add("Risk questions not informed properly, please inform three values as zeros and ones");
            if (clientProfile.House != null && clientProfile.House.OwnershipStatus != OwnershipStatus.Owned && clientProfile.House.OwnershipStatus != OwnershipStatus.Mortgaged)
                errorMessages.Add("House ownership status must be 'owned' or 'mortgaged'");

            return new BaseResult(errorMessages);
        }

        public InsuranceAdvice GenerateInsuranceAdvice(ClientProfile clientProfile)
        {
            var riskScoreResult = _riskScoreService.ComputateRiskScore(clientProfile);

            return ComputateInsuranceAdvice(riskScoreResult);
        }

        private InsuranceAdvice ComputateInsuranceAdvice(InsuranceLinesScore insuranceLinesScore)
        {
            var autoInsuranceAdvice = GetInsuranceAdviceStatusByScore(insuranceLinesScore.Auto);
            var disabilityInsuranceAdvice = GetInsuranceAdviceStatusByScore(insuranceLinesScore.Disability);
            var homeInsuranceAdvice = GetInsuranceAdviceStatusByScore(insuranceLinesScore.Home);
            var lifeInsuranceAdvice = GetInsuranceAdviceStatusByScore(insuranceLinesScore.Life);

            var insuranceAdvice = new InsuranceAdvice(autoInsuranceAdvice,
                                                      disabilityInsuranceAdvice,
                                                      homeInsuranceAdvice,
                                                      lifeInsuranceAdvice);

            return insuranceAdvice;
        }

        private static InsuranceAdviceStatus GetInsuranceAdviceStatusByScore(RiskScore riskScore) => riskScore switch
        {
            { IsIneligible: true } => InsuranceAdviceStatus.Ineligible,
            { Score: <= 0 } => InsuranceAdviceStatus.Economic,
            { Score: 1 or 2 } => InsuranceAdviceStatus.Regular,
            { Score: >= 3 } => InsuranceAdviceStatus.Responsible
        };
	}
}
