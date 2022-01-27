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
            if (clientProfile.MartialStatus != "single" && clientProfile.MartialStatus != "married")
                errorMessages.Add("Martial status unrecognized, use `single` or `married` as possible martial status");
            if (clientProfile.RiskQuestions.Count != 3)
                errorMessages.Add("Risk answers not informed properly, please inform three values as zero or one");

            return new BaseResult(errorMessages);
        }

        public InsuranceAdvice GenerateInsuranceAdvice(ClientProfile clientProfile)
        {
            var riskScoreResult = _riskScoreService.ComputateRiskScore(clientProfile);

            return ComputateInsuranceAdvice(riskScoreResult);
        }

        private InsuranceAdvice ComputateInsuranceAdvice(InsuranceLinesScore insuranceLinesScore)
        {
            // TODO: computate insurance advice based on scores of each insurance line
            throw new NotImplementedException();
        }
    }
}
