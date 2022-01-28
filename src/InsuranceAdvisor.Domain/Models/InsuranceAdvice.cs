using InsuranceAdvisor.Domain.Models;

namespace InsuranceAdvisor.Domain.Services
{
    public class InsuranceAdvice
    {
        public InsuranceAdviceStatus Auto { get; }
        public InsuranceAdviceStatus Disability { get; }
        public InsuranceAdviceStatus Home { get; }
        public InsuranceAdviceStatus Life { get; }

        public InsuranceAdvice(InsuranceAdviceStatus auto,
                               InsuranceAdviceStatus disability,
                               InsuranceAdviceStatus home,
                               InsuranceAdviceStatus life)
        {
            Auto = auto;
            Disability = disability;
            Home = home;
            Life = life;
        }
    }
}