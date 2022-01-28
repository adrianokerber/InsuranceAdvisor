namespace InsuranceAdvisor.Domain.Models
{
    public class HouseProfile
    {
        public OwnershipStatus OwnershipStatus { get; }

        public HouseProfile(OwnershipStatus ownershipStatus)
        {
            OwnershipStatus = ownershipStatus;
        }
    }
}