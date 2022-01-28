using InsuranceAdvisor.Domain.Interfaces.Rules;

namespace InsuranceAdvisor.Domain.Models.Rules
{
    public class ClientIsMarried : IRiskRule
    {
        public bool MatchCondition(ClientProfile clientProfile) => clientProfile.MartialStatus == MartialStatus.Married;

        public void ApplyScore(InsuranceLinesScore insuranceLinesScore)
        {
            insuranceLinesScore.Life.Score += 1;
            insuranceLinesScore.Disability.Score -= 1;
        }
    }
}
