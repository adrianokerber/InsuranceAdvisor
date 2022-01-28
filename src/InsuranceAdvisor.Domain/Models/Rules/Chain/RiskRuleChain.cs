using InsuranceAdvisor.Domain.Interfaces.Rules;

namespace InsuranceAdvisor.Domain.Models.Rules.Chain
{
    public class RiskRuleChain : IRiskRuleChain
    {
        private readonly List<IRiskRule> _rules;

        public RiskRuleChain()
        {
            _rules = new List<IRiskRule>();
        }

        public RiskRuleChain AddRule(IRiskRule rule)
        {
            _rules.Add(rule);

            return this;
        }

        public InsuranceLinesScore RunRiskRuleChainWith(ClientProfile clientProfile)
        {
            var insuranceLinesScore = new InsuranceLinesScore();

            foreach (var rule in _rules)
            {
                if (rule.MatchCondition(clientProfile))
                    rule.ApplyScore(insuranceLinesScore);
            }

            return insuranceLinesScore;
        }
    }
}
