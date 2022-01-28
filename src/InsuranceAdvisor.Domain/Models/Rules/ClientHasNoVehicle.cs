using InsuranceAdvisor.Domain.Interfaces.Rules;

namespace InsuranceAdvisor.Domain.Models.Rules
{
    public class ClientHasNoVehicle : IRiskRule
    {
        public bool MatchCondition(ClientProfile clientProfile) => clientProfile.Vehicle == null;

        public void ApplyScore(InsuranceLinesScore insuranceLinesScore) => insuranceLinesScore.Auto.IsIneligible = true;
    }
}
