using InsuranceAdvisor.Domain.Interfaces.Rules;

namespace InsuranceAdvisor.Domain.Models.Rules
{
    public class ClientOver60YearsOld : IRiskRule
    {
        public bool MatchCondition(ClientProfile clientProfile) => clientProfile.Age > 60;

        public void ApplyScore(InsuranceLinesScore insuranceLinesScore)
        {
            insuranceLinesScore.Life.IsIneligible = true;
            insuranceLinesScore.Disability.IsIneligible = true;
        }
    }
}
