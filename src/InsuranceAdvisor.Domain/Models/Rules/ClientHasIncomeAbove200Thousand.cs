using InsuranceAdvisor.Domain.Interfaces.Rules;

namespace InsuranceAdvisor.Domain.Models.Rules
{
    public class ClientHasIncomeAbove200Thousand : IRiskRule
    {
        public bool MatchCondition(ClientProfile clientProfile) => clientProfile.Income > 200_000;

        public void ApplyScore(InsuranceLinesScore insuranceLinesScore)
        {
            insuranceLinesScore.Life.Score -= 1;
            insuranceLinesScore.Disability.Score -= 1;
            insuranceLinesScore.Home.Score -= 1;
            insuranceLinesScore.Auto.Score -= 1;
        }
    }
}
