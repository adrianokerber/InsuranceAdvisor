namespace InsuranceAdvisor.Domain.Models
{
    public class ClientProfile
    {
        public int Age { get; }
        public int Dependents { get; }
        public HouseProfile? House { get; }
        public decimal Income { get; }
        public string MartialStatus { get; }
        public List<int> RiskQuestions { get; }
        public VehicleProfile? Vehicle { get; }

        public ClientProfile(int age,
                             int dependents,
                             HouseProfile? house,
                             decimal income,
                             string martialStatus,
                             List<int> riskQuestions,
                             VehicleProfile? vehicle)
        {
            Age = age;
            Dependents = dependents;
            House = house;
            Income = income;
            MartialStatus = martialStatus;
            RiskQuestions = riskQuestions;
            Vehicle = vehicle;
        }
    }
}
