using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.WebApi.Models;

namespace InsuranceAdvisor.WebApi.Mappers
{
    public static class VehicleProfileMapper
    {
        public static VehicleProfile ToDomain(this VehicleProfileDto dto)
            => new VehicleProfile(dto.Year);
    }
}
