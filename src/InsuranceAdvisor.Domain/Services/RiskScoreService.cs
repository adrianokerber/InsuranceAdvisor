using InsuranceAdvisor.Domain.Interfaces;
using InsuranceAdvisor.Domain.Interfaces.Rules;
using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Rules;

namespace InsuranceAdvisor.Domain.Services
{
    public class RiskScoreService : IRiskScoreService
    {
        private readonly IRiskRuleChain _riskRuleChain;

        public RiskScoreService(IRiskRuleChain riskRuleChain)
        {
            _riskRuleChain = ConfigureRiskRuleChain(riskRuleChain);
        }

        private IRiskRuleChain ConfigureRiskRuleChain(IRiskRuleChain riskRuleChain)
        {
            return riskRuleChain
                .AddRule(new ClientHasNoIncome())
                .AddRule(new ClientHasNoVehicle());
        }

        public InsuranceLinesScore ComputateRiskScore(ClientProfile clientProfile)
        {
            return _riskRuleChain.RunRiskRuleChainWith(clientProfile);
        }
    }
}
