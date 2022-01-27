namespace InsuranceAdvisor.Domain.Services
{
    public class InsuranceAdvice
    {
        public string Auto { get; }
        public string Disability { get; }
        public string Home { get; }
        public string Life { get; }

        public InsuranceAdvice(string auto, string disability, string home, string life)
        {
            Auto = auto;
            Disability = disability;
            Home = home;
            Life = life;
        }
    }
}