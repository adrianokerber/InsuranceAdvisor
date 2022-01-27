using InsuranceAdvisor.Domain.Models;

namespace InsuranceAdvisor.Domain.Interfaces
{
    public interface IRiskScoreService
    {
        public InsuranceLinesScore ComputateRiskScore(ClientProfile clientProfile);
    }
}
