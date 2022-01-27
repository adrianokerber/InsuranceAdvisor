using InsuranceAdvisor.Domain.Models;
using InsuranceAdvisor.Domain.Models.Bases;
using InsuranceAdvisor.Domain.Services;

namespace InsuranceAdvisor.Domain.Interfaces
{
    public interface IInsuranceAdvisorService
    {
        public BaseResult ValidateClientProfile(ClientProfile clientProfile);
        public InsuranceAdvice GenerateInsuranceAdvice(ClientProfile clientProfile);
    }
}
