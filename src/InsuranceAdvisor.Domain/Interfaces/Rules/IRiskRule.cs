using InsuranceAdvisor.Domain.Models;

namespace InsuranceAdvisor.Domain.Interfaces.Rules
{
    public interface IRiskRule
    {
        public bool MatchCondition(ClientProfile clientProfile);
        public void ApplyScore(InsuranceLinesScore insuranceLinesScore);
    }
}
