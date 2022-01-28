using InsuranceAdvisor.Domain.Interfaces.Rules;

namespace InsuranceAdvisor.Domain.Models.Rules
{
    public class ClientsHouseIsMortgaged : IRiskRule
    {
        public bool MatchCondition(ClientProfile clientProfile) => clientProfile.House?.OwnershipStatus == OwnershipStatus.Mortgaged;

        public void ApplyScore(InsuranceLinesScore insuranceLinesScore)
        {
            insuranceLinesScore.Disability.Score += 1;
            insuranceLinesScore.Home.Score += 1;
        }
    }
}
