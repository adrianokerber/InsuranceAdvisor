namespace InsuranceAdvisor.Domain.Models
{
    public class InsuranceAdviceStatus
    {
        public string Name { get; }

        public InsuranceAdviceStatus(string value)
        {
            Name = value;
        }

        public static InsuranceAdviceStatus Economic = new InsuranceAdviceStatus("economic");
        public static InsuranceAdviceStatus Ineligible = new InsuranceAdviceStatus("ineligible");
        public static InsuranceAdviceStatus Regular = new InsuranceAdviceStatus("regular");
        public static InsuranceAdviceStatus Responsible = new InsuranceAdviceStatus("responsible");
    }
}
