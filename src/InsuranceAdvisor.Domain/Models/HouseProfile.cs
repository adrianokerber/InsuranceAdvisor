namespace InsuranceAdvisor.Domain.Models
{
    public class HouseProfile
    {
        public string OwnershipStatus { get; }

        public HouseProfile(string ownershipStatus)
        {
            OwnershipStatus = ownershipStatus;
        }
    }
}