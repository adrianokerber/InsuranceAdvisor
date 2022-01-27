namespace InsuranceAdvisor.Domain.Models
{
    public class InsuranceLinesScore
    {
        public RiskScore Auto { get; } = new RiskScore();
        public RiskScore Disability { get; } = new RiskScore();
        public RiskScore Home { get; } = new RiskScore();
        public RiskScore Life { get; } = new RiskScore();
    }
}
