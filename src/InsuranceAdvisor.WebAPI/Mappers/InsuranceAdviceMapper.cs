using InsuranceAdvisor.Domain.Services;
using InsuranceAdvisor.WebApi.Models;

namespace InsuranceAdvisor.WebApi.Mappers
{
    public static class InsuranceAdviceMapper
    {
        public static InsuranceAdviceDto ToDto(this InsuranceAdvice entity)
            => new InsuranceAdviceDto(entity.Auto.Name,
                                      entity.Disability.Name,
                                      entity.Home.Name,
                                      entity.Life.Name);
    }
}
