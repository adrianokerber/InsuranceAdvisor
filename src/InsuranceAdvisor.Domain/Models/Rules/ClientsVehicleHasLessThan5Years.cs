using InsuranceAdvisor.Domain.Interfaces.Rules;

namespace InsuranceAdvisor.Domain.Models.Rules
{
    public class ClientsVehicleHasLessThan5Years : IRiskRule
    {
        public bool MatchCondition(ClientProfile clientProfile)
        {
            var fiveYearsAgo = DateTime.UtcNow.Year - 5;

            return clientProfile.Vehicle?.Year > fiveYearsAgo;
        }

        public void ApplyScore(InsuranceLinesScore insuranceLinesScore)
        {
            insuranceLinesScore.Life.Score += 1;
            insuranceLinesScore.Auto.Score -= 1;
        }
    }
}
