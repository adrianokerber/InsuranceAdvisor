using InsuranceAdvisor.Domain.Interfaces.Rules;

namespace InsuranceAdvisor.Domain.Models.Rules
{
    public class ClientBetween30and40YearsOld : IRiskRule
    {
        public bool MatchCondition(ClientProfile clientProfile) => clientProfile.Age >= 30 && clientProfile.Age <= 40;

        public void ApplyScore(InsuranceLinesScore insuranceLinesScore)
        {
            insuranceLinesScore.Life.Score -= 1;
            insuranceLinesScore.Disability.Score -= 1;
            insuranceLinesScore.Home.Score -= 1;
            insuranceLinesScore.Auto.Score -= 1;
        }
    }
}
