using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.WebApi.Models;

namespace InsuranceAdvisor.WebApi.Mappers
{
    public static class ClientProfileMapper
    {
        public static ClientProfile ToDomain(this ClientProfileDto dto)
            => new ClientProfile(dto.Age,
                                 dto.Dependents,
                                 dto.House?.ToDomain(),
                                 dto.Income,
                                 dto.MartialStatus,
                                 dto.RiskQuestions,
                                 dto.Vehicle?.ToDomain());
    }
}
