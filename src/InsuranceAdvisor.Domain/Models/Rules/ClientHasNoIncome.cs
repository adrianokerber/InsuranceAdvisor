using InsuranceAdvisor.Domain.Models.Bases.Rules;

namespace InsuranceAdvisor.Domain.Models.Rules
{
    public class ClientHasNoIncome : IRiskRule
    {
        public bool MatchCondition(ClientProfile clientProfile) => clientProfile.Income <= 0;

        public void ApplyScore(InsuranceLinesScore insuranceLinesScore)
        {
            insuranceLinesScore.Disability.IsIneligible = true;
        }
    }
}
