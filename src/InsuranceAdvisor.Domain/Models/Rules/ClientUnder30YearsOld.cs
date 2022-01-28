using InsuranceAdvisor.Domain.Interfaces.Rules;

namespace InsuranceAdvisor.Domain.Models.Rules
{
    public class ClientUnder30YearsOld : IRiskRule
    {
        public bool MatchCondition(ClientProfile clientProfile) => clientProfile.Age < 30;

        public void ApplyScore(InsuranceLinesScore insuranceLinesScore)
        {
            insuranceLinesScore.Life.Score -= 2;
            insuranceLinesScore.Disability.Score -= 2;
            insuranceLinesScore.Home.Score -= 2;
            insuranceLinesScore.Auto.Score -= 2;
        }
    }
}
