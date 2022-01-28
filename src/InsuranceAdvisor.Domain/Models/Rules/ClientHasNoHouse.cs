using InsuranceAdvisor.Domain.Interfaces.Rules;

namespace InsuranceAdvisor.Domain.Models.Rules
{
    public class ClientHasNoHouse : IRiskRule
    {
        public bool MatchCondition(ClientProfile clientProfile) => clientProfile.House == null;

        public void ApplyScore(InsuranceLinesScore insuranceLinesScore) => insuranceLinesScore.Home.IsIneligible = true;
    }
}
