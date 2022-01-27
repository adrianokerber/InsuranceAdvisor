namespace InsuranceAdvisor.Domain.Models.Bases.Rules
{
    public interface IRiskRule
    {
        public bool MatchCondition(ClientProfile clientProfile);
        public void ApplyScore(InsuranceLinesScore insuranceLinesScore);
    }
}
