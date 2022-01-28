using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Rules.Chain;

namespace InsuranceAdvisor.Domain.Interfaces.Rules
{
    public interface IRiskRuleChain
    {
        public RiskRuleChain AddRule(IRiskRule rule);

        public InsuranceLinesScore RunRiskRuleChainWith(ClientProfile clientProfile);
    }
}
