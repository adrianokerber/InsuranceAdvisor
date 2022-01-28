namespace InsuranceAdvisor.Domain.Models
{
    public class RiskScore
    {
        public short Score { get; set; } = 0;
        public bool IsIneligible { get; set; } = false;
    }
}
