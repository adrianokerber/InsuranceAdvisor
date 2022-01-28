using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.WebApi.Models;

namespace InsuranceAdvisor.WebApi.Mappers
{
    public static class ClientProfileMapper
    {
        public static ClientProfile ToDomain(this ClientProfileDto dto)
        {
            if (!Enum.TryParse<MartialStatus>(dto.MartialStatus, true, out var martialStatus))
                martialStatus = MartialStatus.None;

            return new ClientProfile(dto.Age,
                                     dto.Dependents,
                                     dto.House?.ToDomain(),
                                     dto.Income,
                                     martialStatus,
                                     dto.RiskQuestions,
                                     dto.Vehicle?.ToDomain());
        }
    }
}
