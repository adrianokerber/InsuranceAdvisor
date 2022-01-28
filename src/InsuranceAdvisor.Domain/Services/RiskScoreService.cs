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
                .AddRule(new ClientHasNoVehicle())
                .AddRule(new ClientHasNoHouse())
                .AddRule(new ClientOver60YearsOld())
                .AddRule(new ClientUnder30YearsOld())
                .AddRule(new ClientBetween30and40YearsOld())
                .AddRule(new ClientHasIncomeAbove200Thousand())
                .AddRule(new ClientsHouseIsMortgaged())
                .AddRule(new ClientHasDependents())
                .AddRule(new ClientIsMarried())
                .AddRule(new ClientsVehicleHasLessThan5Years());
        }

        public InsuranceLinesScore ComputateRiskScore(ClientProfile clientProfile)
        {
            return _riskRuleChain.RunRiskRuleChainWith(clientProfile);
        }
    }
}
