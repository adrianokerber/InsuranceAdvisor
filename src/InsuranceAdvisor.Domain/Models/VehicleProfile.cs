namespace InsuranceAdvisor.Domain.Models
{
    public class VehicleProfile
    {
        public int Year { get; }

        public VehicleProfile(int year)
        {
            Year = year;
        }
    }
}