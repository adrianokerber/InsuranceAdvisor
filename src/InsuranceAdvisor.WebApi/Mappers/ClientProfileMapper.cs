using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.WebApi.Models;

namespace InsuranceAdvisor.WebApi.Mappers
{
    public static class ClientProfileMapper
    {
        public static ClientProfile ToDomain(this ClientProfileDto dto)
        {
            if (!Enum.TryParse<MaritalStatus>(dto.MaritalStatus, true, out var maritalStatus))
                maritalStatus = MaritalStatus.None;

            return new ClientProfile(dto.Age,
                                     dto.Dependents,
                                     dto.House?.ToDomain(),
                                     dto.Income,
                                     maritalStatus,
                                     dto.RiskQuestions,
                                     dto.Vehicle?.ToDomain());
        }
    }
}
