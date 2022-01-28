using InsuranceAdvisor.Domain.Interfaces.Rules;

namespace InsuranceAdvisor.Domain.Models.Rules
{
    public class ClientHasDependents : IRiskRule
    {
        public bool MatchCondition(ClientProfile clientProfile) => clientProfile.Dependents > 0;

        public void ApplyScore(InsuranceLinesScore insuranceLinesScore)
        {
            insuranceLinesScore.Life.Score += 1;
            insuranceLinesScore.Disability.Score += 1;
        }
    }
}
