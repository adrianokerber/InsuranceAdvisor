using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.WebApi.Models;

namespace InsuranceAdvisor.WebApi.Mappers
{
    public static class HouseProfileMapper
    {
        public static HouseProfile ToDomain(this HouseProfileDto dto)
            => new HouseProfile(dto.OwnershipStatus);
    }
}
