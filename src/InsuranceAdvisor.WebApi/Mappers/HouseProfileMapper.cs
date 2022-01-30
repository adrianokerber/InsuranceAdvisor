using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.WebApi.Models;

namespace InsuranceAdvisor.WebApi.Mappers
{
    public static class HouseProfileMapper
    {
        public static HouseProfile ToDomain(this HouseProfileDto dto)
        {
            if (!Enum.TryParse<OwnershipStatus>(dto.OwnershipStatus, true, out var ownershipStatus))
                ownershipStatus = OwnershipStatus.None;

            return new HouseProfile(ownershipStatus);
        }
    }
}
