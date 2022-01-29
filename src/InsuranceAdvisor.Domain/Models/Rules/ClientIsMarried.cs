using InsuranceAdvisor.Domain.Interfaces.Rules;

namespace InsuranceAdvisor.Domain.Models.Rules
{
    public class ClientIsMarried : IRiskRule
    {
        public bool MatchCondition(ClientProfile clientProfile) => clientProfile.MaritalStatus == MaritalStatus.Married;

        public void ApplyScore(InsuranceLinesScore insuranceLinesScore)
        {
            insuranceLinesScore.Life.Score += 1;
            insuranceLinesScore.Disability.Score -= 1;
        }
    }
}
