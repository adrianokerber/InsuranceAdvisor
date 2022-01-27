using InsuranceAdvisor.Domain.Interfaces;
using InsuranceAdvisor.Domain.Models;

namespace InsuranceAdvisor.Domain.Services
{
    public class RiskScoreService : IRiskScoreService
    {
        public InsuranceLinesScore ComputateRiskScore(ClientProfile clientProfile)
        {
            // TODO: apply chained rules using polymorphism

            var insuranceLinesScore = new InsuranceLinesScore();

            throw new NotImplementedException();
        }
    }
}
