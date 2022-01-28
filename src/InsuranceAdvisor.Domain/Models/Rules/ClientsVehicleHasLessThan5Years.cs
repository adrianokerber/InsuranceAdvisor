using InsuranceAdvisor.Domain.Interfaces.Rules;

namespace InsuranceAdvisor.Domain.Models.Rules
{
    public class ClientsVehicleHasLessThan5Years : IRiskRule
    {
        private int _fiveYearsAgo = DateTime.UtcNow.Year - 5;

        public bool MatchCondition(ClientProfile clientProfile) => clientProfile.Vehicle?.Year > _fiveYearsAgo;

        public void ApplyScore(InsuranceLinesScore insuranceLinesScore)
        {
            insuranceLinesScore.Life.Score += 1;
            insuranceLinesScore.Auto.Score -= 1;
        }
    }
}
